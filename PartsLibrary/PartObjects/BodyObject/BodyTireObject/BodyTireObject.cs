using PartsEditor;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;
using System;

namespace PartsLibrary
{
    public class BodyTireObject : PartObject
    {
        public string Name
        {
            get { return Runtime.TireNameList[TireIndex]; }
        }

        [PartParam(SectionIdentifier.BodyTire, 0)]
        public float TireScaleX { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public float TireScaleYZ { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public int TireAngle { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public PartsEditor.BodyTire.TireShaftTransform TireShaftTransform { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector4 Unknown { get; set; } //1, 1, 1, 1

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector4 Padding1 { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector2 Padding2 { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public PartsEditor.BodyTire.TireKartTransform TireKartTransform { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public int TireIndex { get; set; }

        public BodyTireObject(int tireIndex) {
            TireIndex = tireIndex;
            UpdateGetters();
        }

        internal override Dword GetValue(SectionIdentifier type, int index)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;
            return data[bodyIndex][TireIndex][index];
        }

        internal override void SetValue(SectionIdentifier type, int index, Dword value)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;

           // if (Name == "Monster")
               // Console.WriteLine($"BDTR {bodyIndex}_{TireIndex} {value.Single}/{value.Int32}");

            data[bodyIndex][TireIndex][index] = value; 
        }
    }
}
