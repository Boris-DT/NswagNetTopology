using NetTopologySuite.Geometries;
using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;

namespace Nswag14_0_7_Type_Mapper.TypeMappers;

public class LineStringTypeMapper : ITypeMapper
{
    public void GenerateSchema(JsonSchema schema, TypeMapperContext context)
    {
        if (context.Type == typeof(LineString))
        {
            var hasSchema = context.JsonSchemaResolver.HasSchema(typeof(LineString), false);
            schema.Type = JsonObjectType.Object;
            schema.Description = "GeoJSON geometry";
            schema.Properties.Add("type", new JsonSchemaProperty
            {
                Type = JsonObjectType.String,
                Example = "LineString",
                IsRequired = true
            });
            schema.Properties.Add("coordinates", new JsonSchemaProperty
            {
                Type = JsonObjectType.Array,
                Item = new JsonSchema
                {
                    Type = JsonObjectType.Array,
                    Item = new JsonSchema
                    {
                        Type = JsonObjectType.Number
                    },
                    Example = new double[] { 8.541694, 47.376888 },
                    MinItems = 2,
                    MaxItems = 3,
                    Description = "A position is an array of numbers. There MUST be two or more elements. The first two elements are longitude and latitude, or easting and northing, precisely in that order and using decimal numbers. Altitude or elevation MAY be included as an optional third element."
                },
                IsRequired = true,
                MinItems = 2,
                Description = "GeoJSon fundamental geometry construct, array of two or more positions."
            });
            if (!hasSchema)
            {
                context.JsonSchemaResolver.AddSchema(typeof(LineString), false, schema);
            }

        }
    }

    public Type MappedType => typeof(LineString);
    public bool UseReference => true;
}