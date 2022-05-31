namespace RollCallSystem.Client.Services;

public class CoffeeTrackerService
{
    public bool GetRecommendation(int coffeesHad, out string response)
    {
        switch (coffeesHad)
        {
            case 1 or 2:
                response = "You need more coffee.";
                return true;
            default:
                return RandomSuggestion(out response);
        }
    }

    private bool RandomSuggestion(out string suggestion)
    {
        Random random = new Random();
        int number = random.Next(0, 10);

        if (number < 8)
        {
            suggestion = "No more coffee for today.";
            return false;
        }
        else if (number < 9)
        {
            suggestion = "Perhaps one more.";
            return true;
        }
        else
        {
            suggestion = "Get one more cup.";
            return true;
        }
    }
}
