using Crypts_And_Coders.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Data
{
    public class CryptsDbContext : IdentityDbContext
    {
        public DbSet<Character> Character { get; set; }

        public CryptsDbContext(DbContextOptions<CryptsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Name = "Galdifor",
                    Species = SpeciesAndClass.Species.Elf,
                    Class = SpeciesAndClass.Class.Thief,
                    WeaponId = 1,
                    LocationId = 1
                },

                new Character
                {
                    Name = "Dragorn",
                    Species = SpeciesAndClass.Species.Dwarf,
                    Class = SpeciesAndClass.Class.Paladin,
                    WeaponId = 1,
                    LocationId = 1
                },

                new Character
                {
                    Name = "Glen",
                    Species = SpeciesAndClass.Species.Human,
                    Class = SpeciesAndClass.Class.Bard,
                    WeaponId = 1,
                    LocationId = 1
                }
            );

            modelBuilder.Entity<Enemy>().HasData(
                new Enemy
                {
                    Id = 1,
                    Abilities = 1,
                    Type = "Warrior",
                    Species = SpeciesAndClass.Species.Goblin,
                },

                new Enemy
                {
                    Id = 2,
                    Abilities = 1,
                    Type = "Beast",
                    Species = SpeciesAndClass.Species.Troll,
                },

                new Enemy
                {
                    Id = 3,
                    Abilities = 1,
                    Type = "Mythical",
                    Species = SpeciesAndClass.Species.Dragon
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Name = "Health Potion",
                    Value = 25
                },

                new Item
                {
                    Name = "Cup",
                    Value = 5
                },

                new Item
                {
                    Name = "Dungeon Key",
                    Value = 100
                }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Faldor",
                    Description = "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains."
                },

                new Location
                {
                    Id = 2,
                    Name = "Murkden",
                    Description = "Plagued by the great war, Murkden remains uninhibited from all intelligent life forms, although various beasts still dwell in the deep marshes."
                },

                new Location
                {
                    Id = 3,
                    Name = "Lyderton",
                    Description = "Lyderton is full of simpletons who prefer to keep war and conflict outside of their borders. It is rich farmland with dense amounts of beautiful wildlife."
                }
            );
        }
    }
}