using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IInfoModel {
        /// <summary>
        /// Gets the player's name.
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// Gets the player's level.
        /// </summary>
        int PlayerLevel { get; }

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

        event EventHandler<string> PlayerNameChanged;
        event EventHandler<int> PlayerLevelChanged;
        event EventHandler<int> GoldChanged;
        event EventHandler<int> ReputationChanged;
        event EventHandler<int> HonorChanged;
        event EventHandler<int> FoodChanged;
        event EventHandler<int> MaxFoodChanged;
        event EventHandler<int> ForceChanged;
        event EventHandler<int> MaxForceChanged;
        event EventHandler<int> SilverChanged;
        event EventHandler<int> MaxSilverChanged;
    }
}
