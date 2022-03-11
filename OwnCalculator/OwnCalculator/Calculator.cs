namespace OwnCalculator
{
    public class Calculator
    {
        private double _result;

        public double Result
        {
            get => _result;
            set => _result = value;
        }

        public void Add(double x, double y)
        {
            _result = x + y;
        }
        public void Sub(double x, double y)
        {
            _result = x - y;
        }
        public void Mul(double x, double y)
        {
            _result = x * y;
        }
        public void Div(double x, double y)
        {
            _result = x / y;
        }
        public void Modulo(double x, double y)
        {
            _result = x % y;
        }
    }
}

