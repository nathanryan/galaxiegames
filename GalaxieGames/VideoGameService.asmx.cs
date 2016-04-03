using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Entity;
using System.Web.Mvc;
using GalaxieGames.DAL;
using GalaxieGames.Models;

/*
* VideoGameService.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames
{
    /// <summary>
    /// Summary description for VideoGameService
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class VideoGameService : System.Web.Services.WebService
    {
        private StoreContext db = new StoreContext();

        [WebMethod]
        public Object[] GetGamesByTitle(string titlePart)
        {
            List<Object> games = new List<Object>();

            if (titlePart != "")
            {
                foreach (var game in db.VideoGames
                                        .Where(a => a.Title.Contains(titlePart))
                                        .ToList())
                {
                    games.Add("Title: " + game.Title);
                    games.Add("Platform: " + game.Platform.PlatformName);
                    games.Add("Genre: " + game.Genre.GenreName);
                    games.Add("Price: " + game.Price);
                    games.Add("Year: " + game.Year + "<br /> <hr />");
                }
            }
            return games.ToArray();
        }
    }
}
