using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FlexibleDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                if (DateTimeOffset.TryParse(stringValue, out var dateTimeOffset))
                {
                    return dateTimeOffset;
                }
                else
                {
                    throw new JsonException($"Unable to parse the string value '{stringValue}' to DateTimeOffset.");
                }
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                var numberValue = reader.GetDouble();
                if (numberValue > long.MaxValue || numberValue < long.MinValue)
                {
                    throw new JsonException($"The numeric value '{numberValue}' is out of bounds for an Int64.");
                }

                // Check if the number is in seconds or milliseconds
                if (numberValue > 1_000_000_000_000)
                {
                    // Assume milliseconds
                    return DateTimeOffset.FromUnixTimeMilliseconds((long)numberValue);
                }
                else
                {
                    // Assume seconds
                    return DateTimeOffset.FromUnixTimeSeconds((long)numberValue);
                }
            }
        }
        catch (Exception ex)
        {
            throw new JsonException($"Unable to convert the value to {typeToConvert}.", ex);
        }

        throw new JsonException($"Unable to convert the value to {typeToConvert}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("o"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}