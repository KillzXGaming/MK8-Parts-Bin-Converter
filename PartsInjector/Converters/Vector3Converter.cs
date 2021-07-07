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
    public class Vector3Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.Formatting = Formatting.None;

            var token = JToken.FromObject(value);
            var x = token["X"].Value<float>();
            var y = token["Y"].Value<float>();
            var z = token["Z"].Value<float>();
            var vector = new[] { x, y, z };
            var o = JArray.FromObject(vector);
            o.WriteTo(writer);

            writer.Formatting = Formatting.Indented;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<string> items = token.ToObject<List<string>>();
            return new Vector3 { X = float.Parse(items[0]), Y = float.Parse(items[1]), Z = float.Parse(items[2]) };
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Vector3).IsAssignableFrom(objectType);
        }
    }
}
