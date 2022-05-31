namespace RollCallSystem.Client.Services;

public class PenPickerService
{
    private readonly List<string> colours = new List<string>()
    {
        "Red",
        "Black",
        "Blue",
        "Green",
        "A permanent marker :^)"
    };

    public string Pick()
    {
        Random random = new Random();
        return colours[random.Next(colours.Count)];
    }
}
