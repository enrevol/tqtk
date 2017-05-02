namespace k8asd {
    public interface IClientComponent {
        /// <summary>
        /// Gets or sets the underlying client.
        /// </summary>
        IClient Client { get; set; }
    }
}
