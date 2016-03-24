namespace PeriodicCountingNetwork
{
    public class Balancer
    {
        private readonly object _lock = new object();

        private bool _toggle = true;

        public int Traverse()
        {
            lock (_lock)
            {
                try
                {
                    if (_toggle)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                finally
                {
                    _toggle = !_toggle;
                }
            }
        }
    }
}
