﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Haandvaerker
    {
        public Haandvaerker()
        {
            Vaerktoejskasse = new HashSet<Vaerktoejskasse>();
        }
        [Key]
        public int HaandvaerkerId { get; set; }
        public DateTime HVAnsaettelsedato { get; set; }
        public string HVEfternavn { get; set; }
        public string HVFagomraade { get; set; }
        public string HVFornavn { get; set; }
        public HashSet<Vaerktoejskasse> Vaerktoejskasse { get; set; }
    }
}
