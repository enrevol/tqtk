using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IDailyTask : IClientComponent {
        /// <summary>
        /// Enables or disables auto doing daily tasks.
        /// </summary>
        bool Enabled { get; set; }


    }
}
