﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Crypts_And_Coders.Models.SpeciesAndClass;

namespace Crypts_And_Coders.Models.DTOs
{
    public class EnemyDTO
    {
        public int Id { get; set; }
        public string Abilities { get; set; }
        public string Type { get; set; }
        public Species Species { get; set; }

        // Navigation properties
        public List<EnemyInLocation> EnemyInLocation { get; set; }
    }
}