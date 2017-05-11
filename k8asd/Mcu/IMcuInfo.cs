using System;

namespace k8asd {
    public interface IMcuInfo : IClientComponent {
        event EventHandler McuChanged;
        event EventHandler MaxMcuChanged;
        event EventHandler McuCooldownChanged;
        event EventHandler ExtraZhengzhanChanged;
        event EventHandler ExtraGongjiChanged;
        event EventHandler ExtraZhengfuChanged;
        event EventHandler ExtraNongtianChanged;
        event EventHandler ExtraYinkuangChanged;
        event EventHandler TokencdusableChanged;

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
        /// Whether or not the player can use a token.
        /// </summary>
        bool Tokencdusable { get; }
    }
}
