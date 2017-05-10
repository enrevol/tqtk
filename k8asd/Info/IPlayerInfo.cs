using System;

namespace k8asd {
    public interface IPlayerInfo : IClientComponent {
        event EventHandler PlayerIdChanged;
        event EventHandler PlayerNameChanged;
        event EventHandler PlayerLevelChanged;
        event EventHandler LegionNameChanged;
        event EventHandler GoldChanged;
        event EventHandler ReputationChanged;
        event EventHandler HonorChanged;
        event EventHandler FoodChanged;
        event EventHandler MaxFoodChanged;
        event EventHandler ForceChanged;
        event EventHandler MaxForceChanged;
        event EventHandler SilverChanged;
        event EventHandler MaxSilverChanged;

        int PlayerId { get; }

        /// <summary>
        /// Gets the player's name.
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// Gets the player's level.
        /// </summary>
        int PlayerLevel { get; }

        string LegionName { get; }

        /// <summary>
        /// Gets the server time.
        /// </summary>
        DateTime ServerTime { get; }

        /// <summary>
        /// Gets the player's total gold.
        /// </summary>
        int Gold { get; }

        /// <summary>
        /// Gets the player's reputation points (uy danh).
        /// </summary>
        int Reputation { get; }

        /// <summary>
        /// Gets the player's honor points (chiến tích).
        /// </summary>
        int Honor { get; }

        /// <summary>
        /// Gets the player's current food (lúa).
        /// </summary>
        int Food { get; }

        /// <summary>
        /// Gets the player's food capacity.
        /// </summary>
        int MaxFood { get; }

        /// <summary>
        /// Gets the player's current force (lính).
        /// </summary>
        int Force { get; }

        /// <summary>
        /// Gets the player's force capacity.
        /// </summary>
        int MaxForce { get; }

        /// <summary>
        /// Gets the player's current silver (bạc).
        /// </summary>
        int Silver { get; }

        /// <summary>
        /// Gets the player's silver capacity.
        /// </summary>
        int MaxSilver { get; }
    }
}
