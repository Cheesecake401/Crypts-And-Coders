﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface ICharacterStat
    {
        /// <summary>
        /// Creates a new stat for a specific character in the database
        /// </summary>
        /// <param name="characterStat">CharacterStat information for creation</param>
        /// <returns>Successful result of characterStat creation</returns>
        Task<CharacterStat> Create(CharacterStat characterStat);

        /// <summary>
        /// Get a list of all of a character's stats in the database
        /// </summary>
        /// <returns>Successful result with list of characterStats</returns>
        Task<List<CharacterStat>> GetCharacterStats(int id);

        /// <summary>
        /// Get a specific stat from a character in the database by ID
        /// </summary>
        /// <param name="id">Id of characterStat to search for</param>
        /// <returns>Successful result of specified characterStat</returns>
        Task<CharacterStat> GetCharacterStat(int charId, int statId);

        /// <summary>
        /// Update a given character's stat in the database
        /// </summary>
        /// <param name="id">Id of characterStat to be updated</param>
        /// <param name="characterStat">CharacterStat information for update</param>
        /// <returns>Successful result of specified updated characterStat</returns>
        Task<CharacterStat> Update(CharacterStat characterStat);

        /// <summary>
        /// Delete a character's stat from the database
        /// </summary>
        /// <param name="id">Id of characterStat to be deleted</param>
        /// <returns>Task of completion for characterStat delete</returns>
        Task Delete(int charId, int statId);
    }
}
