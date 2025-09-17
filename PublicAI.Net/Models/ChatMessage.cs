namespace PublicAI.Net.Models;

public record ChatMessage(ChatMessageRole Role, string Content)
{
    /// <summary>
    ///     Optional name of the participant.
    /// </summary>
    public string? Name { get; init; }
}
