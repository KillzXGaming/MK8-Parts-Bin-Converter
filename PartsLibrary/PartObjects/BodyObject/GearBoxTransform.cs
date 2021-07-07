using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class GearBoxTransform
    {
        [PartParam(SectionIdentifier.Body)]
        public Vector3 Scale { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 FrontOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 BackOffset { get; set; }
    }
}
