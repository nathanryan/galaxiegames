using System;
using System.Collections.Generic;

/*
* VideoGame.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.Models
{
    public class VideoGame
    {
        public int VideoGameID { get; set; }
        public String Title { get; set; }
        public String Year { get; set; }
        public int Price { get; set; }
        public int PlatformID { get; set; }
        public int StudioID { get; set; }
        public int GenreID { get; set; }

        public virtual Platform Platform { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual Genre Genre { get; set; }
    }
}