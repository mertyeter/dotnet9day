using Microsoft.ML.Tokenizers;

// Initialize the Tiktoken tokenizer for the GPT-4 model
var tokenizer = TiktokenTokenizer.CreateForModel("gpt-4");

// Define the text to be tokenized
string text = "tiktoken is great!";

// Encode the text to token IDs
IReadOnlyList<int> encodedIds = tokenizer.EncodeToIds(text);
Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedIds)}}}");

// Decode the token IDs back to text
string decodedText = tokenizer.Decode(encodedIds);
Console.WriteLine($"decodedText = {decodedText}");

// Get the count of tokens in the text
int idsCount = tokenizer.CountTokens(text);
Console.WriteLine($"idsCount = {idsCount}");

// Encode the text to tokens
var encodedTokens = tokenizer.EncodeToTokens(text, normalizedText: out var _);
Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedTokens.Select(token => $"\"{token.Value}\""))}}}");

