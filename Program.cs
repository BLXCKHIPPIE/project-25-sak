using System.Net.NetworkInformation;

namespace Wah
{
    internal class Program
    {
        public static string name = " "; //static variables go up here
        


        
        static void Main() // Declare main method
        {
            Console.WriteLine("Keep me HUNGRY"); // placeholder
			
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

            //for (int i = 0; i<55; i++)//"loading" screen
            //{
            //    Console.Write("/-");
            //    Thread.Sleep(50);
            //}
            Console.Clear();

            while (correctName == false)//will keep looping until user confirms their name
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PLEASE TYPE YOUR NAME.");
                temp = Console.ReadLine();
                name = temp;

                Console.WriteLine($"\nYOUR NAME IS ---| {temp} |---, IS THAT CORRECT?\n");//error correction
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
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("INVALID INPUT. TRY AGAIN.");
                    Thread.Sleep(1500);

                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                //Will put actual intro here
            }

            Console.WriteLine("'Nothingness shouldn't hurt so much, should it?'");
  
            Console.WriteLine("The voice drags you awake, prompting you to pull your head up and look around, blinking open your sleep-encrusted eyes.\n" +
                "In front of you is an elderly man, hunched over, with a wispy beard drooping down his chin. \n" +
                "It's a bit creepy how he's staring down at you.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            menuOptions = "1. Stand up, 2. Attack, 3. Question";
            split = menuOptions.Split(','); //Formats the choice
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("You " +(temp == "3" ? "start to speak " : (temp == "2" ? "try to attack " : "try to get up ")) + "but something stops you.\n" +
                "Looking down, you see that your limbs are wrapped in thick, hoary rimes of ice. " +
                "No sooner have you noticed than the pain sets in. It's both numbing and agonizing at the same time; " +
                "every cell of your body demands that you MAKE IT STOP.\n");
            Thread.Sleep(200);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            menuOptions = "1. Struggle, 2. Attack, 3. Ask for help"; //Eventually will set stats
            split = menuOptions.Split(','); //Formats the choice
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.Write(temp == "1" ? "You squirm around, systematically testing for weaknesses in your bindings." +
                " At first it feels impossible, but eventually you feel it begin to give way. Slowly, the ice loosens, until you finally pull an arm free. " +
                "After that, it's a simple matter of working your way free." : (temp == "2" ? " You writhe around with brute force, " +
                "throwing your will against the ice that binds you. It pushes back, but then, with a sudden crack, it gives way." : 
                "'Okay, hold tight.'\n" +
                "The old man pulls out a knife and begins chipping at your binds with a rusty knife. It takes several firm blows,\n" +
                "but eventually, you feel the ice loosen all at once, then shatter.\n")+
                "You stand up, looking around. You are standing on a vast plain of ice, like you've seen in depictions of Antarctica,\n" +
                "a howling wind hurling great billowing clouds of snow against your face. Your toes still feel numb,\n" +
                "but what really chills you are the frozen statues dotting the ice. Those could have been you.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            menuOptions = "1. Where are we?";
            split = menuOptions.Split(','); //Formats the choice
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("'Hell'.\n" +
                "The old man replies quickly.\n" +
                "'No, seriously. Actual H-E-Double-Hockeystick Hell. Look, there's the Devil over there.'");
            Console.ReadLine();
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
                Console.WriteLine("rope bridge mini-game here");
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You continue down the trail. As you progress you feel the winds getting stronger.\n" +
                "as the dust settles you notice a marble staircase leading down.. it appears polished and out of place in. ");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("1.Take stairs down (Back to Gluttony)\n" +
                "2. Circle back and take the path to high ground");
            decision= Convert.ToInt32(Console.ReadLine());
            if (decision == 1)
            { Level6(); }
            else
            { Level7_1(); }
            Console.ReadLine();
        }







        }
    }

