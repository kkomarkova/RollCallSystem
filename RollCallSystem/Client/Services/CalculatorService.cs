using System.Globalization;

namespace RollCallSystem.Client.Services;

public enum CalculatorState
{
    Default,
    Plus,
    Minus,
    Multiply,
    Divide,
    PostEquals
}

public class CalculatorService
{
    public CalculatorState State { get; private set; } = CalculatorState.Default;
    public string Number1 { get; private set; } = "0";
    public string Number2 { get; private set; } = "0";

    public string Calculate()
    {
        string result;

        switch (State)
        {
            case CalculatorState.Plus:
                result = (double.Parse(Number1, CultureInfo.InvariantCulture) + double.Parse(Number2, CultureInfo.InvariantCulture)).ToString();
                break;
            case CalculatorState.Minus:
                result = (double.Parse(Number1, CultureInfo.InvariantCulture) - double.Parse(Number2, CultureInfo.InvariantCulture)).ToString();
                break;
            case CalculatorState.Multiply:
                result = (double.Parse(Number1, CultureInfo.InvariantCulture) * double.Parse(Number2, CultureInfo.InvariantCulture)).ToString();
                break;
            case CalculatorState.Divide:
                result = (double.Parse(Number1, CultureInfo.InvariantCulture) / double.Parse(Number2, CultureInfo.InvariantCulture)).ToString();
                break;
            default:
                result = Number1.ToString();
                break;
        }

        Number1 = result;
        Number2 = "0";
        State = CalculatorState.PostEquals;
        result = result.Replace(',', '.');
        return result;
    }

    public void AddDigit(int digit)
    {
        if (State == CalculatorState.Default || State == CalculatorState.PostEquals)
        {
            if (Number1 == "0" || State == CalculatorState.PostEquals)
                Number1 = digit.ToString();
            else
                Number1 += digit;
        }

        else
        {
            if (Number2 == "0")
                Number2 = digit.ToString();
            else
                Number2 += digit;
        }

        if (State == CalculatorState.PostEquals)
            State = CalculatorState.Default;
    }

    public void ChangeState(CalculatorState newState)
    {
        Number1 = Calculate();
        State = newState;
    }

    public void Reset()
    {
        Number1 = "0";
        Number2 = "0";
        State = CalculatorState.Default;
    }

    public void AddComma()
    {
        if(State == CalculatorState.Default || State == CalculatorState.PostEquals)
        {
            if (Number1.Contains('.'))
                throw new Exception();
            else if (State == CalculatorState.PostEquals)
                Number1 = "0.";
            else Number1 += ".";
        }
        else
        {
            if (Number2.Contains('.'))
                throw new Exception();
            else Number2 += ".";
        }
    }

    public string GetOutput()
    {
        if (State == CalculatorState.Default || State == CalculatorState.PostEquals)
            return Number1;
        else return Number2;
    }
}