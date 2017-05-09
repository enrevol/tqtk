using System;
using System.Threading.Tasks;

namespace k8asd {
    public class FoodTaskHelper : ITaskHelper {
        private IPacketWriter writer;
        private IInfoModel info;
        private MarketInfo market;

        public FoodTaskHelper(IPacketWriter writer, IInfoModel info, MarketInfo market) {
            this.writer = writer;
            this.info = info;
            this.market = market;
        }

        public int PredictDifficulty(int times) {
            int remainTrades = market.MaxTradeAmount - market.TradeAmount;
            return PredictDifficulty(times, remainTrades, market.Price, info.Food, info.MaxFood, info.Silver, info.MaxSilver);
        }

        private int PredictDifficulty(int times, int trades, double price, int food, int maxFood, int silver, int maxSilver) {
            if (times == 0) {
                // OK.
                return TaskDifficulty.FoodOk();
            }
            if (trades <= 0) {
                // Chợ đen.
                // Chợ đen giá gấp đôi.
                var cost = (int) Math.Floor(price * 2);
                if (food + 1 <= maxFood && silver >= cost) {
                    // Đủ bạc và không tràn kho lúa.
                    return PredictDifficulty(times - 1, trades, price, food + 1, maxFood, silver - cost, maxSilver);
                }
            } else {
                // Giao dịch thường.
                // Bán lúa trước.
                var cost = (int) Math.Floor(price); // Cost = 0?
                if (food > 0 && silver + cost <= maxSilver) {
                    return PredictDifficulty(times - 1, trades - 1, price, food - 1, maxFood, silver + cost, maxSilver);
                }

                // Mua lúa.
                if (food + 1 < maxFood && silver >= cost) {
                    return PredictDifficulty(times - 1, trades - 1, price, food + 1, maxFood, silver - cost, maxSilver);
                }
            }

            // Không thể hoàn thành (bây giờ).
            return TaskDifficulty.FoodNotOk();
        }

        public async Task<TaskResult> Do(int times) {
            int remainTrades = market.MaxTradeAmount - market.TradeAmount;
            for (int i = 0; i < times; ++i) {
                var buyBlackMarket = (remainTrades <= 0);
                var result = await DoSingle(buyBlackMarket);
                if (result != TaskResult.Done) {
                    return result;
                }
                --remainTrades;

                // Tránh kẹt acc.
                await Task.Delay(250);
            }
            return TaskResult.Done;
        }

        /// <summary>
        /// Làm nhiệm vụ mua bán lúa 1 lần.
        /// </summary>
        public async Task<TaskResult> DoSingle(bool buyBlackMarket) {
            const int amount = 1;

            if (buyBlackMarket) {
                var p1 = await writer.BuyPaddyInMaketAsync(amount);
                if (p1 == null) {
                    return TaskResult.LostConnection;
                }
                if (p1.HasError) {
                    // Lúa tràn kho???
                    return TaskResult.CanBeDone;
                }
                return TaskResult.Done;
            }

            var p = await writer.SalePaddyAsync(amount);
            if (p == null) {
                return TaskResult.LostConnection;
            }
            if (p.HasError) {
                // Hết số lượng giao dịch.
                // Số bạc tràn kho.

                var p0 = await writer.BuyPaddyAsync(amount);
                if (p0 == null) {
                    return TaskResult.LostConnection;
                }
                if (p0.HasError) {
                    // Hết số lượng giao dịch.
                    // Lúa tràn kho.

                    return await DoSingle(true);
                }
                return TaskResult.CanBeDone;
            }
            return TaskResult.Done;
        }
    }
}
