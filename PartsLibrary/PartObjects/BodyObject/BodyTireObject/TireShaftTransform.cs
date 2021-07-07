using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor.BodyTire
{
    public class TireShaftTransform
    {
        [PartParam(SectionIdentifier.BodyTire)]
        public float FrontScaleX { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public float FrontScaleYZ { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public float BackScaleX { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public float BackScaleYZ { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 FrontOffset { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 FrontAntiGravityOffset { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 Unknown1 { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 BackOffset { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 BackAntiGravityOffset { get; set; }

        [PartParam(SectionIdentifier.BodyTire)]
        public Vector3 Unknown2 { get; set; }

        public bool HasFrontOffset() {
            return FrontOffset.X != 0 && FrontOffset.Y != 0 && FrontOffset.Z != 0;
        }

        public bool HasBackOffset() {
            return BackOffset.X != 0 && BackOffset.Y != 0 && BackOffset.Z != 0;
        }
    }
}
