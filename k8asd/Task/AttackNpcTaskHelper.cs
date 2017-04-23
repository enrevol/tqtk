using System.Threading.Tasks;

namespace k8asd {
    public class AttackNpcTaskHelper : ITaskHelper {
        private IPacketWriter writer;
        private IMcuModel mcu;

        public AttackNpcTaskHelper(IPacketWriter writer, IMcuModel mcu) {
            this.writer = writer;
            this.mcu = mcu;
        }

        public int PredictDifficulty(int times) {
            var turns = mcu.Mcu;
            if (mcu.ExtraZhengzhan) {
                ++turns;
            }
            if (turns < times) {
                return TaskDifficulty.AttackNpcLackTurns(times, times - turns);
            }
            return TaskDifficulty.AttackNpcOk(times);
        }

        public async Task<TaskResult> Do(int times) {
            // Nguỵ Tục - Lữ Bố.
            const int NpcId = 2214;

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(NpcId);
                if (result != TaskResult.Done)
                    return result;
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(int npcId) {
            var p = await writer.AttackNpcAsync(npcId, PartyType.Normal);
            if (p == null) {
                return TaskResult.LostConnection;
            }

            if (p.HasError) {
                // Thiếu lượt, đóng băng.
                return TaskResult.CanBeDone;
            }

            /// FIXME.
            //xu ly chinh chien that bai (chua lam)
            //if (token["battlereport"]["message"].ToString() == "Ngài đã thất bại .....")
            //{
            //    //phai danh lai cho du so sao (chua lam)
            //}
            return TaskResult.Done;
        }
    }
}
