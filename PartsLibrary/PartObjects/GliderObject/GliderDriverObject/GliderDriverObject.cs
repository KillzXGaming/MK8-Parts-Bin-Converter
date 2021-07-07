using PartsEditor;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsLibrary
{
    public class GliderDriverObject : PartObject
    {
        [PartParam(SectionIdentifier.GliderDriver)]
        public int A { get; set; }

        [PartParam(SectionIdentifier.GliderDriver)]
        public float Scale { get; set; }

        [PartParam(SectionIdentifier.GliderDriver)]
        internal Vector2S RecolorFlags { get; set; }

        [PartParam(SectionIdentifier.GliderDriver)]
        public int D { get; set; }

        public short DiffuseTexture
        {
            get { return RecolorFlags.X; }
            set { RecolorFlags = new Vector2S(value, RecolorFlags.Y); }
        }

        public short SpecularTexture
        {
            get { return RecolorFlags.Y; }
            set { RecolorFlags = new Vector2S(RecolorFlags.X, value); }
        }

        internal int DriverIndex { get; set; }

        public GliderDriverObject(int driverIndex) {
            DriverIndex = driverIndex;
            UpdateGetters();
        }

        internal override Dword GetValue(SectionIdentifier type, int index)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;
            return data[bodyIndex][DriverIndex][index];
        }

        internal override void SetValue(SectionIdentifier type, int index, Dword value)
        {
            Section section = Runtime.BinFile.GetSectionByID((uint)type);
            var data = ((DwordSectionData)section.Data).Data;
            //Get a list of all active indices for the current combination of parts
            int bodyIndex = Runtime.BodyIndex;
            data[bodyIndex][DriverIndex][index] = value;
        }
    }
}
