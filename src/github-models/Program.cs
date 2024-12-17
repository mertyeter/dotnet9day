using Azure;
using Azure.AI.Inference;
using Microsoft.Extensions.Configuration;

// Read the API key from the user secrets
var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

// Define the endpoint for the AI model
const string endpoint = "https://models.inference.ai.azure.com";

// Create a new chat completions client using the endpoint and API key
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(configuration["gh-token"]!));

// Initialize the chat history with a system message
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

while (true)
{
    // Prompt the user for input
    Console.Write("You: ");
    var userPrompt = Console.ReadLine();

    // Exit the loop if the user types "/bye"
    if (userPrompt!.StartsWith("/bye"))
    {
        break;
    }

    // Add the user's message to the chat history
    chatHistory.Add(new ChatRequestUserMessage(userPrompt));

    // Create options for the chat completions request with the chat history and model
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "Llama-3.3-70B-Instruct"
    };

    // Get the AI response
    ChatCompletions? chatCompletions = await client.CompleteAsync(options);

    // Display the AI response
    Console.WriteLine($"AI Response: {chatCompletions.Content}");

    // Add the AI's message to the chat history
    chatHistory.Add(new ChatRequestAssistantMessage(chatCompletions.Content));    
}