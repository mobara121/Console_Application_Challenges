using _02_Badges_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _02_Badges_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        private Badge _badge = new Badge();
        //readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu options
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Create New Badge\n" +
                    "2. Update accessible Door info on an existing Badge\n" +
                    "3. Show a list with all badge ID and door access\n" +
                    "4. Exit"
                    );

                // Get Admin's input
                string input = Console.ReadLine();

                // Evaluate the admin's input --> treat
                
                switch (input)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Good job!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number");
                        break;
                }
                Console.WriteLine("Please enter any key to continue");

                Console.ReadKey();

                Console.Clear();
            }

        }

        private void CreateBadge()
        {
            Console.Clear();
            Badge newbadge = new Badge();

            // Badge ID
            Console.WriteLine("What is the number of the badge (ex: 12345): ");
            string idAsString = Console.ReadLine();
            newbadge.BadgeId = int.Parse(idAsString);

            // Name
            Console.WriteLine("What is the name on the badge: ");
            newbadge.Name = Console.ReadLine();

            // Accessible Door1
            Console.WriteLine("List a door that it needs access to: ");
            
            var doorName1 = new List<string>();
            foreach (var door in doorName1)
            {
                Console.WriteLine($"{door}");
            }

            string doorAsString1 = Console.ReadLine();
            doorName1.Add(doorAsString1);

            // Accessible Door2
            Console.WriteLine("Any other doors(y/n)?");
            string inputYOrN = Console.ReadLine();
            if (inputYOrN == "y")
            {
                Console.WriteLine("List a door that it needs access to: ");

                var doorName2 = new List<string>();
                foreach (var door in doorName2)
                {
                    Console.WriteLine($"{door}");
                }

                string doorAsString2 = Console.ReadLine();
                doorName2.Add(doorAsString2);
            }
            else
            {
                Console.ReadKey();
            }
            
            Badge newBadge = new Badge(newbadge.BadgeId, newbadge.Name, new List<string>());
            _badgeRepo.AddBadgeDictionary(newbadge.BadgeId, newBadge);
        }    

        public void UpdateBadge()
        {
            ShowAllBadges();
            

            // Ask for the badge number to update
            Console.WriteLine("What is the badge number to update? (ex: 12345)");

            // Get thet number
            string idAsString = Console.ReadLine();
            int idNumber = int.Parse(idAsString);
            
            Console.Clear();
            Badge oldContent = _badgeRepo.GetBadgeById(idNumber);
            Badge newbadge = new Badge();

            //Accessible door
            Console.WriteLine($"{oldContent.BadgeId} has access to {oldContent.Doors}.\n" +
                $"What would you like to do?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door"
                );

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?\n" +
                        $"{_badge.Doors}" );
                    string inputAsNameOfDoorOne = Console.ReadLine();
                    if(inputAsNameOfDoorOne != null)
                    {
                        bool wasRemoved = _badge.Doors.Remove(oldContent.Doors[1]);
                        if (wasRemoved)
                        {
                            Console.WriteLine("Door removed.");
                        }
                    }
                    break;
                case "2":
                    var doorName = new List<string>();
                    foreach (var door in doorName)
                    {
                        Console.WriteLine($"{door}");
                    }

                    string doorAsString2 = Console.ReadLine();
                    doorName.Add(doorAsString2);
                    if (oldContent.Doors.Count < _badge.Doors.Count)
                    {
                        Console.WriteLine("Successfully added!");
                    }

                    //Console.WriteLine("Please enter any key to continue");

                    //Console.ReadKey();

                    //Console.Clear();
                    break;
                default:
                    break;
                    
            }
            
            _badgeRepo.UpdateExistingBadge(idNumber, newbadge);

        }

        public void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = _badgeRepo.GetBadgeDictionary();

            foreach (KeyValuePair<int, Badge> badgeKeyValuePair in badgeDictionary)
            {

                Console.WriteLine($"Badge ID: {badgeKeyValuePair.Key}\n" +
                    $"Door Access: {_badgeRepo._badge.Doors}"); 
  
            }
        }

        private void DeleteBadge()
        {
            Console.Clear();

            ShowAllBadges();

            // Get the Dictionary.Key to remove its doors
            Console.WriteLine("Enter Badge ID to remove its Access Doors");
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);

            // Call the delete method
            bool wasDeleted = _badgeRepo.RemoveBadgeFromDictionary(input);
            
            if(wasDeleted)
            {
                Console.WriteLine("The Badge was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Badge could not be deleted.");
            }

        }

        //Seed method
        private void SeedBadgeDictionary()
        {
            Badge Romeo = new Badge(12345, "Romeo", new List<string>{"A1", "A5"});
            Badge Mizue = new Badge(22345, "Mizue", new List<string> { "B3, B7"});
            Badge Rihoko = new Badge(32345, "Rihoko", new List<string> {"A1", "B7" });

            _badgeRepo.AddBadgeDictionary(12345, Romeo);
            _badgeRepo.AddBadgeDictionary(22345, Mizue);
            _badgeRepo.AddBadgeDictionary(32345, Rihoko);
        }

        
    }
}
