using System;
using System.Threading;

namespace Jint
{
    public class CancellationScope : IDisposable
    {
        [ThreadStatic]
        private static CancellationToken _cancellationToken;

        public CancellationScope(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }

        public void Dispose()
        {
            _cancellationToken = CancellationToken.None;
        }

        public static bool IsCancellationRequested
        {
            get { return _cancellationToken.IsCancellationRequested; }
        }

        public static void ThrowIfCancellationRequested()
        {
            _cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
