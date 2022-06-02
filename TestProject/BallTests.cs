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
}
