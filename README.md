# PublicAI.Net

PublicAI.NET is a .NET client library for interacting with the PublicAI platform, which is built on top of the Apertus Large Language Model. 
This library provides basic tooling to work with PublicAI Rest API.

## What is PublicAI.co

PublicAI.co hosts the open source LLM Apertus with its ChatAPI. (accessible [here](https://chat.publicai.co))


`The Public AI Inference Utility is a nonprofit, open-source project. Our team builds products and organizes advocacy to support the work of public AI model builders like the Swiss AI Initiative, AI Singapore, AI Sweden, and the Barcelona Supercomputing Center.`

Source: https://publicai.co/about

## What is Apertus

`EPFL, ETH Zurich, and the Swiss National Supercomputing Centre (CSCS) has released Apertus, Switzerland’s first large-scale open, multilingual language model — a milestone in generative AI for transparency and diversity. Trained on 15 trillion tokens across more than 1,000 languages – 40% of the data is non-English – Apertus includes many languages that have so far been underrepresented in LLMs, such as Swiss German, Romansh, and many others. Apertus serves as a building block for developers and organizations for future applications such as chatbots, translation systems, or educational tools.`

Source: https://www.swiss-ai.org/apertus

# How to use PublicAI.Net

## Get API Key

API Keys are available from [here](https://platform.publicai.co/api) (where you also find the API Spec).

You'll need to to login first or create an account.

The API Keys can be generated under your profile (in the upper right corner).

As of 20.09.2025 the API is free to use under fair use policy, and you can generate API keys which never expire.

## Install PublicAI.Net

`dotnet add package PublicAI.Net`

## Simple Example

```csharp
using PublicAI.Net;
using PublicAI.Net.Models;

PublicAIClientSettings settings = new PublicAIClientSettings
{
	ApiKey = Environment.GetEnvironmentVariable("PUBLICAI_API_KEY")
}

PublicAIClient client = new PublicAIClient(settings);
ModelResponse? models = await client.ListModelsAsync();

string modelName = models?.Data?.FirstOrDefault(m => m.Id == "swiss-ai/apertus-70b-instruct")?.Id ?? throw new Exception("Model not found");

ChatCompletionRequest request = new ChatCompletionRequest(modelName,
        [
            new ChatMessage(ChatMessageRole.User, "When should I use AI?")
        ]);

ChatCompletionReponse? response = await client.ChatAsync(request);
Console.WriteLine(response.Choices.First().Message.Content);
```

# Repository

The repository uses [semver](https://semver.org/) and [gitversion](https://gitversion.net/docs/reference/configuration), so follow the proper branch naming convention.