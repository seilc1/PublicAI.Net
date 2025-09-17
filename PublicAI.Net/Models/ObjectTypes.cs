using System.Text.Json.Serialization;

namespace PublicAI.Net;

[JsonConverter(typeof(JsonStringEnumConverter<ObjectTypes>))]
public enum ObjectTypes
{
    [JsonStringEnumMemberName("model")]
    Model,

    [JsonStringEnumMemberName("list")]
    List,
    
    [JsonStringEnumMemberName("chat.completion")]
    ChatCompletion
}