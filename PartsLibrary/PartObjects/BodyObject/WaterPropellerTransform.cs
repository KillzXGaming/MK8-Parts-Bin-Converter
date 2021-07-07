using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class WaterPropellerTransform
    {
        [PartParam(SectionIdentifier.Body)]
        public float FanScale { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ScewScale { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector2 FanOffsetYZ { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector2 ScewOffsetYZ { get; set; }
    }
}
