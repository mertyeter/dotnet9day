// Import the System.Numerics.Tensors namespace
using System.Numerics.Tensors;

//Define an array of games with their titles and embeddings
var games = new[] {
    new { Title="Call of Duty", Embedding= new [] { 0.712, 0.885, 0.820, 0.780, 0.647 } },
    new { Title="Medal of Honor", Embedding= new [] { 0.647, 0.617, 0.860, 0.780, 0.812 } },
    new { Title="Battlefield", Embedding= new [] { 0.606, 0.891, 0.850, 0.664, 0.655 } },
    new { Title="Gran Tourismo", Embedding= new [] { 0.255, 0.291, 0.357, 0.330, 0.287 } },
    new { Title="God of War", Embedding= new [] { 0.384, 0.242, 0.288, 0.310, 0.337 } }
};

// Define a query embedding to compare against the games genre
var queryEmbedding = new[] { 0.836, 0.660, 0.754, 0.778, 0.614 };

// Calculate the dot product between the query embedding and each games' embedding
var similarGamesTensors =
    games
        .Select(game =>
            (
                game.Title,
                Similarity: TensorPrimitives.Dot<double>(queryEmbedding, game.Embedding)
            ))
        .OrderByDescending(game => game.Similarity) // Order the games by similarity in descending order
        .Take(3); // Take the top 3 most similar games

// Print the top 3 most similar movies
foreach (var game in similarGamesTensors)
{
    Console.WriteLine(game);
}