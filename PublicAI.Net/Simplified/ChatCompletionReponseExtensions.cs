namespace PublicAI.Net.Simplified;

public static class ChatCompletionReponseExtensions
{
    public static string GetText(this Models.ChatCompletionReponse response)
    {
        if (response == null)
        {
            throw new ArgumentNullException(nameof(response));
        }

        if (response.Choices == null || response.Choices.Length == 0)
        {
            throw new ArgumentException("Response contains no choices.", nameof(response));
        }

        return response.Choices[0].Message.Content;
    }
}
