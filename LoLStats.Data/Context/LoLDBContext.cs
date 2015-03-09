#region References

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LoLStats.Core.Models.Entities;
using LoLStats.Data.ModelMaps;

#endregion

namespace LoLStats.Data.Context
{
    public class LoLDBContext : DbContext
    {
        #region Constructors

        public LoLDBContext() : base(ConnectionStringName)
        {
        }

        static LoLDBContext()
        {
            ConnectionStringName = "LoLConnection";
        }

        #endregion

        #region Properties

        public static string ConnectionStringName { get; set; }

        public IDbSet<Champion> Champions { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Configurations.Add(new ChampionModelMap());
        }

        #endregion
    }
}