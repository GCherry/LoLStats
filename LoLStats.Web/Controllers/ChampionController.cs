#region References

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LoLStats.Data.Context;
using LoLStats.Shared.Interfaces;
using LoLStats.Shared.Models.Entities;
using LoLStats.Shared.Models.RiotAPIModels;
using Newtonsoft.Json;

#endregion

namespace LoLStats.Web.Controllers
{
    public class ChampionController : Controller
    {
        #region Fields

        protected static readonly string GncRiotApiKey = "c92b6d81-20ff-438c-a966-503fa839c3e5";
        private readonly IChampionManager _championManager;
        private readonly LoLDBContext _db = new LoLDBContext();

        #endregion

        #region Constructors

        ///Dependency injection using the NinjectWebCommon.cs file to bind the User manager classes
        public ChampionController(IChampionManager manager)
        {
            _championManager = manager;
        }

        #endregion

        #region Methods

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var champion = _db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAllChampions()
        {
            //TODO abstract this from this class
            var urlRequest = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?api_key=" + GncRiotApiKey;

            var champStatic = new ChampionListStatic();
            var getRequest = (HttpWebRequest) WebRequest.Create(urlRequest);
            using (var getResponse = getRequest.GetResponse())
            using (var reader = new StreamReader(getResponse.GetResponseStream()))
            {
                var responseText = reader.ReadToEnd();
                champStatic = JsonConvert.DeserializeObject<ChampionListStatic>(responseText);
            }

            var champList = champStatic.Champions.Select(champ => new Champion()
            {
                Active = true, 
                Key = champ.Value.Key, 
                Name = champ.Value.Name, 
                RiotId = champ.Value.Id, 
                Title = champ.Value.Title, 
                CreatedOn = DateTime.Now, 
                ModifiedOn = DateTime.Now
            }).ToList();

            _championManager.AddOrUpdateAllChampionsFromRiotApi(champList);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View(_db.Champions.ToList());
        }

        #endregion
    }
}