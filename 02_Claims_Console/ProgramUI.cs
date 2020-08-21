using _02_Claims_Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    
    class ProgramUI
    {    
        public ClaimRepository _contentRepo = new ClaimRepository();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //menu options
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Modify an existing claim\n" +
                    "5. Delete a claim\n" +
                    "6. Exit" 
                    );

                //User's input
                string input = Console.ReadLine();

                //methods for user's input
                switch (input)
                {
                    case "1":
                        ViewAllContent(); 
                        break;
                    case "2":
                        ViewContentById();
                        break;
                    case "3":
                        CreateContent();
                        break;
                    case "4":
                        UpdateContent();
                        break;
                    case "5":
                        DeleteContent();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye");
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

        private void CreateContent()
        {
            Console.Clear();

            Claim newContent = new Claim();

            //Claim ID
            Console.WriteLine("Enter the Claim ID: ");
            string idAsString = Console.ReadLine();
            newContent.ClaimId = int.Parse(idAsString);

            //Claim Type/ Car Home Theft
            Console.WriteLine("Enter the Claim Type Number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft"
                );
            newContent.ClaimType = Console.ReadLine();

            //Description
            Console.WriteLine("Describe this incident: ");
            newContent.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the Claim Amount(USD): ");
            string starAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(starAsString);

            //Date of Incident  //If this claim is valid (30 days)
            Console.WriteLine("Enter the date of this incident in 'mm, dd, yyyy' format:");
            string dateAsString = Console.ReadLine();
            DateTime incidentDate = DateTime.Parse(dateAsString);
            Console.WriteLine(incidentDate);  
            var today = DateTime.Now;
            TimeSpan difference = today - incidentDate;
            newContent.DateOfIncident = DateTime.Parse(dateAsString);

            //Date of Claim
            Console.WriteLine("Enter the claim date of this incident in 'mm, dd, yyyy' format:");
            string claimDateAsString = Console.ReadLine();
            newContent.DateOfClaim = DateTime.Parse(claimDateAsString);

            // IsValid?
            if (difference.TotalDays < 30 )
            {
                newContent.IsValid = true;
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                newContent.IsValid = false;
                Console.WriteLine("This claim is invalid.");
            }

            Console.WriteLine("Please enter any key to continue");

            Console.ReadKey();

            Console.Clear();
        }

        private void ViewAllContent()
        {
            Console.Clear();
            List<Claim> listOfContent = _contentRepo.GetClaimList();

            foreach (Claim content in listOfContent)
            {
                Console.WriteLine($"Claim ID: {content.ClaimId}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount(USD): {content.ClaimAmount}\n" +
                    $"Date of Accident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is this claim valid?: {content.IsValid}\n" +
                    $" "
                    );
            }
        }
        private void ViewContentById()
        {
            Console.Clear();

            //user to input claim ID
            Console.WriteLine("Enter the claim ID No. you'd like to see");

            // Get the user's input
            string idAsString = Console.ReadLine();
            int inputId = int.Parse(idAsString);

            //Find the content by that title
            Claim content = _contentRepo.GetContentByClaimId(inputId);

            //Display said content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Claim ID: {content.ClaimId}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount(USD): {content.ClaimAmount}\n" +
                    $"Date of Accident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is this claim valid?: {content.IsValid}"
                    );
            }
            else
            {
                Console.WriteLine("No claim by that Claim ID");
            }
        }
        private void UpdateContent()
        {
            //Display all claims
            ViewAllContent();

            //Ask for the claim ID to update
            Console.WriteLine("Enter the claim ID you'd like to update");

            //Get that claim ID
            string oldClaimId = Console.ReadLine();

            //We will build a new object
            Console.Clear();

            Claim newContent = new Claim();

            //Claim ID
            Console.WriteLine("Enter the Claim ID");
            string idAsString = Console.ReadLine();
            newContent.ClaimId = int.Parse(idAsString);

            //Claim Type
            Console.WriteLine("Enter the Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft"
                );
            newContent.ClaimType = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Description");
            newContent.Description = Console.ReadLine();


            //Claim Amount
            Console.WriteLine("Enter Claim Amount(USD)");
            string amountAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(amountAsString);

            //Accident date
            Console.WriteLine("Enter the date of this incident in 'mm, dd, yyyy' format:");
            string dateAsString = Console.ReadLine();
            DateTime incidentDate = DateTime.Parse(dateAsString);
            Console.WriteLine(incidentDate);
            newContent.DateOfIncident = DateTime.Parse(dateAsString);

            //Date of Claim
            Console.WriteLine("Enter the claim date of this incident in 'mm, dd, yyyy' format:");
            string claimDateAsString = Console.ReadLine();
            newContent.DateOfClaim = DateTime.Parse(claimDateAsString);

            //Is Valid? -- If this claim is valid (30 days)
            var today = DateTime.Now;
            TimeSpan difference = today - incidentDate;
            if (difference.TotalDays < 30)
            {
                newContent.IsValid = true;
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                newContent.IsValid = false;
                Console.WriteLine("This claim is invalid.");
            }

            //verify the update worked
            int oldId = int.Parse(oldClaimId);
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldId, newContent);
            if (wasUpdated)
            {
                Console.WriteLine("Successfully updated!");
            }
            else
            {
                Console.WriteLine("Couldn't be updated.");
            }
        }

        private void DeleteContent()
        {
            Console.Clear();

            ViewAllContent();

            // Get claim ID they want to remove
            Console.WriteLine("enter claim ID you'd like to remove");
            string input = Console.ReadLine();
            int oldId = int.Parse(input);
            //  Call the delete method
            bool wasDeleted = _contentRepo.RemoveContenetFromList(oldId);

            //if the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The Claim was dusccessfully deleted");
            }
            else
            {
                Console.WriteLine("The Claim could not be deleted");
            }

        }

        //Seed method
        private void SeedContentList()
        {
            Claim claimOne = new Claim(1, "Car", "Car accident on 465.", 400.00, new DateTime(2018,04,25), new DateTime(2018,04,27), true);
            Claim claimTwo = new Claim(2, "Home", "House fire in kitchen.", 4000.00, new DateTime(2018,04,11), new DateTime(2018,04,12), true);
            Claim claimThree = new Claim(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), true);

            _contentRepo.AddClaimList(claimOne);
            _contentRepo.AddClaimList(claimTwo);
            _contentRepo.AddClaimList(claimThree);
        }
    }
    
       
    
}
