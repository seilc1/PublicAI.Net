using PublicAI.Net.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublicAI.Net;

public class PublicAIClient
{
    private readonly PublicAIClientSettings _settings;

    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() }
    };

    public PublicAIClient(PublicAIClientSettings settings)
        : this(settings, new HttpClient())
    { }

    public PublicAIClient(PublicAIClientSettings settings, HttpClient httpClient)
    {
        _settings = settings;

        _httpClient = httpClient;

        _httpClient.BaseAddress = _settings.BaseAddress;
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_settings.ApiKey}");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", $"PublicAIClient.Net");
    }

    public async Task<ModelResponse?> ListModelsAsync(CancellationToken cancellationToken = default)
    {
        const string ModelsEndpoint = "/v1/models";

        HttpResponseMessage response = await _httpClient.GetAsync(ModelsEndpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ModelResponse>(jsonSerializerOptions, cancellationToken);
    }

    public async Task<ChatCompletionReponse?> ChatAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default)
    {
        const string ChatCompletionsEndpoint = "/v1/chat/completions";

        string requestString = JsonSerializer.Serialize(request, jsonSerializerOptions);

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ChatCompletionsEndpoint, request, jsonSerializerOptions, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ChatCompletionReponse>(jsonSerializerOptions, cancellationToken);
    }
}
