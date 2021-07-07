using PartsEditor;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;
using Newtonsoft.Json;

namespace PartsLibrary
{
    public class BodyGliderObject : PartObject
    {
        public string Name
        {
            get { return Runtime.GliderNameList[GliderIndex]; }
        }

        [PartParam(SectionIdentifier.BodyGlider)]
        public float A { get; set; }

        [PartParam(SectionIdentifier.BodyGlider)]
        public float B { get; set; }

        [PartParam(SectionIdentifier.BodyGlider)]
        public float C { get; set; }

        [PartParam(SectionIdentifier.BodyGlider)]
        public float D { get; set; }

        [PartParam(SectionIdentifier.BodyGlider)]
        public int E { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public int GliderIndex { get; set; }

        public BodyGliderObject(int gliderIndex) {
            GliderIndex = gliderIndex;
            UpdateGetters();
        }

        internal override Dword GetValue(SectionIdentifier type, int index)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;
            return data[bodyIndex][GliderIndex][index];
        }

        internal override void SetValue(SectionIdentifier type, int index, Dword value)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;
            data[bodyIndex][GliderIndex][index] = value;
        }
    }
}
