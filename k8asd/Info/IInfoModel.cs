using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IInfoModel {
        string PlayerName { get; }
        int PlayerLevel { get; }
        int Gold { get; }
        int Reputation { get; }
        int Honor { get; }
        int Food { get; }
        int MaxFood { get; }
        int Force { get; }
        int MaxForce { get; }
        int Silver { get; }
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
