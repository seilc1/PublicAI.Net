namespace PublicAI.Net;

public class PublicAIClientSettings
{
    public Uri BaseAddress { get; set; } = new Uri("https://api.publicai.co");

    public required string ApiKey { get; set; }
}
