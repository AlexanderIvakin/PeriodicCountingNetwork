namespace PeriodicCountingNetwork
{
    public class Periodic
    {
        private Block[] _block;
        public Periodic(int width)
        {
            var logSize = 0;
            var myWidth = width;

            while (myWidth > 1)
            {
                logSize++;
                myWidth = myWidth / 2;
            }

            _block = new Block[logSize];
            for (var i = 0; i < logSize; ++i)
            {
                _block[i] = new Block(width);
            }
        }

        public int Traverse(int input)
        {
            var wire = input;
            foreach (var b in _block)
            {
                wire = b.Traverse(wire);
            }
            return wire;
        }
    }
}
