#region References

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LoLStats.Data.Context;
using LoLStats.Shared.Interfaces;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Core.Managers
{
    public class ChampionManager : IChampionManager
    {
        #region Fields

        private readonly LoLDBContext _lolDbContext = new LoLDBContext();

        #endregion

        #region Methods

        public Champion Add(Champion item)
        {
            _lolDbContext.Champions.Add(item);
            _lolDbContext.SaveChanges();

            return item;
        }

        public bool AddOrUpdateAllChampionsFromRiotApi(IEnumerable<Champion> champ)
        {
            foreach (var item in champ)
            {
                var selectedChamp = GetOneByRiotId(item.RiotId);

                if (selectedChamp == null)
                {
                    _lolDbContext.Champions.Add(item);
                }
                else if (selectedChamp.RiotId == item.RiotId)
                {
                    _lolDbContext.Champions.AddOrUpdate(selectedChamp);
                }
            }

            _lolDbContext.SaveChanges();

            return true;
        }

        public Champion DeleteById(int id)
        {
            var champ = GetOneById(id);

            if (champ != null)
            {
                _lolDbContext.Champions.Remove(champ);
            }

            _lolDbContext.SaveChanges();

            return champ;
        }

        public Champion EditById(Champion item, int id)
        {
            throw new NotImplementedException();
        }

        public List<Champion> GetAll()
        {
            var champ = _lolDbContext.Champions.ToList();

            return champ;
        }

        public Champion GetOneById(int id)
        {
            var champ = _lolDbContext.Champions.SingleOrDefault(x => x.Id == id);

            return champ;
        }

        public Champion GetOneByRiotId(int id)
        {
            var champ = _lolDbContext.Champions.SingleOrDefault(x => x.RiotId == id);

            return champ;
        }

        #endregion
    }
}