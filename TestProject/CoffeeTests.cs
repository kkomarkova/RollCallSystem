using RollCallSystem.Client.Services;

namespace TestProject;

[TestClass]
public class CoffeeTests
{
    //Fist coffee must tell you to drink another one
    [TestMethod]
    public void TestFirstCoffee()
    {
        //Arrange
        CoffeeTrackerService tracker = new CoffeeTrackerService();
        int numberOfCoffees = 1;
        //Act
        bool haveAnother = tracker.GetRecommendation(numberOfCoffees, out _);
    }

    //Second coffee must tell you to drink another one
    [TestMethod]
    public void TestSecondCoffee()
    {
        //Arrange
        CoffeeTrackerService tracker = new CoffeeTrackerService();
        int numberOfCoffees = 2;
        //Act
        bool haveAnother = tracker.GetRecommendation(numberOfCoffees, out _);
    }

    //Third coffee onwanrds somtetimes tells you to stop
    [TestMethod]
    public void TestThirdCoffeeStop()
    {
        //Arrange
        CoffeeTrackerService tracker = new CoffeeTrackerService();
        int numberOfCoffees = 3;
        //Act
        int numberOfContinue = 0;
        int numberOfStop = 0;
        for(int i = 0; i < 100; i++)
        {
            if (tracker.GetRecommendation(numberOfCoffees, out _))
                numberOfContinue++;
            else
                numberOfStop++;
        }
        //Assert
        Assert.IsTrue(numberOfContinue > 0);
    }

    //Third coffee onwanrds sometimes tells you to have another one
    [TestMethod]
    public void TestThirdCoffeeContinue()
    {
        //Arrange
        CoffeeTrackerService tracker = new CoffeeTrackerService();
        int numberOfCoffees = 3;
        //Act
        int numberOfContinue = 0;
        int numberOfStop = 0;
        for (int i = 0; i < 100; i++)
        {
            if (tracker.GetRecommendation(numberOfCoffees, out _))
                numberOfContinue++;
            else
                numberOfStop++;
        }
        //Assert
        Assert.IsTrue(numberOfStop > 0);
    }

    //Third coffee onwanrds tells you to stop more often than to continue
    [TestMethod]
    public void TestThirdCoffeeContinueToStopRatio()
    {
        //Arrange
        CoffeeTrackerService tracker = new CoffeeTrackerService();
        int numberOfCoffees = 3;
        //Act
        int numberOfContinue = 0;
        int numberOfStop = 0;
        for (int i = 0; i < 100; i++)
        {
            if (tracker.GetRecommendation(numberOfCoffees, out _))
                numberOfContinue++;
            else
                numberOfStop++;
        }
        //Assert
        Assert.IsTrue(numberOfStop > numberOfContinue);
    }
}
