using System.Numerics;
using Data;
using Logic;
using NUnit.Framework;

namespace LogicTest;

public class DataLayerTest
{
    [Test]
    public void TestConstructor()
    {
        Ball ball = new Ball();
        Assert.AreEqual(25, ball.Radius);
    }

    [Test]
    public void TestCoordiantesAndXAndY()
    {
        Ball ball = new Ball();
        Vector2 coords = new Vector2(5, 15);
        ball.Coordinates = coords;
        Assert.AreEqual(coords, ball.Coordinates);
        Assert.AreEqual(5, ball.X);
        Assert.AreEqual(5, ball.X);
        Assert.AreEqual(15, ball.Y);
    }

    [Test]
    public void TestVelocity()
    {
        Ball ball = new Ball();
        ball.Velocity = new Vector2(-3, 7);
        Assert.AreEqual(-3, ball.Velocity.X);
        Assert.AreEqual(7, ball.Velocity.Y);
    }

    [Test]
    public void TestUpdatePosition()
    {
        Ball ball = new Ball();
        ball.Velocity = new Vector2(-3, 7);
        ball.Coordinates = new Vector2(DataApi.WIDTH, DataApi.HEIGHT);
        ball.UpdatePostion();
        Assert.AreNotEqual(DataApi.WIDTH, ball.Velocity.X);
        Assert.AreNotEqual(DataApi.HEIGHT, ball.Velocity.Y);
    }
}