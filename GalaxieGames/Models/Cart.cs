using System.ComponentModel.DataAnnotations;

/*
* Cart.cs
*
* v1.0
*
* 08/12/2015
*
* @reference Jon Galloway http://www.asp.net/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-8
*/

namespace GalaxieGames.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int VideoGameID { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}