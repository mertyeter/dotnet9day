# Deep Dive into AI Innovation with .NET 9 and GitHub Models

This repository contains the source code and presentation materials for my session titled *"Deep Dive into AI Innovations with .NET 9 and GitHub Models"* at the .NET 9 Day event, held on Dec 21st, 2024.

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Ollama](https://ollama.com/)
- [GitHub Models](https://github.com/marketplace/models)

## Projects

### GitHubModels

This project uses Azure AI Inference to interact with a chat model hosted on Azure.

#### Setup

1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone the repository.
3. Navigate to the `src/github-models` directory.
4. Add your Azure API key to the user secrets:
    ```sh
    dotnet user-secrets init
    dotnet user-secrets set "gh-token" "<your-api-key>"
    ```
5. Restore the required NuGet packages:
    ```sh
    dotnet restore
    ```
6. Run the project:
    ```sh
    dotnet run
    ```

### LocalModels

This project uses the [Microsoft.Extensions.AI.Ollama](http://_vscodecontentref_/1) package to interact with a locally hosted AI model.

#### Ollama Setup

1. Download and install Ollama from the [official website](https://ollama.com/download).
2. Start the Ollama server:
    ```sh
    ollama serve
    ```
3. Ensure the server is running on `http://localhost:11434`.
4. Pull required Ollama [models](https://ollama.com/library) with 
```sh
ollama pull '<model-name>'
```

#### Setup

1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone the repository.
3. Navigate to the [local-models](http://_vscodecontentref_/2) directory.
4. Restore the required NuGet packages:
    ```sh
    dotnet restore
    ```
5. Run the project:
    ```sh
    dotnet run
    ```
