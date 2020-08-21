using System;
using System.Collections.Generic;
using Gold_Badge_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_RamenCafe_Test
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _item = new Menu(1, "Miso-Ramen", "Combination of bonito stock and miso soup.", 11.5, IngredientType.Miso);

            _repo.AddItemToMenu(_item);
      
        }

        [TestMethod]
        public void GetMenus_ShouldReturnCorrectCollection()
        {
            //Arrange
            MenuRepository repo = new MenuRepository();
            Menu tamago = new Menu();
            repo.AddItemToMenu(tamago);

            //Act
            List<Menu> item = repo.GetMenus();

            bool itemHasTamago = item.Contains(tamago);

            // Assert 
            Assert.IsTrue(itemHasTamago);
        }

    }
}
