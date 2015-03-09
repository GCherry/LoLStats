#region References

using System;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Shared.Interfaces
{
    public interface IChampionManager : IManager<Champion>
    {
        Boolean UpdateAllChampionsFromRiotApi(Champion champ);
        Boolean UpdateNewChampionsFromRiotApi(Champion champ);
    }
}