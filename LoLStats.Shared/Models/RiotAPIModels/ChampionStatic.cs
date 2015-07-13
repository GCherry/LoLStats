#region References

using System;
using Newtonsoft.Json;

#endregion

namespace LoLStats.Shared.Models.RiotAPIModels
{
    /// <summary>
    /// Class representing a champion (Static API).
    /// </summary>
    [Serializable]
    public class ChampionStatic
    {
        #region Constructors


        #endregion

        #region Properties

        /// <summary>
        /// Id of this champion.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Key of this champion.
        /// <para>This is diffrent from the Name attribute!
        /// (Name = ingame display name, Key = codebase name
        /// [Fiddlesticks key = FiddleSticks, Wukong key = MonkeyKing, ... ]</para>
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of this champion.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Title of this champion.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion
    }
}