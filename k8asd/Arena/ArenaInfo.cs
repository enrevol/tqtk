﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Parses 64005 message.
    /// </summary>
    class ArenaInfo {
        private List<ArenaPlayer> players;
        private ArenaPlayer currentPlayer;
        private Cooldown cooldown;

        public List<ArenaPlayer> Players { get { return players; } }
        public ArenaPlayer CurrentPlayer { get { return currentPlayer; } }
        public int Cooldown { get { return cooldown.RemainingMilliseconds; } }

        public static ArenaInfo Parse(JToken token) {
            var result = new ArenaInfo();

            result.players = new List<ArenaPlayer>();
            var rankList = (JArray) token["rankList"];
            foreach (var rank in rankList) {
                var player = ArenaPlayer.Parse(rank);
                result.players.Add(player);
            }

            var playerInfo = token["playerInfo"];
            result.currentPlayer = ArenaPlayer.Parse(playerInfo);

            var cd = (int) token["cd"]; // seconds.
            result.cooldown = new Cooldown(cd * 1000);

            return result;
        }
    }
}