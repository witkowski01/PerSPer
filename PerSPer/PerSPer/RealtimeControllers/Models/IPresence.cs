﻿using System;

namespace PerSPer.RealtimeControllers.Models
{
    public interface IPresence
    {
        Guid Id { get; set; }
        bool Online { get; set; }
        string UserName { get; set; }
        Availability Availability { get; set; }        
    }
}