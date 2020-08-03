﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class Enemy
    {
        /// <summary>
        /// Id, Ability, and Type properties
        /// Enemy Species specifically for enemies
        /// </summary>
        public int Id {get; set;}
        public int Abilities {get; set;}
        public string Type {get; set;}

        public Species EnemySpecies { get; set; }

        public enum Species
        {
            Human,
            Elf,
            Gnome,
            Dwarf,
            HalfOrc,
            Dragonborn
        }

    }
}