using PublicAI.Net.Models;
using Shouldly;

namespace PublicAI.Net.Tests.Integration;

public class PublicAIClientFixture
{
    [Fact]
    public async Task ListModelsAsync_ShouldListModels()
    {
        PublicAIClient client = CreateClient();
        ModelResponse? models = await client.ListModelsAsync();

        models.ShouldNotBeNull();
    }

    [Fact]
    public async Task ChatAsync_ShouldReturnChatCompletion()
    {
        PublicAIClient client = CreateClient();

        ChatCompletionRequest request = new ChatCompletionRequest("swiss-ai/apertus-70b-instruct",
        [
            new ChatMessage(ChatMessageRole.System, "You are a Kindergarten Teacher and are talking to one of your pupils."),
            new ChatMessage(ChatMessageRole.User, "Hello, how are you?")
        ]);

        ChatCompletionReponse? response = await client.ChatAsync(request);
        response.ShouldNotBeNull();
        response.Choices.ShouldNotBeEmpty();
        response.Choices.First().Message.Content.ShouldNotBeNullOrEmpty();
    }

    private static PublicAIClient CreateClient()
    {
        return new PublicAIClient(new PublicAIClientSettings
        {
            ApiKey = Environment.GetEnvironmentVariable("PUBLICAI_API_KEY")
                    ?? Environment.GetEnvironmentVariable("PUBLICAI_API_KEY", EnvironmentVariableTarget.User)
                    ?? throw new InvalidOperationException("PUBLICAI_API_KEY environment variable is not set.")
        }, new HttpClient());

    }
}
