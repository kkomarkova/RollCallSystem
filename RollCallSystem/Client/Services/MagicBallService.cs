namespace RollCallSystem.Client.Services;

public class MagicBallService
{
    private readonly List<string> responses = new List<string>()
    {
        "It is certain.",
        "It is decidedly so.",
        "Without a doubt.",
        "Yes definitely.",
        "You may rely on it.",
        "As I see it, yes.",
        "Most likely.",
        "Outlook good.",
        "Yes.",
        "Signs point to yes.",
        "Reply hazy, try again.",
        "Ask again later.",
        "Better not tell you now.",
        "Cannot predict now.",
        "Concentrate and ask again.",
        "Don't count on it.",
        "My reply is no.",
        "My sources say no.",
        "Outlook not so good.",
        "Very doubtful."
    };

    public string ContactTheSpirits()
    {
        Random random = new Random();
        return responses[random.Next(responses.Count)];
    }

    public bool ValidateQuestion(string question)
    {
        if (!question.EndsWith('?') || question.Length < 5 || question.Length > 50)
            return false;
        return true;
    }
}
