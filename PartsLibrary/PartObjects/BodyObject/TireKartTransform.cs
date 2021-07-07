using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class TireKartTransform
    {
        [PartParam(SectionIdentifier.Body)]
        public Vector3 FrontOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 BackOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 FrontAntiGravityOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 BackAntiGravityOffset { get; set; }
    }
}
