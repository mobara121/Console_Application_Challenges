using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Console_App
{
    public class MenuRepository
    {
        //Field 新旧データを保ってくれる。
        private List<Menu> _listOfItem = new List<Menu>();

        //Method(CRUD)
        //Create
        public void AddItemToMenu(Menu item)
        {
            _listOfItem.Add(item);
        }

        //Read
        public List<Menu> GetMenus()
        {
            return _listOfItem;
        }

        //Update
        public bool UpdateExistingItem (int originalNumber, Menu newItem)
        {
            //Find the item. Numberで特定して、
            Menu oldItem = GetItemByNumber(originalNumber);
            //oldItemに存在していれば、Updateしていく
            if (oldItem != null)
            {
                oldItem.Number = newItem.Number;
                oldItem.Name = newItem.Name;
                oldItem.Description = newItem.Description;
                oldItem.Price = newItem.Price;
                oldItem.TypeOfIngredient = newItem.TypeOfIngredient;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Delete Numberで特定して、存在すれば　→　Removeで除去して、元々のアイテム数より除去後のアイテム数のほうが少ないことをもって確認。
        public bool RemoveItemFromList(int number)
        {
            Menu item = GetItemByNumber(number);
            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfItem.Count;
            _listOfItem.Remove(item);
            if (initialCount > _listOfItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper 他のメソッド（Delete/Update)を助ける
        public Menu GetItemByNumber(int number)
        {
            foreach (Menu item in _listOfItem)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
