namespace LoLStats.Shared.Models.Entities
{
    public class Champion : Entity
    {
        #region Properties

        public bool Active { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public int RiotId { get; set; }
        public string Title { get; set; }

        #endregion
    }
}