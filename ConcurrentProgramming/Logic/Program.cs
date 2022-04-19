using System.Numerics;

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ball ball = new Ball(15, 10, 20);
            // Console.WriteLine(ball.Radius);
            // Console.WriteLine(ball.X);
            // Console.WriteLine(ball.Y);
            //
            // Ball kula2 = new Ball();
            // Generator gen = new Generator();
            // gen.GenerateXY();
            // kula2.X = gen.X;
            // kula2.Y = gen.Y;
            // Console.WriteLine(kula2.Radius);
            // Console.WriteLine(kula2.X);
            // Console.WriteLine(kula2.Y);
            //
            // Board board = new Board();
            // Console.WriteLine(board.A);
            // board.AddBallToBoard(ball);
            // board.AddBallToBoard(kula2);
            // board.ShowBalls();

            Board board2 = new Board();
            board2.CreateBalls();
            board2.ShowBalls();
            
            Console.WriteLine("a");
            System.Random random = new System.Random();
            List<Ball> ballsy = board2.Balls.GetRange(0, board2.Balls.Count - 1);
            //ballsy[0].Velocity = new Vector2((float) 0.1, (float) 0.2);
            // ballsy[0].Velocity=new Vector2(50 + (float) random.NextDouble() * 100,
            
            //      50 + (float) random.NextDouble() * 100);
            // ball.Velocity = new Vector2(50 - (float) random.NextDouble() * 100,
            //     50 - (float) random.NextDouble() * 100);
            //Console.WriteLine(ballsy[0].Coordinates);
            while (true)
            {
                //long time = DateTime.Now.Second;
                long time = DateTime.Now.Second;
                 
                 
                //Console.WriteLine(time);
                ballsy[0].UpdatePostion(time);
                 
                Console.WriteLine(ballsy[0].Coordinates);
            }
            //private long _gameTime = DateTime.Now.Millisecond;


        }
    }
}