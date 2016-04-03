using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
* OrderDetail.cs
*
* v1.0
*
* 08/12/2015
*
* @reference Jon Galloway http://www.asp.net/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-8
*/

namespace GalaxieGames.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int VideoGameID { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual VideoGame VideoGame { get; set; }
        public virtual Order Order { get; set; }

    }
}