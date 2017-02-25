using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class Cooldown {
        private DateTime endDateTime;

        public Cooldown() {
            RemainingMilliseconds = 0;
        }

        public Cooldown(int milliseconds) {
            RemainingMilliseconds = milliseconds;
        }

        public bool Usable {
            get { return endDateTime <= DateTime.Now; }
        }

        public int RemainingMilliseconds {
            set {
                endDateTime = DateTime.Now.AddMilliseconds(value);
            }
            get {
                return Math.Max(0, (int) (endDateTime - DateTime.Now).TotalMilliseconds);
            }
        }
    }
}
