
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

[TestFixture]
public class RobotsTests
{
    private RobotManager robotManager;
    private Robot robot;
    [SetUp]
    public void SetUp()
    {
        this.robotManager = new RobotManager(10);
        this.robot = new Robot("TestRobot", 10);
        robotManager.Add(robot);
    }
    [Test]
    public void RobotConstructor_ShouldSetValuesProperly()
    {
        Assert.AreEqual("TestRobot", this.robot.Name);
        Assert.AreEqual(10, this.robot.MaximumBattery);
        Assert.AreEqual(10, this.robot.Battery);
    }
    [Test]
    public void RobotManagerConstructor_ShouldInitializeRobotsProperly()
    {
        var robots = this.robotManager
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .First(x => x.Name == "robots")
            .GetValue(this.robotManager);
        Assert.IsNotNull(robots);
    }
    [Test]
    public void RobotManagerConstructor_ShouldInitializeCapacityProperly()
    {
        var capacityField = this.robotManager
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .First(x => x.Name == "capacity")
                .GetValue(this.robotManager);
        Assert.AreEqual(10, capacityField);
    }
    [Test]
    [TestCase(-1)]
    [TestCase(-10)]
    public void RobotManagerConstructor_ShouldThrowExceptionWhenCapacityIsLessThan0(int capacity)
    {
        Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
    }
    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(40)]
    public void RobotManagerConstructor_ShouldSetCapacityProperly(int capacity)
    {
        var robotManger = new RobotManager(capacity);
        Assert.AreEqual(capacity, robotManger.Capacity);
    }
    [Test]
    public void Add_ShouldThrowExceptionWhenThereIsExistingRobotWithThatName()
    {
        var sameRobot = new Robot("TestRobot", 10);
        Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(sameRobot));
    }
    [Test]
    public void Add_ShouldThrowExceptionWhenThereIsNoMoreCapacity()
    {
        var noCapManager = new RobotManager(1);
        var validRobot = new Robot("ValidRobot", 10);
        noCapManager.Add(validRobot);
        var anotherValidRobot = new Robot("ValidRobot1", 10);
        Assert.Throws<InvalidOperationException>(() => noCapManager.Add(anotherValidRobot));
    }
    [Test]
    public void Add_ShouldAddRobotCorrectly()
    {
        var validRobot = new Robot("TestRobot2", 10);
        this.robotManager.Add(validRobot);
        Assert.AreEqual(2, this.robotManager.Count);
    }
    [Test]
    public void Count_ShouldReturnCountOfRobotsCorrectly()
    {
        Assert.AreEqual(1, this.robotManager.Count);
        var validRobot = new Robot("TestRobot2", 10);
        this.robotManager.Add(validRobot);
        Assert.AreEqual(2, this.robotManager.Count);
    }
    [Test]
    public void Remove_ShouldThrowExceptionWhenRobotDoesNotExist()
    {
        Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("InvalidRobot"));
    }
    [Test]
    public void Remove_ShouldRemoveExistingRobotCorrectly()
    {
        this.robotManager.Remove("TestRobot");
        Assert.AreEqual(0, this.robotManager.Count);
    }
    [Test]
    public void Work_ShouldThrowExceptionWhenRobotDoesNotExist()
    {
        Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("InvalidRobot", "Job", 10));
    }
    [Test]
    [TestCase(11)]
    [TestCase(30)]
    public void Work_ShouldThrowExceptionWhenRobotDoesNotHaveEnoughBattery(int batteryNeeded)
    {
        Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("TestRobot", "Job", batteryNeeded));
    }
    [Test]
    [TestCase(10)]
    [TestCase(5)]
    public void Work_ShouldTakeOutBatteryWhenRobotHasBattery(int battery)
    {
        this.robotManager.Work("TestRobot", "Job", battery);
        Assert.AreEqual(this.robot.MaximumBattery - battery, this.robot.Battery);
    }
    [Test]
    public void Charge_ShouldThrowExceptionWhenRobotDoesNotExist()
    {
        Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("InvalidRobot"));
    }
    [Test]
    public void Charge_ShouldChargeRobotFullyWhenRobotExists()
    {
        this.robotManager.Work("TestRobot","Job",10);
        this.robotManager.Charge("TestRobot");
        Assert.AreEqual(this.robot.MaximumBattery, this.robot.Battery);
    }
}

