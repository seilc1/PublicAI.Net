namespace PublicAI.Net;

public record ChatCompletionUsage(int PromptTokens, int CompletionTokens, int TotalTokens);
