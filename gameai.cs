using System;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.Console;

class Program
{
    static void Main(string[] args)
    {
        var adapter = new ConsoleAdapter()
            .Use(new RegisterClassMiddleware<IActivity>(typeof(Bot)));

        var bot = new Bot();

        while (true)
        {
            var userMessage = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                break;
            }

            bot.OnTurnAsync(new TurnContext(adapter, new Activity
            {
                Type = ActivityTypes.Message,
                Text = userMessage
            })).Wait();
        }
    }
}

class Bot : IBot
{
    public async Task OnTurnAsync(ITurnContext turnContext)
    {
        if (turnContext.Activity.Type == ActivityTypes.Message)
        {
            var userInput = turnContext.Activity.Text;

            // Add your own logic to process user input and generate a response
            var response = GetResponse(userInput);

            await turnContext.SendActivityAsync(MessageFactory.Text(response));
        }
    }

    private string GetResponse(string userInput)
    {
        // Add your own logic here to generate a response based on user input
        // For example, you can use if-else statements, switch cases, or any other processing logic.

        // As a basic example, let's echo back the user's input:
        return $"You said: {userInput}";
    }
}
