using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsLibrary;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public  class GliderObject : PartObject
    {
        /// <summary>
        /// Gets or sets the scale of the glider.
        /// </summary>
        [PartParam(SectionIdentifier.Glider)]
        public float Scale { get; set; }

        [PartParam(SectionIdentifier.Glider)]
        internal int RecolorFlags { get; set; }

        public bool HasRecolors
        {
            get { return RecolorFlags == 1; }
            set {
                if (value)
                    RecolorFlags = 1;
                else
                    RecolorFlags = 0;
            }
        }

        public GliderObject(string filePath, string partName)
            : base(filePath, partName)
        {

        }

        public List<GliderDriverObject> GetBodyDriverObjects()
        {
            List<GliderDriverObject> gliderDrivers = new List<GliderDriverObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.GliderDriver);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++) {
                gliderDrivers.Add(new GliderDriverObject(i));
            }
            return gliderDrivers;
        }
    }
}
