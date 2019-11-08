
/*
 * Robin:
 * Mer än hälften av alla using statements kan tas bort.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The code is kinda self explanatory
/// Robin:
/// Det är upp till de som läser koden att bestämma.
/// </summary>

class Program
{
    private List<Ant> ants;
    static void Main()
    {
        Program prog = new Program();
        prog.Start();

    }

    private void FillingListWithTestData()
    {
        Random rand = new Random();

        ants.Add(new Ant(rand.Next(2, 10), "Gunnar"));
        ants.Add(new Ant(rand.Next(2, 10), "Bertil"));
        ants.Add(new Ant(rand.Next(2, 10), "Carlos"));
        ants.Add(new Ant(rand.Next(2, 10), "Gunnilla"));
        ants.Add(new Ant(rand.Next(2, 10), "gunIlla"));
        ants.Add(new Ant(rand.Next(2, 10), "Jan-Stjart"));
        ants.Add(new Ant(rand.Next(2, 10), "Buske"));

    }

    private void Start()
    {
        ants = new List<Ant>();
        //FillingListWithTestData();

        /*
         * Robin:
         * Vad gör dessa 2 variabler? Kunde du inte bara skkriva ut det som finns i första
         * if-satsen innan loopen börjar? Vad används stopProg till?
         */
        int stopHelp = 0;
        int stopProg = 0;

        while (stopProg == 0)
        {
            if (stopHelp == 0)
            {
                Console.WriteLine("Type 'Help' for help");
                stopHelp += 1;
            }

            /*
             * Robin:
             * vad betyder line i detta kontext? en rad text?
             */
            string line = Console.ReadLine().ToLower();
            Console.WriteLine("---------------------------");

            if (line == "exit")
            {
                return;
            }
            else
            {
                MainLoop(line);
            }

        }

    }

    /*
     * Robin:
     * Snyggt att du delat upp loopen i 2 metoder. Dock så är namngivningen otydlig,
     * då metoden inte ens innehåller en loop. Start metoden innehåller din loop,
     * och den här metoden verkar bara skicka runt en baserat på input.
     */
    private void MainLoop(string line)
    {

        switch (line)
        {
            case "help":
                PrintHelp();
                break;
            case "add":
                AddAnt();
                break;
            case "print":
                PrintAllAnts();
                break;
            case "remove":
                RemoveAnt();
                break;
            case "searchbyname":
                SearchAntByName();
                break;
            case "searchbylegs":
                SearchByLegs();
                break;
            case "printalllegsinorder":
                PrintAllAntsInLegsOrder();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid argument");
                break;
        }

    }

    /*
     * Robin:
     * Hade det gått att förkorta de olika kommandon som finns något för att
     * underlätta för användaren? t.ex. PrintOrdered eller något liknande?
     */
    private void PrintHelp()
    {
        Console.WriteLine("1: Add");
        Console.WriteLine("2: Print");
        Console.WriteLine("3: Remove");
        Console.WriteLine("4: SearchByName");
        Console.WriteLine("5: SeaechByLegs"); /* Robin: Typo */
        Console.WriteLine("6: PrintAllLegsInOrder");

        Console.WriteLine("7: Exit");
    }

    private void PrintAllAnts()
    {
        Console.WriteLine("Total ants: " + ants.Count);
        for (int i = 0; i < ants.Count; i++)
        {

            Console.WriteLine(i + 1 + ": " + ants[i].GetName());
            Console.WriteLine(ants[i].GetLegs());
            Console.WriteLine("---------");

        }
    }
    private void AddAnt()
    {
        string name;
        string stringLegs;
        int legs;

        Console.WriteLine("Enter Name:");
        name = Console.ReadLine();

        if (name.Length > 10)
        {
            Console.WriteLine("Name way to long \n");
            return;
        }

        for (int i = 0; i < ants.Count; i++)
        {

            if (name.ToLower() == ants[i].GetName().ToLower())
            {
                Console.WriteLine("Someone alrady has that name");

                return;

            }

        }

        
        Console.WriteLine("Enter Amount of legs:");
        stringLegs = Console.ReadLine();
        try
        {
            //You can either use 'try catch' or 'TryParse'. They basically do the same thing
            legs = int.Parse(stringLegs);

        }
        catch (Exception)
        {
            Console.WriteLine("Not a number \n-----------");

            return;
        }


        ants.Add(new Ant(legs, name));
    }

    private void RemoveAnt()
    {
        if (ants.Count == 0)
        {
            Console.WriteLine("No ants in colony");
            return;
        }

        while (true)
        {
            string input;
            Console.WriteLine("What ant you wanna remove? \n if not then type -1");
            input = Console.ReadLine();

            int res;
            bool succeed = int.TryParse(input, out res);
            if (succeed)
            {
                if (res == -1)
                {
                    return;
                }
                else
                {
                    ants.RemoveAt(res - 1);
                }
            }
            else
            {
                Console.WriteLine("Please pass a int as a argument");
            }


        }

    }

    private bool PrintAllAntsInLegsOrder()
    {
        if (ants.Count == 0)
        {
            Console.WriteLine("No ants in colony");
            return false;
        }

        //Bubble sort. https://en.wikipedia.org/wiki/Bubble_sort
        List<Ant> sortedAnts = new List<Ant>(ants);
        bool notSorted = true;
        while (notSorted)
        {
            notSorted = false;

            for (int i = 0; i < sortedAnts.Count-1; i++)
            {
                if (sortedAnts[i].GetLegs() > sortedAnts[i+1].GetLegs())
                {
                    Ant temp = sortedAnts[i];
                    sortedAnts[i] = sortedAnts[i + 1];
                    sortedAnts[i + 1] = temp;
                    notSorted = true;
                }   
            }

        }

        //Print sorted ants
        for (int i = 0; i < sortedAnts.Count; i++)
        {
            Console.WriteLine(i + 1 + ": " + sortedAnts[i].GetName() + " :Legs " + sortedAnts[i].GetLegs());
        }


        return true;
    }
    
    /*
     * Robin:
     * Tur att det är myror man letar efter! Vad letar SearchByLegs() metoden efter?
     */
    private void SearchAntByName()
    {

        ///<summary>
        ///Look at the 'SearchByLegs' method for doc.
        ///This method is almost the same as Legs one the only difference is that it looks for name instead. 
        ///</summary>

        if (ants.Count == 0)
        {
            Console.WriteLine("No ants in colony");
            return;
        }

        Console.WriteLine("Please enter name \n");
        string input = Console.ReadLine();
        input = input.ToLower();

        for (int i = 0; i < ants.Count; i++)
        {

            if (input == ants[i].GetName().ToLower())
            {
                Console.WriteLine(i + 1 + ": " + ants[i].GetName() + " :Legs " + ants[i].GetLegs());

            }

        }

    }

    private void SearchByLegs()
    {

        /// <summary> 
        /// Searches ants by legs.
        /// Does this by getting an input from user and trying Parse
        /// If it succseed then it goes trhough and cycles the list and prints out the ants.
        /// If it doesn't succseed then it prints out "Invalid Input".
        /// </summary>

        if (ants.Count == 0)
        {
            Console.WriteLine("No ants in colony");
            return;
        }

        Console.WriteLine("Please enter a number \n");
        string tempInput = Console.ReadLine();
        int input;
        bool succseed = int.TryParse(tempInput, out input); /* Robin: succeed */

        if (succseed)
        {
            for (int i = 0; i < ants.Count; i++)
            {

                if (input == ants[i].GetLegs())
                {
                    Console.WriteLine(i + 1 + ": " + ants[i].GetName() + " :Legs " + ants[i].GetLegs());

                }

            }
        }
        else
        {
            Console.WriteLine("Invalid Input");

        }


    }


}


/*
 * Robin:
 * Snyggt jobbat! Programmet är robust och jag kan inte hitta några uppenbara kraschar. Kodningstilen
 * är överlag konsekvent och absolut läsbar, men det finns absolut en del saker vi kan förbättra på här.
 * 
 * Det finns en del variabler och metoder med namn som jag gärna hade slipat lite på, och en del
 * variabler som helt kan tas bort. Det finns även en del stavfel som kan rättas.
 * 
 * Det finns många onödiga och inkensekventa tomma rader i koden. Ibland så är det en tom rad mellan
 * metoder, ibland inte. Ibland är det tomrum mellan rader med slut paranteser, ibland inte. Jag
 * skulle gärna se dig slipa lite mer på det så att koden känns lite 'renare' och mer professionell ut.
 * 
 * Det största som jag anser kan förbättras är att ge användaren feedback. Det är inte alltid klart 
 * vad som ska skrivas efter att man t.ex. försökt ge en myra A i antal ben. Ska jag skriva en ny siffra
 * eller är jag tillbaka till huvud menyn? Det finns många ställen i koden där något utförs utan
 * att ge användaren några instruktioner om vart i programmet man befinner sig.
 * 
 * Annars så måste jag säga att det är bra jobbat!
 */