using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IMcuModel {
        int Mcu { get; }
        int MaxMcu { get; }
        int McuCooldown { get; }
        bool ExtraZhengzhan { get; }
        bool ExtraGongji { get; }
        bool ExtraZhengfu { get; }
        bool ExtraNongtian { get; }
        bool ExtraYinkuang { get; }

        event EventHandler<int> McuChanged;
        event EventHandler<int> MaxMcuChanged;
        event EventHandler<int> MCUCooldownChanged;
        event EventHandler<bool> ExtraZhengzhanChanged;
        event EventHandler<bool> ExtraGongjiChanged;
        event EventHandler<bool> ExtraZhengfuChanged;
        event EventHandler<bool> ExtraNongtianChanged;
        event EventHandler<bool> ExtraYinkuangChanged;
    }
}
