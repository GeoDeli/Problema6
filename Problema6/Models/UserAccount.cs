﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Problema6.Models
{
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }
        public string User { get; set; }
        public string Parola { get; set; }

    }
}