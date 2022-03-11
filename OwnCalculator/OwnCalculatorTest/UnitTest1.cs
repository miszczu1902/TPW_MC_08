using NUnit.Framework;
using OwnCalculator;

namespace OwnCalculatorTest;

public class Tests
{
    [Test]
    public void GetSetTest()
    {
        //Arrange
        var calculator = new Calculator();

        //Act
        calculator.Result = 20;

        //Assert
        Assert.AreEqual(20, calculator.Result);
        Assert.AreNotEqual(200, calculator.Result);

        var tmp = calculator.Result;
        Assert.AreEqual(20, tmp);
    }

    [Test]
    public void AddTest()
    {
        var calculator = new Calculator();

        calculator.Add(50, 15.577);

        Assert.AreEqual(65.577, calculator.Result);
        Assert.AreEqual(65.58, calculator.Result, 0.01);
    }

    [Test]
    public void SubTest()
    {
        var calculator = new Calculator();

        calculator.Sub(123, 19);

        Assert.AreEqual(104, calculator.Result);

        calculator.Sub(-100, 200);

        Assert.AreEqual(-300.00, calculator.Result, 0.01);
    }

    [Test]
    public void MulTest()
    {
        var calculator = new Calculator();

        calculator.Mul(34.765, 5.0);

        Assert.AreEqual(173.825, calculator.Result);
        Assert.AreEqual(173.83, calculator.Result, 0.01);
    }

    [Test]
    public void DivTest()
    {
        var calculator = new Calculator();

        calculator.Div(35, 5.0);

        Assert.AreEqual(7.0, calculator.Result);
    }
    
    [Test]
    public void ModuloTest()
    {
        var calculator = new Calculator();

        calculator.Modulo(22, 21);

        Assert.AreEqual(1, calculator.Result);
    }
}