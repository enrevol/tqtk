using System.Threading.Tasks;

namespace k8asd {
    class AttackNpcTaskHelper : ITaskHelper {
        public async Task<TaskResult> Do(IPacketWriter writer, int times) {
            // Nguỵ Tục - Lữ Bố.
            const int NpcId = 2214;

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer, NpcId);
                if (result != TaskResult.Done)
                    return result;
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(IPacketWriter writer, int npcId) {
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
