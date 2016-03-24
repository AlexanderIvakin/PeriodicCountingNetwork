namespace PeriodicCountingNetwork
{
    public class Block
    {
        private Block _north;
        private Block _south;

        private Layer _layer;
        private int _width;

        public Block(int width)
        {
            _width = width;
            if (width > 2)
            {
                _north = new Block(width / 2);
                _south = new Block(width / 2);
            }
            _layer = new Layer(width);
        }

        public int Traverse(int input)
        {
            int wire = _layer.Traverse(input);
            if (_width > 2)
            {
                if (wire < _width / 2)
                {
                    return _north.Traverse(wire);
                }
                else
                {
                    return (_width / 2) + _south.Traverse(wire - (_width / 2));
                }
            }
            else
            {
                return wire;
            }
        }
    }
}
