namespace PublicAI.Net.Simplified;

public class ChatContextBuilder
{
    public static ChatContextBuilder Create()
        => new ChatContextBuilder();

    private List<string>? _systemContext;

    private string? _model;

    private string? _apiKey;

    public ChatContextBuilder WithSystemContext(params string[] systemContextMessage)
    {
        _systemContext ??= new List<string>();
        _systemContext.AddRange(systemContextMessage);
        return this;
    }

    public ChatContextBuilder WithModel(string model)
    {
        _model = model;
        return this;
    }

    public ChatContextBuilder WithApiKey(string apiKey)
    {
        _systemContext = null;
        return this;
    }

    public ChatContext Build() 
        => new ChatContext(BuildPublicAIClient(), _model, _systemContext);

    private PublicAIClient BuildPublicAIClient()
        => new PublicAIClient(BuildPublicAIClientSettings());

    private PublicAIClientSettings BuildPublicAIClientSettings()
        => new PublicAIClientSettings
        {
            ApiKey = _apiKey
                ?? Environment.GetEnvironmentVariable("PUBLICAI_API_KEY")
                   ?? Environment.GetEnvironmentVariable("PUBLICAI_API_KEY", EnvironmentVariableTarget.User)
                   ?? throw new InvalidOperationException($"No ApiKey present, either provide it {nameof(WithApiKey)} or by setting with PUBLICAI_API_KEY environment variable.")
        };
}
