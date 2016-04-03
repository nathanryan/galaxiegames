using System;
using System.Collections.Generic;

/*
* Studio.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.Models
{
    public class Studio
    {
        public int ID { get; set; }
        public string StudioName { get; set; }

        public string Country { get; set; }

        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}