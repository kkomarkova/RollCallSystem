using RollCallSystem.Client.Services;

namespace TestProject;

[TestClass]
public class CalculatorTests
{
    //Calculator must be able to add numbers
    [TestMethod]
    public void TestAddition()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Plus;
        int number1 = 6;
        int number2 = 7;
        string expectedResult = "13";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //Testing boundary values that fail
    [DataTestMethod]
    [DataRow(6)]
    [DataRow(8)]
    public void TestAdditionBad(int number2)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Plus;
        int number1 = 6;
        string expectedResult = "13";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreNotEqual(expectedResult, calculator.Calculate());
    }

    //Calculator must be able to subtract numbers
    [TestMethod]
    public void TestSubtraction()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Minus;
        int number1 = 6;
        int number2 = 7;
        string expectedResult = "1";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //Testing boundary values that fail
    [DataTestMethod]
    [DataRow(6)]
    [DataRow(8)]
    public void TestSubtractionBad(int number2)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Minus;
        int number1 = 6;
        string expectedResult = "-1";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreNotEqual(expectedResult, calculator.Calculate());
    }

    //Calculator must be able to multiply numbers
    [TestMethod]
    public void TestMultiplication()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Multiply;
        int number1 = 6;
        int number2 = 7;
        string expectedResult = "42";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //Testing boundary values that fail
    [DataTestMethod]
    [DataRow(6)]
    [DataRow(8)]
    public void TestMultiplicationBad(int number2)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Multiply;
        int number1 = 6;
        string expectedResult = "42";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreNotEqual(expectedResult, calculator.Calculate());
    }

    //Calculator must be able to divide numbers
    [TestMethod]
    public void TestDivision()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Divide;
        int number1 = 12;
        int number2 = 6;
        string expectedResult = "2";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //Testing boundary values that fail
    [DataTestMethod]
    [DataRow(5)]
    [DataRow(7)]
    public void TestDivisionBad(int number2)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Divide;
        int number1 = 12;
        string expectedResult = "2";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreNotEqual(expectedResult, calculator.Calculate());
    }

    //Dividing by zero returns infinity and doesn't crash the program
    [TestMethod]
    public void TestDivisionByZero()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Divide;
        int number1 = 12;
        int number2 = 0;
        string expectedResult = "∞";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //The clear button must reset the calculator. The old values must not interfere with the new calculation.
    [DataTestMethod]
    [DataRow(CalculatorState.Plus, "8")]
    [DataRow(CalculatorState.Minus, "4")]
    [DataRow(CalculatorState.Multiply, "12")]
    [DataRow(CalculatorState.Divide, "3")]
    public void TestClear(CalculatorState operation, string expectedResult)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 12;
        int number2 = 4;
        int number3 = 6;
        int number4 = 2;
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        calculator.Reset();
        calculator.AddDigit(number3);
        calculator.ChangeState(operation);
        calculator.AddDigit(number4);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //After calculating, the user must be able to do extra operations with the result
    [TestMethod]
    public void TestExtraOperation()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Plus;
        int number1 = 6;
        int number2 = 7;
        string expectedResult = "20";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        calculator.Calculate();
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //After calculating, inputting a new number must reset the calculator
    [TestMethod]
    public void TestResetAfterCompletion()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        CalculatorState operation = CalculatorState.Plus;
        int number1 = 12;
        int number2 = 4;
        int number3 = 6;
        string expectedResult = "18";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        calculator.Calculate();
        calculator.AddDigit(number1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number3);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //The calculator must be able to handle decimal values for all operations
    [DataTestMethod]
    [DataRow(CalculatorState.Plus, "13.7")]
    [DataRow(CalculatorState.Minus, "-0.7000000000000002")]
    [DataRow(CalculatorState.Multiply, "46.800000000000004")]
    [DataRow(CalculatorState.Divide, "0.9027777777777778")]
    public void TestDecimalValues(CalculatorState operation, string expectedResult)
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 6;
        int decimal1 = 5;
        int number2 = 7;
        int decimal2 = 2;
        //Act
        calculator.AddDigit(number1);
        calculator.AddComma();
        calculator.AddDigit(decimal1);
        calculator.ChangeState(operation);
        calculator.AddDigit(number2);
        calculator.AddComma();
        calculator.AddDigit(decimal2);
        //Assert
        Assert.AreEqual(expectedResult, calculator.Calculate());
    }

    //The calculator must not allow two decimal points in one number
    [TestMethod]
    public void TestTwoDecimalPointsError()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 6;
        int decimal1 = 6;
        //Act
        calculator.AddDigit(number1);
        calculator.AddComma();
        calculator.AddDigit(decimal1);
        //Assert
        Assert.ThrowsException<Exception>(() => calculator.AddComma());
    }

    //The calculator's output must be the first number before any action is performed
    [TestMethod]
    public void TestFirstOutput()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 5;
        //Act
        calculator.AddDigit(number1);
        //Assert
        Assert.AreEqual(number1.ToString(), calculator.GetOutput());
    }

    //The calculator's output must be zero after an operation is selected
    [TestMethod]
    public void TestOutputZeroAfterOperationSelect()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 5;
        string zero = "0";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(CalculatorState.Plus);
        //Assert
        Assert.AreEqual(zero, calculator.GetOutput());
    }

    //The calculator's output must be the second number after an operation is selected an the second number has been put in
    [TestMethod]
    public void TestOutPutSecond()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 5;
        int number2 = 6;
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(CalculatorState.Plus);
        calculator.AddDigit(number2);
        //Assert
        Assert.AreEqual(number2.ToString(), calculator.GetOutput());
    }

    //The calculator's output must be the result after the calculation is performed
    [TestMethod]
    public void TestOutpustAfterCalculation()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        int number1 = 5;
        int number2 = 6;
        string result = "11";
        //Act
        calculator.AddDigit(number1);
        calculator.ChangeState(CalculatorState.Plus);
        calculator.AddDigit(number2);
        calculator.Calculate();
        //Assert
        Assert.AreEqual(result, calculator.GetOutput());
    }


    //The calculator's default output must be 0
    [TestMethod]
    public void TestOutputDefault()
    {
        //Arrange
        CalculatorService calculator = new CalculatorService();
        string zero = "0";
        //Act
        //Assert
        Assert.AreEqual(zero, calculator.GetOutput());
    }
}
