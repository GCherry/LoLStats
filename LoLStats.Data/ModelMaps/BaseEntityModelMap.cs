#region References

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LoLStats.Core.Models.Entities;

#endregion

namespace LoLStats.Data.ModelMaps
{
    public class BaseEntityModelMap<T> : EntityTypeConfiguration<T> where T : Entity
    {
        #region Constructors

        public BaseEntityModelMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedOn).IsRequired();
            Property(x => x.ModifiedOn).IsRequired();
        }

        #endregion
    }
}