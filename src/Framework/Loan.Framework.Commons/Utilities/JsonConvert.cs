
using System.Text.Json;

namespace Loan.Framework.Commons.Utilities
{
    public static class JsonDataConvert
    {
        public static string Serialize<T>(this T type) => JsonSerializer.Serialize(type);

        public static T Deserialize<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    }
}
