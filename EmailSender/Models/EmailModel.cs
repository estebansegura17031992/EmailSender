﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSender.Models
{
    public class EmailModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}