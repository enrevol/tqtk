using System.Collections.Generic;

namespace k8asd {
    public interface ISystemLogView {
        /// <summary>
        /// Gets or sets the underlying system log model.
        /// </summary>
        List<ISystemLog> Models { get; set; }
    }
}
