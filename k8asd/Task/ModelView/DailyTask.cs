using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class DailyTask : IDailyTask {
        private IClient client;

        public IClient Client {
            get { return client; }
            set {
                client = value;
            }
        }
    }
}
