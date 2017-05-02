namespace k8asd {
    public interface IModule {
        /// <summary>
        /// Gets or sets the underlying client.
        /// </summary>
        IClient Client { get; set; }
    }
}
