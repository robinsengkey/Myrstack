using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        FillingListWithTestData();

        int stopHelp = 0;
        int stopProg = 0;

        while (stopProg == 0)
        {
            if (stopHelp == 0)
            {
                Console.WriteLine("Type 'Help' for help");
                stopHelp += 1;
            }

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

    private void PrintHelp()
    {
        Console.WriteLine("1: Add");
        Console.WriteLine("2: Print");
        Console.WriteLine("3: Remove");
        Console.WriteLine("4: SearchByName");
        Console.WriteLine("5: SeaechByLegs");
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

        for (int i = 0; i < sortedAnts.Count; i++)
        {
            Console.WriteLine(i + 1 + ": " + sortedAnts[i].GetName() + " :Legs " + sortedAnts[i].GetLegs());
        }


        return true;
    }

    private void SearchAntByName()
    {

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

        if (ants.Count == 0)
        {
            Console.WriteLine("No ants in colony");
            return;
        }

        Console.WriteLine("Please enter a number \n");
        string tempInput = Console.ReadLine();
        int input;
        bool succseed = int.TryParse(tempInput, out input);

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
