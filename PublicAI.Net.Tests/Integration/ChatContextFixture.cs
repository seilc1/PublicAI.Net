using Microsoft.VisualStudio.TestPlatform.Utilities;
using PublicAI.Net.Models;
using PublicAI.Net.Simplified;
using Shouldly;
using Xunit.Abstractions;

namespace PublicAI.Net.Tests.Integration;

public class ChatContextFixture
{
    private readonly ITestOutputHelper _output;

    public ChatContextFixture(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task ChatAsync_ShouldReturnChatCompletion()
    {
        // Arrange
        ChatContext chatContext = ChatContextBuilder
            .Create()
            .WithSystemContext("You are code assistent for a c# coder. Your responses contain examples and are no longer then 1000 words.")
            .Build();

        // Act
        ChatCompletionReponse response = await chatContext.ChatAsync("Write a c# function that reverses a string.");

        // Assert
        response.ShouldNotBeNull();
    }

    [Fact]
    public async Task ChatAsync_ShouldReturnChatCompletion_Json()
    {
        ChatContext chatContext = ChatContextBuilder
                .Create()
                .WithApiKey("{apiKey}")
                .WithSystemContext("Answer in no more than 100 words.")
                .Build();

        _output.WriteLine((await chatContext.ChatAsync("Why should I use an open source AI?")).GetText());
        _output.WriteLine((await chatContext.ChatAsync("Can you elaborate on the first point?")).GetText());
    }
}
