﻿namespace JustWars.Web.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            this.Gold = 100;
        }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public Color Color { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public int Gold { get; set; }

        public int Strength { get; set; }

        public int Defence { get; set; }

        public int Stamina { get; set; }

        public int Agility { get; set; }

        public int Charisma { get; set; }
    }
}