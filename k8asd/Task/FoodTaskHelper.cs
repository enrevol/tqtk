using System.Threading.Tasks;

namespace k8asd {
    class FoodTaskHelper : ITaskHelper {
        public Task<bool> CanDo(IPacketWriter writer, int times) {
            return Task.FromResult(true);
        }

        public async Task<bool> Do(IPacketWriter writer, int times) {
            var market = await writer.RefreshMarketAsync();
            if (market == null) {
                return false;
            }

            int remainTrades = market.MaxTradeAmount - market.TradeAmount;
            for (int i = 0; i < times; ++i) {
                if (!await DoSingle(writer, remainTrades > 0)) {
                    return false;
                }
                --remainTrades;
            }
            return true;
        }

        /// <summary>
        /// Làm nhiệm vụ mua bán lúa 1 lần.
        /// </summary>
        public async Task<bool> DoSingle(IPacketWriter writer, bool buyBlackMarket) {
            const int amount = 1;

            if (buyBlackMarket) {
                var p1 = await writer.BuyPaddyInMaketAsync(amount);
                if (p1 == null) {
                    return false;
                }
                if (p1.HasError) {
                    // Lúa tràn kho???
                    return false;
                }
                return true;
            }

            var p = await writer.SalePaddyAsync(amount);
            if (p == null) {
                return false;
            }
            if (p.HasError) {
                // Hết số lượng giao dịch.
                // Số bạc tràn kho.

                var p0 = await writer.BuyPaddyAsync(amount);
                if (p0 == null) {
                    return false;
                }
                if (p0.HasError) {
                    // Hết số lượng giao dịch.
                    // Lúa tràn kho.

                    return await DoSingle(writer, true);
                }
                return false;
            }
            return true;
        }
    }
}
