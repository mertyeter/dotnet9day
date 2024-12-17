using Microsoft.Extensions.AI;

// Create a new chat client
var chatClient = new OllamaChatClient(new Uri("http://localhost:11434/"), "phi3");

// Start the conversation with context for the AI model
List<ChatMessage> chatHistory = [];

while (true)
{
    // Get user prompt and add to chat history
    Console.Write("Your prompt: ");
    var userPrompt = Console.ReadLine();

    // Exit loop if the user types "/bye"
    if (userPrompt!.StartsWith("/bye"))
    {
        break;
    }

    // Add user prompt to chat history
    chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

    // Stream the AI response and add to chat history
    Console.Write("AI Response: ");
    var response = string.Empty;

    // Stream the AI response
    await foreach (var item in chatClient.CompleteStreamingAsync(chatHistory))
    {
        response += item;
        Console.Write(item);
    }

    // Add the AI's response to the chat history
    chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
    Console.WriteLine();
}