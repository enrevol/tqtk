namespace k8asd {
    public interface ISystemLogView {
        /// <summary>
        /// Gets or sets the underlying system log model.
        /// </summary>
        ISystemLog SystemLog { get; set; }
    }
}
