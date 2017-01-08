using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface ICooldownModel {
        int ImposeCooldown { get; }
        int GuideCooldown { get; }
        int UpgradeCooldown { get; }
        int AppointCooldown { get; }
        int TechCooldown { get; }
        int WeaveCooldown { get; }

        event EventHandler<int> ImposeCooldownChanged;
        event EventHandler<int> GuideCooldownChanged;
        event EventHandler<int> UpgradeCooldownChanged;
        event EventHandler<int> AppointCooldownChanged;
        event EventHandler<int> TechCooldownChanged;
        event EventHandler<int> WeaveCooldownChanged;
    }
}
