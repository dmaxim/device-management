using System.Text.Json;
using Microsoft.Extensions.Options;
using MxInfo.DeviceManager.Agent.Business.DeviceManagerFunctions;
using OpenAI;
using OpenAI.Chat;

namespace MxInfo.DeviceManager.Agent.Business.Managers;


/// <summary>
/// Implementation of the OpenAI manager
/// </summary>
public class OpenAiManager(IOptions<OpenAiConfiguration> configuration) : IOpenAiManager
{
    private readonly OpenAiConfiguration _configuration = configuration.Value;
    public async Task<string> GetMessage()
    {
        try
        {
            var client = new ChatClient(_configuration.OpenAiModel, _configuration.OpenAiKey);

            var completion = await client.CompleteChatAsync("Tell me a joke about C# programming language");

            return completion.Value.Content[0].Text.Trim();

        }
        catch (System.Exception e)
        {
            return e.Message;
        }        

    }

    public async Task<IList<string>> StreamMessage()
    {
        var client = new ChatClient(_configuration.OpenAiModel, _configuration.OpenAiKey);
        var completionUpdates = client.CompleteChatStreamingAsync("Tell me a joke about Terraform");
        var contentParts = new List<string>();
        await foreach (var message in completionUpdates)
        {
            contentParts.AddRange(message.ContentUpdate.Select(contentPart => contentPart.Text.Trim()));
        }
        
        return contentParts;
    }

    public async Task ChatWithMessages()
    {
        var completionOptions = new ChatCompletionOptions
            {
                MaxOutputTokenCount = 300,
                Temperature = 0.7f,
                FrequencyPenalty = 0.0f,
                PresencePenalty = 0.0f,
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
              
            };
           
        var openAiClient = new OpenAIClient(_configuration.OpenAiKey);
        var chatClient = openAiClient.GetChatClient(_configuration.OpenAiModel);
        var messages = new List<string>();
        ChatMessage[] chatMessages =
        [
            new SystemChatMessage("You are a helpful assistant that is knowledgeable in the food space"),
            new UserChatMessage("Hi can you help me"),
            new AssistantChatMessage("Of course, what do you need help with?"),
            new UserChatMessage("Can you give me a list of the top 10 most popular foods in the world?"),
        ];
        
        var completionUpdates = chatClient.CompleteChatStreamingAsync(chatMessages);

        await foreach (var message in completionUpdates)
        {
            messages.AddRange(message.ContentUpdate.Select(contentPart => contentPart.Text.Trim()));
        }
    }

    public async Task GetDeviceDetails()
    {
        var openAiClient = new OpenAIClient(_configuration.OpenAiKey);
        var chatClient = openAiClient.GetChatClient(_configuration.OpenAiModel);
        var requiresAction = true;

        List<ChatMessage> messages =
        [
            new UserChatMessage("Get the details of the device with serial number 12345"),
        ];

        var options = new ChatCompletionOptions
        {
            Tools = { FunctionRegistry.GetDeviceInfoTool, FunctionRegistry.GetDeviceNetworkInfoTool }
        };

        while (requiresAction)
        {
            requiresAction = false;
            var response = await chatClient.CompleteChatAsync(messages, options);

            switch (response.Value.FinishReason)
            {
                case ChatFinishReason.ToolCalls:
                {
                    messages.Add(new AssistantChatMessage(response));
                    foreach (var toolCall in response.Value.ToolCalls)
                    {
                        switch (toolCall.FunctionName)
                        {
                            case nameof(FunctionRegistry.GetDeviceInfo):
                            {
                                using JsonDocument argumentsJson =
                                    JsonDocument.Parse(toolCall.FunctionArguments.ToString());
                                var toolResult = FunctionRegistry.GetDeviceInfo(
                                    argumentsJson.RootElement.GetProperty("serialNumber").GetString()!);
                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                break;
                            }
                            case nameof(FunctionRegistry.GetDeviceNetworkInfo):
                            {
                                using JsonDocument argumentsJson =
                                    JsonDocument.Parse(toolCall.FunctionArguments.ToString());
                                var toolResult = FunctionRegistry.GetDeviceNetworkInfo(
                                    argumentsJson.RootElement.GetProperty("serialNumber").GetString()!);
                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                break;
                            }
                        }
                    }

                    requiresAction = true;
                    break;
                }
                case ChatFinishReason.Stop:
                {
                    messages.Add(new AssistantChatMessage(response));
                    break;
                }
                case ChatFinishReason.Length:
                    throw new InvalidOperationException("The response exceeded the maximum length.");
                case ChatFinishReason.ContentFilter:
                    throw new InvalidOperationException("The response omitted content due to a content filter.");
                case ChatFinishReason.FunctionCall:
                    throw new InvalidOperationException("Deprecated in favor of tool calls.");
                default:
                    throw new InvalidOperationException(response.Value.FinishReason.ToString());
            }
        }

        foreach (var message in messages)
        {
            if (message.Content.Count > 0)
            {
                Console.WriteLine(message.Content[0].Text.Trim());
            }
        }
    }
}