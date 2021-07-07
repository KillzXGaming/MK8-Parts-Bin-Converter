using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public class TireShaftTransform
    {
        [PartParam(SectionIdentifier.Body)]
        public float FrontScaleX { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float FrontScaleYZ { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float BackScaleX { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float BackScaleYZ { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 FrontOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 FrontAntiGravityOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 Unknown1 { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 BackOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 BackAntiGravityOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector3 Unknown2 { get; set; }

    }
}
