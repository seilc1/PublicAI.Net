namespace PublicAI.Net.Models;

public record CompletionChoice(int Index, ChatMessage Message, FinishReason FinishReason);
