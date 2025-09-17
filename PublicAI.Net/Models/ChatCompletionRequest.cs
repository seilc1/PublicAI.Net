using PublicAI.Net.Models;
using System.Text.Json.Serialization;

namespace PublicAI.Net;

public record ChatCompletionRequest(string Model, IEnumerable<ChatMessage> Messages)
{
    public byte? Temperature { get; init; }

    [JsonPropertyName("top_p")]
    public byte? TopP { get; init; }

    [JsonPropertyName("n")]
    public int? ChatCompletionChoiceCount { get; init; }

    public bool? Stream { get; init; }

    /// <summary>
    ///     The maximum number of tokens to generate in the chat completion
    /// </summary>
    [JsonPropertyName("max_tokens")]
    public byte? MaxTokens { get; init; }

    [JsonPropertyName("presence_penalty")]
    public byte? PresencePenalty { get; init; }

    [JsonPropertyName("frequency_penalty")]
    public byte? FrequencyPenalty { get; init; }

    public string? User { get; init; }
}
