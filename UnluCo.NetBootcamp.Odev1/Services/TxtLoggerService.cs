﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev2.Services
{
    public class TxtLoggerService : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[TxtLogged] - " + message);
        }
    }
}
