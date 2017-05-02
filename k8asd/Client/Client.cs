﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public class Client : IClient {
        public event EventHandler<Packet> PacketReceived;
        public event EventHandler<ClientState> StateChanged;

        private Timer dataTimer;
        private Timer testConnectionTimer;

        private bool disconnectedLocking;
        private ClientState state;
        private ClientConfig config;

        private LoginHelper loginHelper;
        private PacketHandler packetHandler;

        private IChatLog chatLog;
        private IMessageLog messageLog;

        public ClientState State {
            get { return state; }
            set {
                state = value;
                StateChanged.Raise(this, value);
            }
        }

        public ClientConfig Config {
            get {
                return config;
            }
            set {
                config = new ClientConfig(value.Data);
            }
        }

        public int PlayerId {
            get {
                if (loginHelper == null) {
                    return 0;
                }
                return Int32.Parse(loginHelper.Session.UserId);
            }
        }

        public string PlayerName {
            get { return ""; } // return infoModel.PlayerName; }
        }

        public Client() {
            dataTimer = new Timer();
            dataTimer.Interval = 3000;
            dataTimer.Tick += OnDataTimerTick;

            testConnectionTimer = new Timer();
            testConnectionTimer.Interval = 1000;
            testConnectionTimer.Tick += OnTestConnectionTimerTick;

            disconnectedLocking = false;
            state = ClientState.Disconnected;

            chatLog = new ChatLog();
            chatLog.Client = this;

            messageLog = new MessageLog();
            messageLog.Client = this;
        }

        public async Task<Packet> SendCommandAsync(int id, params string[] parameters) {
            if (State != ClientState.Connected) {
                // Chưa kết nối.
                return null;
            }
            var packet = await packetHandler.SendCommandAsync(id, parameters);
            if (packet == null) {
                await DisconnectedFromServer();
            }
            return packet;
        }

        public async Task<bool> LogIn(bool parallel) {
            if (State == ClientState.Connected) {
                messageLog.LogInfo("Đã đăng nhập, không cần đăng nhập lại!");
                return false;
            }
            if (State == ClientState.Connecting) {
                messageLog.LogInfo("Đang đang nhập, không cần đăng nhập lại!");
                return false;
            }
            if (State == ClientState.Disconnecting) {
                messageLog.LogInfo("Đang đang xuất, không thể đăng nhập!");
                return false;
            }
            try {
                await LogIn(Config.ServerId, Config.Username, Config.Password, parallel);
                return true;
            } catch (WebException ex) {
                messageLog.LogInfo(ex.Message);
                messageLog.LogInfo("Đăng nhập thất bại!");
                State = ClientState.Disconnected;
                return false;
            }
        }

        public async Task<bool> LogOut() {
            if (State == ClientState.Disconnected) {
                return false;
            }
            if (State == ClientState.Disconnecting) {
                return false;
            }
            if (State == ClientState.Connecting) {
                messageLog.LogInfo("Đang đang nhập, không thể đăng xuất!");
                return false;
            }

            messageLog.LogInfo("Bắt đầu đăng xuất...");
            await Disconnect();
            messageLog.LogInfo("Đăng xuất thành công.");
            return true;
        }

        /// <summary>
        /// Called when the client is suddenly disconnected from the server.
        /// </summary>
        private async Task DisconnectedFromServer() {
            if (disconnectedLocking) {
                return;
            }
            disconnectedLocking = true;
            if (State == ClientState.Connected) {
                messageLog.LogInfo("Mất kết nối với máy chủ.");
                await Disconnect();
            }
            disconnectedLocking = false;
        }

        /// <summary>
        /// Manually disconnects the client.
        /// </summary>
        private async Task Disconnect() {
            Debug.Assert(State == ClientState.Connected);
            State = ClientState.Disconnecting;

            dataTimer.Stop();
            packetHandler.PacketReceived -= OnPacketReceived;

            await packetHandler.Disconnect();

            State = ClientState.Disconnected;
        }

        private async Task<bool> Connect(bool parallel) {
            Debug.Assert(State == ClientState.Connecting);
            await packetHandler.ConnectAsync();

            packetHandler.PacketReceived += OnPacketReceived;
            dataTimer.Start();

            State = ClientState.Connected;

            if (!parallel) {
                var p0 = await SendCommandAsync(10100);
                if (p0 == null) {
                    await DisconnectedFromServer();
                    return false;
                }
            }

            var p1 = await SendCommandAsync(11102);
            if (p1 == null) {
                await DisconnectedFromServer();
                return false;
            }

            // FIXME: handle case character not yet created.
            return true;
        }

        /// <summary>
        /// Attempts to connect the client.
        /// </summary>
        private async Task LogIn(int serverId, string username, string password, bool parallel) {
            Debug.Assert(state == ClientState.Disconnected);
            State = ClientState.Connecting;

            loginHelper = new LoginHelper(username, password);

            messageLog.LogInfo("Bắt đầu đăng nhập tài khoản...");
            var loginAccountStatus = await loginHelper.LoginAccount();
            switch (loginAccountStatus) {
            case LoginStatus.NoConnection:
                messageLog.LogInfo("Không có kết nối mạng.");
                State = ClientState.Disconnected;
                return;
            case LoginStatus.WrongUsernameOrPassword:
                messageLog.LogInfo("Sai tên người dùng hoặc mật khẩu.");
                State = ClientState.Disconnected;
                return;
            case LoginStatus.UnknownError:
                messageLog.LogInfo("Có lỗi xảy ra.");
                State = ClientState.Disconnected;
                return;
            }
            messageLog.LogInfo("Đăng nhập tài khoản thành công.");

            messageLog.LogInfo("Bắt đầu lấy thông tin để kết nối với máy chủ...");
            var loginServerStatus = await loginHelper.LoginServer(serverId);
            switch (loginServerStatus) {
            case LoginStatus.NoConnection:
                messageLog.LogInfo("Không có kết nối mạng.");
                State = ClientState.Disconnected;
                return;
            case LoginStatus.UnknownError:
                messageLog.LogInfo("Có lỗi xảy ra.");
                State = ClientState.Disconnected;
                return;
            }
            messageLog.LogInfo("Lấy thông tin thành công.");

            packetHandler = new PacketHandler(loginHelper.Session);
            messageLog.LogInfo("Bắt đầu kết nối với máy chủ...");
            if (await Connect(parallel)) {
                messageLog.LogInfo("Kết nối với máy chủ thành công.");
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            PacketReceived.Raise(this, packet);
        }

        private async void OnDataTimerTick(object sender, EventArgs e) {
            if (!await packetHandler.ReadData()) {
                await DisconnectedFromServer();
            }
        }

        private async void OnTestConnectionTimerTick(object sender, EventArgs e) {
            if (State == ClientState.Connected) {
                if (!packetHandler.Connected) {
                    await DisconnectedFromServer();
                }
            }
        }
    }
}