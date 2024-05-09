using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BatDongSan.Converters
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string dateFormat = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)//
        {
            return DateTime.ParseExact(reader.GetString(),dateFormat,CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)// o tren web api doc du lieu xuong va bien doi thanh dateformat
        {
            writer.WriteStringValue(value.ToString(dateFormat));
        }
    }
}
