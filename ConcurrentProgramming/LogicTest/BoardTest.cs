using System;
using Logic;
using NUnit.Framework;

namespace LogicTest;

public class BoardTest
{
    [Test]
    public void TestConstructor()
    {
        Board board = new Board();
        Assert.AreEqual(0, board.Balls.Count);
    }

    [Test]
    public void TestCreateBalls()
    {
        Board board = new Board();
        board.CreateBalls(50);
        Assert.AreEqual(50, board.Balls.Count);
        board.CreateBalls(51);
        Assert.AreEqual(51, board.Balls.Count);
        Assert.Throws<Exception>(() => board.CreateBalls(-50));
    }

    [Test]
    public void TestStartStopBalls()
    {
        Board board = new Board();
        board.CreateBalls(2);
        board.StartBalls();
        Assert.AreEqual(2, board.TasksAmount);
        Assert.AreEqual(board.TasksAmount, board.Balls.Count);
        board.Stop();
        Assert.AreEqual(0, board.TasksAmount);
        Assert.AreEqual(board.TasksAmount, board.Balls.Count);
    }
}