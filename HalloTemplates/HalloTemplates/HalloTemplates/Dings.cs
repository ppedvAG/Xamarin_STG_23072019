using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace HalloTemplates
{
    public class Dings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class DingsManager
    {
        public static IEnumerable<Dings> GetDings()
        {
            return new Faker<Dings>()
                    .RuleFor(x => x.Id, (x, u) => x.Random.Int())
                    .RuleFor(x => x.Name, (x, u) => x.Internet.UserName())
                    .RuleFor(x => x.BirthDate, (x, u) => x.Date.Past())
                    .RuleFor(x => x.AvatarUrl, (x, u) => x.Internet.Avatar())
                    .Generate(20);
        }
    }


}
