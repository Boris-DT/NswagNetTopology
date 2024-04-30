using System.Text.Json;
using NetTopologySuite.IO.Converters;

namespace Nswag14_0_7.Client
{
    /// <summary>
    ///     Base client
    /// </summary>
    public class BaseClient
    {
        /// <summary>
        ///     Add additional JSON Converters
        /// </summary>
        /// <param name="settings">JSON Serializer Settings</param>
        protected static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
            var geoJsonConverterFactory = new GeoJsonConverterFactory();
            settings.Converters.Add(geoJsonConverterFactory);
        }
    }
}