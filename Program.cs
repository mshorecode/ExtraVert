using System.Globalization;

using Microsoft.VisualBasic;

using Plants;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        PlantID = 1,
        Species = "Chinese Evergreen",
        LightNeeds = 4,
        AskingPrice = 24.00M,
        City = "Hendersonville",
        ZIP = 37075,
        Sold = false
    },
    new Plant()
    {
        PlantID = 2,
        Species = "Fern",
        LightNeeds = 2,
        AskingPrice = 12.00M,
        City = "Fern Gully",
        ZIP = 97031,
        Sold = true
    },
    new Plant()
    {
        PlantID = 3,
        Species = "Peace Lily",
        LightNeeds = 5,
        AskingPrice = 32.35M,
        City = "Las Vegas",
        ZIP = 88901,
        Sold = false
    },
    new Plant()
    {
        PlantID = 4,
        Species = "Money Tree",
        LightNeeds = 3,
        AskingPrice = 20.00M,
        City = "Nashville",
        ZIP = 37011,
        Sold = false,
    },
    new Plant()
    {
        PlantID = 5,
        Species = "Aloe Vera",
        LightNeeds = 3,
        AskingPrice = 8.00M,
        City = "Goodlettsville",
        ZIP = 37072,
        Sold = true
    }
};

string greeting = "\n\t\tWelcome to Green Again\n\tYesterday's Blooms, Today's Treasures.\n";

Console.WriteLine(greeting);

string? choice = null;
while (choice != "5")
{
  
    Console.WriteLine("Main Menu:");
    Console.WriteLine("1. Display all plants");
    Console.WriteLine("2. Post a plant to be adopted");
    Console.WriteLine("3. Adopt a plant");
    Console.WriteLine("4. Delist a plant");
    Console.WriteLine("5. Exit\n");
  
  choice = Console.ReadLine();
  switch (choice)
  {
      case "1":
          Console.Clear();
          ListPlants();
          ReturnMessage();
          Console.Clear();
          break;
    
      case "2":
          Console.Clear();
          PostPlant();
          Console.Clear();
          break;

      case "3":
          Console.Clear();
          AdoptPlant();
          ReturnMessage();
          Console.Clear();
          // ReturnMessage();
          break;

      case "4":
          // Delist Plant

      case "5":
          Console.Clear();
          Console.WriteLine("\nHave a pleasant day!\n\n");
          break;
      
      default:
          Console.Clear();
          Console.WriteLine("\nInvalid choice. Please, input a number from the list...");
          break;
          
  }
}

void ListPlants()
{
  Console.WriteLine("Plants:\n");

  for (int i = 0; i < plants.Count; i++)
  {
      Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold == true ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
  }
}

void PostPlant()
{   
    string? readResult = null;

    Console.WriteLine("Post a Plant:\n");



    do
    {
        string? plantSpecies = null;
        int plantLight = 0;
        decimal plantPrice = 0M;
        string? plantCity = null;
        int plantZip = 0;

        Console.WriteLine("Enter plant species:"); // Prompts User
        readResult = Console.ReadLine(); // User Input
        plantSpecies = readResult;

        Console.WriteLine("\nEnter plant light needs (1-5):");
        readResult = Console.ReadLine();
        plantLight = Convert.ToInt32(readResult.Trim());

        Console.WriteLine("\nEnter plant price:");
        readResult = Console.ReadLine();
        plantPrice = Convert.ToDecimal(readResult);

        Console.WriteLine("\nEnter the city where plant is located:");
        readResult = Console.ReadLine();
        plantCity = readResult;

        Console.WriteLine("\nEnter zip code of city:");
        readResult = Console.ReadLine();
        plantZip = Convert.ToInt32(readResult);

        Plant newPlant = new()
        {
            Species = plantSpecies,
            LightNeeds = plantLight,
            AskingPrice = plantPrice,
            City = plantCity,
            ZIP = plantZip,
        };

        plants.Add(newPlant);
        Console.Clear();
        Console.WriteLine("Plant Added!");

        Console.WriteLine("Would you like to add another plant?\n\nHit Enter to add another or type Exit to go back to Main Menu...");
        readResult = Console.ReadLine();
    }
    while (string.IsNullOrEmpty(readResult));
}

void AdoptPlant()
{
    // Display only available plants
    List<Plant> availablePlants = plants.Where(p =>!p.Sold).ToList();

    Console.WriteLine("Select a plant using its number:\n");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }

    Console.WriteLine();
    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice > 0 && choice <= availablePlants.Count)
    {
        Plant selectedPlant = availablePlants[choice - 1];
        selectedPlant.Sold = true;
        Console.WriteLine($"\n{selectedPlant.Species} has been purchased!");
    }
    else
    {
        Console.WriteLine("\nThat plant is no longer available");
    }
}

void RemovePlant()
{
    
}

void ReturnMessage()
{
    string returnMessage = "\nPress any key to go back to the Main Menu...";
    Console.WriteLine(returnMessage);
    Console.ReadKey();
}