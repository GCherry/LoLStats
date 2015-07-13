#region References

using System;
using System.Collections.Generic;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Shared.Interfaces
{
    public interface IChampionManager : IManager<Champion>
    {
        Boolean AddOrUpdateAllChampionsFromRiotApi(IEnumerable<Champion> champ);
        Champion GetOneByRiotId(int riotId);
    }
}