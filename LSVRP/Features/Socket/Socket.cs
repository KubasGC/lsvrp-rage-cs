/*
* LSVRP C# Engine
* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer.
* @Author: Kubas (Jakub Skakuj)
* @StartDate: Jun 2018
*
* @urls:
* 		@RAGE-MP  	    https://rage.mp
* 		@LSVRP:			https://lsvrp.pl
*
* All Rights Reserved
* Copyright prohibited
*/
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LSVRP.Modules;

namespace LSVRP.Features.Socket
{
    public class LsvrpSocket
    {
        private const int BufSize = 8 * 1024;
        private EndPoint _epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback _recv;

        private readonly System.Net.Sockets.Socket _socket =
            new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        private readonly State _state = new State();

        public void Server(string address, int port)
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        private void Receive()
        {
            _socket.BeginReceiveFrom(_state.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv = ar =>
            {
                State so = (State) ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref _epFrom);
                _socket.BeginReceiveFrom(so.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv, so);
                Log.ConsoleLog("SOCKET", $"Odebrano dane... [UDP][{_epFrom.ToString()}][{bytes}]");
                Library.OnSocketGotData(Encoding.UTF8.GetString(so.Buffer, 0, bytes));
            }, _state);
        }

        public class State
        {
            public readonly byte[] Buffer = new byte[BufSize];
        }
    }
}