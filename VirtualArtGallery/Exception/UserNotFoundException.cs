﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Exception
{
    internal class UserNotFoundException :ApplicationException
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string message) : base(message)
        {

        }

    }
}
