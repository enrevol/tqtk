using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class CharacterInfoView : UserControl {
        public CharacterInfoView() {
            InitializeComponent();
        }

        public void SetGold(int gold) {
            goldLabel.Text = gold.ToString();
        }

        public void SetReputationPoints(int reputationPoints) {
            reputationLabel.Text = reputationPoints.ToString();
        }

        public void SetHonorPoints(int honorPoints) {
            honorLabel.Text = honorPoints.ToString();
        }

        public void SetFood(int food, int maxFood) {
            foodLabel.Text = String.Format("{0}/{1}", food, maxFood);
        }

        public void SetForces(int forces, int maxForces) {
            forcesLabel.Text = String.Format("{0}/{1}", forces, maxForces);
        }

        public void SetSilver(int silver, int maxSilver) {
            silverLabel.Text = String.Format("{0}/{1}", silver, maxSilver);
        }
    }
}
