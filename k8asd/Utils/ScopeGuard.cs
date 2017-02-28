using System;

namespace k8asd {
    /// <summary>
    /// https://www.c-plusplus.net/forum/204844-full
    /// RAII Scope Guard pattern.
    /// </summary>
    class ScopeGuard : IDisposable {
        private Action callback;
        private bool dismissed;
        private bool disposed;

        public ScopeGuard(Action callback) {
            this.callback = callback;
            dismissed = false;
            disposed = false;
        }

        public void Dismiss() {
            disposed = true;
        }

        public void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    if (!dismissed) {
                        callback.Invoke();
                    }
                }
                callback = null;
                disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ScopeGuard() {
            Dispose(false);
        }
    }
}
