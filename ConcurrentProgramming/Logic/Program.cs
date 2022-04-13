namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball(15, 10, 20);
            Console.WriteLine(ball.Radius);
            Console.WriteLine(ball.X);
            Console.WriteLine(ball.Y);

            Ball kula2 = new Ball();
            Generator gen = new Generator();
            gen.GenerateXY();
            kula2.X = gen.X;
            kula2.Y = gen.Y;
            Console.WriteLine(kula2.Radius);
            Console.WriteLine(kula2.X);
            Console.WriteLine(kula2.Y);
            
            Board board = new Board();
            Console.WriteLine(board.A);
            board.AddBallToBoard(ball);
            board.AddBallToBoard(kula2);
            board.ShowBalls();
        }
    }
}
