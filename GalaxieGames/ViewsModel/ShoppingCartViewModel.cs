using System.Collections.Generic;
using GalaxieGames.Models;

namespace GalaxieGames.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}