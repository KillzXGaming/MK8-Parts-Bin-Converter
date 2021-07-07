using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PartsEditor;

namespace PartsInjector
{
    public class Vector4BConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.Formatting = Formatting.None;

            var token = JToken.FromObject(value);
            var x = token["X"].Value<byte>();
            var y = token["Y"].Value<byte>();
            var z = token["Z"].Value<byte>();
            var w = token["W"].Value<byte>();
            var vector = new[] { x, y, z, w };
            var o = JArray.FromObject(vector);
            o.WriteTo(writer);

            writer.Formatting = Formatting.Indented;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<string> items = token.ToObject<List<string>>();
            return new Vector4 { X = byte.Parse(items[0]), Y = byte.Parse(items[1]), Z = byte.Parse(items[2]), W = byte.Parse(items[3]) };
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Vector4B).IsAssignableFrom(objectType);
        }
    }
}
