using System.Text.Json.Serialization;

namespace PublicAI.Net.Models;

public record ChatCompletionReponse(string Id, string Object, int Created, string Model, CompletionChoice[] Choices, ChatCompletionUsage Usage)
{
    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; init; }
}
