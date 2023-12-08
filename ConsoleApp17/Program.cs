using ConsoleApp17;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .Build();

string deploymentName = config["OpenAI:DeploymentName"] ?? throw new InvalidOperationException("OpenAI:DeploymentName is not set.");
string modelId = config["OpenAI:ModelId"] ?? throw new InvalidOperationException("OpenAI:ModelId is not set.");
string endpoint = config["OpenAI:Endpoint"] ?? throw new InvalidOperationException("OpenAI:BaseUrl is not set.");
string key = config["OpenAI:Key"] ?? throw new InvalidOperationException("OpenAI:Key is not set.");

KernelBuilder builder = new();


builder.Services.AddAzureOpenAIChatCompletion(
    deploymentName,
    modelId,
    endpoint, 
    key);
builder.Plugins.AddFromType<Plugin>();

Kernel kernel = builder.Build();
OpenAIPromptExecutionSettings? setting = new()
{
    FunctionCallBehavior = FunctionCallBehavior.AutoInvokeKernelFunctions
};

while (true)
{
    Console.Write("User > ");
    string input = Console.ReadLine()!;
    if (input == "exit")
    {
        break;
    }
    else
    {
        var result = await kernel.InvokePromptAsync(input, new(setting));
        Console.WriteLine($"Assistant > {result}");
    }
}
