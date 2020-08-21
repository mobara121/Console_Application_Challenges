using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Console_App
{
    public enum IngredientType
    {
        Pork_Bone = 1,
        Miso,
        Soy_sauce,
        Salt,
        Kimchi
    }
    public class Menu
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IngredientType TypeOfIngredient { get; set; }

        public Menu() { }

        public Menu(int number, string name, string description, double price, IngredientType typeOfIngredient)
        {
            Number = number;
            Name = name;
            Description = description;
            Price = price;
            TypeOfIngredient = typeOfIngredient;

        }
    }
}
