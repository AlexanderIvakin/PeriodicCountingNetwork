using System.Threading;

namespace PeriodicCountingNetwork
{
    public class Balancer
    {
        private int _toggle = 1;

        public int Traverse()
        {
            while (true)
            {
                if (1 == Interlocked.Exchange(ref _toggle, 0))
                {
                    return 0;
                }
                if (0 == Interlocked.Exchange(ref _toggle, 1))
                {
                    return 1;
                }
            }
        }
    }
}
