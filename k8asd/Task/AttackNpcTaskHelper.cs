using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class AttackNpcTaskHelper : ITaskHelper {
        public Task<bool> CanDo(IPacketWriter writer, int times) {
            return Task.FromResult(true);
        }

        public async Task<bool> Do(IPacketWriter writer, int times) {
            // Nguỵ Tục - Lữ Bố.
            const int NpcId = 2214;

            for (int i = 0; i < times; ++i) {
                if (!await DoSingle(writer, NpcId)) {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> DoSingle(IPacketWriter writer, int npcId) {
            var p = await writer.AttackNpcAsync(npcId, PartyType.Normal);
            if (p == null) {
                return false;
            }

            if (p.HasError) {
                return false;
            }

            /// FIXME.
            //xu ly chinh chien that bai (chua lam)
            //if (token["battlereport"]["message"].ToString() == "Ngài đã thất bại .....")
            //{
            //    //phai danh lai cho du so sao (chua lam)
            //}
            return true;
        }
    }
}
