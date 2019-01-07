using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace QQMusic.hzexe.com.Utils
{
    class NullAbleConverter<T> : JsonConverter
        where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // writer.WriteValue(int.Parse(value.ToString()));
            // writer.WriteValue(int.Parse(value.ToString()));
            //throw new NotImplementedException();
            writer.WriteValue(value);

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj=JObject.ReadFrom(reader);
            if (jobj.HasValues)
                return jobj.Value<T>();
            else
                return default(T);
    }

        public override bool CanConvert(Type objectType)
        {
            //return objectType.IsValueType;
            return objectType.Equals(typeof(T));

        }
    }
}
