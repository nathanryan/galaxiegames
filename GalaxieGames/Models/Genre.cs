using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/*
* Genre.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }

        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}