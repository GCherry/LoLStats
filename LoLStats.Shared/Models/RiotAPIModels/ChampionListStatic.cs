#region References

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace LoLStats.Shared.Models.RiotAPIModels
{
    /// <summary>
    /// Class representing a list of champions (Static API).
    /// </summary>
    [Serializable]
    public class ChampionListStatic
    {

        #region Properties

        /// <summary>
        /// Map of champions indexed by their name.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, ChampionStatic> Champions { get; set; }

        /// <summary>
        /// TAPI type (item).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        #endregion
    }
}