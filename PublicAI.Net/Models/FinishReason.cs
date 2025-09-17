using System.Text.Json.Serialization;

namespace PublicAI.Net.Models;

[JsonConverter(typeof(JsonStringEnumConverter<FinishReason>))]
public enum FinishReason
{
    [JsonStringEnumMemberName("stop")]
    Stop,

    [JsonStringEnumMemberName("length")]
    Length,

    [JsonStringEnumMemberName("tool_calls")]
    ToolCalls,

    [JsonStringEnumMemberName("content_filter")]
    ContentFilter,

    [JsonStringEnumMemberName("function_call")]
    FunctionCall
}
