﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;

namespace PGO_BOT
{
    public class MySettings : ISettings
    {
        public AuthType AuthType { get; set; }
        public double DefaultLatitude { get; set; }
        public double DefaultLongitude { get; set; }
        public double DefaultAltitude { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string PtcPassword { get; set; }
        public string PtcUsername { get; set; }
        public string GoogleUsername { get; set; }
        public string GooglePassword { get; set; }
    }
}
