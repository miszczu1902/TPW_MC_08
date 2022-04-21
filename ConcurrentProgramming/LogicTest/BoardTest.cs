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
    }
    
    [Test]
    public void TestStartBalls()
    {
        Board board = new Board();
        board.CreateBalls(2);
    }
}