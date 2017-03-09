using System;

namespace k8asd {
    public interface IMcuModel {
        /// <summary>
        /// Gets the current number of MCU (Milliray Call-up Units).
        /// </summary>
        int Mcu { get; }

        /// <summary>
        /// Gets the maximum number of MCU.
        /// </summary>
        int MaxMcu { get; }

        /// <summary>
        /// Gets the current MCU cooldown in milliseconds.
        /// </summary>
        int McuCooldown { get; }

        /// <summary>
        /// Free Đ turn.
        /// </summary>
        bool ExtraZhengzhan { get; }

        /// <summary>
        /// Free T turn.
        /// </summary>
        bool ExtraGongji { get; }

        /// <summary>
        /// Free C turn.
        /// </summary>
        bool ExtraZhengfu { get; }

        /// <summary>
        /// Free R turn.
        /// </summary>
        bool ExtraNongtian { get; }

        /// <summary>
        /// Free M turn.
        /// </summary>
        bool ExtraYinkuang { get; }

        /// <summary>
        /// Free T turn.
        /// </summary>
        bool Tokencdusable { get; }

        event EventHandler<int> McuChanged;
        event EventHandler<int> MaxMcuChanged;
        event EventHandler<int> McuCooldownChanged;
        event EventHandler<bool> ExtraZhengzhanChanged;
        event EventHandler<bool> ExtraGongjiChanged;
        event EventHandler<bool> ExtraZhengfuChanged;
        event EventHandler<bool> ExtraNongtianChanged;
        event EventHandler<bool> ExtraYinkuangChanged;
        event EventHandler<bool> TokencdusableChanged;
    }
}
