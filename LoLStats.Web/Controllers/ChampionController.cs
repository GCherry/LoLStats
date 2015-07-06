#region References

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoLStats.Data.Context;
using LoLStats.Shared.Interfaces;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Web.Controllers
{
    public class ChampionController : Controller
    {
        #region Fields

        private readonly IChampionManager _championManager;
        private readonly LoLDBContext db = new LoLDBContext();
        protected static readonly string gncRiotAPIKey = "c92b6d81-20ff-438c-a966-503fa839c3e5";

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
            var champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }
    
        public ActionResult Index()
        {
            return View(db.Champions.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAllChampions()
        {
            var urlRequest = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?api_key=" + gncRiotAPIKey;
            var urlParameters = "?api_key=" + gncRiotAPIKey;

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(urlRequest);

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

       
            //HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            HttpWebRequest request = WebRequest.Create(urlRequest) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    Champion champ = (Champion)js.Deserialize(objText, typeof(Champion));
                }
                
            }

            //if (response.IsSuccessStatusCode)
            //{
            //    Champion champ = response.Content.ReadAsAsync<Champion>().Result;

            //    foreach (var x in champ)
            //    {
                    
            //    }


            //}

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}