namespace JustWars.Web.Migrations
{
    using JustWars.Web.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;

    public class SeedData
    {
        public static Random Rand = new Random();

        public List<User> Users;

        public List<Item> Items;

        public List<Battle> Battles;

        public SeedData()
        {
            this.Users = new List<User>();
            var passwordHash = new PasswordHasher();
            Users.Add(new User() { UserName = "dtraykov", Email = "dtraykov@telerik.com", PasswordHash = passwordHash.HashPassword("Ju$tpa$$1"), Color = Color.Green, SecurityStamp = Guid.NewGuid().ToString() });
            Users.Add(new User() { UserName = "mr.krustev", Email = "mr.krustev@telerik.com", PasswordHash = passwordHash.HashPassword("Ju$tpa$$1"), Color = Color.Blue, SecurityStamp = Guid.NewGuid().ToString() });
            Users.Add(new User() { UserName = "emilnik", Email = "emilnik@telerik.com", PasswordHash = passwordHash.HashPassword("Ju$tpa$$1"), Color = Color.Red, SecurityStamp = Guid.NewGuid().ToString() });

            this.Items = new List<Item>();
            Items.Add(new Item()
            {
                Name = "Holy Hammer",
                Strength = 1,
                Agility = 2
            });
            Items.Add(new Item()
            {
                Name = "Awesome Shield",
                Defence = 3,
                Charisma = 2
            });

            this.Battles = new List<Battle>();
            Battles.Add(new Battle()
            {
                FirstPlayer = this.Users[0],
                SecondPlayer = this.Users[1],
                Status = BattleStatus.WonBySecondPlayer
            });
            Battles.Add(new Battle()
            {
                FirstPlayer = this.Users[0],
                SecondPlayer = this.Users[2],
                Status = BattleStatus.WonByFirstPlayer
            });
            Battles.Add(new Battle()
            {
                FirstPlayer = this.Users[1],
                SecondPlayer = this.Users[2],
                Status = BattleStatus.NotFinished
            });
        }
    }
}
