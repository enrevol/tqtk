using System.Collections.Generic;

namespace k8asd {
    public interface IClientView {
        /// <summary>
        /// Gets or sets the underlying client model.
        /// </summary>
        List<IClient> Clients { get; set; }
    }
}
