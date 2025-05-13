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
            Console.WriteLine("You descend down a cliff and are met with a river of blood and fire. Across is a dark and twisted forest\n");
            Thread.Sleep(750);
            Console.WriteLine("The River is guarded by a group of Centaurs armed with bows and arrows, who take notice of you\n");
            Thread.Sleep(750);
            Console.WriteLine("You may cross the river safely if you have not committed the sin of Violence. Those who have committed the sin of Violence will sink. Will you attempt to cross?");
            Console.WriteLine("1. Cross the river");
            Console.WriteLine("2. Wait for the Centaurs to leave");
            
            // If the player attacked the person in the last level, they will not be able to pass the river
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
            int decision;

            Console.WriteLine($"level 7 - Welcome {name}");
            Console.WriteLine("You land on your feet but cannot see anything. Slowly the fog of war clears,\n" +
                "you are standing in the pit of a rocky chasm. The sky above is an iridescent\n" +
                "purple with lines of black almost tearing up the sky. You are in some kind of anomaly unlike \n" +
                "anything you have ever experienced.\n\nTo your left you see a path stretching up the chasm leading to higher ground\n" +
                "It is unclear what lies straight ahead as the path is shrouded by a cloud of dust and debris.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
            Console.WriteLine("1.Take the path up to higher ground\n2.Continue straight ahead");
            decision = Convert.ToInt32(Console.ReadLine()); // decision now equals user input
            if (decision == 1) // if user enters "1"

            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("You walk all the way back the the ramp on the left, you feel the air pressure lessen as you progress");
                Level7_1();
            }
            else
            { 
                Level7_2();
            }
            
             
        }
          
        public static void Level7_1()// Circle 3: Lust - Taking the path to high ground
        {
            int decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You start walking up the path on the left side, it takes you higher and higher until you are around 100m\n" +
                " from the pit of the chasm. The path begins to get dangerously narrow.\n" +
                " As you steady yourself and walk down it you eventually reach a rope bridge.\n" +
                " Looking behind at the left most edge of the wall you notice that it is quite easily climbable.\n\n ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
            Console.WriteLine("1. Climb the chasm\n2. Take your chances on the rope bridge");
            decision = Convert.ToInt32(Console.ReadLine()); // decision now equals user input
            if (decision == 2)
            {
                
                Level7_3();
            }
            else
            {

                Console.WriteLine("chasm climbing stuff happens here");
            }
            Console.ReadLine();
        }
        public static void Level7_2()// Circle 3: Lust - continuing straight ahead

        {
            int decision;
            Console.Clear(); // clearing console
            Console.ForegroundColor = ConsoleColor.White; // setting text color to white
            Console.WriteLine("You continue down the trail. As you progress you feel the winds getting stronger.\n" +
                "as the dust settles you notice a marble staircase leading down.. it appears polished and out of place in. ");
            Console.ForegroundColor= ConsoleColor.DarkYellow; // setting decisions text to "DarkYellow"
            Console.WriteLine("1.Take stairs down (Back to Gluttony)\n" +
                "2. Circle back and take the path to high ground");
            decision= Convert.ToInt32(Console.ReadLine()); // Convert to int and accept users input
            if (decision == 1)
            { Level6(); } // calls Level6 method
            else
            { Level7_1(); } // calls Level7_1 method
            Console.ReadLine();
        }

        public static void Level7_3() // Circle 3: Lust - Rope Bridge mini-game
        {
            Random rnd = new Random(); // importing random
            int chance = rnd.Next(0, 100); // setting up chance of success
            Console.Clear(); // clear screen
            Console.ForegroundColor = ConsoleColor.White; // setting text to white
            Console.WriteLine("You decide to take your chances on the rope bridge\n it looks sketchy but hey, fortune favors the bold right?");

            Console.Clear();
            Console.WriteLine(".");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("..");
            Thread.Sleep(200);
            Console.Clear(); //           Adding animation for success suspense. 
            Console.WriteLine("...");

            Thread.Sleep(2000);
            Console.Clear();


            if (chance < 50)
            {
                Console.WriteLine("You successfully cross the rope bridge clearing the chasm, You look back down and \n" +
                    "realize that if the rope had of snapped you would have fell 100 meters to your death. ");
                    }
            else
            {
                Console.WriteLine("You hear a thunderous snap behind you and you begin to fall down the chasm\n" +
                    "by sheer luck you manage to hold onto the rope and are smashed against the side of the chasm");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-10 hp"); // Loss of HP to be added later as global variable
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Strength check:");
            }
            
            Console.ReadLine();

        }




        }
    }

