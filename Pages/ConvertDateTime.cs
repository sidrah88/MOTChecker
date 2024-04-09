using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ConvertDateTime : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        string value = reader.GetString();
        if (!DateTime.TryParseExact(value, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            throw new JsonException();
        }

        return date;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy.MM.dd"));
    }
}

