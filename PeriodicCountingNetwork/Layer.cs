namespace PeriodicCountingNetwork
{
    public class Layer
    {
        private readonly int _width;
        private Balancer[] _layer;

        public Layer(int width)
        {
            _width = width;
            _layer = new Balancer[_width];
            for (var i = 0; i < _width / 2; ++i)
            {
                _layer[i] = _layer[_width - i - 1] = new Balancer();
            }
        }

        public int Traverse(int input)
        {
            var toggle = _layer[input].Traverse();
            int hi, lo;
            if (input < _width / 2)
            {
                lo = input;
                hi = _width - input - 1;
            }
            else
            {
                lo = _width - input - 1;
                hi = input;
            }

            if (toggle == 0)
            {
                return lo;
            }
            else
            {
                return hi;
            }
        }
    }
}
