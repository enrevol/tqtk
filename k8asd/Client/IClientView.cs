namespace k8asd {
    public interface IClientView {
        /// <summary>
        /// Gets or sets the underlying client model.
        /// </summary>
        IClient Client { get; set; }
    }
}
