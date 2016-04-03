using System;
using System.Collections.Generic;

/*
* Platform.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.Models
{
    public class Platform
    {
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }

        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}