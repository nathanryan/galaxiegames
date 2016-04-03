using Microsoft.AspNet.Identity.EntityFramework;
using System;

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
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}