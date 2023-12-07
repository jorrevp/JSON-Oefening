using PeopleDB;

/*
 * Opdracht: ga op zoek naar de comments die starten met TODO
 * en voeg daar de nodig code toe.
 * De opdrachten zitten in dit bestand, en in het bestand Group.cs
 */

Group group = new Group();
string filePath = "../../../database.json";

// try to load data
LoadFromDisk();

// Menu setup
Menu menu = new Menu();
menu.AddOption('1', "Set Group Name", SetGroupName);
menu.AddOption('2', "Add Person", AddPerson);
menu.AddOption('3', "Show Members", ShowMembers);

menu.Start();

// menu had ended. Save everything
SaveToDisk();


// Hier beginnen de opdrachten
void SetGroupName()
{
    // TODO: vraag om een groepsnaam en wijs die toe aan de groep
    Console.WriteLine("Geef een groepsnaam: ");
    string? groepsnaam = Console.ReadLine();
    group.Name = groepsnaam;
}

void AddPerson()
{
    Person person = new Person();

    // TODO: vraag naam, leeftijd, en hobbies en wijs die toe aan de persoon
    Console.WriteLine("Geef de naam, de leeftijd en de hobbies: ");

    person.Name = Console.ReadLine();
    
    person.Age = int.Parse(Console.ReadLine());

    string[] persoonshobbies = Console.ReadLine().Split(',');
    person.Hobbys.AddRange(persoonshobbies);

    group.People.Add(person);
}

void ShowMembers()
{
    // TODO: toon de naam van de groep, en info over alle leden
    Console.WriteLine($"groepsnaam: {group.Name}");
    Console.WriteLine("leden:");

    foreach (var person in group.People)
    {
        Console.WriteLine(person.ToString());
    }
}

void SaveToDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep op te slaan. Voeg foutafhandeling toe.
    try
    {
        string json = group.Serialize();
        File.WriteAllText(filePath, json);
        Console.WriteLine("Data saved to disk.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving data to disk: {ex.Message}");
    }
}

void LoadFromDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep te laden. Voeg foutafhandeling toe.
    Console.WriteLine($"groepsnaam: {group.Name}");
    Console.WriteLine("leden:");

    foreach (var person in group.People)
    {
        Console.WriteLine(person.ToString());
    }
    try
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            group = Group.Deserialize(json);
            Console.WriteLine("Data loaded from disk.");
        }
        else
        {
            Console.WriteLine("No data file found. Starting with an empty group.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data from disk: {ex.Message}");
    }
}


