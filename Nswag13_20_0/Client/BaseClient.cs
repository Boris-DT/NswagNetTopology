using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using NetTopologySuite.IO.Converters;

namespace Nswag13_20_0.Client
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
        [SuppressMessage("Performance", "CA1822:Mark members as static",
            Justification = "Partial method, other side is generated code")]
        protected void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
            var geoJsonConverterFactory = new GeoJsonConverterFactory();
            settings.Converters.Add(geoJsonConverterFactory);
        }
    }
}