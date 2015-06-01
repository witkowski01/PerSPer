using System;

namespace InterVision.RealtimeControllers.Models
{
    public interface IPeerConnection
    {
        Guid Context { get; set; }
        Guid PeerId { get; set; }
    }
}