﻿using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.DTOs;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Crypts_And_Coders.Models.SpeciesAndClass;

namespace CryptsAndTesters
{
    public class EnemyServicesTest : DatabaseTest

    {
        /// <summary>
        /// access interface enemy and construct new db
        /// </summary>
        /// <returns></returns>
        private IEnemy BuildRepo()
        {
            return new EnemyRepository(_db);
        }

        /// <summary>
        /// create enemy test
        /// </summary>
        [Fact]
        public async void CanCreateEnemy()
        {
            Enemy enemy = new Enemy()
            {
                Id = 4,
                Abilities = "Firebreath",
                Type = "Warrior",
            };

            var repository = BuildRepo();

            EnemyDTO enemyDTO = new EnemyDTO()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type
            };

            var saved = await repository.Create(enemyDTO);

            Assert.NotNull(saved);
            Assert.Equal(enemy.Abilities, saved.Abilities);
            Assert.Equal(enemy.Type, saved.Type);
        }

        /// <summary>
        /// get an enemy
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CanReadEnemy()
        {
            Enemy enemy = new Enemy()
            {
                Id = 4,
                Abilities = "Firebreath",
                Type = "Warrior",
            };

            var repo = BuildRepo();

            EnemyDTO enemyDTO = new EnemyDTO()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type
            };

            await repo.Create(enemyDTO);
            var result = await repo.GetEnemy(enemyDTO.Id);

            Assert.Equal(enemy.Id, result.Id);
        }

        /// <summary>
        /// get all enemies
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReadAllEnemies()
        {
            var repo = BuildRepo();

            var result = await repo.GetEnemies();

            // Three from seeded data
            Assert.Equal(3, result.Count);
        }

        /// <summary>
        /// update enemies
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CanUpdateEnemies()
        {
            Enemy enemy = new Enemy()
            {
                Id = 1,
                Abilities = "Firebreath",
                Type = "Warrior",
            };

            var repo = BuildRepo();

            EnemyDTO enemyDTO = new EnemyDTO()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type
            };

            repo.Update(enemyDTO);

            var result = await repo.GetEnemy(1);

            Assert.Equal(1, result.Id);
            Assert.Equal(result.Id, enemy.Id);
            Assert.Equal(result.Abilities, enemy.Abilities);
            Assert.Equal(result.Type, enemy.Type);
        }

        [Fact]
        public async void CanDeleteEnemy()
        {
            var repository = BuildRepo();

            await repository.Delete(1);
            var returnFromMethod = await repository.GetEnemies();

            var expected = new List<string>()
            {
                "Smash", "Beast", "Firebreath", "Mythical"
            };

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Abilities);
                returnList.Add(item.Type);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }
    }
}