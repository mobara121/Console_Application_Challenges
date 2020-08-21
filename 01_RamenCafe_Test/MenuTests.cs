using System;
using Gold_Badge_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_RamenCafe_Test
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void MenuInitialization()
        {
            var menu = new Menu(1, "Miso", "Formented soy-bean", 8.55, IngredientType.Miso);

            Assert.AreEqual(1, menu.Number);
            Assert.AreEqual("Miso", menu.Name);
            Assert.AreEqual("Formented soy-bean", menu.Description);
            Assert.AreEqual(8.55, menu.Price);
            Assert.AreEqual(IngredientType.Miso, menu.TypeOfIngredient);

        }
    }
}
