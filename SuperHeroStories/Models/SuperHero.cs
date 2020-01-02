using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroStories.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string superHeroName { get; set; }
        public string alterEgoName { get; set; }
        public string primaryAbility { get; set; }
        public string secondaryAbility { get; set; }
        public string catchPhrase { get; set; }
    }
}