using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Badges_Repository
{
    public enum DoorName
    {
        A1 = 1,
        A2,
        A3,
        A4,
        A5,
        A6,
        A7,
        B1,
        B2,
        B3,
        B4,
        B5,
        B6,
        B7,
        NA
    }

    

    public class Badge
    {
        public int BadgeId { get; set; }
        public string Name { get; set; }
        //public List<DoorName> Doors { get; set; } = new List<DoorName>();
        public List<string> Doors { get; set; }

        public Badge() { }

        public Badge(int badgeId, string name, List<string> doors)
        {
            BadgeId = badgeId;
            Name = name;
            Doors = doors;
        }
    }
}
