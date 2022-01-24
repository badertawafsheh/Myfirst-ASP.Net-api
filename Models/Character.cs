using first_web_api.Models;
using System;
using System.Collections.Generic;

namespace models.first_web_api
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Bader";
        public int age { get; set; } = 22;
        public string Description { get; set; } = "Hello, Welcome to my first WepApi. using Api dotnet";

        public RpgClass Class { get; set; } = RpgClass.Nader;
        public User User { get; set; }

        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }

    }

}