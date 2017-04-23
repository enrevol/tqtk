using System.Threading.Tasks;

namespace k8asd {
    class FoodTaskHelper : ITaskHelper {
        public async Task<TaskResult> Do(IPacketWriter writer, int times) {
            var market = await writer.RefreshMarketAsync();
            if (market == null) {
                return TaskResult.LostConnection;
            }

            int remainTrades = market.MaxTradeAmount - market.TradeAmount;
            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer, remainTrades > 0);
                if (result != TaskResult.Done) {
                    return result;
                }
                --remainTrades;
            }
            return TaskResult.Done;
        }

        /// <summary>
        /// Làm nhiệm vụ mua bán lúa 1 lần.
        /// </summary>
        public async Task<TaskResult> DoSingle(IPacketWriter writer, bool buyBlackMarket) {
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

                    return await DoSingle(writer, true);
                }
                return TaskResult.CanBeDone;
            }
            return TaskResult.Done;
        }
    }
}
