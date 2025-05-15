using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace Wah
{
    internal class Program
    {
        public static Random rand = new Random();






        static void Main() // Declare main method
        {
            Console.WriteLine("Keep me HUNGRY"); // placeholder
			
			Console.ReadLine(); // pause
            Menu(); // calls menu


        }

        // Character sheet ---- 
       
        public static string name = " "; 
        public static int strength = 10;
        public static int vitality = 100; // Max health
        public static int intelligence = 10;
        public static int karmaScore = -10;
        public static int gold = 0;
        public static int death = 0;
        public static int level = 0;


        static void Character()
        {
            string karma; // Basic Karma rank system
            if (karmaScore < 0)
            {
                karma = "Sinner";
            }
            else if (karmaScore >= 0 && karmaScore < 20)
            {
                karma = "Neutral";
            }
            else
            {
                karma = "Saint";
            }

            Console.WriteLine($"--- Character ---");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Name: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(name);
            Console.WriteLine("--- Skills ---");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Strength: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine (strength);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Vitality: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(vitality);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Intelligence: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(intelligence);
            Console.WriteLine("\n--- Statistics ---");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Karma: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(karma);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Gold: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gold);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($" Deaths: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(death);





            Console.ReadLine();
        }



        static void DeathScreen()
        {
            int chosenQuote;
            chosenQuote = rand.Next(29);
            string[] deathQuotes = {
    "All hope abandon, ye who enter here.",
    "The more a thing is perfect, the more it feels pleasure and pain.",
    "The love that moves the sun and the other stars.",
    "Consider your origin. You were not formed to live like brutes but to follow virtue and knowledge.",
    "Into the eternal darkness, into fire and into ice.",
    "The man who lies asleep will never waken fame, and his desire and all his life drift past him like a dream.",
    "There is no greater sorrow than to recall happiness in times of misery.",
    "Midway upon the journey of our life, I found myself within a forest dark, for the straightforward pathway had been lost.",
    "Av’rice, envy, pride, Three fatal sparks, have set the hearts of all on fire.",
    "Not all the gold, that is beneath the moon, or ever hath been, might purchase rest for one.",
    "The hottest places in Hell are reserved for those who, in times of great moral crisis, maintain their neutrality.",
    "Beauty awakens the soul to act.",
    "The path to paradise begins in hell.",
    "A great flame follows a little spark.",
    "Follow your own path, wherever it may lead you.",
    "The worst of all deceptions is self-deception.",
    "Nature is the art of God.",
    "From a little spark may burst a flame.",
    "The purpose of the present life is virtuous action.",
    "Do not be afraid; our fate cannot be taken from us; it is a gift.",
    "All your anxieties will disappear if you are willing to live in the moment.",
    "Heaven wheels above you, displaying to you her eternal glories, and still your eyes are on the ground.",
    "Love, that quickly seized upon my heart, led me to make my state of mind like to itself.",
    "The more perfect a thing is, the more susceptible to good and bad treatment it is.",
    "The world is not only for the clever ones.",
    "Remember tonight… for it is the beginning of always.",
    "Weeping is a sign of love.",
    "The day that man allows true love to appear, those things which are well made will fall into confusion and will overturn everything we believe to be right and true.",
    "I did not die, and yet I lost life’s breath.",
    "O human race, born to fly upward, wherefore at a little wind dost thou so fall?" };
            string quote = deathQuotes[chosenQuote];

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You Are Dead.\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine($"\n{quote}");
            Console.ReadLine();
            Console.Clear();
            death++;
            Character();
            Console.ReadLine();
        }



        static void Menu() // Declare title method
        {

            int decision; // define decision variable
            do
            {

                Console.ForegroundColor = ConsoleColor.White;//Ensures the menu color is always white if the game takes you back to menu
                Console.WriteLine("Menu\n1. New Game\n2. Credits\n3. Lust (test)\n4. Violence (test)\n5. Character (test)\n6. Death Screen"); // presenting options
                decision = Convert.ToInt32(Console.ReadLine());// taking user input and assigning to decision
                Console.Clear(); // clearing screen
                switch (decision) // switch statement for different options
                {

                    case 1:
                        NameCreation();
                        break;
                    case 2://heads to credits
                        Credits();
                        break;                      
                    case 3: // use to test levels we will remove this from menu later!
                        Level7();
                        break;
                    case 4:
                        Level2_1(); //Takes you to level 2
                        break;
                    case 5:
                        Character();
                        break;
                    case 6:
                        DeathScreen();
                        break;
                    case 7:
                        decision = 0;
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


        public static void NameCreation()// Basic menu to set player name
        {
            string menuOptions = "1.Yes, 2.No", temp = " ";
            string[] split;
            bool correctName = false;

            Console.Clear();

            do
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
            } while (correctName == false);//will keep looping until user confirms their name)
            Level1();//Will put actual intro here

        }
        public static void Level1()// Circle 9: Treachery
        {
            string menuOptions = "1.Yes, 2.No", temp = " ";
            string[] split;
            level = 1;

            for (int i = 0; i<55; i++)//"loading" screen
            {
                Console.Write("/-");
                Thread.Sleep(50);
            }
            Console.Clear();

            Console.WriteLine("'Nothingness shouldn't hurt so much, should it?'\n\n" +
                "The voice drags you awake, prompting you to pull your head up and look around, blinking open your sleep-encrusted eyes.\n" +
                "In front of you is an elderly man, hunched over, with a wispy beard drooping down his chin.\n" +
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

            Console.WriteLine("You " + (temp == "3" ? "start to speak, " : (temp == "2" ? "HATE old people, so you try to attack, " : "try to get up, ")) + "but something stops you.\n" +
                "Looking down, you see that your limbs are wrapped in thick, hoary rimes of ice. \n" +
                "No sooner have you noticed than the pain sets in. It's both numbing and agonizing at the same time; every \n" +
                "cell of your body demands that you MAKE IT STOP.\n");
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

            Console.Write((temp == "1" ? "You squirm around, systematically testing for weaknesses in your bindings.\n" +
                "At first it feels impossible, but eventually you feel it begin to give way. Slowly, the ice loosens,\n" +
                "until you finally pull an arm free. After that, it's a simple matter of working your way free.\n\n" +
                "" : (temp == "2" ? "You writhe around with brute force,throwing your will against the ice that binds you.\n" +
                "It pushes back, but then, with a sudden crack, it gives way.\n" :
                "'Okay, hold tight.'\n\n" +
                "The old man pulls out a knife and begins chipping at your binds with a rusty knife. It takes several firm blows,\n" +
                "but eventually, you feel the ice loosen all at once, then shatter.\n")) +
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

            Console.WriteLine("'Hell'.\n\n" +
                "The old man replies quickly.\n\n" +
                "'No, seriously. Actual H-E-Double-Hockeystick Hell. Look, there's the Devil over there.'\n\n" +
                "He points into the distance, and you can see a great looming shape that you had thought was a mountain.\n" +
                "It's not the red man in tights that you had always thought he would be, no, it's a massive serpentine\n" +
                "shape, half-frozen in ice, with three writhing heads coiling into the air like the mythological hydra.\n" +
                "The details are hidden by the blustering snow, but the sillhouette is enough to make you shiver.\n\n" +
                "'Anyway, my name is Bryan.'\n\n" +
                "It's clear from the way he says it that Bryan is expecting you to give your name.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            menuOptions = $"1. My name is {name}, 2. Attack, 3. Say Nothing";
            split = menuOptions.Split(','); //Formats the choice
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.ReadLine();
        }










        public static void Level2()// Circle 8: Violence
        {




        }
        public static void Level2_1()// Circle 8: Violence River
        {
            int decision, committedViolence; //CommittedViolence is probably just a temporary variable for now
            Console.WriteLine("This is just here for testing. Decide whether or not you attacked the guy in Treachery\n1. Attacked him\n2. Did not");
            committedViolence = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("You descend down a cliff and are met with a river of blood and fire. Across is a dark and twisted forest.");
            Thread.Sleep(1000);
            Console.WriteLine("The River is guarded by a group of Centaurs armed with bows and arrows, who take notice of you.");
            Thread.Sleep(1000);
            Console.WriteLine("Those who have committed the sin of Violence will sink. Will you attempt to cross?");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Cross the river");
            Console.WriteLine("2. Wait for the Centaurs to leave");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            // If the player attacked the person in the last level, they will not be able to pass the river
            if (decision == 1) //If they cross the river
            {
                Console.Write("You step into the river");
                Thread.Sleep(500); Console.Write(".");
                Thread.Sleep(500); Console.Write(".");
                Thread.Sleep(500); Console.Write(".");
                Thread.Sleep(500);
                Console.Clear();
                if (committedViolence == 1) // If they attacked the guy in treachery
                {
                    Console.WriteLine("You feel the weight of your sins sinking you deeper into the river of blood and fire.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Your acts of violence in Treachery drag you deeper in the river.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Your body is burning in fire while drowning at the same time");
                    Console.ReadLine();

                    Console.Clear();
                } else //If they did NOT attack the guy in treachery
                {
                    Console.Write("You are able to walk through the river without sinking.");
                    Console.ReadLine();
                    Console.Clear();
                    Level2_2();
                }
            }

            if (decision == 2) //If they wait
            {
                if (committedViolence == 1) //If they attacked the guy in treachery
                {
                    Console.WriteLine("You wait at the river, hoping that the Centaurs will leave, however you seem to have forgotten that they have already noticed you.\nA group of Centaurs gallop over to you and pelt you with arrows and drag you to the river");
                    Console.ReadLine();
                    Console.Clear();
                    Level1();
                }
                else //If they did NOT attack the guy in treachery
                {
                    do // The player is allowed to cross so nothing happens until they cross
                    {
                        Console.Clear();
                        Console.WriteLine("You wait an hour, but the Centaurs are still there. Would you like to:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("1. Cross the river\n2. Wait longer");
                        Console.ForegroundColor = ConsoleColor.White;
                        decision = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if(decision == 1)
                        {
                            Console.Write("You step into the river"); Thread.Sleep(500);
                            Thread.Sleep(500); Console.Write(".");
                            Thread.Sleep(500); Console.Write(".");
                            Thread.Sleep(500); Console.Write(".");
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.Write("You are able to walk through the river without sinking.");
                            Console.ReadLine();
                            Console.Clear();
                            Level2_2();
                        }
                    } while (decision != 1);
                }
            }
        }
        
        public static void Level2_2() //Violence Forest
        {
            Console.WriteLine("You enter the forest. The colourless trees are warped and thorny. They remind you of people in agony"); Thread.Sleep(1000);
            Console.WriteLine("The cold dark forest gives you a feeling of uneasiness, like anything could jump out and get you"); Thread.Sleep(1000);
            Console.WriteLine("Would you like to gather some wood to make a fire? Or would you like to carry on moving?"); Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Gather Wood\n2. Carry on moving through the forest");
            Console.ForegroundColor = ConsoleColor.White;
            int decision = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (decision == 1) //If the player decides to gather wood
            {
                Console.WriteLine("You walk to a tree with many branches that looks like it would be good to start a fire."); Thread.Sleep(1000);
                Console.WriteLine("As you snap the branch off, blood spills out and the tree screams");
                Console.ReadLine(); //Pause so the player can read the tree screaming
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("AAAAAAARRHHHGHH!"); Thread.Sleep(1500);
                Console.WriteLine("WHY WOULD YOU RIP OFF THAT BRANCH!"); Thread.Sleep(1500);
                Console.WriteLine("DO YOU HAVE ANY EMPATHY?"); Thread.Sleep(1500);
                Console.WriteLine("WHAT IS WRONG WITH YOU!"); Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else //If the player decides to leave the forest
            {
                Console.WriteLine("You decide that your best priority is getting out of the forest as soon as possible");
            }
            Console.ReadLine() ;

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
                Console.WriteLine("-10 hp"); 
                vitality = vitality - 10; // Lowering Vitality
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Strength check:");
            }
            
            Console.ReadLine();

        }




        }
    }

