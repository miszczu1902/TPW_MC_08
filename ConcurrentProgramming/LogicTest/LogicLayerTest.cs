using System;
using System.IO;
using Logic;
using NUnit.Framework;

namespace LogicTest;

public class LogicLayerTest
{
    [Test]
    public void TestConstructor()
    {
        LogicApi logicApi = new LogicApi();
        Assert.AreEqual(0, logicApi.Balls.Count);
    }

    [Test]
    public void TestCreateBalls()
    {
        LogicApi logicApi = new LogicApi();
        logicApi.CreateBalls(50);
        Assert.AreEqual(50, logicApi.Balls.Count);
        logicApi.CreateBalls(51);
        Assert.AreEqual(51, logicApi.Balls.Count);
        Assert.Throws<Exception>(() => logicApi.CreateBalls(-50));
    }

    [Test]
    public void TestStartStopBalls()
    {
        
        LogicApi logicApi = new LogicApi();
        logicApi.CreateBalls(2);
        Assert.AreNotEqual(2, logicApi.TasksAmount);
        Assert.AreNotEqual(logicApi.TasksAmount, logicApi.Balls.Count);
        logicApi.Stop();
        Assert.AreNotEqual(2, logicApi.TasksAmount);
        Assert.AreEqual(logicApi.TasksAmount, logicApi.Balls.Count);
    }
}