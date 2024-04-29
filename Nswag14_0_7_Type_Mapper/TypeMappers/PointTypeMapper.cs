using NetTopologySuite.Geometries;
using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;

namespace Nswag14_0_7_Type_Mapper.TypeMappers;

public class PointTypeMapper : ITypeMapper
{
    public void GenerateSchema(JsonSchema schema, TypeMapperContext context)
    {
        if (context.Type == typeof(Point))
        {
            var hasSchema = context.JsonSchemaResolver.HasSchema(typeof(Point), false);
            schema.Type = JsonObjectType.Object;
            schema.Description = "GeoJSON Point";
            schema.Properties.Add("type", new JsonSchemaProperty
            {
                Type = JsonObjectType.String,
                Example = "Point",
            });
            schema.Properties.Add("coordinates", new JsonSchemaProperty
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
            });
            if (!hasSchema)
            {
                context.JsonSchemaResolver.AddSchema(typeof(Point), false, schema);
            }

        }
    }

    public Type MappedType => typeof(Point);
    public bool UseReference => true;
}