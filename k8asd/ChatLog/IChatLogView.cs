using System.Collections.Generic;

namespace k8asd {
    public interface IChatLogView {
        /// <summary>
        /// Gets or sets the chat log model of this view.
        /// </summary>
        List<IChatLog> Models { get; set; }
    }
}
