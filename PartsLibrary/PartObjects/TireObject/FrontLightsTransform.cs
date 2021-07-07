using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class TireSection2
    {
        [PartParam(SectionIdentifier.Tire)]
        public float InverseScaleX { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public Vector2 Unknown1 { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public Vector3 Unknown2 { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public Vector3 Unknown3 { get; set; }
    }
}
