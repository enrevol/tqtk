using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Parses 64005 message.
    /// </summary>
    class ArenaInfo {
        private Cooldown cooldown;

        public List<ArenaPlayer> Players { get; private set; }
        public ArenaPlayer CurrentPlayer { get; private set; }
        public int Cooldown { get { return cooldown.RemainingMilliseconds; } }

        public static ArenaInfo Parse(JToken token) {
            var result = new ArenaInfo();

            result.Players = new List<ArenaPlayer>();
            var rankList = (JArray) token["rankList"];
            foreach (var rank in rankList) {
                var player = ArenaPlayer.Parse(rank);
                result.Players.Add(player);
            }

            var playerInfo = token["playerInfo"];
            result.CurrentPlayer = ArenaPlayer.Parse(playerInfo);

            var cd = (int) token["cd"]; // seconds.
            result.cooldown = new Cooldown(cd * 1000);

            return result;
        }
    }
}
