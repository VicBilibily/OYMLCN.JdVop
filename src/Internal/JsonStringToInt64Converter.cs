using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Internal
{
    class JsonStringToInt64Converter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long value))
                return value;
            if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), out value))
                return value;
            return default;
        }
        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value);
    }
}
