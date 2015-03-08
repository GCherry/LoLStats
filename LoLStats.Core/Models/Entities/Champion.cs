namespace LoLStats.Core.Models.Entities
{
    public class Champion : Entity
    {
        #region Properties

        public string Key { get; set; }
        public string Name { get; set; }
        public int RiotId { get; set; }
        public string Title { get; set; }

        #endregion
    }
}