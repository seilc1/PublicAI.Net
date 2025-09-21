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

## Simplified Example

The Library provides a simplified way to interact with the Chat API.

```csharp
using PublicAI.Net.Simplified;
using PublicAI.Net.Models;

ChatContext chatContext = ChatContextBuilder
        .Create()
        .WithApiKey("{apiKey}") // if not provided will try to read it from environment variables
        .WithSystemContext("Answer in no more than 100 words.")
        .Build();

_output.WriteLine((await chatContext.ChatAsync("Why should I use an open source AI?")).GetText());
_output.WriteLine((await chatContext.ChatAsync("Can you elaborate on the first point?")).GetText());
```

Output:

```
Using open-source AI can be beneficial for several reasons:

1. Transparency: Open-source AI models ensure transparency as their code and algorithmic processes are all open for review. This helps users understand how decisions are made and fosters trust.

2. Customization: Open-source AI enables users to customize models to fit specific requirements or datasets more effectively.

3. Collaborative Development: The open-source nature of AI allows for widespread collaboration, with multiple developers working on issues, leading to rapid improvement and updates.

4. Community Engagement: By being open, it encourages feedback and contributions from users and experts, leading to better models that can be used by the broader community.

5. Cost-effective: Since open-source AI often eliminates licensing costs, it can save money for organizations or individuals.
```

```
Absolutely!

Transparency is a great benefit of using open-source AI. Since open-source AI models have open source code, anyone can inspect the code to understand how the AI model works. This helps with algorithmic accountability, meaning users can see if the AI model is doing something it shouldn’t be (like unfairly discriminating against certain groups).

This transparency is crucial for building trust, especially in applications where AI is making critical decisions (like in healthcare, justice, or finance). Users and developers can follow the "state-of-the-art" and adapt new methods as they become available, since they know exactly how the model operates.

However, it's important to note that transparency doesn't necessarily imply simplicity; complex algorithms can still be obscure even when open-source. But the existence of the code allows for analysis and audit if needed.
```

## Base Example

```csharp
using PublicAI.Net;
using PublicAI.Net.Models;

PublicAIClientSettings settings = new PublicAIClientSettings
{
	ApiKey = Environment.GetEnvironmentVariable("PUBLICAI_API_KEY")
}

PublicAIClient client = new PublicAIClient(settings);
ModelResponse? models = await client.ListModelsAsync();

string modelName = models?.Data?.FirstOrDefault(m => m.Id == "swiss-ai/apertus-70b-instruct")?.Id 
                    ?? throw new Exception("Model not found");

ChatCompletionRequest request = new ChatCompletionRequest(
        modelName,
        [
            new ChatMessage(ChatMessageRole.User, "When should I use AI?")
        ]);

ChatCompletionReponse? response = await client.ChatAsync(request);
Console.WriteLine(response.Choices.First().Message.Content);
```

# Repository

The repository uses [gitversion](https://gitversion.net/docs/reference/configuration), so follow the proper branch naming convention.