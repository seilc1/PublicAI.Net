using System.Text.Json.Serialization;

namespace PublicAI.Net.Models;

[JsonConverter(typeof(JsonStringEnumConverter<ChatMessageRole>))]
public enum ChatMessageRole
{
    [JsonStringEnumMemberName("system")]
    System,

    [JsonStringEnumMemberName("user")]
    User,

    [JsonStringEnumMemberName("assistant")]
    Assistant,

    [JsonStringEnumMemberName("tool")]
    Tool
}