namespace k8asd {
    interface IPacketReader {
        /// <summary>
        /// Notified when there is an available packet to read.
        /// </summary>
        /// <param name="packet"></param>
        void OnPacketReceived(Packet packet);
    }
}
