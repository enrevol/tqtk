using System.Windows.Forms;

namespace k8asd {
    partial class ClientView : UserControl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.pnlAcc = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.testButton = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.navPower = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pagArmy = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grpArmyParty = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.radArmy2 = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radArmy1 = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.lstArmyMember = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.btnArmyInvite = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyQuit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyDisband = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyAttack = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyCreate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyTeam = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.grpArmyList = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.chkArmyCd = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.numArmyRefresh = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.numArmyAttack = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.btnArmyAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkArmyAttack = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkArmyAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lstArmyList = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.btnArmyDown = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyDel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnArmyUp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkArmyRefresh = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lblArmyMode = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbbArmyMode = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.chkArmy = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.grpArmyInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnArmyInfo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtArmyInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtArmyInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtArmyInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblArmyInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblArmyInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblArmyInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbbArmy2 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbbArmy1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.pagCampaign = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.chkCamp = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.grpCampInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtCampInfo5 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCampInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCampInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCampInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCampInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblCampInfo5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCampInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCampInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCampInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCampInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpCampParty = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.radCamp1 = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radCamp2 = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.lstCampMember = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.btnCampInvite = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampQuit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampDisband = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampAttack = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampCreate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampTeam = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.btnCampQuitIn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCampInfo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbbCamp = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblCampCd = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.pnlCampMap = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.navMsg = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pagMsg = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pagRank = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pnlNav = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnMsg = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnOthers = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnShop = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnPower = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnWorkshop = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.navShop = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pagBag = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.lblBag = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpBag = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lblBagBindCd = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBagDegrade = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBagSell = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBagInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBagInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnBagDegrade = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblBagInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnBagSell = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtBagBindCd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBagDegrade = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnBagBind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtBagSell = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblBagInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtBagInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBagInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBagInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBagInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbbBag = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.pagUpg = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grpUpg = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lblUpgBindCd = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUpgDe = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUpgUp = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUpgInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUpgInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnUpgDe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblUpgInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnUpgUp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtUpgBindCd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUpgDe = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnUpgradeBind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtUpgUp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblUpgInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUpgInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUpgInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUpgInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUpgInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbbUpg2 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbbUpg1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.pagApp = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.navOthers = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pagForces = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.chkForcesFree = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkForces = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnForcesRecruit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnForcesFree = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblForcesRecruit = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numForces = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.numForcesRecruit = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.lblUpdate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.navWorkshop = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pagWeave = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.numWeaveProduct = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.grpWeaveCreate = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.grpWeaveWorker = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnWeaveShift = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblWeaveSkill2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveSkill1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveExp = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbbWeaveWorker = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtWeaveExp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.grpWeaveProduct = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lblWeaveInfo9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveInfo8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtWeaveInfo9 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbbWeaveProduct = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtWeaveInfo8 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnWeaveCreate2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnWeaveCreate1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grpWeaveParty = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.btnWeaveQuit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnWeaveInvite = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnWeaveDisband = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnWeaveMake = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lstWeaveMember = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.grpWeaveInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.txtWeaveInfo7 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtWeaveInfo6 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblWeaveInfo7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveInfo6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtWeaveInfo5 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblWeaveInfo5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnWeaveCreate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnWeaveTeam = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.grpWeaveInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.txtWeaveInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtWeaveInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtWeaveInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtWeaveInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblWeaveInfo4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveInfo3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveInfo2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblWeaveInfo1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkWeave = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lblWeaveProduct = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbbWeaveMode = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblWeaveMode = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numWeaveLimit = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.chkWeaveMake = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.pagMerchant = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.numUpdate = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.btnChatExpand = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grpLog = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnLog = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUsername = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblServer = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtChat = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbbChat = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.navChat = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.btnAuto = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.txtLogs = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.tmrData = new System.Windows.Forms.Timer(this.components);
            this.tmrCd = new System.Windows.Forms.Timer(this.components);
            this.tmrReq = new System.Windows.Forms.Timer(this.components);
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.chksetNav = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.btnImposeAnswer1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImposeAnswer2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblImposeQuest = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lblVassalLv = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalArea = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalOffice = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalCopper = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalLegion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalUpdate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barFoodBuy = new System.Windows.Forms.TrackBar();
            this.btnFoodBuy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblFoodBuy = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barFoodSell = new System.Windows.Forms.TrackBar();
            this.btnFoodSell = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblFoodSell = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize) (this.pnlAcc)).BeginInit();
            this.pnlAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.navPower)).BeginInit();
            this.navPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pagArmy)).BeginInit();
            this.pagArmy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyParty.Panel)).BeginInit();
            this.grpArmyParty.Panel.SuspendLayout();
            this.grpArmyParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyList.Panel)).BeginInit();
            this.grpArmyList.Panel.SuspendLayout();
            this.grpArmyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmyMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyInfo.Panel)).BeginInit();
            this.grpArmyInfo.Panel.SuspendLayout();
            this.grpArmyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagCampaign)).BeginInit();
            this.pagCampaign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampInfo.Panel)).BeginInit();
            this.grpCampInfo.Panel.SuspendLayout();
            this.grpCampInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampParty.Panel)).BeginInit();
            this.grpCampParty.Panel.SuspendLayout();
            this.grpCampParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbCamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pnlCampMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.navMsg)).BeginInit();
            this.navMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pagMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pnlNav)).BeginInit();
            this.pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.navShop)).BeginInit();
            this.navShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pagBag)).BeginInit();
            this.pagBag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpBag.Panel)).BeginInit();
            this.grpBag.Panel.SuspendLayout();
            this.grpBag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagUpg)).BeginInit();
            this.pagUpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpUpg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpUpg.Panel)).BeginInit();
            this.grpUpg.Panel.SuspendLayout();
            this.grpUpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbUpg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.cbbUpg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.navOthers)).BeginInit();
            this.navOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pagForces)).BeginInit();
            this.pagForces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.navWorkshop)).BeginInit();
            this.navWorkshop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pagWeave)).BeginInit();
            this.pagWeave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveCreate.Panel)).BeginInit();
            this.grpWeaveCreate.Panel.SuspendLayout();
            this.grpWeaveCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveWorker.Panel)).BeginInit();
            this.grpWeaveWorker.Panel.SuspendLayout();
            this.grpWeaveWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveProduct.Panel)).BeginInit();
            this.grpWeaveProduct.Panel.SuspendLayout();
            this.grpWeaveProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveParty.Panel)).BeginInit();
            this.grpWeaveParty.Panel.SuspendLayout();
            this.grpWeaveParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo2.Panel)).BeginInit();
            this.grpWeaveInfo2.Panel.SuspendLayout();
            this.grpWeaveInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo.Panel)).BeginInit();
            this.grpWeaveInfo.Panel.SuspendLayout();
            this.grpWeaveInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagMerchant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpLog.Panel)).BeginInit();
            this.grpLog.Panel.SuspendLayout();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.cbbChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.navChat)).BeginInit();
            this.navChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.chksetNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.barFoodBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.barFoodSell)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAcc
            // 
            this.pnlAcc.Controls.Add(this.testButton);
            this.pnlAcc.Controls.Add(this.navPower);
            this.pnlAcc.Controls.Add(this.navMsg);
            this.pnlAcc.Controls.Add(this.pnlNav);
            this.pnlAcc.Controls.Add(this.navShop);
            this.pnlAcc.Controls.Add(this.navOthers);
            this.pnlAcc.Controls.Add(this.lblUpdate);
            this.pnlAcc.Controls.Add(this.navWorkshop);
            this.pnlAcc.Controls.Add(this.btnSave);
            this.pnlAcc.Controls.Add(this.numUpdate);
            this.pnlAcc.Controls.Add(this.btnChatExpand);
            this.pnlAcc.Controls.Add(this.grpLog);
            this.pnlAcc.Controls.Add(this.txtChat);
            this.pnlAcc.Controls.Add(this.cbbChat);
            this.pnlAcc.Controls.Add(this.navChat);
            this.pnlAcc.Controls.Add(this.btnAuto);
            this.pnlAcc.Controls.Add(this.txtLogs);
            this.pnlAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcc.Location = new System.Drawing.Point(0, 0);
            this.pnlAcc.Name = "pnlAcc";
            this.pnlAcc.Size = new System.Drawing.Size(2000, 805);
            this.pnlAcc.TabIndex = 0;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(909, 4);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(127, 25);
            this.testButton.TabIndex = 27;
            this.testButton.Values.Text = "TEST";
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // navPower
            // 
            this.navPower.AllowPageReorder = false;
            this.navPower.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.navPower.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navPower.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navPower.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navPower.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navPower.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navPower.Location = new System.Drawing.Point(1889, 19);
            this.navPower.Name = "navPower";
            this.navPower.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pagArmy,
            this.pagCampaign});
            this.navPower.SelectedIndex = 0;
            this.navPower.Size = new System.Drawing.Size(423, 412);
            this.navPower.TabIndex = 11;
            this.navPower.Text = "kryptonNavigator1";
            this.navPower.SelectedPageChanged += new System.EventHandler(this.navPower_SelectedPageChanged);
            // 
            // pagArmy
            // 
            this.pagArmy.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagArmy.Controls.Add(this.grpArmyParty);
            this.pagArmy.Controls.Add(this.grpArmyList);
            this.pagArmy.Controls.Add(this.lblArmyMode);
            this.pagArmy.Controls.Add(this.cbbArmyMode);
            this.pagArmy.Controls.Add(this.chkArmy);
            this.pagArmy.Controls.Add(this.grpArmyInfo);
            this.pagArmy.Controls.Add(this.cbbArmy2);
            this.pagArmy.Controls.Add(this.cbbArmy1);
            this.pagArmy.Flags = 65534;
            this.pagArmy.LastVisibleSet = true;
            this.pagArmy.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagArmy.Name = "pagArmy";
            this.pagArmy.Size = new System.Drawing.Size(421, 385);
            this.pagArmy.Text = "Quân đoàn";
            this.pagArmy.ToolTipTitle = "Page ToolTip";
            this.pagArmy.UniqueName = "3189FEA2443C4DC382B8619F80F03D5B";
            // 
            // grpArmyParty
            // 
            this.grpArmyParty.AutoSize = true;
            this.grpArmyParty.Location = new System.Drawing.Point(35, 142);
            this.grpArmyParty.Name = "grpArmyParty";
            // 
            // grpArmyParty.Panel
            // 
            this.grpArmyParty.Panel.Controls.Add(this.radArmy2);
            this.grpArmyParty.Panel.Controls.Add(this.radArmy1);
            this.grpArmyParty.Panel.Controls.Add(this.lstArmyMember);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyInvite);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyQuit);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyDisband);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyAttack);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyCreate);
            this.grpArmyParty.Panel.Controls.Add(this.btnArmyTeam);
            this.grpArmyParty.Size = new System.Drawing.Size(273, 172);
            this.grpArmyParty.TabIndex = 27;
            this.grpArmyParty.Visible = false;
            // 
            // radArmy2
            // 
            this.radArmy2.Checked = true;
            this.radArmy2.Location = new System.Drawing.Point(3, 39);
            this.radArmy2.Name = "radArmy2";
            this.radArmy2.Size = new System.Drawing.Size(72, 20);
            this.radArmy2.TabIndex = 7;
            this.radArmy2.Values.Text = "Quốc gia";
            this.radArmy2.CheckedChanged += new System.EventHandler(this.radArmy2_CheckedChanged);
            // 
            // radArmy1
            // 
            this.radArmy1.Location = new System.Drawing.Point(81, 39);
            this.radArmy1.Name = "radArmy1";
            this.radArmy1.Size = new System.Drawing.Size(50, 20);
            this.radArmy1.TabIndex = 6;
            this.radArmy1.Values.Text = "Bang";
            this.radArmy1.CheckedChanged += new System.EventHandler(this.radArmy1_CheckedChanged);
            // 
            // lstArmyMember
            // 
            this.lstArmyMember.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.lstArmyMember.Location = new System.Drawing.Point(137, 3);
            this.lstArmyMember.Name = "lstArmyMember";
            this.lstArmyMember.Size = new System.Drawing.Size(131, 164);
            this.lstArmyMember.TabIndex = 5;
            this.lstArmyMember.SelectedValueChanged += new System.EventHandler(this.lstArmyMember_SelectedValueChanged);
            // 
            // btnArmyInvite
            // 
            this.btnArmyInvite.Location = new System.Drawing.Point(3, 137);
            this.btnArmyInvite.Name = "btnArmyInvite";
            this.btnArmyInvite.Size = new System.Drawing.Size(61, 30);
            this.btnArmyInvite.TabIndex = 4;
            this.btnArmyInvite.Values.Text = "Mời";
            this.btnArmyInvite.Click += new System.EventHandler(this.btnArmyInvite_Click);
            // 
            // btnArmyQuit
            // 
            this.btnArmyQuit.Location = new System.Drawing.Point(70, 137);
            this.btnArmyQuit.Name = "btnArmyQuit";
            this.btnArmyQuit.Size = new System.Drawing.Size(61, 30);
            this.btnArmyQuit.TabIndex = 4;
            this.btnArmyQuit.Values.Text = "Thoái";
            this.btnArmyQuit.Click += new System.EventHandler(this.btnArmyQuit_Click);
            // 
            // btnArmyDisband
            // 
            this.btnArmyDisband.Location = new System.Drawing.Point(70, 101);
            this.btnArmyDisband.Name = "btnArmyDisband";
            this.btnArmyDisband.Size = new System.Drawing.Size(61, 30);
            this.btnArmyDisband.TabIndex = 4;
            this.btnArmyDisband.Values.Text = "Giải tán";
            this.btnArmyDisband.Click += new System.EventHandler(this.btnArmyDisband_Click);
            // 
            // btnArmyAttack
            // 
            this.btnArmyAttack.Location = new System.Drawing.Point(3, 101);
            this.btnArmyAttack.Name = "btnArmyAttack";
            this.btnArmyAttack.Size = new System.Drawing.Size(61, 30);
            this.btnArmyAttack.TabIndex = 4;
            this.btnArmyAttack.Values.Text = "Tấn công";
            this.btnArmyAttack.Click += new System.EventHandler(this.btnArmyAttack_Click);
            // 
            // btnArmyCreate
            // 
            this.btnArmyCreate.Location = new System.Drawing.Point(3, 65);
            this.btnArmyCreate.Name = "btnArmyCreate";
            this.btnArmyCreate.Size = new System.Drawing.Size(128, 30);
            this.btnArmyCreate.TabIndex = 3;
            this.btnArmyCreate.Values.Text = "Lập tổ đội";
            this.btnArmyCreate.Click += new System.EventHandler(this.btnArmyCreate_Click);
            // 
            // btnArmyTeam
            // 
            this.btnArmyTeam.Location = new System.Drawing.Point(3, 3);
            this.btnArmyTeam.Name = "btnArmyTeam";
            this.btnArmyTeam.Size = new System.Drawing.Size(128, 30);
            this.btnArmyTeam.TabIndex = 0;
            this.btnArmyTeam.Values.Text = "5 tổ đội";
            // 
            // grpArmyList
            // 
            this.grpArmyList.AutoSize = true;
            this.grpArmyList.Location = new System.Drawing.Point(3, 145);
            this.grpArmyList.Name = "grpArmyList";
            // 
            // grpArmyList.Panel
            // 
            this.grpArmyList.Panel.Controls.Add(this.chkArmyCd);
            this.grpArmyList.Panel.Controls.Add(this.numArmyRefresh);
            this.grpArmyList.Panel.Controls.Add(this.numArmyAttack);
            this.grpArmyList.Panel.Controls.Add(this.btnArmyAdd);
            this.grpArmyList.Panel.Controls.Add(this.chkArmyAttack);
            this.grpArmyList.Panel.Controls.Add(this.chkArmyAll);
            this.grpArmyList.Panel.Controls.Add(this.lstArmyList);
            this.grpArmyList.Panel.Controls.Add(this.btnArmyDown);
            this.grpArmyList.Panel.Controls.Add(this.btnArmyDel);
            this.grpArmyList.Panel.Controls.Add(this.btnArmyUp);
            this.grpArmyList.Panel.Controls.Add(this.chkArmyRefresh);
            this.grpArmyList.Size = new System.Drawing.Size(306, 237);
            this.grpArmyList.TabIndex = 31;
            this.grpArmyList.Values.Heading = "";
            // 
            // chkArmyCd
            // 
            this.chkArmyCd.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkArmyCd.Location = new System.Drawing.Point(3, 3);
            this.chkArmyCd.Name = "chkArmyCd";
            this.chkArmyCd.Size = new System.Drawing.Size(247, 20);
            this.chkArmyCd.TabIndex = 24;
            this.chkArmyCd.Text = "Chờ hết đóng băng sau 1 lần chinh chiến";
            this.chkArmyCd.Values.Text = "Chờ hết đóng băng sau 1 lần chinh chiến";
            // 
            // numArmyRefresh
            // 
            this.numArmyRefresh.Location = new System.Drawing.Point(213, 28);
            this.numArmyRefresh.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numArmyRefresh.Name = "numArmyRefresh";
            this.numArmyRefresh.Size = new System.Drawing.Size(40, 22);
            this.numArmyRefresh.TabIndex = 18;
            this.numArmyRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numArmyRefresh.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numArmyAttack
            // 
            this.numArmyAttack.Location = new System.Drawing.Point(174, 54);
            this.numArmyAttack.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numArmyAttack.Name = "numArmyAttack";
            this.numArmyAttack.Size = new System.Drawing.Size(36, 22);
            this.numArmyAttack.TabIndex = 18;
            this.numArmyAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numArmyAttack.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // btnArmyAdd
            // 
            this.btnArmyAdd.Location = new System.Drawing.Point(233, 139);
            this.btnArmyAdd.Name = "btnArmyAdd";
            this.btnArmyAdd.Size = new System.Drawing.Size(61, 25);
            this.btnArmyAdd.TabIndex = 21;
            this.btnArmyAdd.Values.Text = "Thêm";
            this.btnArmyAdd.Click += new System.EventHandler(this.btnArmyAdd_Click);
            // 
            // chkArmyAttack
            // 
            this.chkArmyAttack.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkArmyAttack.Location = new System.Drawing.Point(3, 55);
            this.chkArmyAttack.Name = "chkArmyAttack";
            this.chkArmyAttack.Size = new System.Drawing.Size(260, 20);
            this.chkArmyAttack.TabIndex = 18;
            this.chkArmyAttack.Text = "Tự động tấn công khi có >=               người";
            this.chkArmyAttack.Values.Text = "Tự động tấn công khi có >=               người";
            // 
            // chkArmyAll
            // 
            this.chkArmyAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkArmyAll.Location = new System.Drawing.Point(233, 81);
            this.chkArmyAll.Name = "chkArmyAll";
            this.chkArmyAll.Size = new System.Drawing.Size(56, 20);
            this.chkArmyAll.TabIndex = 22;
            this.chkArmyAll.Text = "Tất cả";
            this.chkArmyAll.Values.Text = "Tất cả";
            // 
            // lstArmyList
            // 
            this.lstArmyList.Location = new System.Drawing.Point(3, 81);
            this.lstArmyList.Name = "lstArmyList";
            this.lstArmyList.Size = new System.Drawing.Size(224, 144);
            this.lstArmyList.TabIndex = 20;
            // 
            // btnArmyDown
            // 
            this.btnArmyDown.Location = new System.Drawing.Point(233, 201);
            this.btnArmyDown.Name = "btnArmyDown";
            this.btnArmyDown.Size = new System.Drawing.Size(61, 25);
            this.btnArmyDown.TabIndex = 21;
            this.btnArmyDown.Values.Text = "▼";
            this.btnArmyDown.Click += new System.EventHandler(this.btnArmyDown_Click);
            // 
            // btnArmyDel
            // 
            this.btnArmyDel.Location = new System.Drawing.Point(233, 108);
            this.btnArmyDel.Name = "btnArmyDel";
            this.btnArmyDel.Size = new System.Drawing.Size(61, 25);
            this.btnArmyDel.TabIndex = 21;
            this.btnArmyDel.Values.Text = "Xoá";
            this.btnArmyDel.Click += new System.EventHandler(this.btnArmyDel_Click);
            // 
            // btnArmyUp
            // 
            this.btnArmyUp.Location = new System.Drawing.Point(233, 170);
            this.btnArmyUp.Name = "btnArmyUp";
            this.btnArmyUp.Size = new System.Drawing.Size(61, 25);
            this.btnArmyUp.TabIndex = 21;
            this.btnArmyUp.Values.Text = "▲";
            this.btnArmyUp.Click += new System.EventHandler(this.btnArmyUp_Click);
            // 
            // chkArmyRefresh
            // 
            this.chkArmyRefresh.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkArmyRefresh.Location = new System.Drawing.Point(3, 29);
            this.chkArmyRefresh.Name = "chkArmyRefresh";
            this.chkArmyRefresh.Size = new System.Drawing.Size(296, 20);
            this.chkArmyRefresh.TabIndex = 25;
            this.chkArmyRefresh.Text = "Tự động trong giờ tinh anh đến <=                phút";
            this.chkArmyRefresh.Values.Text = "Tự động trong giờ tinh anh đến <=                phút";
            // 
            // lblArmyMode
            // 
            this.lblArmyMode.Location = new System.Drawing.Point(178, 3);
            this.lblArmyMode.Name = "lblArmyMode";
            this.lblArmyMode.Size = new System.Drawing.Size(50, 20);
            this.lblArmyMode.TabIndex = 30;
            this.lblArmyMode.Values.Text = "Chế độ";
            // 
            // cbbArmyMode
            // 
            this.cbbArmyMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbArmyMode.DropDownWidth = 140;
            this.cbbArmyMode.Location = new System.Drawing.Point(234, 3);
            this.cbbArmyMode.Name = "cbbArmyMode";
            this.cbbArmyMode.Size = new System.Drawing.Size(125, 21);
            this.cbbArmyMode.TabIndex = 29;
            // 
            // chkArmy
            // 
            this.chkArmy.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkArmy.Location = new System.Drawing.Point(3, 3);
            this.chkArmy.Name = "chkArmy";
            this.chkArmy.Size = new System.Drawing.Size(102, 20);
            this.chkArmy.TabIndex = 28;
            this.chkArmy.Text = "Tự động chiến";
            this.chkArmy.Values.Text = "Tự động chiến";
            this.chkArmy.CheckedChanged += new System.EventHandler(this.chkArmy_CheckedChanged);
            // 
            // grpArmyInfo
            // 
            this.grpArmyInfo.AutoSize = true;
            this.grpArmyInfo.Location = new System.Drawing.Point(3, 57);
            this.grpArmyInfo.Name = "grpArmyInfo";
            // 
            // grpArmyInfo.Panel
            // 
            this.grpArmyInfo.Panel.Controls.Add(this.btnArmyInfo);
            this.grpArmyInfo.Panel.Controls.Add(this.txtArmyInfo1);
            this.grpArmyInfo.Panel.Controls.Add(this.txtArmyInfo3);
            this.grpArmyInfo.Panel.Controls.Add(this.txtArmyInfo2);
            this.grpArmyInfo.Panel.Controls.Add(this.lblArmyInfo3);
            this.grpArmyInfo.Panel.Controls.Add(this.lblArmyInfo2);
            this.grpArmyInfo.Panel.Controls.Add(this.lblArmyInfo1);
            this.grpArmyInfo.Size = new System.Drawing.Size(349, 85);
            this.grpArmyInfo.TabIndex = 26;
            this.grpArmyInfo.Text = "Caption";
            // 
            // btnArmyInfo
            // 
            this.btnArmyInfo.Location = new System.Drawing.Point(262, 3);
            this.btnArmyInfo.Name = "btnArmyInfo";
            this.btnArmyInfo.Size = new System.Drawing.Size(80, 24);
            this.btnArmyInfo.TabIndex = 2;
            this.btnArmyInfo.Values.Text = "Tấn công";
            this.btnArmyInfo.Click += new System.EventHandler(this.btnArmyInfo_Click);
            // 
            // txtArmyInfo1
            // 
            this.txtArmyInfo1.Location = new System.Drawing.Point(65, 5);
            this.txtArmyInfo1.Name = "txtArmyInfo1";
            this.txtArmyInfo1.ReadOnly = true;
            this.txtArmyInfo1.Size = new System.Drawing.Size(57, 23);
            this.txtArmyInfo1.TabIndex = 1;
            this.txtArmyInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtArmyInfo3
            // 
            this.txtArmyInfo3.Location = new System.Drawing.Point(62, 33);
            this.txtArmyInfo3.Name = "txtArmyInfo3";
            this.txtArmyInfo3.ReadOnly = true;
            this.txtArmyInfo3.Size = new System.Drawing.Size(280, 23);
            this.txtArmyInfo3.TabIndex = 1;
            // 
            // txtArmyInfo2
            // 
            this.txtArmyInfo2.Location = new System.Drawing.Point(199, 5);
            this.txtArmyInfo2.Name = "txtArmyInfo2";
            this.txtArmyInfo2.ReadOnly = true;
            this.txtArmyInfo2.Size = new System.Drawing.Size(57, 23);
            this.txtArmyInfo2.TabIndex = 1;
            this.txtArmyInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblArmyInfo3
            // 
            this.lblArmyInfo3.Location = new System.Drawing.Point(3, 33);
            this.lblArmyInfo3.Name = "lblArmyInfo3";
            this.lblArmyInfo3.Size = new System.Drawing.Size(53, 20);
            this.lblArmyInfo3.TabIndex = 0;
            this.lblArmyInfo3.Values.Text = "Thưởng";
            // 
            // lblArmyInfo2
            // 
            this.lblArmyInfo2.Location = new System.Drawing.Point(128, 5);
            this.lblArmyInfo2.Name = "lblArmyInfo2";
            this.lblArmyInfo2.Size = new System.Drawing.Size(65, 20);
            this.lblArmyInfo2.TabIndex = 0;
            this.lblArmyInfo2.Values.Text = "Chiến tích";
            // 
            // lblArmyInfo1
            // 
            this.lblArmyInfo1.Location = new System.Drawing.Point(3, 5);
            this.lblArmyInfo1.Name = "lblArmyInfo1";
            this.lblArmyInfo1.Size = new System.Drawing.Size(56, 20);
            this.lblArmyInfo1.TabIndex = 0;
            this.lblArmyInfo1.Values.Text = "Giới hạn";
            // 
            // cbbArmy2
            // 
            this.cbbArmy2.DropDownHeight = 400;
            this.cbbArmy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbArmy2.DropDownWidth = 150;
            this.cbbArmy2.Location = new System.Drawing.Point(129, 30);
            this.cbbArmy2.Name = "cbbArmy2";
            this.cbbArmy2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cbbArmy2.Size = new System.Drawing.Size(230, 21);
            this.cbbArmy2.TabIndex = 25;
            this.cbbArmy2.SelectedIndexChanged += new System.EventHandler(this.cbbArmy2_SelectedIndexChanged);
            // 
            // cbbArmy1
            // 
            this.cbbArmy1.DropDownHeight = 400;
            this.cbbArmy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbArmy1.DropDownWidth = 150;
            this.cbbArmy1.Location = new System.Drawing.Point(3, 30);
            this.cbbArmy1.Name = "cbbArmy1";
            this.cbbArmy1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cbbArmy1.Size = new System.Drawing.Size(120, 21);
            this.cbbArmy1.TabIndex = 24;
            this.cbbArmy1.SelectedIndexChanged += new System.EventHandler(this.cbbArmy1_SelectedIndexChanged);
            // 
            // pagCampaign
            // 
            this.pagCampaign.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagCampaign.Controls.Add(this.chkCamp);
            this.pagCampaign.Controls.Add(this.grpCampInfo);
            this.pagCampaign.Controls.Add(this.grpCampParty);
            this.pagCampaign.Controls.Add(this.btnCampQuitIn);
            this.pagCampaign.Controls.Add(this.btnCampInfo);
            this.pagCampaign.Controls.Add(this.cbbCamp);
            this.pagCampaign.Controls.Add(this.lblCampCd);
            this.pagCampaign.Controls.Add(this.pnlCampMap);
            this.pagCampaign.Flags = 65534;
            this.pagCampaign.LastVisibleSet = true;
            this.pagCampaign.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagCampaign.Name = "pagCampaign";
            this.pagCampaign.Size = new System.Drawing.Size(421, 385);
            this.pagCampaign.Text = "Chiến dịch";
            this.pagCampaign.ToolTipTitle = "Page ToolTip";
            this.pagCampaign.UniqueName = "C35DB147A37145F1EEAD93F6D384309E";
            // 
            // chkCamp
            // 
            this.chkCamp.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkCamp.Location = new System.Drawing.Point(293, 221);
            this.chkCamp.Name = "chkCamp";
            this.chkCamp.Size = new System.Drawing.Size(128, 20);
            this.chkCamp.TabIndex = 28;
            this.chkCamp.Text = "Tự động chiến dịch";
            this.chkCamp.Values.Text = "Tự động chiến dịch";
            // 
            // grpCampInfo
            // 
            this.grpCampInfo.AutoSize = true;
            this.grpCampInfo.Location = new System.Drawing.Point(282, 34);
            this.grpCampInfo.Name = "grpCampInfo";
            // 
            // grpCampInfo.Panel
            // 
            this.grpCampInfo.Panel.Controls.Add(this.txtCampInfo5);
            this.grpCampInfo.Panel.Controls.Add(this.txtCampInfo4);
            this.grpCampInfo.Panel.Controls.Add(this.txtCampInfo3);
            this.grpCampInfo.Panel.Controls.Add(this.txtCampInfo2);
            this.grpCampInfo.Panel.Controls.Add(this.txtCampInfo1);
            this.grpCampInfo.Panel.Controls.Add(this.lblCampInfo5);
            this.grpCampInfo.Panel.Controls.Add(this.lblCampInfo4);
            this.grpCampInfo.Panel.Controls.Add(this.lblCampInfo3);
            this.grpCampInfo.Panel.Controls.Add(this.lblCampInfo2);
            this.grpCampInfo.Panel.Controls.Add(this.lblCampInfo1);
            this.grpCampInfo.Size = new System.Drawing.Size(136, 181);
            this.grpCampInfo.TabIndex = 27;
            this.grpCampInfo.Text = "Caption";
            this.grpCampInfo.Visible = false;
            // 
            // txtCampInfo5
            // 
            this.txtCampInfo5.Location = new System.Drawing.Point(79, 129);
            this.txtCampInfo5.Name = "txtCampInfo5";
            this.txtCampInfo5.ReadOnly = true;
            this.txtCampInfo5.Size = new System.Drawing.Size(50, 23);
            this.txtCampInfo5.TabIndex = 1;
            this.txtCampInfo5.Text = "kryptonTextBox1";
            this.txtCampInfo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCampInfo4
            // 
            this.txtCampInfo4.Location = new System.Drawing.Point(3, 103);
            this.txtCampInfo4.Name = "txtCampInfo4";
            this.txtCampInfo4.ReadOnly = true;
            this.txtCampInfo4.Size = new System.Drawing.Size(126, 23);
            this.txtCampInfo4.TabIndex = 1;
            this.txtCampInfo4.Text = "kryptonTextBox1";
            this.txtCampInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCampInfo3
            // 
            this.txtCampInfo3.Location = new System.Drawing.Point(79, 55);
            this.txtCampInfo3.Name = "txtCampInfo3";
            this.txtCampInfo3.ReadOnly = true;
            this.txtCampInfo3.Size = new System.Drawing.Size(50, 23);
            this.txtCampInfo3.TabIndex = 1;
            this.txtCampInfo3.Text = "kryptonTextBox1";
            this.txtCampInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCampInfo2
            // 
            this.txtCampInfo2.Location = new System.Drawing.Point(79, 29);
            this.txtCampInfo2.Name = "txtCampInfo2";
            this.txtCampInfo2.ReadOnly = true;
            this.txtCampInfo2.Size = new System.Drawing.Size(50, 23);
            this.txtCampInfo2.TabIndex = 1;
            this.txtCampInfo2.Text = "kryptonTextBox1";
            this.txtCampInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCampInfo1
            // 
            this.txtCampInfo1.Location = new System.Drawing.Point(79, 3);
            this.txtCampInfo1.Name = "txtCampInfo1";
            this.txtCampInfo1.ReadOnly = true;
            this.txtCampInfo1.Size = new System.Drawing.Size(50, 23);
            this.txtCampInfo1.TabIndex = 1;
            this.txtCampInfo1.Text = "kryptonTextBox1";
            this.txtCampInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCampInfo5
            // 
            this.lblCampInfo5.Location = new System.Drawing.Point(3, 129);
            this.lblCampInfo5.Name = "lblCampInfo5";
            this.lblCampInfo5.Size = new System.Drawing.Size(72, 20);
            this.lblCampInfo5.TabIndex = 0;
            this.lblCampInfo5.Values.Text = "Đóng băng";
            // 
            // lblCampInfo4
            // 
            this.lblCampInfo4.Location = new System.Drawing.Point(3, 81);
            this.lblCampInfo4.Name = "lblCampInfo4";
            this.lblCampInfo4.Size = new System.Drawing.Size(51, 20);
            this.lblCampInfo4.TabIndex = 0;
            this.lblCampInfo4.Values.Text = "Tiến độ";
            // 
            // lblCampInfo3
            // 
            this.lblCampInfo3.Location = new System.Drawing.Point(3, 55);
            this.lblCampInfo3.Name = "lblCampInfo3";
            this.lblCampInfo3.Size = new System.Drawing.Size(48, 20);
            this.lblCampInfo3.TabIndex = 0;
            this.lblCampInfo3.Values.Text = "Còn lại";
            // 
            // lblCampInfo2
            // 
            this.lblCampInfo2.Location = new System.Drawing.Point(3, 29);
            this.lblCampInfo2.Name = "lblCampInfo2";
            this.lblCampInfo2.Size = new System.Drawing.Size(61, 20);
            this.lblCampInfo2.TabIndex = 0;
            this.lblCampInfo2.Values.Text = "Thời gian";
            // 
            // lblCampInfo1
            // 
            this.lblCampInfo1.Location = new System.Drawing.Point(3, 3);
            this.lblCampInfo1.Name = "lblCampInfo1";
            this.lblCampInfo1.Size = new System.Drawing.Size(60, 20);
            this.lblCampInfo1.TabIndex = 0;
            this.lblCampInfo1.Values.Text = "Đội quân";
            // 
            // grpCampParty
            // 
            this.grpCampParty.AutoSize = true;
            this.grpCampParty.Location = new System.Drawing.Point(3, 34);
            this.grpCampParty.Name = "grpCampParty";
            // 
            // grpCampParty.Panel
            // 
            this.grpCampParty.Panel.Controls.Add(this.radCamp1);
            this.grpCampParty.Panel.Controls.Add(this.radCamp2);
            this.grpCampParty.Panel.Controls.Add(this.lstCampMember);
            this.grpCampParty.Panel.Controls.Add(this.btnCampInvite);
            this.grpCampParty.Panel.Controls.Add(this.btnCampQuit);
            this.grpCampParty.Panel.Controls.Add(this.btnCampDisband);
            this.grpCampParty.Panel.Controls.Add(this.btnCampAttack);
            this.grpCampParty.Panel.Controls.Add(this.btnCampCreate);
            this.grpCampParty.Panel.Controls.Add(this.btnCampTeam);
            this.grpCampParty.Size = new System.Drawing.Size(273, 172);
            this.grpCampParty.TabIndex = 25;
            this.grpCampParty.Visible = false;
            // 
            // radCamp1
            // 
            this.radCamp1.Checked = true;
            this.radCamp1.Location = new System.Drawing.Point(3, 39);
            this.radCamp1.Name = "radCamp1";
            this.radCamp1.Size = new System.Drawing.Size(72, 20);
            this.radCamp1.TabIndex = 7;
            this.radCamp1.Values.Text = "Quốc gia";
            // 
            // radCamp2
            // 
            this.radCamp2.Location = new System.Drawing.Point(81, 39);
            this.radCamp2.Name = "radCamp2";
            this.radCamp2.Size = new System.Drawing.Size(50, 20);
            this.radCamp2.TabIndex = 6;
            this.radCamp2.Values.Text = "Bang";
            // 
            // lstCampMember
            // 
            this.lstCampMember.Location = new System.Drawing.Point(137, 3);
            this.lstCampMember.Name = "lstCampMember";
            this.lstCampMember.Size = new System.Drawing.Size(131, 164);
            this.lstCampMember.TabIndex = 5;
            // 
            // btnCampInvite
            // 
            this.btnCampInvite.Location = new System.Drawing.Point(3, 137);
            this.btnCampInvite.Name = "btnCampInvite";
            this.btnCampInvite.Size = new System.Drawing.Size(61, 30);
            this.btnCampInvite.TabIndex = 4;
            this.btnCampInvite.Values.Text = "Mời";
            this.btnCampInvite.Click += new System.EventHandler(this.btnCampInvite_Click);
            // 
            // btnCampQuit
            // 
            this.btnCampQuit.Location = new System.Drawing.Point(70, 137);
            this.btnCampQuit.Name = "btnCampQuit";
            this.btnCampQuit.Size = new System.Drawing.Size(61, 30);
            this.btnCampQuit.TabIndex = 4;
            this.btnCampQuit.Values.Text = "Thoái";
            this.btnCampQuit.Click += new System.EventHandler(this.btnCampQuit_Click);
            // 
            // btnCampDisband
            // 
            this.btnCampDisband.Location = new System.Drawing.Point(70, 101);
            this.btnCampDisband.Name = "btnCampDisband";
            this.btnCampDisband.Size = new System.Drawing.Size(61, 30);
            this.btnCampDisband.TabIndex = 4;
            this.btnCampDisband.Values.Text = "Giải tán";
            this.btnCampDisband.Click += new System.EventHandler(this.btnCampDisband_Click);
            // 
            // btnCampAttack
            // 
            this.btnCampAttack.Location = new System.Drawing.Point(3, 101);
            this.btnCampAttack.Name = "btnCampAttack";
            this.btnCampAttack.Size = new System.Drawing.Size(61, 30);
            this.btnCampAttack.TabIndex = 4;
            this.btnCampAttack.Values.Text = "Tấn công";
            this.btnCampAttack.Click += new System.EventHandler(this.btnCampAttack_Click);
            // 
            // btnCampCreate
            // 
            this.btnCampCreate.Location = new System.Drawing.Point(3, 65);
            this.btnCampCreate.Name = "btnCampCreate";
            this.btnCampCreate.Size = new System.Drawing.Size(128, 30);
            this.btnCampCreate.TabIndex = 3;
            this.btnCampCreate.Values.Text = "Lập tổ đội";
            this.btnCampCreate.Click += new System.EventHandler(this.btnCampCreate_Click);
            // 
            // btnCampTeam
            // 
            this.btnCampTeam.Location = new System.Drawing.Point(3, 3);
            this.btnCampTeam.Name = "btnCampTeam";
            this.btnCampTeam.Size = new System.Drawing.Size(128, 30);
            this.btnCampTeam.TabIndex = 0;
            this.btnCampTeam.Values.Text = "5 tổ đội";
            // 
            // btnCampQuitIn
            // 
            this.btnCampQuitIn.Location = new System.Drawing.Point(282, 3);
            this.btnCampQuitIn.Name = "btnCampQuitIn";
            this.btnCampQuitIn.Size = new System.Drawing.Size(136, 25);
            this.btnCampQuitIn.TabIndex = 24;
            this.btnCampQuitIn.Values.Text = "Thoát";
            this.btnCampQuitIn.Visible = false;
            this.btnCampQuitIn.Click += new System.EventHandler(this.btnCampQuitIn_Click);
            // 
            // btnCampInfo
            // 
            this.btnCampInfo.Location = new System.Drawing.Point(156, 3);
            this.btnCampInfo.Name = "btnCampInfo";
            this.btnCampInfo.Size = new System.Drawing.Size(120, 25);
            this.btnCampInfo.TabIndex = 23;
            this.btnCampInfo.Values.Text = "Tấn công";
            this.btnCampInfo.Click += new System.EventHandler(this.btnCampInfo_Click);
            // 
            // cbbCamp
            // 
            this.cbbCamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCamp.DropDownWidth = 140;
            this.cbbCamp.Location = new System.Drawing.Point(3, 5);
            this.cbbCamp.Name = "cbbCamp";
            this.cbbCamp.Size = new System.Drawing.Size(147, 21);
            this.cbbCamp.TabIndex = 22;
            // 
            // lblCampCd
            // 
            this.lblCampCd.AutoSize = false;
            this.lblCampCd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCampCd.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (30)))), ((int) (((byte) (57)))), ((int) (((byte) (91)))));
            this.lblCampCd.Location = new System.Drawing.Point(3, 34);
            this.lblCampCd.Name = "lblCampCd";
            this.lblCampCd.Size = new System.Drawing.Size(273, 347);
            this.lblCampCd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCampMap
            // 
            this.pnlCampMap.AutoScroll = true;
            this.pnlCampMap.Location = new System.Drawing.Point(3, 34);
            this.pnlCampMap.Name = "pnlCampMap";
            this.pnlCampMap.Size = new System.Drawing.Size(273, 347);
            this.pnlCampMap.TabIndex = 26;
            // 
            // navMsg
            // 
            this.navMsg.AllowPageReorder = false;
            this.navMsg.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navMsg.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navMsg.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navMsg.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navMsg.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navMsg.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navMsg.Location = new System.Drawing.Point(1084, 529);
            this.navMsg.Name = "navMsg";
            this.navMsg.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pagMsg,
            this.pagRank});
            this.navMsg.SelectedIndex = 1;
            this.navMsg.Size = new System.Drawing.Size(648, 250);
            this.navMsg.TabIndex = 26;
            this.navMsg.Text = "kryptonNavigator1";
            // 
            // pagMsg
            // 
            this.pagMsg.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagMsg.Flags = 65534;
            this.pagMsg.LastVisibleSet = true;
            this.pagMsg.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagMsg.Name = "pagMsg";
            this.pagMsg.Size = new System.Drawing.Size(646, 223);
            this.pagMsg.Text = "Thư";
            this.pagMsg.ToolTipTitle = "Page ToolTip";
            this.pagMsg.UniqueName = "04E6C8989E7D4476D5B51E6AFBAED09C";
            // 
            // pagRank
            // 
            this.pagRank.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagRank.Flags = 65534;
            this.pagRank.LastVisibleSet = true;
            this.pagRank.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagRank.Name = "pagRank";
            this.pagRank.Size = new System.Drawing.Size(646, 223);
            this.pagRank.Text = "Xếp hạng";
            this.pagRank.ToolTipTitle = "Page ToolTip";
            this.pagRank.UniqueName = "0F8FFF735A3A42E8CEA9BF55C6F72DA1";
            // 
            // pnlNav
            // 
            this.pnlNav.AutoSize = true;
            this.pnlNav.Controls.Add(this.btnMsg);
            this.pnlNav.Controls.Add(this.btnOthers);
            this.pnlNav.Controls.Add(this.btnShop);
            this.pnlNav.Controls.Add(this.btnPower);
            this.pnlNav.Controls.Add(this.btnWorkshop);
            this.pnlNav.Location = new System.Drawing.Point(555, 31);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(348, 72);
            this.pnlNav.TabIndex = 25;
            // 
            // btnMsg
            // 
            this.btnMsg.Location = new System.Drawing.Point(261, 3);
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(80, 25);
            this.btnMsg.TabIndex = 13;
            this.btnMsg.Values.Text = "Thư";
            this.btnMsg.CheckedChanged += new System.EventHandler(this.btnMsg_CheckedChanged);
            // 
            // btnOthers
            // 
            this.btnOthers.Location = new System.Drawing.Point(175, 3);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(80, 25);
            this.btnOthers.TabIndex = 12;
            this.btnOthers.Values.Text = "Binh doanh";
            this.btnOthers.CheckedChanged += new System.EventHandler(this.btnOthers_CheckedChanged);
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(175, 34);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(80, 25);
            this.btnShop.TabIndex = 12;
            this.btnShop.Values.Text = "Cửa tiệm";
            this.btnShop.CheckedChanged += new System.EventHandler(this.btnShop_CheckedChanged);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(3, 34);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(80, 25);
            this.btnPower.TabIndex = 12;
            this.btnPower.Values.Text = "Chiến";
            this.btnPower.CheckedChanged += new System.EventHandler(this.btnPower_CheckedChanged);
            // 
            // btnWorkshop
            // 
            this.btnWorkshop.Location = new System.Drawing.Point(89, 34);
            this.btnWorkshop.Name = "btnWorkshop";
            this.btnWorkshop.Size = new System.Drawing.Size(80, 25);
            this.btnWorkshop.TabIndex = 12;
            this.btnWorkshop.Values.Text = "Dệt";
            this.btnWorkshop.CheckedChanged += new System.EventHandler(this.btnWorkshop_CheckedChanged);
            // 
            // navShop
            // 
            this.navShop.AllowPageReorder = false;
            this.navShop.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.navShop.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navShop.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navShop.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navShop.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navShop.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navShop.Location = new System.Drawing.Point(753, 161);
            this.navShop.Name = "navShop";
            this.navShop.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pagBag,
            this.pagUpg,
            this.pagApp});
            this.navShop.SelectedIndex = 0;
            this.navShop.Size = new System.Drawing.Size(457, 317);
            this.navShop.TabIndex = 24;
            this.navShop.Text = "kryptonNavigator1";
            this.navShop.SelectedPageChanged += new System.EventHandler(this.navShop_SelectedPageChanged);
            // 
            // pagBag
            // 
            this.pagBag.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagBag.Controls.Add(this.lblBag);
            this.pagBag.Controls.Add(this.grpBag);
            this.pagBag.Controls.Add(this.cbbBag);
            this.pagBag.Flags = 65534;
            this.pagBag.LastVisibleSet = true;
            this.pagBag.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagBag.Name = "pagBag";
            this.pagBag.Size = new System.Drawing.Size(455, 290);
            this.pagBag.Text = "Túi đồ";
            this.pagBag.ToolTipTitle = "Page ToolTip";
            this.pagBag.UniqueName = "3189FEA2443C4DC382B8619F80F03D5B";
            // 
            // lblBag
            // 
            this.lblBag.Location = new System.Drawing.Point(3, 3);
            this.lblBag.Name = "lblBag";
            this.lblBag.Size = new System.Drawing.Size(72, 20);
            this.lblBag.TabIndex = 33;
            this.lblBag.Values.Text = "Số ô: 12/15";
            // 
            // grpBag
            // 
            this.grpBag.AutoSize = true;
            this.grpBag.Location = new System.Drawing.Point(3, 56);
            this.grpBag.Name = "grpBag";
            // 
            // grpBag.Panel
            // 
            this.grpBag.Panel.Controls.Add(this.lblBagBindCd);
            this.grpBag.Panel.Controls.Add(this.lblBagDegrade);
            this.grpBag.Panel.Controls.Add(this.lblBagSell);
            this.grpBag.Panel.Controls.Add(this.lblBagInfo4);
            this.grpBag.Panel.Controls.Add(this.lblBagInfo3);
            this.grpBag.Panel.Controls.Add(this.btnBagDegrade);
            this.grpBag.Panel.Controls.Add(this.lblBagInfo2);
            this.grpBag.Panel.Controls.Add(this.btnBagSell);
            this.grpBag.Panel.Controls.Add(this.txtBagBindCd);
            this.grpBag.Panel.Controls.Add(this.txtBagDegrade);
            this.grpBag.Panel.Controls.Add(this.btnBagBind);
            this.grpBag.Panel.Controls.Add(this.txtBagSell);
            this.grpBag.Panel.Controls.Add(this.lblBagInfo1);
            this.grpBag.Panel.Controls.Add(this.txtBagInfo4);
            this.grpBag.Panel.Controls.Add(this.txtBagInfo3);
            this.grpBag.Panel.Controls.Add(this.txtBagInfo2);
            this.grpBag.Panel.Controls.Add(this.txtBagInfo1);
            this.grpBag.Size = new System.Drawing.Size(214, 203);
            this.grpBag.TabIndex = 32;
            this.grpBag.Values.Heading = "";
            // 
            // lblBagBindCd
            // 
            this.lblBagBindCd.Location = new System.Drawing.Point(3, 169);
            this.lblBagBindCd.Name = "lblBagBindCd";
            this.lblBagBindCd.Size = new System.Drawing.Size(59, 20);
            this.lblBagBindCd.TabIndex = 25;
            this.lblBagBindCd.Values.Text = "Mở khoá";
            // 
            // lblBagDegrade
            // 
            this.lblBagDegrade.Location = new System.Drawing.Point(3, 139);
            this.lblBagDegrade.Name = "lblBagDegrade";
            this.lblBagDegrade.Size = new System.Drawing.Size(40, 20);
            this.lblBagDegrade.TabIndex = 25;
            this.lblBagDegrade.Values.Text = "Nhận";
            // 
            // lblBagSell
            // 
            this.lblBagSell.Location = new System.Drawing.Point(3, 109);
            this.lblBagSell.Name = "lblBagSell";
            this.lblBagSell.Size = new System.Drawing.Size(28, 20);
            this.lblBagSell.TabIndex = 25;
            this.lblBagSell.Values.Text = "Giá";
            // 
            // lblBagInfo4
            // 
            this.lblBagInfo4.Location = new System.Drawing.Point(3, 81);
            this.lblBagInfo4.Name = "lblBagInfo4";
            this.lblBagInfo4.Size = new System.Drawing.Size(68, 20);
            this.lblBagInfo4.TabIndex = 25;
            this.lblBagInfo4.Values.Text = "Cấp tướng";
            // 
            // lblBagInfo3
            // 
            this.lblBagInfo3.Location = new System.Drawing.Point(3, 55);
            this.lblBagInfo3.Name = "lblBagInfo3";
            this.lblBagInfo3.Size = new System.Drawing.Size(78, 20);
            this.lblBagInfo3.TabIndex = 25;
            this.lblBagInfo3.Values.Text = "Cấp trang bị";
            // 
            // btnBagDegrade
            // 
            this.btnBagDegrade.Location = new System.Drawing.Point(125, 137);
            this.btnBagDegrade.Name = "btnBagDegrade";
            this.btnBagDegrade.Size = new System.Drawing.Size(82, 24);
            this.btnBagDegrade.TabIndex = 26;
            this.btnBagDegrade.Values.Text = "Hạ cấp";
            this.btnBagDegrade.Click += new System.EventHandler(this.btnBagDegrade_Click);
            // 
            // lblBagInfo2
            // 
            this.lblBagInfo2.Location = new System.Drawing.Point(3, 29);
            this.lblBagInfo2.Name = "lblBagInfo2";
            this.lblBagInfo2.Size = new System.Drawing.Size(54, 20);
            this.lblBagInfo2.TabIndex = 26;
            this.lblBagInfo2.Values.Text = "Binh lực";
            // 
            // btnBagSell
            // 
            this.btnBagSell.Location = new System.Drawing.Point(125, 107);
            this.btnBagSell.Name = "btnBagSell";
            this.btnBagSell.Size = new System.Drawing.Size(82, 24);
            this.btnBagSell.TabIndex = 26;
            this.btnBagSell.Values.Text = "Bán";
            this.btnBagSell.Click += new System.EventHandler(this.btnBagSell_Click);
            // 
            // txtBagBindCd
            // 
            this.txtBagBindCd.Location = new System.Drawing.Point(69, 169);
            this.txtBagBindCd.Name = "txtBagBindCd";
            this.txtBagBindCd.ReadOnly = true;
            this.txtBagBindCd.Size = new System.Drawing.Size(50, 23);
            this.txtBagBindCd.TabIndex = 23;
            this.txtBagBindCd.Text = "71:59:59";
            this.txtBagBindCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBagDegrade
            // 
            this.txtBagDegrade.Location = new System.Drawing.Point(49, 139);
            this.txtBagDegrade.Name = "txtBagDegrade";
            this.txtBagDegrade.ReadOnly = true;
            this.txtBagDegrade.Size = new System.Drawing.Size(70, 23);
            this.txtBagDegrade.TabIndex = 23;
            this.txtBagDegrade.Text = "50000 Bạc";
            this.txtBagDegrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBagBind
            // 
            this.btnBagBind.Location = new System.Drawing.Point(125, 167);
            this.btnBagBind.Name = "btnBagBind";
            this.btnBagBind.Size = new System.Drawing.Size(82, 24);
            this.btnBagBind.TabIndex = 26;
            this.btnBagBind.Values.Text = "Khoá";
            this.btnBagBind.Click += new System.EventHandler(this.btnBagBind_Click);
            // 
            // txtBagSell
            // 
            this.txtBagSell.Location = new System.Drawing.Point(49, 109);
            this.txtBagSell.Name = "txtBagSell";
            this.txtBagSell.ReadOnly = true;
            this.txtBagSell.Size = new System.Drawing.Size(70, 23);
            this.txtBagSell.TabIndex = 23;
            this.txtBagSell.Text = "50000 Bạc";
            this.txtBagSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBagInfo1
            // 
            this.lblBagInfo1.Location = new System.Drawing.Point(3, 3);
            this.lblBagInfo1.Name = "lblBagInfo1";
            this.lblBagInfo1.Size = new System.Drawing.Size(42, 20);
            this.lblBagInfo1.TabIndex = 27;
            this.lblBagInfo1.Values.Text = "Chính";
            // 
            // txtBagInfo4
            // 
            this.txtBagInfo4.Location = new System.Drawing.Point(87, 81);
            this.txtBagInfo4.Name = "txtBagInfo4";
            this.txtBagInfo4.ReadOnly = true;
            this.txtBagInfo4.Size = new System.Drawing.Size(120, 23);
            this.txtBagInfo4.TabIndex = 23;
            this.txtBagInfo4.Text = "Tướng Lv.100 trở lên";
            this.txtBagInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBagInfo3
            // 
            this.txtBagInfo3.Location = new System.Drawing.Point(87, 54);
            this.txtBagInfo3.Name = "txtBagInfo3";
            this.txtBagInfo3.ReadOnly = true;
            this.txtBagInfo3.Size = new System.Drawing.Size(120, 23);
            this.txtBagInfo3.TabIndex = 23;
            this.txtBagInfo3.Text = "Lv12-10";
            this.txtBagInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBagInfo2
            // 
            this.txtBagInfo2.Location = new System.Drawing.Point(87, 28);
            this.txtBagInfo2.Name = "txtBagInfo2";
            this.txtBagInfo2.ReadOnly = true;
            this.txtBagInfo2.Size = new System.Drawing.Size(120, 23);
            this.txtBagInfo2.TabIndex = 22;
            this.txtBagInfo2.Text = "+480";
            this.txtBagInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBagInfo1
            // 
            this.txtBagInfo1.Location = new System.Drawing.Point(87, 2);
            this.txtBagInfo1.Name = "txtBagInfo1";
            this.txtBagInfo1.ReadOnly = true;
            this.txtBagInfo1.Size = new System.Drawing.Size(120, 23);
            this.txtBagInfo1.TabIndex = 24;
            this.txtBagInfo1.Text = "Công phép +2500";
            this.txtBagInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbBag
            // 
            this.cbbBag.DropDownHeight = 400;
            this.cbbBag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBag.DropDownWidth = 150;
            this.cbbBag.Location = new System.Drawing.Point(3, 29);
            this.cbbBag.Name = "cbbBag";
            this.cbbBag.Size = new System.Drawing.Size(214, 21);
            this.cbbBag.TabIndex = 25;
            this.cbbBag.SelectedIndexChanged += new System.EventHandler(this.cbbBag_SelectedIndexChanged);
            // 
            // pagUpg
            // 
            this.pagUpg.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagUpg.Controls.Add(this.grpUpg);
            this.pagUpg.Controls.Add(this.cbbUpg2);
            this.pagUpg.Controls.Add(this.cbbUpg1);
            this.pagUpg.Flags = 65534;
            this.pagUpg.LastVisibleSet = true;
            this.pagUpg.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagUpg.Name = "pagUpg";
            this.pagUpg.Size = new System.Drawing.Size(455, 290);
            this.pagUpg.Text = "Cường hoá";
            this.pagUpg.ToolTipTitle = "Page ToolTip";
            this.pagUpg.UniqueName = "C35DB147A37145F1EEAD93F6D384309E";
            // 
            // grpUpg
            // 
            this.grpUpg.AutoSize = true;
            this.grpUpg.Location = new System.Drawing.Point(3, 30);
            this.grpUpg.Name = "grpUpg";
            // 
            // grpUpg.Panel
            // 
            this.grpUpg.Panel.Controls.Add(this.lblUpgBindCd);
            this.grpUpg.Panel.Controls.Add(this.lblUpgDe);
            this.grpUpg.Panel.Controls.Add(this.lblUpgUp);
            this.grpUpg.Panel.Controls.Add(this.lblUpgInfo4);
            this.grpUpg.Panel.Controls.Add(this.lblUpgInfo3);
            this.grpUpg.Panel.Controls.Add(this.btnUpgDe);
            this.grpUpg.Panel.Controls.Add(this.lblUpgInfo2);
            this.grpUpg.Panel.Controls.Add(this.btnUpgUp);
            this.grpUpg.Panel.Controls.Add(this.txtUpgBindCd);
            this.grpUpg.Panel.Controls.Add(this.txtUpgDe);
            this.grpUpg.Panel.Controls.Add(this.btnUpgradeBind);
            this.grpUpg.Panel.Controls.Add(this.txtUpgUp);
            this.grpUpg.Panel.Controls.Add(this.lblUpgInfo1);
            this.grpUpg.Panel.Controls.Add(this.txtUpgInfo4);
            this.grpUpg.Panel.Controls.Add(this.txtUpgInfo3);
            this.grpUpg.Panel.Controls.Add(this.txtUpgInfo2);
            this.grpUpg.Panel.Controls.Add(this.txtUpgInfo1);
            this.grpUpg.Size = new System.Drawing.Size(214, 203);
            this.grpUpg.TabIndex = 35;
            this.grpUpg.Values.Heading = "";
            // 
            // lblUpgBindCd
            // 
            this.lblUpgBindCd.Location = new System.Drawing.Point(3, 169);
            this.lblUpgBindCd.Name = "lblUpgBindCd";
            this.lblUpgBindCd.Size = new System.Drawing.Size(59, 20);
            this.lblUpgBindCd.TabIndex = 25;
            this.lblUpgBindCd.Values.Text = "Mở khoá";
            this.lblUpgBindCd.Visible = false;
            // 
            // lblUpgDe
            // 
            this.lblUpgDe.Location = new System.Drawing.Point(3, 139);
            this.lblUpgDe.Name = "lblUpgDe";
            this.lblUpgDe.Size = new System.Drawing.Size(40, 20);
            this.lblUpgDe.TabIndex = 25;
            this.lblUpgDe.Values.Text = "Nhận";
            // 
            // lblUpgUp
            // 
            this.lblUpgUp.Location = new System.Drawing.Point(3, 109);
            this.lblUpgUp.Name = "lblUpgUp";
            this.lblUpgUp.Size = new System.Drawing.Size(31, 20);
            this.lblUpgUp.TabIndex = 25;
            this.lblUpgUp.Values.Text = "Cần";
            // 
            // lblUpgInfo4
            // 
            this.lblUpgInfo4.Location = new System.Drawing.Point(3, 81);
            this.lblUpgInfo4.Name = "lblUpgInfo4";
            this.lblUpgInfo4.Size = new System.Drawing.Size(68, 20);
            this.lblUpgInfo4.TabIndex = 25;
            this.lblUpgInfo4.Values.Text = "Cấp tướng";
            // 
            // lblUpgInfo3
            // 
            this.lblUpgInfo3.Location = new System.Drawing.Point(3, 55);
            this.lblUpgInfo3.Name = "lblUpgInfo3";
            this.lblUpgInfo3.Size = new System.Drawing.Size(78, 20);
            this.lblUpgInfo3.TabIndex = 25;
            this.lblUpgInfo3.Values.Text = "Cấp trang bị";
            // 
            // btnUpgDe
            // 
            this.btnUpgDe.Location = new System.Drawing.Point(125, 137);
            this.btnUpgDe.Name = "btnUpgDe";
            this.btnUpgDe.Size = new System.Drawing.Size(82, 24);
            this.btnUpgDe.TabIndex = 26;
            this.btnUpgDe.Values.Text = "Hạ cấp";
            this.btnUpgDe.Click += new System.EventHandler(this.btnUpgDe_Click);
            // 
            // lblUpgInfo2
            // 
            this.lblUpgInfo2.Location = new System.Drawing.Point(3, 29);
            this.lblUpgInfo2.Name = "lblUpgInfo2";
            this.lblUpgInfo2.Size = new System.Drawing.Size(54, 20);
            this.lblUpgInfo2.TabIndex = 26;
            this.lblUpgInfo2.Values.Text = "Binh lực";
            // 
            // btnUpgUp
            // 
            this.btnUpgUp.Location = new System.Drawing.Point(125, 107);
            this.btnUpgUp.Name = "btnUpgUp";
            this.btnUpgUp.Size = new System.Drawing.Size(82, 24);
            this.btnUpgUp.TabIndex = 26;
            this.btnUpgUp.Values.Text = "Nâng cấp";
            this.btnUpgUp.Click += new System.EventHandler(this.btnUpgUp_Click);
            // 
            // txtUpgBindCd
            // 
            this.txtUpgBindCd.Location = new System.Drawing.Point(69, 169);
            this.txtUpgBindCd.Name = "txtUpgBindCd";
            this.txtUpgBindCd.ReadOnly = true;
            this.txtUpgBindCd.Size = new System.Drawing.Size(50, 23);
            this.txtUpgBindCd.TabIndex = 23;
            this.txtUpgBindCd.Text = "71:59:59";
            this.txtUpgBindCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUpgBindCd.Visible = false;
            // 
            // txtUpgDe
            // 
            this.txtUpgDe.Location = new System.Drawing.Point(49, 139);
            this.txtUpgDe.Name = "txtUpgDe";
            this.txtUpgDe.ReadOnly = true;
            this.txtUpgDe.Size = new System.Drawing.Size(70, 23);
            this.txtUpgDe.TabIndex = 23;
            this.txtUpgDe.Text = "50000 Bạc";
            this.txtUpgDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpgradeBind
            // 
            this.btnUpgradeBind.Location = new System.Drawing.Point(125, 167);
            this.btnUpgradeBind.Name = "btnUpgradeBind";
            this.btnUpgradeBind.Size = new System.Drawing.Size(82, 24);
            this.btnUpgradeBind.TabIndex = 26;
            this.btnUpgradeBind.Values.Text = "Khoá";
            this.btnUpgradeBind.Visible = false;
            // 
            // txtUpgUp
            // 
            this.txtUpgUp.Location = new System.Drawing.Point(49, 109);
            this.txtUpgUp.Name = "txtUpgUp";
            this.txtUpgUp.ReadOnly = true;
            this.txtUpgUp.Size = new System.Drawing.Size(70, 23);
            this.txtUpgUp.TabIndex = 23;
            this.txtUpgUp.Text = "5000000 Bạc";
            this.txtUpgUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUpgInfo1
            // 
            this.lblUpgInfo1.Location = new System.Drawing.Point(3, 3);
            this.lblUpgInfo1.Name = "lblUpgInfo1";
            this.lblUpgInfo1.Size = new System.Drawing.Size(42, 20);
            this.lblUpgInfo1.TabIndex = 27;
            this.lblUpgInfo1.Values.Text = "Chính";
            // 
            // txtUpgInfo4
            // 
            this.txtUpgInfo4.Location = new System.Drawing.Point(87, 81);
            this.txtUpgInfo4.Name = "txtUpgInfo4";
            this.txtUpgInfo4.ReadOnly = true;
            this.txtUpgInfo4.Size = new System.Drawing.Size(120, 23);
            this.txtUpgInfo4.TabIndex = 23;
            this.txtUpgInfo4.Text = "Yêu cầu cấp 80";
            this.txtUpgInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUpgInfo3
            // 
            this.txtUpgInfo3.Location = new System.Drawing.Point(87, 54);
            this.txtUpgInfo3.Name = "txtUpgInfo3";
            this.txtUpgInfo3.ReadOnly = true;
            this.txtUpgInfo3.Size = new System.Drawing.Size(120, 23);
            this.txtUpgInfo3.TabIndex = 23;
            this.txtUpgInfo3.Text = "Lv12-10";
            this.txtUpgInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUpgInfo2
            // 
            this.txtUpgInfo2.Location = new System.Drawing.Point(87, 28);
            this.txtUpgInfo2.Name = "txtUpgInfo2";
            this.txtUpgInfo2.ReadOnly = true;
            this.txtUpgInfo2.Size = new System.Drawing.Size(120, 23);
            this.txtUpgInfo2.TabIndex = 22;
            this.txtUpgInfo2.Text = "+480";
            this.txtUpgInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUpgInfo1
            // 
            this.txtUpgInfo1.Location = new System.Drawing.Point(87, 2);
            this.txtUpgInfo1.Name = "txtUpgInfo1";
            this.txtUpgInfo1.ReadOnly = true;
            this.txtUpgInfo1.Size = new System.Drawing.Size(120, 23);
            this.txtUpgInfo1.TabIndex = 24;
            this.txtUpgInfo1.Text = "Công phép +2500";
            this.txtUpgInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbUpg2
            // 
            this.cbbUpg2.DropDownHeight = 400;
            this.cbbUpg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUpg2.DropDownWidth = 150;
            this.cbbUpg2.Location = new System.Drawing.Point(89, 3);
            this.cbbUpg2.Name = "cbbUpg2";
            this.cbbUpg2.Size = new System.Drawing.Size(200, 21);
            this.cbbUpg2.TabIndex = 26;
            this.cbbUpg2.SelectedIndexChanged += new System.EventHandler(this.cbbUpg2_SelectedIndexChanged);
            // 
            // cbbUpg1
            // 
            this.cbbUpg1.DropDownHeight = 400;
            this.cbbUpg1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUpg1.DropDownWidth = 80;
            this.cbbUpg1.Location = new System.Drawing.Point(3, 3);
            this.cbbUpg1.Name = "cbbUpg1";
            this.cbbUpg1.Size = new System.Drawing.Size(80, 21);
            this.cbbUpg1.TabIndex = 26;
            this.cbbUpg1.SelectedIndexChanged += new System.EventHandler(this.cbbUpg1_SelectedIndexChanged);
            // 
            // pagApp
            // 
            this.pagApp.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagApp.Flags = 65534;
            this.pagApp.LastVisibleSet = true;
            this.pagApp.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagApp.Name = "pagApp";
            this.pagApp.Size = new System.Drawing.Size(455, 290);
            this.pagApp.Text = "Uỷ phái";
            this.pagApp.ToolTipTitle = "Page ToolTip";
            this.pagApp.UniqueName = "42D86A93C0A14554F99559C059F4F75B";
            // 
            // navOthers
            // 
            this.navOthers.AllowPageReorder = false;
            this.navOthers.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navOthers.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navOthers.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navOthers.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navOthers.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navOthers.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navOthers.Location = new System.Drawing.Point(1039, 10);
            this.navOthers.Name = "navOthers";
            this.navOthers.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pagForces});
            this.navOthers.SelectedIndex = 0;
            this.navOthers.Size = new System.Drawing.Size(229, 144);
            this.navOthers.TabIndex = 23;
            this.navOthers.Text = "kryptonNavigator1";
            this.navOthers.SelectedPageChanged += new System.EventHandler(this.navOthers_SelectedPageChanged);
            // 
            // pagForces
            // 
            this.pagForces.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagForces.Controls.Add(this.chkForcesFree);
            this.pagForces.Controls.Add(this.chkForces);
            this.pagForces.Controls.Add(this.btnForcesRecruit);
            this.pagForces.Controls.Add(this.btnForcesFree);
            this.pagForces.Controls.Add(this.lblForcesRecruit);
            this.pagForces.Controls.Add(this.numForces);
            this.pagForces.Controls.Add(this.numForcesRecruit);
            this.pagForces.Flags = 65534;
            this.pagForces.LastVisibleSet = true;
            this.pagForces.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagForces.Name = "pagForces";
            this.pagForces.Size = new System.Drawing.Size(227, 117);
            this.pagForces.Text = "Binh doanh";
            this.pagForces.ToolTipTitle = "Page ToolTip";
            this.pagForces.UniqueName = "04E6C8989E7D4476D5B51E6AFBAED09C";
            // 
            // chkForcesFree
            // 
            this.chkForcesFree.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkForcesFree.Location = new System.Drawing.Point(3, 94);
            this.chkForcesFree.Name = "chkForcesFree";
            this.chkForcesFree.Size = new System.Drawing.Size(127, 20);
            this.chkForcesFree.TabIndex = 10;
            this.chkForcesFree.Text = "Tự động tuyển lính";
            this.chkForcesFree.Values.Text = "Tự động tuyển lính";
            // 
            // chkForces
            // 
            this.chkForces.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkForces.Location = new System.Drawing.Point(3, 68);
            this.chkForces.Name = "chkForces";
            this.chkForces.Size = new System.Drawing.Size(145, 20);
            this.chkForces.TabIndex = 11;
            this.chkForces.Text = "Đào tạo lính khi lính <";
            this.chkForces.Values.Text = "Đào tạo lính khi lính <";
            // 
            // btnForcesRecruit
            // 
            this.btnForcesRecruit.Location = new System.Drawing.Point(102, 31);
            this.btnForcesRecruit.Name = "btnForcesRecruit";
            this.btnForcesRecruit.Size = new System.Drawing.Size(92, 30);
            this.btnForcesRecruit.TabIndex = 9;
            this.btnForcesRecruit.Values.Text = "Đào tạo";
            this.btnForcesRecruit.Click += new System.EventHandler(this.btnForcesRecruit_Click);
            // 
            // btnForcesFree
            // 
            this.btnForcesFree.Location = new System.Drawing.Point(3, 31);
            this.btnForcesFree.Name = "btnForcesFree";
            this.btnForcesFree.Size = new System.Drawing.Size(92, 30);
            this.btnForcesFree.TabIndex = 8;
            this.btnForcesFree.Values.Text = "Tuyển";
            this.btnForcesFree.Click += new System.EventHandler(this.btnForcesFree_Click);
            // 
            // lblForcesRecruit
            // 
            this.lblForcesRecruit.Location = new System.Drawing.Point(3, 4);
            this.lblForcesRecruit.Name = "lblForcesRecruit";
            this.lblForcesRecruit.Size = new System.Drawing.Size(115, 20);
            this.lblForcesRecruit.TabIndex = 7;
            this.lblForcesRecruit.Values.Text = "Số lính cần đào tạo";
            // 
            // numForces
            // 
            this.numForces.Location = new System.Drawing.Point(154, 67);
            this.numForces.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numForces.Name = "numForces";
            this.numForces.Size = new System.Drawing.Size(70, 22);
            this.numForces.TabIndex = 5;
            this.numForces.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numForces.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // numForcesRecruit
            // 
            this.numForcesRecruit.Location = new System.Drawing.Point(124, 3);
            this.numForcesRecruit.Name = "numForcesRecruit";
            this.numForcesRecruit.Size = new System.Drawing.Size(70, 22);
            this.numForcesRecruit.TabIndex = 6;
            this.numForcesRecruit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Location = new System.Drawing.Point(555, 4);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(122, 20);
            this.lblUpdate.TabIndex = 22;
            this.lblUpdate.Values.Text = "Tốc độ cập nhật(ms)";
            // 
            // navWorkshop
            // 
            this.navWorkshop.AllowPageReorder = false;
            this.navWorkshop.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navWorkshop.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navWorkshop.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navWorkshop.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navWorkshop.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navWorkshop.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navWorkshop.Location = new System.Drawing.Point(1132, 64);
            this.navWorkshop.Name = "navWorkshop";
            this.navWorkshop.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pagWeave,
            this.pagMerchant});
            this.navWorkshop.SelectedIndex = 0;
            this.navWorkshop.Size = new System.Drawing.Size(500, 387);
            this.navWorkshop.TabIndex = 20;
            this.navWorkshop.Text = "kryptonNavigator1";
            // 
            // pagWeave
            // 
            this.pagWeave.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagWeave.Controls.Add(this.numWeaveProduct);
            this.pagWeave.Controls.Add(this.grpWeaveCreate);
            this.pagWeave.Controls.Add(this.grpWeaveParty);
            this.pagWeave.Controls.Add(this.grpWeaveInfo);
            this.pagWeave.Controls.Add(this.chkWeave);
            this.pagWeave.Controls.Add(this.lblWeaveProduct);
            this.pagWeave.Controls.Add(this.cbbWeaveMode);
            this.pagWeave.Controls.Add(this.lblWeaveMode);
            this.pagWeave.Controls.Add(this.numWeaveLimit);
            this.pagWeave.Controls.Add(this.chkWeaveMake);
            this.pagWeave.Flags = 65534;
            this.pagWeave.LastVisibleSet = true;
            this.pagWeave.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagWeave.Name = "pagWeave";
            this.pagWeave.Size = new System.Drawing.Size(498, 360);
            this.pagWeave.Text = "Dệt";
            this.pagWeave.ToolTipTitle = "Page ToolTip";
            this.pagWeave.UniqueName = "223BED226E66428C59B16A7852659EC2";
            // 
            // numWeaveProduct
            // 
            this.numWeaveProduct.Location = new System.Drawing.Point(381, 3);
            this.numWeaveProduct.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWeaveProduct.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeaveProduct.Name = "numWeaveProduct";
            this.numWeaveProduct.Size = new System.Drawing.Size(40, 22);
            this.numWeaveProduct.TabIndex = 24;
            this.numWeaveProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWeaveProduct.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpWeaveCreate
            // 
            this.grpWeaveCreate.AutoSize = true;
            this.grpWeaveCreate.Location = new System.Drawing.Point(301, 66);
            this.grpWeaveCreate.Name = "grpWeaveCreate";
            // 
            // grpWeaveCreate.Panel
            // 
            this.grpWeaveCreate.Panel.Controls.Add(this.grpWeaveWorker);
            this.grpWeaveCreate.Panel.Controls.Add(this.grpWeaveProduct);
            this.grpWeaveCreate.Panel.Controls.Add(this.btnWeaveCreate2);
            this.grpWeaveCreate.Panel.Controls.Add(this.btnWeaveCreate1);
            this.grpWeaveCreate.Size = new System.Drawing.Size(247, 253);
            this.grpWeaveCreate.TabIndex = 21;
            this.grpWeaveCreate.Visible = false;
            // 
            // grpWeaveWorker
            // 
            this.grpWeaveWorker.Location = new System.Drawing.Point(3, 119);
            this.grpWeaveWorker.Name = "grpWeaveWorker";
            // 
            // grpWeaveWorker.Panel
            // 
            this.grpWeaveWorker.Panel.Controls.Add(this.btnWeaveShift);
            this.grpWeaveWorker.Panel.Controls.Add(this.lblWeaveSkill2);
            this.grpWeaveWorker.Panel.Controls.Add(this.lblWeaveSkill1);
            this.grpWeaveWorker.Panel.Controls.Add(this.lblWeaveExp);
            this.grpWeaveWorker.Panel.Controls.Add(this.cbbWeaveWorker);
            this.grpWeaveWorker.Panel.Controls.Add(this.txtWeaveExp);
            this.grpWeaveWorker.Size = new System.Drawing.Size(239, 129);
            this.grpWeaveWorker.TabIndex = 0;
            this.grpWeaveWorker.Text = "Công nhân";
            this.grpWeaveWorker.Values.Heading = "Công nhân";
            // 
            // btnWeaveShift
            // 
            this.btnWeaveShift.Location = new System.Drawing.Point(144, 28);
            this.btnWeaveShift.Name = "btnWeaveShift";
            this.btnWeaveShift.Size = new System.Drawing.Size(88, 25);
            this.btnWeaveShift.TabIndex = 19;
            this.btnWeaveShift.Values.Text = "Chuyển sinh";
            // 
            // lblWeaveSkill2
            // 
            this.lblWeaveSkill2.Location = new System.Drawing.Point(3, 82);
            this.lblWeaveSkill2.Name = "lblWeaveSkill2";
            this.lblWeaveSkill2.Size = new System.Drawing.Size(217, 20);
            this.lblWeaveSkill2.TabIndex = 0;
            this.lblWeaveSkill2.Values.Text = "Kỹ năng 1: Thiên Đạo Thủ Cần +1 Cấp";
            // 
            // lblWeaveSkill1
            // 
            this.lblWeaveSkill1.Location = new System.Drawing.Point(3, 56);
            this.lblWeaveSkill1.Name = "lblWeaveSkill1";
            this.lblWeaveSkill1.Size = new System.Drawing.Size(217, 20);
            this.lblWeaveSkill1.TabIndex = 0;
            this.lblWeaveSkill1.Values.Text = "Kỹ năng 1: Thiên Đạo Thủ Cần +1 Cấp";
            // 
            // lblWeaveExp
            // 
            this.lblWeaveExp.Location = new System.Drawing.Point(3, 30);
            this.lblWeaveExp.Name = "lblWeaveExp";
            this.lblWeaveExp.Size = new System.Drawing.Size(79, 20);
            this.lblWeaveExp.TabIndex = 0;
            this.lblWeaveExp.Values.Text = "Kinh nghiệm";
            // 
            // cbbWeaveWorker
            // 
            this.cbbWeaveWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWeaveWorker.DropDownWidth = 140;
            this.cbbWeaveWorker.Location = new System.Drawing.Point(3, 3);
            this.cbbWeaveWorker.Name = "cbbWeaveWorker";
            this.cbbWeaveWorker.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.cbbWeaveWorker.Size = new System.Drawing.Size(229, 21);
            this.cbbWeaveWorker.TabIndex = 18;
            this.cbbWeaveWorker.SelectedIndexChanged += new System.EventHandler(this.cbbWeaveWorker_SelectedIndexChanged);
            // 
            // txtWeaveExp
            // 
            this.txtWeaveExp.Location = new System.Drawing.Point(88, 30);
            this.txtWeaveExp.Name = "txtWeaveExp";
            this.txtWeaveExp.ReadOnly = true;
            this.txtWeaveExp.Size = new System.Drawing.Size(50, 23);
            this.txtWeaveExp.TabIndex = 1;
            this.txtWeaveExp.Text = "99.99%";
            this.txtWeaveExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpWeaveProduct
            // 
            this.grpWeaveProduct.AutoSize = true;
            this.grpWeaveProduct.Location = new System.Drawing.Point(3, 34);
            this.grpWeaveProduct.Name = "grpWeaveProduct";
            // 
            // grpWeaveProduct.Panel
            // 
            this.grpWeaveProduct.Panel.Controls.Add(this.lblWeaveInfo9);
            this.grpWeaveProduct.Panel.Controls.Add(this.lblWeaveInfo8);
            this.grpWeaveProduct.Panel.Controls.Add(this.txtWeaveInfo9);
            this.grpWeaveProduct.Panel.Controls.Add(this.cbbWeaveProduct);
            this.grpWeaveProduct.Panel.Controls.Add(this.txtWeaveInfo8);
            this.grpWeaveProduct.Size = new System.Drawing.Size(239, 82);
            this.grpWeaveProduct.TabIndex = 0;
            this.grpWeaveProduct.Text = "Vải";
            this.grpWeaveProduct.Values.Heading = "Vải";
            // 
            // lblWeaveInfo9
            // 
            this.lblWeaveInfo9.Location = new System.Drawing.Point(118, 30);
            this.lblWeaveInfo9.Name = "lblWeaveInfo9";
            this.lblWeaveInfo9.Size = new System.Drawing.Size(28, 20);
            this.lblWeaveInfo9.TabIndex = 0;
            this.lblWeaveInfo9.Values.Text = "Giá";
            // 
            // lblWeaveInfo8
            // 
            this.lblWeaveInfo8.Location = new System.Drawing.Point(3, 30);
            this.lblWeaveInfo8.Name = "lblWeaveInfo8";
            this.lblWeaveInfo8.Size = new System.Drawing.Size(33, 20);
            this.lblWeaveInfo8.TabIndex = 0;
            this.lblWeaveInfo8.Values.Text = "Tỉ lệ";
            // 
            // txtWeaveInfo9
            // 
            this.txtWeaveInfo9.Location = new System.Drawing.Point(152, 30);
            this.txtWeaveInfo9.Name = "txtWeaveInfo9";
            this.txtWeaveInfo9.ReadOnly = true;
            this.txtWeaveInfo9.Size = new System.Drawing.Size(80, 23);
            this.txtWeaveInfo9.TabIndex = 1;
            this.txtWeaveInfo9.Text = "24000 - 36000";
            this.txtWeaveInfo9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbWeaveProduct
            // 
            this.cbbWeaveProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWeaveProduct.DropDownWidth = 140;
            this.cbbWeaveProduct.Location = new System.Drawing.Point(3, 3);
            this.cbbWeaveProduct.Name = "cbbWeaveProduct";
            this.cbbWeaveProduct.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.cbbWeaveProduct.Size = new System.Drawing.Size(229, 21);
            this.cbbWeaveProduct.TabIndex = 18;
            this.cbbWeaveProduct.SelectedIndexChanged += new System.EventHandler(this.cbbWeaveProduct_SelectedIndexChanged);
            // 
            // txtWeaveInfo8
            // 
            this.txtWeaveInfo8.Location = new System.Drawing.Point(42, 30);
            this.txtWeaveInfo8.Name = "txtWeaveInfo8";
            this.txtWeaveInfo8.ReadOnly = true;
            this.txtWeaveInfo8.Size = new System.Drawing.Size(70, 23);
            this.txtWeaveInfo8.TabIndex = 1;
            this.txtWeaveInfo8.Text = "90% - 20%";
            this.txtWeaveInfo8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnWeaveCreate2
            // 
            this.btnWeaveCreate2.Location = new System.Drawing.Point(126, 3);
            this.btnWeaveCreate2.Name = "btnWeaveCreate2";
            this.btnWeaveCreate2.Size = new System.Drawing.Size(80, 25);
            this.btnWeaveCreate2.TabIndex = 4;
            this.btnWeaveCreate2.Values.Text = "Huỷ";
            this.btnWeaveCreate2.Click += new System.EventHandler(this.btnWeaveCreate2_Click);
            // 
            // btnWeaveCreate1
            // 
            this.btnWeaveCreate1.Location = new System.Drawing.Point(39, 3);
            this.btnWeaveCreate1.Name = "btnWeaveCreate1";
            this.btnWeaveCreate1.Size = new System.Drawing.Size(80, 25);
            this.btnWeaveCreate1.TabIndex = 4;
            this.btnWeaveCreate1.Values.Text = "OK";
            this.btnWeaveCreate1.Click += new System.EventHandler(this.btnWeaveCreate1_Click);
            // 
            // grpWeaveParty
            // 
            this.grpWeaveParty.AutoSize = true;
            this.grpWeaveParty.Location = new System.Drawing.Point(3, 90);
            this.grpWeaveParty.Name = "grpWeaveParty";
            // 
            // grpWeaveParty.Panel
            // 
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveQuit);
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveInvite);
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveDisband);
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveMake);
            this.grpWeaveParty.Panel.Controls.Add(this.lstWeaveMember);
            this.grpWeaveParty.Panel.Controls.Add(this.grpWeaveInfo2);
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveCreate);
            this.grpWeaveParty.Panel.Controls.Add(this.btnWeaveTeam);
            this.grpWeaveParty.Size = new System.Drawing.Size(266, 194);
            this.grpWeaveParty.TabIndex = 20;
            // 
            // btnWeaveQuit
            // 
            this.btnWeaveQuit.Enabled = false;
            this.btnWeaveQuit.Location = new System.Drawing.Point(201, 82);
            this.btnWeaveQuit.Name = "btnWeaveQuit";
            this.btnWeaveQuit.Size = new System.Drawing.Size(60, 30);
            this.btnWeaveQuit.TabIndex = 7;
            this.btnWeaveQuit.Values.Text = "Thoát";
            this.btnWeaveQuit.Click += new System.EventHandler(this.btnWeaveQuit_Click);
            // 
            // btnWeaveInvite
            // 
            this.btnWeaveInvite.Enabled = false;
            this.btnWeaveInvite.Location = new System.Drawing.Point(135, 82);
            this.btnWeaveInvite.Name = "btnWeaveInvite";
            this.btnWeaveInvite.Size = new System.Drawing.Size(60, 30);
            this.btnWeaveInvite.TabIndex = 6;
            this.btnWeaveInvite.Values.Text = "Mời";
            this.btnWeaveInvite.Click += new System.EventHandler(this.btnWeaveInvite_Click);
            // 
            // btnWeaveDisband
            // 
            this.btnWeaveDisband.Enabled = false;
            this.btnWeaveDisband.Location = new System.Drawing.Point(201, 46);
            this.btnWeaveDisband.Name = "btnWeaveDisband";
            this.btnWeaveDisband.Size = new System.Drawing.Size(60, 30);
            this.btnWeaveDisband.TabIndex = 5;
            this.btnWeaveDisband.Values.Text = "Giải tán";
            this.btnWeaveDisband.Click += new System.EventHandler(this.btnWeaveDisband_Click);
            // 
            // btnWeaveMake
            // 
            this.btnWeaveMake.Enabled = false;
            this.btnWeaveMake.Location = new System.Drawing.Point(135, 46);
            this.btnWeaveMake.Name = "btnWeaveMake";
            this.btnWeaveMake.Size = new System.Drawing.Size(60, 30);
            this.btnWeaveMake.TabIndex = 4;
            this.btnWeaveMake.Values.Text = "Chế tạo";
            this.btnWeaveMake.Click += new System.EventHandler(this.btnWeaveMake_Click);
            // 
            // lstWeaveMember
            // 
            this.lstWeaveMember.Enabled = false;
            this.lstWeaveMember.Location = new System.Drawing.Point(3, 125);
            this.lstWeaveMember.Name = "lstWeaveMember";
            this.lstWeaveMember.Size = new System.Drawing.Size(258, 64);
            this.lstWeaveMember.TabIndex = 3;
            this.lstWeaveMember.SelectedValueChanged += new System.EventHandler(this.lstWeaveMember_SelectedValueChanged);
            // 
            // grpWeaveInfo2
            // 
            this.grpWeaveInfo2.AutoSize = true;
            this.grpWeaveInfo2.Enabled = false;
            this.grpWeaveInfo2.Location = new System.Drawing.Point(3, 39);
            this.grpWeaveInfo2.Name = "grpWeaveInfo2";
            // 
            // grpWeaveInfo2.Panel
            // 
            this.grpWeaveInfo2.Panel.Controls.Add(this.txtWeaveInfo7);
            this.grpWeaveInfo2.Panel.Controls.Add(this.txtWeaveInfo6);
            this.grpWeaveInfo2.Panel.Controls.Add(this.lblWeaveInfo7);
            this.grpWeaveInfo2.Panel.Controls.Add(this.lblWeaveInfo6);
            this.grpWeaveInfo2.Panel.Controls.Add(this.txtWeaveInfo5);
            this.grpWeaveInfo2.Panel.Controls.Add(this.lblWeaveInfo5);
            this.grpWeaveInfo2.Size = new System.Drawing.Size(126, 83);
            this.grpWeaveInfo2.TabIndex = 2;
            // 
            // txtWeaveInfo7
            // 
            this.txtWeaveInfo7.Location = new System.Drawing.Point(41, 55);
            this.txtWeaveInfo7.Name = "txtWeaveInfo7";
            this.txtWeaveInfo7.ReadOnly = true;
            this.txtWeaveInfo7.Size = new System.Drawing.Size(80, 23);
            this.txtWeaveInfo7.TabIndex = 5;
            this.txtWeaveInfo7.Text = "12000 - 45000";
            this.txtWeaveInfo7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWeaveInfo6
            // 
            this.txtWeaveInfo6.Location = new System.Drawing.Point(41, 29);
            this.txtWeaveInfo6.Name = "txtWeaveInfo6";
            this.txtWeaveInfo6.ReadOnly = true;
            this.txtWeaveInfo6.Size = new System.Drawing.Size(80, 23);
            this.txtWeaveInfo6.TabIndex = 4;
            this.txtWeaveInfo6.Text = "102% - 44%";
            this.txtWeaveInfo6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWeaveInfo7
            // 
            this.lblWeaveInfo7.Location = new System.Drawing.Point(3, 55);
            this.lblWeaveInfo7.Name = "lblWeaveInfo7";
            this.lblWeaveInfo7.Size = new System.Drawing.Size(28, 20);
            this.lblWeaveInfo7.TabIndex = 3;
            this.lblWeaveInfo7.Values.Text = "Giá";
            // 
            // lblWeaveInfo6
            // 
            this.lblWeaveInfo6.Location = new System.Drawing.Point(3, 29);
            this.lblWeaveInfo6.Name = "lblWeaveInfo6";
            this.lblWeaveInfo6.Size = new System.Drawing.Size(33, 20);
            this.lblWeaveInfo6.TabIndex = 2;
            this.lblWeaveInfo6.Values.Text = "Tỉ lệ";
            // 
            // txtWeaveInfo5
            // 
            this.txtWeaveInfo5.Location = new System.Drawing.Point(41, 3);
            this.txtWeaveInfo5.Name = "txtWeaveInfo5";
            this.txtWeaveInfo5.ReadOnly = true;
            this.txtWeaveInfo5.Size = new System.Drawing.Size(80, 23);
            this.txtWeaveInfo5.TabIndex = 1;
            this.txtWeaveInfo5.Text = "48";
            this.txtWeaveInfo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWeaveInfo5
            // 
            this.lblWeaveInfo5.Location = new System.Drawing.Point(3, 3);
            this.lblWeaveInfo5.Name = "lblWeaveInfo5";
            this.lblWeaveInfo5.Size = new System.Drawing.Size(32, 20);
            this.lblWeaveInfo5.TabIndex = 0;
            this.lblWeaveInfo5.Values.Text = "Cấp";
            // 
            // btnWeaveCreate
            // 
            this.btnWeaveCreate.Location = new System.Drawing.Point(135, 3);
            this.btnWeaveCreate.Name = "btnWeaveCreate";
            this.btnWeaveCreate.Size = new System.Drawing.Size(126, 30);
            this.btnWeaveCreate.TabIndex = 1;
            this.btnWeaveCreate.Values.Text = "Lập tổ đội";
            this.btnWeaveCreate.Click += new System.EventHandler(this.btnWeaveCreate_Click);
            // 
            // btnWeaveTeam
            // 
            this.btnWeaveTeam.Location = new System.Drawing.Point(3, 3);
            this.btnWeaveTeam.Name = "btnWeaveTeam";
            this.btnWeaveTeam.Size = new System.Drawing.Size(126, 30);
            this.btnWeaveTeam.TabIndex = 0;
            this.btnWeaveTeam.Values.Text = "5 tổ đội";
            // 
            // grpWeaveInfo
            // 
            this.grpWeaveInfo.AutoSize = true;
            this.grpWeaveInfo.Location = new System.Drawing.Point(3, 30);
            this.grpWeaveInfo.Name = "grpWeaveInfo";
            // 
            // grpWeaveInfo.Panel
            // 
            this.grpWeaveInfo.Panel.Controls.Add(this.txtWeaveInfo4);
            this.grpWeaveInfo.Panel.Controls.Add(this.txtWeaveInfo3);
            this.grpWeaveInfo.Panel.Controls.Add(this.txtWeaveInfo2);
            this.grpWeaveInfo.Panel.Controls.Add(this.txtWeaveInfo1);
            this.grpWeaveInfo.Panel.Controls.Add(this.lblWeaveInfo4);
            this.grpWeaveInfo.Panel.Controls.Add(this.lblWeaveInfo3);
            this.grpWeaveInfo.Panel.Controls.Add(this.lblWeaveInfo2);
            this.grpWeaveInfo.Panel.Controls.Add(this.lblWeaveInfo1);
            this.grpWeaveInfo.Size = new System.Drawing.Size(233, 57);
            this.grpWeaveInfo.TabIndex = 19;
            // 
            // txtWeaveInfo4
            // 
            this.txtWeaveInfo4.Location = new System.Drawing.Point(178, 29);
            this.txtWeaveInfo4.Name = "txtWeaveInfo4";
            this.txtWeaveInfo4.ReadOnly = true;
            this.txtWeaveInfo4.Size = new System.Drawing.Size(50, 23);
            this.txtWeaveInfo4.TabIndex = 7;
            this.txtWeaveInfo4.Text = "10/10";
            this.txtWeaveInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWeaveInfo3
            // 
            this.txtWeaveInfo3.Location = new System.Drawing.Point(178, 3);
            this.txtWeaveInfo3.Name = "txtWeaveInfo3";
            this.txtWeaveInfo3.ReadOnly = true;
            this.txtWeaveInfo3.Size = new System.Drawing.Size(50, 23);
            this.txtWeaveInfo3.TabIndex = 6;
            this.txtWeaveInfo3.Text = "25 - 25";
            this.txtWeaveInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWeaveInfo2
            // 
            this.txtWeaveInfo2.Location = new System.Drawing.Point(79, 29);
            this.txtWeaveInfo2.Name = "txtWeaveInfo2";
            this.txtWeaveInfo2.ReadOnly = true;
            this.txtWeaveInfo2.Size = new System.Drawing.Size(50, 23);
            this.txtWeaveInfo2.TabIndex = 5;
            this.txtWeaveInfo2.Text = "150";
            this.txtWeaveInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWeaveInfo1
            // 
            this.txtWeaveInfo1.Location = new System.Drawing.Point(79, 3);
            this.txtWeaveInfo1.Name = "txtWeaveInfo1";
            this.txtWeaveInfo1.ReadOnly = true;
            this.txtWeaveInfo1.Size = new System.Drawing.Size(50, 23);
            this.txtWeaveInfo1.TabIndex = 4;
            this.txtWeaveInfo1.Text = "50 Cấp";
            this.txtWeaveInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWeaveInfo4
            // 
            this.lblWeaveInfo4.Location = new System.Drawing.Point(137, 29);
            this.lblWeaveInfo4.Name = "lblWeaveInfo4";
            this.lblWeaveInfo4.Size = new System.Drawing.Size(35, 20);
            this.lblWeaveInfo4.TabIndex = 3;
            this.lblWeaveInfo4.Values.Text = "Lượt";
            // 
            // lblWeaveInfo3
            // 
            this.lblWeaveInfo3.Location = new System.Drawing.Point(137, 3);
            this.lblWeaveInfo3.Name = "lblWeaveInfo3";
            this.lblWeaveInfo3.Size = new System.Drawing.Size(33, 20);
            this.lblWeaveInfo3.TabIndex = 2;
            this.lblWeaveInfo3.Values.Text = "Tỉ lệ";
            // 
            // lblWeaveInfo2
            // 
            this.lblWeaveInfo2.Location = new System.Drawing.Point(3, 29);
            this.lblWeaveInfo2.Name = "lblWeaveInfo2";
            this.lblWeaveInfo2.Size = new System.Drawing.Size(52, 20);
            this.lblWeaveInfo2.TabIndex = 1;
            this.lblWeaveInfo2.Values.Text = "Giá bán";
            // 
            // lblWeaveInfo1
            // 
            this.lblWeaveInfo1.Location = new System.Drawing.Point(3, 3);
            this.lblWeaveInfo1.Name = "lblWeaveInfo1";
            this.lblWeaveInfo1.Size = new System.Drawing.Size(70, 20);
            this.lblWeaveInfo1.TabIndex = 0;
            this.lblWeaveInfo1.Values.Text = "Công nhân";
            // 
            // chkWeave
            // 
            this.chkWeave.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkWeave.Location = new System.Drawing.Point(3, 3);
            this.chkWeave.Name = "chkWeave";
            this.chkWeave.Size = new System.Drawing.Size(91, 20);
            this.chkWeave.TabIndex = 17;
            this.chkWeave.Text = "Tự động dệt";
            this.chkWeave.Values.Text = "Tự động dệt";
            this.chkWeave.CheckedChanged += new System.EventHandler(this.chkWeave_CheckedChanged);
            // 
            // lblWeaveProduct
            // 
            this.lblWeaveProduct.Location = new System.Drawing.Point(325, 4);
            this.lblWeaveProduct.Name = "lblWeaveProduct";
            this.lblWeaveProduct.Size = new System.Drawing.Size(50, 20);
            this.lblWeaveProduct.TabIndex = 0;
            this.lblWeaveProduct.Values.Text = "Cấp vải";
            // 
            // cbbWeaveMode
            // 
            this.cbbWeaveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWeaveMode.DropDownWidth = 140;
            this.cbbWeaveMode.Location = new System.Drawing.Point(219, 3);
            this.cbbWeaveMode.Name = "cbbWeaveMode";
            this.cbbWeaveMode.Size = new System.Drawing.Size(100, 21);
            this.cbbWeaveMode.TabIndex = 18;
            // 
            // lblWeaveMode
            // 
            this.lblWeaveMode.Location = new System.Drawing.Point(163, 3);
            this.lblWeaveMode.Name = "lblWeaveMode";
            this.lblWeaveMode.Size = new System.Drawing.Size(50, 20);
            this.lblWeaveMode.TabIndex = 0;
            this.lblWeaveMode.Values.Text = "Chế độ";
            // 
            // numWeaveLimit
            // 
            this.numWeaveLimit.Location = new System.Drawing.Point(144, 289);
            this.numWeaveLimit.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numWeaveLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeaveLimit.Name = "numWeaveLimit";
            this.numWeaveLimit.Size = new System.Drawing.Size(36, 22);
            this.numWeaveLimit.TabIndex = 23;
            this.numWeaveLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWeaveLimit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkWeaveMake
            // 
            this.chkWeaveMake.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkWeaveMake.Location = new System.Drawing.Point(3, 290);
            this.chkWeaveMake.Name = "chkWeaveMake";
            this.chkWeaveMake.Size = new System.Drawing.Size(230, 20);
            this.chkWeaveMake.TabIndex = 22;
            this.chkWeaveMake.Text = "Tự động dệt khi có >=               người";
            this.chkWeaveMake.Values.Text = "Tự động dệt khi có >=               người";
            // 
            // pagMerchant
            // 
            this.pagMerchant.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pagMerchant.Flags = 65534;
            this.pagMerchant.LastVisibleSet = true;
            this.pagMerchant.MinimumSize = new System.Drawing.Size(50, 50);
            this.pagMerchant.Name = "pagMerchant";
            this.pagMerchant.Size = new System.Drawing.Size(498, 364);
            this.pagMerchant.Text = "Thương minh";
            this.pagMerchant.ToolTipTitle = "Page ToolTip";
            this.pagMerchant.UniqueName = "AAAC724AEC0349A027B6BF0C7F749DCE";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(909, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 25);
            this.btnSave.TabIndex = 21;
            this.btnSave.Values.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numUpdate
            // 
            this.numUpdate.Location = new System.Drawing.Point(683, 3);
            this.numUpdate.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpdate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpdate.Name = "numUpdate";
            this.numUpdate.Size = new System.Drawing.Size(72, 22);
            this.numUpdate.TabIndex = 19;
            this.numUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpdate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnChatExpand
            // 
            this.btnChatExpand.Location = new System.Drawing.Point(322, 473);
            this.btnChatExpand.Name = "btnChatExpand";
            this.btnChatExpand.Size = new System.Drawing.Size(21, 21);
            this.btnChatExpand.TabIndex = 16;
            this.btnChatExpand.Values.Text = "+";
            this.btnChatExpand.Click += new System.EventHandler(this.btnChatExpand_Click);
            // 
            // grpLog
            // 
            this.grpLog.AutoSize = true;
            this.grpLog.Location = new System.Drawing.Point(3, 500);
            this.grpLog.Name = "grpLog";
            // 
            // grpLog.Panel
            // 
            this.grpLog.Panel.Controls.Add(this.btnLog);
            this.grpLog.Panel.Controls.Add(this.lblPassword);
            this.grpLog.Panel.Controls.Add(this.lblUsername);
            this.grpLog.Panel.Controls.Add(this.lblServer);
            this.grpLog.Panel.Controls.Add(this.txtPassword);
            this.grpLog.Panel.Controls.Add(this.txtServer);
            this.grpLog.Panel.Controls.Add(this.txtUsername);
            this.grpLog.Size = new System.Drawing.Size(236, 145);
            this.grpLog.TabIndex = 4;
            this.grpLog.Text = "Đăng nhập";
            this.grpLog.Values.Heading = "Đăng nhập";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(53, 82);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(126, 34);
            this.btnLog.TabIndex = 5;
            this.btnLog.Values.Text = "Đăng nhập";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(3, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(62, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Values.Text = "Mật khẩu";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(3, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 20);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Values.Text = "Tài khoản";
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(3, 4);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(101, 20);
            this.lblServer.TabIndex = 6;
            this.lblServer.Values.Text = "Server (Nhập số)";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(72, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(157, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(110, 4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(119, 23);
            this.txtServer.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(72, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(157, 23);
            this.txtUsername.TabIndex = 3;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(83, 474);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(233, 23);
            this.txtChat.TabIndex = 15;
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // cbbChat
            // 
            this.cbbChat.DropDownHeight = 400;
            this.cbbChat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChat.DropDownWidth = 75;
            this.cbbChat.Location = new System.Drawing.Point(2, 474);
            this.cbbChat.Name = "cbbChat";
            this.cbbChat.Size = new System.Drawing.Size(75, 21);
            this.cbbChat.TabIndex = 14;
            // 
            // navChat
            // 
            this.navChat.AllowPageReorder = false;
            this.navChat.Bar.ItemAlignment = ComponentFactory.Krypton.Toolkit.RelativePositionAlign.Center;
            this.navChat.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.navChat.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.navChat.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navChat.Button.CloseButtonShortcut = System.Windows.Forms.Keys.None;
            this.navChat.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.None;
            this.navChat.Button.ContextButtonShortcut = System.Windows.Forms.Keys.None;
            this.navChat.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navChat.Button.NextButtonShortcut = System.Windows.Forms.Keys.None;
            this.navChat.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.None;
            this.navChat.Button.PreviousButtonShortcut = System.Windows.Forms.Keys.None;
            this.navChat.Location = new System.Drawing.Point(3, 316);
            this.navChat.Name = "navChat";
            this.navChat.Size = new System.Drawing.Size(340, 152);
            this.navChat.TabIndex = 13;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(909, 65);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(127, 25);
            this.btnAuto.TabIndex = 12;
            this.btnAuto.Values.Text = "Bắt đầu";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(3, 145);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(340, 165);
            this.txtLogs.TabIndex = 5;
            this.txtLogs.Text = "";
            this.txtLogs.TextChanged += new System.EventHandler(this.txtLogs_TextChanged);
            // 
            // tmrData
            // 
            this.tmrData.Interval = 1;
            this.tmrData.Tick += new System.EventHandler(this.tmrData_Tick);
            // 
            // tmrCd
            // 
            this.tmrCd.Interval = 1000;
            this.tmrCd.Tick += new System.EventHandler(this.tmrCd_Tick);
            // 
            // tmrReq
            // 
            this.tmrReq.Interval = 1000;
            this.tmrReq.Tick += new System.EventHandler(this.tmrReq_Tick);
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "Menu Item\r\n2121\r\n332\r\n3";
            // 
            // chksetNav
            // 
            this.chksetNav.AllowUncheck = true;
            this.chksetNav.CheckButtons.Add(this.btnWorkshop);
            this.chksetNav.CheckButtons.Add(this.btnPower);
            this.chksetNav.CheckButtons.Add(this.btnShop);
            this.chksetNav.CheckButtons.Add(this.btnOthers);
            this.chksetNav.CheckButtons.Add(this.btnMsg);
            // 
            // btnImposeAnswer1
            // 
            this.btnImposeAnswer1.Location = new System.Drawing.Point(3, 87);
            this.btnImposeAnswer1.Name = "btnImposeAnswer1";
            this.btnImposeAnswer1.Size = new System.Drawing.Size(382, 25);
            this.btnImposeAnswer1.TabIndex = 10;
            this.btnImposeAnswer1.Values.Text = "Thu thuế";
            this.btnImposeAnswer1.Click += new System.EventHandler(this.btnImposeAnswer1_Click);
            // 
            // btnImposeAnswer2
            // 
            this.btnImposeAnswer2.Location = new System.Drawing.Point(3, 118);
            this.btnImposeAnswer2.Name = "btnImposeAnswer2";
            this.btnImposeAnswer2.Size = new System.Drawing.Size(382, 25);
            this.btnImposeAnswer2.TabIndex = 10;
            this.btnImposeAnswer2.Values.Text = "Thu thuế";
            this.btnImposeAnswer2.Click += new System.EventHandler(this.btnImposeAnswer2_Click);
            // 
            // lblImposeQuest
            // 
            this.lblImposeQuest.AutoSize = false;
            this.lblImposeQuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImposeQuest.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (30)))), ((int) (((byte) (57)))), ((int) (((byte) (91)))));
            this.lblImposeQuest.Location = new System.Drawing.Point(3, 3);
            this.lblImposeQuest.Name = "lblImposeQuest";
            this.lblImposeQuest.Size = new System.Drawing.Size(382, 81);
            this.lblImposeQuest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVassalLv
            // 
            this.lblVassalLv.Location = new System.Drawing.Point(3, 3);
            this.lblVassalLv.Name = "lblVassalLv";
            this.lblVassalLv.Size = new System.Drawing.Size(32, 20);
            this.lblVassalLv.TabIndex = 4;
            this.lblVassalLv.Values.Text = "Cấp";
            // 
            // lblVassalArea
            // 
            this.lblVassalArea.Location = new System.Drawing.Point(3, 81);
            this.lblVassalArea.Name = "lblVassalArea";
            this.lblVassalArea.Size = new System.Drawing.Size(36, 20);
            this.lblVassalArea.TabIndex = 3;
            this.lblVassalArea.Values.Text = "Vị trí";
            // 
            // lblVassalOffice
            // 
            this.lblVassalOffice.Location = new System.Drawing.Point(3, 29);
            this.lblVassalOffice.Name = "lblVassalOffice";
            this.lblVassalOffice.Size = new System.Drawing.Size(50, 20);
            this.lblVassalOffice.TabIndex = 8;
            this.lblVassalOffice.Values.Text = "Chức vị";
            // 
            // lblVassalCopper
            // 
            this.lblVassalCopper.Location = new System.Drawing.Point(3, 107);
            this.lblVassalCopper.Name = "lblVassalCopper";
            this.lblVassalCopper.Size = new System.Drawing.Size(96, 20);
            this.lblVassalCopper.TabIndex = 7;
            this.lblVassalCopper.Values.Text = "Số bạc được trả";
            // 
            // lblVassalLegion
            // 
            this.lblVassalLegion.Location = new System.Drawing.Point(3, 55);
            this.lblVassalLegion.Name = "lblVassalLegion";
            this.lblVassalLegion.Size = new System.Drawing.Size(38, 20);
            this.lblVassalLegion.TabIndex = 5;
            this.lblVassalLegion.Values.Text = "Bang";
            // 
            // lblVassalUpdate
            // 
            this.lblVassalUpdate.Location = new System.Drawing.Point(3, 133);
            this.lblVassalUpdate.Name = "lblVassalUpdate";
            this.lblVassalUpdate.Size = new System.Drawing.Size(77, 20);
            this.lblVassalUpdate.TabIndex = 6;
            this.lblVassalUpdate.Values.Text = "Lần thu cuối";
            // 
            // barFoodBuy
            // 
            this.barFoodBuy.LargeChange = 100;
            this.barFoodBuy.Location = new System.Drawing.Point(3, 3);
            this.barFoodBuy.Maximum = 1000;
            this.barFoodBuy.Minimum = 1;
            this.barFoodBuy.Name = "barFoodBuy";
            this.barFoodBuy.Size = new System.Drawing.Size(324, 45);
            this.barFoodBuy.TabIndex = 0;
            this.barFoodBuy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodBuy.Value = 1;
            this.barFoodBuy.Scroll += new System.EventHandler(this.barFoodBuy_Scroll);
            // 
            // btnFoodBuy
            // 
            this.btnFoodBuy.Location = new System.Drawing.Point(231, 29);
            this.btnFoodBuy.Name = "btnFoodBuy";
            this.btnFoodBuy.Size = new System.Drawing.Size(96, 25);
            this.btnFoodBuy.TabIndex = 1;
            this.btnFoodBuy.Values.Text = "Mua lúa";
            this.btnFoodBuy.Click += new System.EventHandler(this.btnFoodBuy_Click);
            // 
            // lblFoodBuy
            // 
            this.lblFoodBuy.AutoSize = false;
            this.lblFoodBuy.Location = new System.Drawing.Point(3, 29);
            this.lblFoodBuy.Name = "lblFoodBuy";
            this.lblFoodBuy.Size = new System.Drawing.Size(222, 25);
            this.lblFoodBuy.TabIndex = 2;
            this.lblFoodBuy.Values.Text = "kryptonLabel3";
            // 
            // barFoodSell
            // 
            this.barFoodSell.LargeChange = 100;
            this.barFoodSell.Location = new System.Drawing.Point(3, 3);
            this.barFoodSell.Maximum = 1000;
            this.barFoodSell.Minimum = 1;
            this.barFoodSell.Name = "barFoodSell";
            this.barFoodSell.Size = new System.Drawing.Size(324, 45);
            this.barFoodSell.TabIndex = 0;
            this.barFoodSell.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodSell.Value = 1;
            this.barFoodSell.Scroll += new System.EventHandler(this.barFoodSell_Scroll);
            // 
            // btnFoodSell
            // 
            this.btnFoodSell.Location = new System.Drawing.Point(231, 29);
            this.btnFoodSell.Name = "btnFoodSell";
            this.btnFoodSell.Size = new System.Drawing.Size(96, 25);
            this.btnFoodSell.TabIndex = 1;
            this.btnFoodSell.Values.Text = "Bán lúa";
            this.btnFoodSell.Click += new System.EventHandler(this.btnFoodSell_Click);
            // 
            // lblFoodSell
            // 
            this.lblFoodSell.AutoSize = false;
            this.lblFoodSell.Location = new System.Drawing.Point(3, 29);
            this.lblFoodSell.Name = "lblFoodSell";
            this.lblFoodSell.Size = new System.Drawing.Size(222, 25);
            this.lblFoodSell.TabIndex = 2;
            this.lblFoodSell.Values.Text = "kryptonLabel3";
            // 
            // frmAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAcc);
            this.Name = "frmAcc";
            this.Size = new System.Drawing.Size(2000, 805);
            ((System.ComponentModel.ISupportInitialize) (this.pnlAcc)).EndInit();
            this.pnlAcc.ResumeLayout(false);
            this.pnlAcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.navPower)).EndInit();
            this.navPower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pagArmy)).EndInit();
            this.pagArmy.ResumeLayout(false);
            this.pagArmy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyParty.Panel)).EndInit();
            this.grpArmyParty.Panel.ResumeLayout(false);
            this.grpArmyParty.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyParty)).EndInit();
            this.grpArmyParty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyList.Panel)).EndInit();
            this.grpArmyList.Panel.ResumeLayout(false);
            this.grpArmyList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyList)).EndInit();
            this.grpArmyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmyMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyInfo.Panel)).EndInit();
            this.grpArmyInfo.Panel.ResumeLayout(false);
            this.grpArmyInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpArmyInfo)).EndInit();
            this.grpArmyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.cbbArmy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagCampaign)).EndInit();
            this.pagCampaign.ResumeLayout(false);
            this.pagCampaign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampInfo.Panel)).EndInit();
            this.grpCampInfo.Panel.ResumeLayout(false);
            this.grpCampInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampInfo)).EndInit();
            this.grpCampInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grpCampParty.Panel)).EndInit();
            this.grpCampParty.Panel.ResumeLayout(false);
            this.grpCampParty.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpCampParty)).EndInit();
            this.grpCampParty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbCamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pnlCampMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.navMsg)).EndInit();
            this.navMsg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pagMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pnlNav)).EndInit();
            this.pnlNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.navShop)).EndInit();
            this.navShop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pagBag)).EndInit();
            this.pagBag.ResumeLayout(false);
            this.pagBag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpBag.Panel)).EndInit();
            this.grpBag.Panel.ResumeLayout(false);
            this.grpBag.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpBag)).EndInit();
            this.grpBag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagUpg)).EndInit();
            this.pagUpg.ResumeLayout(false);
            this.pagUpg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpUpg.Panel)).EndInit();
            this.grpUpg.Panel.ResumeLayout(false);
            this.grpUpg.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpUpg)).EndInit();
            this.grpUpg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbUpg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.cbbUpg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.navOthers)).EndInit();
            this.navOthers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pagForces)).EndInit();
            this.pagForces.ResumeLayout(false);
            this.pagForces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.navWorkshop)).EndInit();
            this.navWorkshop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pagWeave)).EndInit();
            this.pagWeave.ResumeLayout(false);
            this.pagWeave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveCreate.Panel)).EndInit();
            this.grpWeaveCreate.Panel.ResumeLayout(false);
            this.grpWeaveCreate.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveCreate)).EndInit();
            this.grpWeaveCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveWorker.Panel)).EndInit();
            this.grpWeaveWorker.Panel.ResumeLayout(false);
            this.grpWeaveWorker.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveWorker)).EndInit();
            this.grpWeaveWorker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveProduct.Panel)).EndInit();
            this.grpWeaveProduct.Panel.ResumeLayout(false);
            this.grpWeaveProduct.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveProduct)).EndInit();
            this.grpWeaveProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveParty.Panel)).EndInit();
            this.grpWeaveParty.Panel.ResumeLayout(false);
            this.grpWeaveParty.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveParty)).EndInit();
            this.grpWeaveParty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo2.Panel)).EndInit();
            this.grpWeaveInfo2.Panel.ResumeLayout(false);
            this.grpWeaveInfo2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo2)).EndInit();
            this.grpWeaveInfo2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo.Panel)).EndInit();
            this.grpWeaveInfo.Panel.ResumeLayout(false);
            this.grpWeaveInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpWeaveInfo)).EndInit();
            this.grpWeaveInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbWeaveMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pagMerchant)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grpLog.Panel)).EndInit();
            this.grpLog.Panel.ResumeLayout(false);
            this.grpLog.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grpLog)).EndInit();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.cbbChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.navChat)).EndInit();
            this.navChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.chksetNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.barFoodBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.barFoodSell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlAcc;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpLog;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUsername;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblServer;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassword;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUsername;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLog;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtLogs;
        private System.Windows.Forms.Timer tmrData;
        private System.Windows.Forms.Timer tmrCd;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navPower;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagArmy;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagCampaign;
        private System.Windows.Forms.Timer tmrReq;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navChat;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbChat;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtChat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnChatExpand;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnPower;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnWorkshop;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navWorkshop;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagWeave;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpWeaveInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkWeave;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbWeaveMode;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagMerchant;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpWeaveParty;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveQuit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveInvite;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveDisband;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveMake;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstWeaveMember;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpWeaveInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnWeaveTeam;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveMode;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpWeaveCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpWeaveProduct;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo8;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbWeaveProduct;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveInfo9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveInfo9;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpWeaveWorker;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveSkill1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveExp;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbWeaveWorker;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWeaveExp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveShift;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveSkill2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveCreate2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnWeaveCreate1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnAuto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnOthers;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navOthers;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagForces;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numWeaveLimit;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkWeaveMake;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWeaveProduct;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numWeaveProduct;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navShop;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagBag;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagUpg;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkCamp;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpCampInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCampInfo5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCampInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCampInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCampInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCampInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCampInfo5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCampInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCampInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCampInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCampInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpCampParty;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radCamp1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radCamp2;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstCampMember;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampInvite;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampQuit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampDisband;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampAttack;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnCampTeam;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampQuitIn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCampInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbCamp;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblCampCd;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlCampMap;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup grpArmyParty;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radArmy2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radArmy1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstArmyMember;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyInvite;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyQuit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyDisband;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyAttack;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnArmyTeam;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpArmyList;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkArmyCd;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numArmyAttack;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkArmyAttack;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkArmyAll;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox lstArmyList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyDown;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyDel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblArmyMode;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbArmyMode;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkArmy;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpArmyInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnArmyInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtArmyInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtArmyInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtArmyInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblArmyInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblArmyInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblArmyInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbArmy2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbArmy1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbBag;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpBag;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBagBind;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBagSell;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBagDegrade;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagSell;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagSell;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagDegrade;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagDegrade;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBagBindCd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBagBindCd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBag;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbUpg1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpUpg;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgBindCd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgDe;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpgDe;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpgUp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgBindCd;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgDe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpgradeBind;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUpgInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgInfo4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgInfo3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgInfo2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpgInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbUpg2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnShop;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagApp;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkArmyRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numArmyRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlNav;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnMsg;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet chksetNav;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkForcesFree;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkForces;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnForcesRecruit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnForcesFree;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblForcesRecruit;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numForces;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numForcesRecruit;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtServer;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton testButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImposeAnswer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImposeAnswer2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblImposeQuest;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalLv;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalArea;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalOffice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalCopper;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalLegion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalUpdate;
        private TrackBar barFoodBuy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFoodBuy;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFoodBuy;
        private TrackBar barFoodSell;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFoodSell;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFoodSell;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator navMsg;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagMsg;
        private ComponentFactory.Krypton.Navigator.KryptonPage pagRank;
    }
}

