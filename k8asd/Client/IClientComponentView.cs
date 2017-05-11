using System.Collections.Generic;

namespace k8asd {
    public interface IClientComponentView<T> where T : IClientComponent {
        /// <summary>
        /// Gets or sets the models for this view.
        /// </summary>
        List<T> Models { get; set; }

        /// <summary>
        /// Binds the current models to this view.
        /// </summary>
        void BindModels();

        /// <summary>
        /// Unbinds the current models from this view.
        /// </summary>
        void UnbindModels();
    }
}
