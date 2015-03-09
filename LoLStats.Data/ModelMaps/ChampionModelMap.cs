#region References

using LoLStats.Core.Models.Entities;

#endregion

namespace LoLStats.Data.ModelMaps
{
    public class ChampionModelMap : BaseEntityModelMap<Champion>
    {
        #region Constructors

        public ChampionModelMap()
        {
            Property(x => x.Key).IsRequired();
            Property(x => x.Active).IsRequired();
            Property(x => x.Name).IsRequired().HasMaxLength(200);
            Property(x => x.RiotId).IsRequired();
            Property(x => x.Title).IsRequired().HasMaxLength(200);

            ToTable("Champion");
        }

        #endregion
    }
}