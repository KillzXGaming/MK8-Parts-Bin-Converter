using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsEditor
{
    public class Runtime
    {
        public static BinFile BinFile { get; set; }

        public static int TireIndex { get; set; }
        public static int BodyIndex { get; set; } 
        public static int GliderIndex { get; set; }
        public static int DriverIndex { get; set; }

        public static List<string> KartNameList
        {
            get { return GetKartBodys(); }
        }

        public static List<string> TireNameList
        {
            get { return tiresCommon; }
        }

        public static List<string> GliderNameList
        {
            get { return glidersCommon; }
        }

        public static List<string> DriversNameList
        {
            get { return driversCommon; }
        }

        public static List<BodyObject> GetBodyParts()
        {
            List<BodyObject> bodyParts = new List<BodyObject>();

            var kartBodys = GetKartBodys();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.Body);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                BodyIndex = i;
                bodyParts.Add(new BodyObject("", kartBodys[i]));
            }
            return bodyParts;
        }

        public static List<DriverObject> GetDriverParts()
        {
            List<DriverObject> driverParts = new List<DriverObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.DriverTOM);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                DriverIndex = i;
                driverParts.Add(new DriverObject("", DriversNameList[i]));
            }
            return driverParts;
        }

        public static List<TireObject> GetTireParts()
        {
            List<TireObject> tireParts = new List<TireObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.Tire);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                TireIndex = i;
                tireParts.Add(new TireObject("", TireNameList[i]));
            }
            return tireParts;
        }

        public static List<GliderObject> GetGliderParts()
        {
            List<GliderObject> gliderParts = new List<GliderObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.Glider);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                GliderIndex = i;
                gliderParts.Add(new GliderObject("", GliderNameList[i]));
            }
            return gliderParts;
        }

        private static List<string> GetKartBodys()
        {
            List<string> kartBodys = new List<string>(kartBodysCommon);
            if (BinFile.Format == BinFileFormat.MarioKart8Deluxe)
                kartBodys.AddRange(kartBodys8D);
            else
                kartBodys.AddRange(kartBodys8U);
            return kartBodys;
        }

        private static readonly List<string> kartBodysCommon = new List<string>()
        {
            "Standard Kart",
            "Pipe Frame", 
            "Mach 8",
            "Steel Driver",
            "Cat Cruiser",
            "Circuit Special",
            "Tri-Speeder",
            "Badwagon",
            "Prancer",
            "Biddybuggy",
            "Landship",
            "Sneeker",
            "Sports Coupe",
            "Gold Standard",
            "Standard Bike",
            "Comet",
            "Sport Bike",
            "The Duke",
            "Flame Rider",
            "Varmint",
            "Mr. Scooty",
            "Jet Bike",
            "Yoshi Bike",
            "Standard ATV",
            "Wild Wiggler",
            "Teddy Buggy",
            "GLA",
            "W 25 Silver Arrow",
            "300 SL Roadster",
            "Blue Falcon",
            "Tanooki Kart",
            "B Dasher",
            "Master Cycle",
        };

        private static readonly List<string> kartBodys8U = new List<string>()
        {
            "Unused 1",
            "Unused 2",
            "Streetle",
            "P-Wing",
            "City Tripper", 
            "Bone Rattler",
        };

        private static readonly List<string> kartBodys8D = new List<string>()
        {
            "Streetle",
            "P-Wing",
            "City Tripper",
            "Bone Rattler",
            "Koopa Clown",
            "Splat Buggy",
            "Inkstriker",
        //    "Master Cycle Zero", Program.R.GetBitmap("Karts.MasterCycleZero.png")),
        };

        private static readonly List<string> tiresCommon = new List<string>()
        {
           "Standard",
           "Monster",
           "Roller",
           "Slim",
           "Slick",
           "Metal",
           "Button",
           "Off-Road",
           "Sponge",
           "Wood",
           "Cushion",
           "Blue Standard",
           "Hot Monster",
           "Azure Roller",
           "Crimson Slim",
           "Cyber Slick",
           "Retro Off-Road",
           "Gold Tires",
           "GLA Tires",
           "Triforce Tires",
           "Leaf Tires",
           "Ancient Tires"
        };

        private static readonly List<string> glidersCommon = new List<string>()
        {
           "Super Glider",
            "Cloud Glider",
            "Wario Wing",
            "Waddle Wing",
            "Peach Parasol",
            "Parachute",
            "Parafoil",
            "Flower Glider",
            "Bowser Kite",
            "Plane Glider",
            "MKTV Parafoil",
            "Gold Glider",
            "Hylian Kite",
            "Paper Glider",
            "Paraglider ",
        };

        private static readonly List<string> driversCommon = new List<string>()
        {
            "Mario",
            "Luigi",
            "Peach",
            "Daisy",
            "Yoshi",
            "Toad",
            "Toadette",
            "Koopa",
            "Bowser",
            "Donkey Kong",
            "Wario",
            "Waluigi",
            "Rosalina",
            "Metal Mario",
            "Pink Gold Peach",
            "Lakitu",
            "Shy Guy",
            "Baby Mario",
            "Baby Luigi",
            "Baby Peach",
            "Baby Daisy",
            "Baby Rosalina", 
            "Larry",
            "Lemmy",
            "Wendy",
            "Ludwig",
            "Iggy",
            "Roy",
            "Morton",
            "Mii", 
            "Tanooki Mario",
            "Link",
            "Villager Male",
            "Isabelle",
            "Cat Peach",
            "Dry Bowser",
            "Villager Female",
            "Gold Mario",
            "Dry Bones",
            "Bowser Jr.",
            "King Boo",
            "Inkling Girl",
            "Inkling Boy",
        };
    }
}
