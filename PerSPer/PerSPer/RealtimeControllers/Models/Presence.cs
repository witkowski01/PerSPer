﻿using System;

namespace InterVision.RealtimeControllers.Models
{
    public class Presence : IPresence
    {
        public Guid Id { get; set; }
        public bool Online { get; set; }
        public string UserName { get; set; }
        public Availability Availability { get; set; }
    }
}