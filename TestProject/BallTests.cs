using RollCallSystem.Client.Services;

namespace TestProject;

[TestClass]
public class BallTests
{
    //Questions must end with a question mark
    [TestMethod]
    public void TestNoQuestionMark()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "A question";
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsFalse(response);
    }

    [TestMethod]
    public void TestQuestionMarkInMiddle()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "A? question";
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsFalse(response);
    }

    [TestMethod]
    public void TestQuestionMark()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "A question?";
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsTrue(response);
    }

    [TestMethod]
    public void TestTooShort()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "huh?";
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsFalse(response);
    }

    [TestMethod]
    public void TestLongEnough()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "1234?";
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsTrue(response);
    }

    [TestMethod]
    public void TestTooLong()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa?"; //51 chars
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsFalse(response);
    }

    [TestMethod]
    public void TestShortEnough()
    {
        //Arrange
        MagicBallService ball = new MagicBallService();
        string question = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa?"; //50 chars
        //Act
        bool response = ball.ValidateQuestion(question);
        //Assert
        Assert.IsTrue(response);
    }
}
