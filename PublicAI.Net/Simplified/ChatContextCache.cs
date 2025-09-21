namespace PublicAI.Net.Simplified;

public static class ChatContextCache
{
    private static volatile string? _defaultModel;

    public static string? DefaultModel
    {
        get => _defaultModel;
        set => _defaultModel = value;
    }
}