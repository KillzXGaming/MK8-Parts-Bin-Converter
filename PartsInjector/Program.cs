﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsEditor;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using System.Globalization;

namespace PartsInjector
{
    class Program
    {
        class CommandLineArgs
        {
            public string PartsBinFilePath = "";
            public string OutputFilePath = "";

            //Uses original bin backup to patch only the injected data.
            public bool InjectBackup = false;

            //Extracts all parts to current folder
            public bool ExtractAll = false;
            //Extracts specified parts by name
            public string[] ExtractParts = new string[0];

            //Injects to all folders dumped to the same tool path
            public bool InjectAll = false;
            //Injects specified parts by path
            public string[] InjectParts = new string[0];
            public string InjectFolder = "";
        }

        static void Main(string[] args)
        {
            int bodyID = 0;
            int tireID = 1;

            Runtime.BinFile = new BinFile("Parts.bin");

            Runtime.BodyIndex = 0;
            Runtime.TireIndex = 1;

            var t = Runtime.GetBodyParts()[bodyID].GetBodyTireObjects()[tireID];

            if (args.Length == 0 || args.Contains("-h") || args.Contains("-help"))
            {
                Console.WriteLine("Tool made by KillzXGaming with the help of Syroot for bin library.");
                Console.WriteLine("Usage: \n" +
                                  "-f (The specified parts.bin file path. Defaults to Parts.bin in program folder.) \n" +
                                  "-o (The output file path. Defaults to Parts.NEW.bin if not set.) \n" +
                                  "-i (Inject from extracted parts.bin Body, Glider, and Tire folders) \n" +
                                  "-e (Extracts parts.bin into Body, Glider, and Tire folders) \n" +
                                  "PartsInjector.exe (arguments)\n");
                return;
            }

            CommandLineArgs argData = new CommandLineArgs();
            argData.PartsBinFilePath = "Parts.bin";
            argData.OutputFilePath = "Parts.NEW.bin";

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-f") argData.PartsBinFilePath = args[i + 1];
                if (args[i] == "-e") argData.ExtractAll = true;
                if (args[i] == "-i") argData.InjectAll = true;
                if (args[i] == "-o") argData.OutputFilePath = args[i + 1];
            }

            if (!Directory.Exists($"Backup"))
                Directory.CreateDirectory($"Backup");

            if (!File.Exists("Backup/Parts.bin"))
                File.Copy(argData.PartsBinFilePath, "Backup/Parts.bin");

            if (argData.InjectBackup)
                argData.PartsBinFilePath = "Backup/Parts.bin";

            if (!File.Exists(argData.PartsBinFilePath))
            {
                Console.WriteLine("Cannot find Parts.bin file! Include it in the program folder or use -f (file path to parts.bin))");
                return;
            }

            if (argData.InjectAll)
                Inject(argData.PartsBinFilePath, argData.OutputFilePath);

            if (argData.ExtractAll)
                Extract(argData.PartsBinFilePath);

            /*if (argData.InjectParts.Length > 0)
                InjectPart(0, argData.InjectParts);
            if (argData.InjectFolder != string.Empty && Directory.Exists(argData.InjectFolder))
                InjectPart(0, argData.InjectFolder);*/
        }

        static void Extract(string fileName)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Runtime.BinFile = new BinFile(fileName);

            if (!Directory.Exists("Body"))
                Directory.CreateDirectory("Body");
            if (!Directory.Exists("Tire"))
                Directory.CreateDirectory("Tire");
            if (!Directory.Exists("Glider"))
                Directory.CreateDirectory("Glider");

            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new Vector2Converter());
            converters.Add(new Vector2SConverter());
            converters.Add(new Vector3Converter());
            converters.Add(new Vector4Converter());
            converters.Add(new Vector4BConverter());

            var settings = new JsonSerializerSettings()
            {
                Converters = converters.ToArray(),
            };

            var bodyParts = Runtime.GetBodyParts();
            var tireParts = Runtime.GetTireParts();
            var gliderParts = Runtime.GetGliderParts();
            var driverParts = Runtime.GetDriverParts();

            int bodyIndex = 0;
            foreach (var bod in bodyParts)
            {
                Runtime.BodyIndex = bodyIndex++;

                if (!Directory.Exists($"Body/{bod.PartName}"))
                    Directory.CreateDirectory($"Body/{bod.PartName}");
                if (!Directory.Exists($"Body/{bod.PartName}/TireParams"))
                    Directory.CreateDirectory($"Body/{bod.PartName}/TireParams");
                if (!Directory.Exists($"Body/{bod.PartName}/DriverParams"))
                    Directory.CreateDirectory($"Body/{bod.PartName}/DriverParams");
                if (!Directory.Exists($"Body/{bod.PartName}/GliderParams"))
                    Directory.CreateDirectory($"Body/{bod.PartName}/GliderParams");

                var json = JsonConvert.SerializeObject(bod, Formatting.Indented, settings);
                File.WriteAllText($"Body/{bod.PartName}/{bod.PartName}.json", json);

                foreach (var tire in bod.GetBodyTireObjects())
                {
                    json = JsonConvert.SerializeObject(tire, Formatting.Indented, settings);
                    File.WriteAllText($"Body/{bod.PartName}/TireParams/{tire.Name}.json", json);
                }
                foreach (var glider in bod.GetBodyGliderObjects())
                {
                    json = JsonConvert.SerializeObject(glider, Formatting.Indented, settings);
                    File.WriteAllText($"Body/{bod.PartName}/GliderParams/{glider.Name}.json", json);
                }
                foreach (var driver in bod.GetBodyDriverObjects())
                {
                    json = JsonConvert.SerializeObject(driver, Formatting.Indented, settings);
                    File.WriteAllText($"Body/{bod.PartName}/DriverParams/{driver.Name}.json", json);
                }
            }

            int tireIndex = 0;
            foreach (var tire in tireParts)
            {
                Runtime.TireIndex = tireIndex++;

                string folder = Path.Combine("Tire", tire.PartName);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string json = JsonConvert.SerializeObject(tire, Formatting.Indented, settings);
                File.WriteAllText(Path.Combine(folder, $"{tire.PartName}.json"), json);

                string bodyFolder = Path.Combine(folder, "Body");
                if (!Directory.Exists(bodyFolder))
                    Directory.CreateDirectory(bodyFolder);

                foreach (var tireBody in tire.GetTireBodyObjects())
                {
                    json = JsonConvert.SerializeObject(tireBody, Formatting.Indented, settings);
                    File.WriteAllText(Path.Combine(bodyFolder, $"{tireBody.Name}.json"), json);
                }
            }

            int gliderIndex = 0;
            foreach (var glider in gliderParts)
            {
                Runtime.GliderIndex = gliderIndex++;

                string folder = Path.Combine("Glider", glider.PartName);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string json = JsonConvert.SerializeObject(glider, Formatting.Indented, settings);
                File.WriteAllText(Path.Combine(folder, $"{glider.PartName}.json"), json);
            }

            int driverIndex = 0;
            foreach (var driver in driverParts)
            {
                Runtime.DriverIndex = driverIndex++;

                string folder = Path.Combine("Driver", driver.PartName);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string json = JsonConvert.SerializeObject(driver, Formatting.Indented, settings);
                File.WriteAllText(Path.Combine(folder, $"{driver.PartName}.json"), json);
            }
        }

        static void Inject(string fileName, string outputFilePath)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Runtime.BinFile = new BinFile(fileName);

            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new Vector2Converter());
            converters.Add(new Vector2SConverter());
            converters.Add(new Vector3Converter());
            converters.Add(new Vector4Converter());
            converters.Add(new Vector4BConverter());

            var bodyParts = Runtime.GetBodyParts();
            var tireParts = Runtime.GetTireParts();
            var gliderParts = Runtime.GetGliderParts();
            var driverParts = Runtime.GetDriverParts();

            var settings = new JsonSerializerSettings()
            {
                Converters = converters.ToArray(),
                FloatParseHandling = FloatParseHandling.Decimal,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Formatting = Formatting.None,
            };

            for (int i = 0; i < bodyParts.Count; i++)
            {
                string name = bodyParts[i].PartName;

                string partFileName = $"Body/{name}/{name}.json";
                if (File.Exists(partFileName)) {
                    Runtime.BodyIndex = i;

                    Console.WriteLine($"Injecting Body {name}");

                    bodyParts[i] = JsonConvert.DeserializeObject<BodyObject>(File.ReadAllText(partFileName), settings);
                    bodyParts[i].UpdateSetters();

                    //Body has 3 sets of additional param tables
                    var bodyGL = bodyParts[i].GetBodyGliderObjects();
                    var bodyTR = bodyParts[i].GetBodyTireObjects();
                    var bodyDR = bodyParts[i].GetBodyDriverObjects();

                    for (int j = 0; j < bodyTR.Count; j++)
                    {
                        partFileName = $"Body/{name}/TireParams/{bodyTR[j].Name}.json";
                        if (File.Exists(partFileName))
                        {
                            bodyTR[j] = JsonConvert.DeserializeObject<PartsLibrary.BodyTireObject>(File.ReadAllText(partFileName), settings);
                            bodyTR[j].TireIndex = j; //Update index as json is edited
                            Runtime.BodyIndex = i;
                            bodyTR[j].UpdateSetters();
                        }
                    }

                     for (int j = 0; j < bodyGL.Count; j++)
                     {
                         partFileName = $"Body/{name}/GliderParams/{bodyGL[j].Name}.json";
                         if (File.Exists(partFileName))
                         {
                             bodyGL[j] = JsonConvert.DeserializeObject<PartsLibrary.BodyGliderObject>(File.ReadAllText(partFileName), settings);
                             bodyGL[j].GliderIndex = j; //Update index as json is edited
                            Runtime.BodyIndex = i;
                            bodyGL[j].UpdateSetters();
                         }
                     }

                     for (int j = 0; j < bodyDR.Count; j++)
                     {
                         partFileName = $"Body/{name}/DriverParams/{bodyDR[j].Name}.json";
                         if (File.Exists(partFileName))
                         {
                             bodyDR[j] = JsonConvert.DeserializeObject<PartsLibrary.BodyDriverObject>(File.ReadAllText(partFileName), settings);
                             bodyDR[j].DriverIndex = j; //Update index as json is edited
                            Runtime.BodyIndex = i;
                            bodyDR[j].UpdateSetters();
                         }
                     }
                }
            }

            for (int i = 0; i < tireParts.Count; i++)
            {
                string name = tireParts[i].PartName;

                string partFileName = $"Tire/{name}/{name}.json";
                if (File.Exists(partFileName))
                {
                    Runtime.TireIndex = i;

                    tireParts[i] = JsonConvert.DeserializeObject<TireObject>(File.ReadAllText(partFileName), settings);
                    tireParts[i].UpdateSetters();
                    Console.WriteLine($"Injecting Tire {name}");
                }
            }

            for (int i = 0; i < gliderParts.Count; i++)
            {
                string name = gliderParts[i].PartName;

                string partFileName = $"Glider/{name}/{name}.json";
                if (File.Exists(partFileName))
                {
                    Runtime.GliderIndex = i;

                    gliderParts[i] = JsonConvert.DeserializeObject<GliderObject>(File.ReadAllText(partFileName), settings);
                    gliderParts[i].UpdateSetters();
                    Console.WriteLine($"Injecting Glider {name}");
                }
            }

            for (int i = 0; i < driverParts.Count; i++)
            {
                string name = driverParts[i].PartName;

                string partFileName = $"Driver/{name}/{name}.json";
                if (File.Exists(partFileName))
                {
                    Runtime.GliderIndex = i;

                    driverParts[i] = JsonConvert.DeserializeObject<DriverObject>(File.ReadAllText(partFileName), settings);
                    driverParts[i].UpdateSetters();
                    Console.WriteLine($"Injecting Driver {name}");
                }
            }

            Console.WriteLine($"Finished! Saving to {outputFilePath}");
            Runtime.BinFile.Save(outputFilePath);
        }

        static void InjectPart(int level, params string[] folders)
        {
            if (level > 3)
                return;

            level++;
            foreach (var folder in folders)
            {
                //Support injecting parts through multiple directories of 2 directory levels.
                //The user can have multiple folders for part mod packs
                foreach (var dir in Directory.GetDirectories(folder))
                    InjectPart(level, dir);

                //Check for matching part names
                string name = new DirectoryInfo(folder).Name;

            }
        }
    }
}
