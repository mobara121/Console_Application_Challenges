using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Badges_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        public Badge _badge = new Badge();



        //Create
        public void AddBadgeDictionary(int badgeId, Badge badge)
        {
            _badgeDictionary.Add(badgeId, badge);
        }

        //Read
        public Dictionary<int, Badge> GetBadgeDictionary()
        {   
                return _badgeDictionary;
        }

        //Update
        public bool UpdateExistingBadge(int originalBadgeId, Badge newBadge)
        {
            Badge oldBadge = GetBadgeById(originalBadgeId);
            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.Name = newBadge.Name;
                oldBadge.Doors = newBadge.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete Key（BadgeId）で特定して、存在すれば　→　Removeで除去して、もともとのアイテム数と比較して少なくなっていればtrue
        public bool RemoveBadgeFromDictionary(int badgeId)
        {
            Badge badge = GetBadgeById(badgeId);
            if (badge == null)
            {
                return false;
            }

            int initialCount = _badgeDictionary.Count;
            _badgeDictionary.Remove(badgeId);
            if (initialCount > _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Badge RemoveDoor1(DoorName nameOfDoor1)
        //{
            
       // }

        //Helper
        public Badge GetBadgeById(int badgeId)
        {
            foreach (KeyValuePair<int, Badge> badgeKeyValuePair in _badgeDictionary)
            {
                if (badgeKeyValuePair.Key == badgeId)
                {
                    return badgeKeyValuePair.Value;
                }
            }
            return null;
        }

    }
}
