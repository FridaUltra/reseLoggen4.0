using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        // Reseloggen 4.0:
        //Utmaning: Två listor som är synkade.

        Console.InputEncoding = Encoding.Unicode;
        List<string> destinations = new();
        List<int> distansToDestination = new();
        // Deklaration av listan måste ligga utanför loopen, annars skapas en ny lista varje gång loopen börjar om och den gamla kastas.
        while (true)
        {
            Showmenu();

            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                Console.Write("Resmål: ");
                destinations.Add(Console.ReadLine()); // lägger till iput i Listan
                int km = TryGetInt("Hur långt är det till ditt resmål i km?");
                distansToDestination.Add(km);
                Console.ReadLine();
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("Dina resmål: ");
                for (int i = 0; i < destinations.Count; i++)
                {
                    Console.WriteLine($"{destinations[i]} --> {distansToDestination[i]} km.");
                }


                Console.ReadKey();
            }
            else if (userChoice == "3")
            {
                Console.WriteLine("Listan är nu tom");
                destinations.Clear();
                Console.ReadKey();
            }
            else if (userChoice == "4")
            {
                // Statistik på antalet element i listan.
                int xAntal = destinations.Count;
                Console.WriteLine($"Det finns {xAntal} resmål i listan.");
                Console.ReadKey();
            }
            else if (userChoice.ToUpper() == "Q")
            {
                Environment.Exit(0);
            }
        }

    }
    public static void Showmenu()
    {
        Console.Clear();
        Console.WriteLine("RESELOGGEN 4.0 \n");
        Console.WriteLine("[1] Lägg till resmål");
        Console.WriteLine("[2] Visa tillagda resmål");
        Console.WriteLine("[3] Rensa listan på resmål");
        Console.WriteLine("[4] Visa statistik");
        Console.WriteLine("[Q] Avsluta");
        Console.Write("> ");
    }
    //----------Metod konvertera sträng -------------
    public static int TryGetInt(string text)
    {
        int result = 0;

        bool success = false;
        while (success == false)
        {
            Console.Write(text + ": ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out result)) // TryParse har inbyggd felhantering. 
            {
                success = true;
            }
            else
            {
                Console.WriteLine("Nu blev det fel, försök igen!");
            }
        }
        return result;
    }
}