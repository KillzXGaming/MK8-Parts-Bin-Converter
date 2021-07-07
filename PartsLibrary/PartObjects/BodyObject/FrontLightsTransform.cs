using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class FrontLightsTransform
    {
        [PartParam(SectionIdentifier.Body)]
        public float ScaleX { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ScaleYZ { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 Offset { get; set; }
    }
}
