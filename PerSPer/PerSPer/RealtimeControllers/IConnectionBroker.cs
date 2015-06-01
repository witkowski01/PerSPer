﻿using System;
using System.Collections.Generic;
using InterVision.RealtimeControllers.Models;
using XSockets.Core.Common.Socket.Event.Interface;

namespace InterVision.RealtimeControllers
{
    public interface IConnectionBroker
    {
        /// <summary>
        /// List of PeerConnections that the Current PeerConnections has connected to
        /// </summary>
        List<IPeerConnection> Connections { get; set; }
        /// <summary>
        /// The Peer of this connection
        /// </summary>
        IPeerConnection Peer { get; set; }
        /// <summary>
        /// Current user status/information
        /// </summary>
        IPresence Presence { get; set; }
        /// <summary>
        /// Distribute signals (SDP's)
        /// </summary>
        /// <param name="signalingModel"></param>
        void ContextSignal(SignalingModel signalingModel);
        /// <summary>
        /// Give this controller a "Generic" behavior
        /// </summary>
        /// <param name="message"></param>
        void OnMessage(IMessage message);
        /// <summary>
        /// Leave a context
        /// </summary>
        void LeaveContext();
        /// <summary>
        /// Current client changes context
        /// </summary>
        /// <param name="contextId"></param>
        void ChangeContext(Guid contextId);
        /// <summary>
        /// Remove another peer by id
        /// </summary>
        /// <param name="recipient"></param>
        void DisconnectPeer(Guid recipient);
        /// <summary>
        /// Notify PeerConnections on the current context that a MediaStream is removed.
        /// </summary>
        /// <param name="streamId"></param>
        void RemoveStream(string streamId);
        /// <summary>
        /// Notify PeerConnections on the current context that a MediaStream is added.
        /// </summary>
        /// <param name="streamId"></param>
        /// <param name="description">JSON</param>
        void AddStream(string streamId, string description);
        /// <summary>
        /// Connect to the current context and Notify peers
        /// </summary>
        void ConnectToContext();


        Guid SaveVoiceMessage(IMessage voiceMessage);
    }
}