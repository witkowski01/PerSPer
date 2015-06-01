using System;

namespace InterVision.RealtimeControllers.Models
{    
    public class PeerConnection : IPeerConnection
    {
        public Guid Context { get; set; }
        public Guid PeerId { get; set; }
    }
}