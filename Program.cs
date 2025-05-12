using System.Net.NetworkInformation;

namespace Wah
{
    internal class Program
    {
        public static string name = " "; //static variables go up here
        


        
        static void Main() // Declare main method
        {
            Console.WriteLine("Keep me empty pls"); // placeholder
			
			Console.ReadLine(); // pause
            Menu(); // calls menu


        }


        static void Menu() // Declare title method
        {

            int decision; // define decision variable
            do
            {

                Console.ForegroundColor = ConsoleColor.White;//Ensures the menu color is always white if the game takes you back to menu
                Console.WriteLine("Menu\n1. New Game\n2. Credits\n3. Exit\n4. Test"); // presenting options
                decision = Convert.ToInt32(Console.ReadLine());// taking user input and assigning to decision
                Console.Clear(); // clearing screen
                switch (decision) // switch statement for different options
                {

                    case 1:
                        Level1();
                        break;
                    case 2://heads to credits
                        Credits();
                        break;
                    case 3://exits the game
                        decision = 0;
                        break;
                    case 4: // use to test levels we will remove this from menu later!
                        Level7();
                        break;
                }
                Console.Clear(); // clear screen
            }
            while (decision != 0); // exit command - placeholder to be worked on


        }
        public static void Credits()// declare Credits method
        {
            string names = "1.Cody Brett, 2.Luke Ari Patel, 3.Ryan Field, 4.Thomas Visser";
            string[] split;

            Console.WriteLine("Irreverence Credits.\n");
            Console.ForegroundColor = ConsoleColor.Green;

            split = names.Split(',');
            foreach (string name in split)//increments names neatly, will assign roles later.
            { 
                Console.WriteLine(name.Trim());
                Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress enter key to return to menu.");
            Console.ReadLine();//Exits back to menu
        }


        public static void Level1()// Circle 9: Treachery
        {
            string menuOptions = "1.Yes, 2.No", temp = " ";
            string[] split;
            bool correctName = false;

            for (int i = 0; i<55; i++)//"loading" screen
            {
                Console.Write("/-");
                Thread.Sleep(50);
            }
            Console.Clear();

            while (correctName == false)//will keep looping until user confirms their name
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PLEASE TYPE YOUR NAME.");
                temp = Console.ReadLine();
                name = temp;

                Console.WriteLine($"YOUR NAME IS ---| {temp} |---, IS THAT CORRECT?\n");//error correction
                split = menuOptions.Split(',');//Same as credits, sves me having to format menu options
                for (int i = 0; i < split.Length; i++)
         
                {
                    Console.WriteLine(split[i].Trim());
                }

                temp = Console.ReadLine();//reads user input
                if (temp == "1")
                {
                    correctName = true;
                }
                else if (temp == "2")
                {
                    Console.WriteLine("THEN TRY AGAIN.");
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.WriteLine("INVALID INPUT. TRY AGAIN.");
                    Thread.Sleep(1500);

                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                //Will put actual into here
            }

            Console.WriteLine("Nothingness shouldn't have texture, should it?");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("The voice drags you aware, prompting you to pull your head up and look around, blinking open your sleep-encrusted eyes.");
            Thread.Sleep(200);
            Console.WriteLine("In front of you is an elderly man, hunched over, with a wispy beard. It's a bit creepy how he's staring down at you.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            menuOptions = "1. Stand up, 2. Attack, 3. Question";
            split = menuOptions.Split(','); //Formats the choice
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }
            temp = Console.ReadLine();

        }
        public static void Level2()// Circle 8: Violence
        {











        }
        public static void Level3()// Circle 7: Heresy
        {











        }
        public static void Level4()// Circle 6: Anger
        {











        }
        public static void Level5()// Circle 5: Greed
        {











        }
        public static void Level6()// Circle 4: Gluttony
        {











        }
        public static void Level7()// Circle 3: Lust
        {


            Console.WriteLine("level 7");
            Console.ReadLine();








        }
    }
}
