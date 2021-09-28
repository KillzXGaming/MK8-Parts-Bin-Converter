using PartsEditor;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsLibrary
{
    public class BodyDriverObject : PartObject
    {
        public string Name
        {
            get { return Runtime.DriversNameList[DriverIndex]; }
        }

        [PartParam(SectionIdentifier.BodyDriver)]
        internal Vector2S RecolorFlags { get; set; }

        [PartParam(SectionIdentifier.BodyDriver)]
        public RecolorTexType RecolorType { get; set; }

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

        public enum RecolorTexType : int
        {
            None,
            DiffuseOnly,
            SpecularOnly,
            DiffuseAndSpecular,
        }

        [Newtonsoft.Json.JsonIgnore]
        public int DriverIndex { get; set; }

        public BodyDriverObject(int driverIndex) {
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
