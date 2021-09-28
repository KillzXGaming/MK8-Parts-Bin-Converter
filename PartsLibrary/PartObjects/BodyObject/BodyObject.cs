using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.MarioKart8.BinData;
using Syroot.NintenTools.MarioKart8.BinData.Parts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PartsLibrary;

namespace PartsEditor
{
    public  class BodyObject : PartObject
    {
        [PartParam(SectionIdentifier.DriverEffect, 0)]
        public Vector2S EffectFlags { get; set; }

        [PartParam(SectionIdentifier.Body, 0)]
        internal Vector2S BodyFlags { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BodyType Type
        {
            get { return (BodyType)BodyFlags.X; }
            set { BodyFlags = new Vector2S((short)value, BodyFlags.Y); }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public WheelAmount WheelType
        {
            get { return (WheelAmount)BodyFlags.Y; }
            set { BodyFlags = new Vector2S(BodyFlags.X, (short)value); }
        }

        /// <summary>
        /// Angles the body's rotation from the handle's location.
        /// Used to slightly tilt the angles for drivers on certain bikes.
        /// </summary>
        [PartParam(SectionIdentifier.Body)]
        public float SeatAngle { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector2 GliderOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public Vector2 AntennaOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public WaterPropellerTransform WaterPropellerTransform { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public GearBoxTransform GearBoxTransform { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float Padding { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public FrontLightsTransform FrontLightsTransform { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAB { get; set; }
        /// <summary>
        /// Max steering angle in degrees. 
        /// </summary>
        [PartParam(SectionIdentifier.Body)]
        public float MaxSteeringAngle { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float PackunOffset { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAE { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAF { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAG { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAH { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamAI { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public int HasAlts { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public TireShaftTransform TireShaftTransform { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBG { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBH { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBI { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBJ { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBK { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBL { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBM { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBN { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBO { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public float ParamBP { get; set; }

        [PartParam(SectionIdentifier.Body)]
        public TireKartTransform TireKartTransform { get; set; }

        public BodyDriverObject GetCurrentBodyDriverParams() {
            return new BodyDriverObject(Runtime.DriverIndex);
        }

        public BodyTireObject GetCurrentBodyTireParams() {
            return new BodyTireObject(Runtime.TireIndex);
        }

        public List<BodyTireObject> GetBodyTireObjects()
        {
            List<BodyTireObject> bodyTires = new List<BodyTireObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.BodyTire);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++) {
                bodyTires.Add(new BodyTireObject(i));
            }
            return bodyTires;
        }

        public List<BodyGliderObject> GetBodyGliderObjects()
        {
            List<BodyGliderObject> bodyGliders = new List<BodyGliderObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.BodyGlider);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                bodyGliders.Add(new BodyGliderObject(i));
            }
            return bodyGliders;
        }

        public List<BodyDriverObject> GetBodyDriverObjects()
        {
            List<BodyDriverObject> bodyDrivers = new List<BodyDriverObject>();

            Section section = Runtime.BinFile.GetSectionByID((uint)SectionIdentifier.BodyDriver);
            var data = ((DwordSectionData)section.Data).Data;
            for (int i = 0; i < data[0].Length; i++)
            {
                bodyDrivers.Add(new BodyDriverObject(i));
            }
            return bodyDrivers;
        }

        public BodyObject(string filePath, string partName)
            : base(filePath, partName)
        {

        }

        public enum BodyType
        {
            Kart = 0,
            OutsideBike = 1,
            InsideBike = 2,
            ATV = 3,
        }

        public enum WheelAmount
        {
            FourWheels,
            TwoWheels,
            ThreeWheels,
        }
    }
}
