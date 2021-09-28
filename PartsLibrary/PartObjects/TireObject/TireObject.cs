using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;

namespace PartsEditor
{
    public  class TireObject : PartObject
    {
        //Tire placement is controlled by 3 sections
        //Tire (default parameters for tires)
        //Tire Body (adjusted tires to configure per body)
        //Body Tire (default offsets used per body)

        /// <summary>
        /// Gets or sets the spin speed of the wheel.
        /// </summary>
        [PartParam(SectionIdentifier.Tire)]
        public float SpinSpeed { get; set; }

        /// <summary>
        /// Gets or sets the height of the current body height used by this tire.
        /// </summary>
        [PartParam(SectionIdentifier.Tire)]
        public float BodyHeight { get; set; }

        /// <summary>
        /// Gets or sets the spring rate of the suspension used by this tire.
        /// </summary>
        [PartParam(SectionIdentifier.Tire)]
        public float SpringRate { get; set; }

        /// <summary>
        /// The offset in the X axis  of the tire position relative to it's current position.
        /// </summary>
        [PartParam(SectionIdentifier.Tire)]
        public float OffsetX { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AntiGravityOffsetZ { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float F { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float G { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float H { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        internal Vector4B TireFlags { get; set; }

        public byte SusTypeFront
        {
            get { return TireFlags.X; }
            set { TireFlags.X = value; }
        }

        public byte SusTypeBack
        {
            get { return TireFlags.Y; }
            set { TireFlags.Y = value; }
        }

        public byte Unknown3
        {
            get { return TireFlags.Z; }
            set { TireFlags.Z = value; }
        }

        public byte Unknown4
        {
            get { return TireFlags.W; }
            set { TireFlags.W = value; }
        }

        [PartParam(SectionIdentifier.Tire)]
        public TireSection2 ArmFront { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public TireSection2 ArmBack { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AB { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AC { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AD { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AE { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AF { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AG { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AH { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AI { get; set; }

        [PartParam(SectionIdentifier.Tire)]
        public float AntiGravityRotation { get; set; }

        public TireObject(string filePath, string partName)
            : base(filePath, partName)
        {

        }
    }
}
