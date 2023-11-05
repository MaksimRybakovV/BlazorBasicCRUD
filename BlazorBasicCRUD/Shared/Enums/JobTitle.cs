using System.Text.Json.Serialization;

namespace BlazorBasicCRUD.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobTitle
    {
        JuniorDeveloper,
        MiddleDeveloper,
        SeniorDeveloper
    }
}
