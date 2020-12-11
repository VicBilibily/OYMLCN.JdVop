using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Internal
{
    class JsonNumToBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
                if (reader.TryGetInt64(out long l))
                    return reader.GetInt64() > 0;
            if (reader.TokenType == JsonTokenType.True)
                return true;
            return false;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            => writer.WriteBooleanValue(value);
    }
}
