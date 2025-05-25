using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Wah
{
    internal class Program
    {
        public static Random rand = new Random();
        //Stats for combat
        public static string monsterName = " ";
        public static int monHp, monPanic, monSpeed, mAttack, hpAtCombat;
        public static bool blocking = false;
        public static bool coward = false;

        // Character sheet //

        public static string name = " ";
        public static int strength = 10;
        public static int vitality = 100; // Max health
        public static int intelligence = 10;
        public static int karmaScore = -10;
        public static int gold = 1000;
        public static int death = 0;
        public static int level = 0;
        public static int weapon = 0; //used to derive damage calcs
        public static string weaponName = "fists";
        public static bool champion = false;
        public static bool degen = false;



        static void Main() // Declare main method
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\n\n     ██╗    ██╗ █████╗ ██╗  ██╗");
            Console.WriteLine("     ██║    ██║██╔══██╗██║  ██║");
            Console.WriteLine("     ██║ █╗ ██║███████║███████║");
            Console.WriteLine("     ██║███╗██║██╔══██║██╔══██║");
            Console.WriteLine("     ╚███╔███╔╝██║  ██║██║  ██║");
            Console.WriteLine("      ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝\n\n");
            Console.WriteLine("   We are hungry games presents...\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine(); // pause
            Console.Clear();
            MainMenu(); // calls menu


        }


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
            Console.WriteLine(strength);
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
            Console.WriteLine($"{karma}  ({karmaScore})");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Gold: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gold);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Weapon:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{weaponName}\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($" Deaths: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(death);
            if (champion == true || degen == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n--- Accolades ---\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                if (champion == true)
                {
                    Console.Write($"'Champion of the Pits'\n");
                }

                if (degen == true)
                {
                    Console.Write($"'Degenerate Gambler'\n");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.ReadLine();
        }



        static void DeathScreen()
        {
            int chosenQuote;
            chosenQuote = rand.Next(30);
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
    "You're not you when you're hungry", //Forgot why this is here, but it's staying
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

            Console.WriteLine($"\n\"{quote}\"");
            Console.ReadLine();
            Console.Clear();
            death++;
            Character();
            Console.WriteLine($"Press enter to return to level {level}");
            Console.ReadLine();
            Console.Clear();


            //Many if statements to take you to the level you're supposed to be on
            switch (level)
            {
                case 1:
                    Level1();
                    break;
                case 2:
                    Level2(); break;
                case 3:
                    Level3();
                    break;
                case 4:
                    Level4();
                    break;
                case 5:
                    Level5();
                    break;
                case 6:
                    Level6();
                    break;
                case 7:
                    Level7();
                    break;
                default:
                    MainMenu();
                    break;
            }

        }



        static void MainMenu() // Declare title method
        {

            string decision; // define decision variable
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\n\n           ██╗██████╗░██████╗░███████╗██╗░░░██╗███████╗██████╗░███████╗███╗░░██╗░█████╗░███████╗");
                Console.WriteLine("           ██║██╔══██╗██╔══██╗██╔════╝██║░░░██║██╔════╝██╔══██╗██╔════╝████╗░██║██╔══██╗██╔════╝");
                Console.WriteLine("           ██║██████╔╝██████╔╝█████╗░░╚██╗░██╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║██║░░╚═╝█████╗░░");
                Console.WriteLine("           ██║██╔══██╗██╔══██╗██╔══╝░░░╚████╔╝░██╔══╝░░██╔══██╗██╔══╝░░██║╚████║██║░░██╗██╔══╝░░");
                Console.WriteLine("           ██║██║░░██║██║░░██║███████╗░░╚██╔╝░░███████╗██║░░██║███████╗██║░╚███║╚█████╔╝███████╗");
                Console.WriteLine("           ╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝░╚════╝░╚══════╝");



                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\n\t|   1. New Game   |   2. Credits   |   3. Readme.txt   |   4. Developer Menu   |   5. Quit   |"); // presenting options

                decision = (Console.ReadLine());// taking user input and assigning to decision
                Console.Clear(); // clearing screen
                switch (decision) // switch statement for different options
                {

                    case "1":
                        NameCreation();
                        break;
                    case "2"://heads to credits
                        Credits();
                        break;
                    case "3":
                        Console.WriteLine("Coming soon");
                        break;
                    case "4":
                        DevMenu();
                        break;
                    case "5":
                        decision = "0";
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
                Console.Clear(); // clear screen
            }
            while (decision != "0");
        } // exit command - placeholder to be worked on

        public static void DevMenu()
        {

            string decision;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1. Lust\n2. Violence\n3. Character\n4. Death Screen\n5. Bonfire\n6. Roulette\n7. Slots\n8. level 5\n9. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            switch (decision)
            {
                case "1": // use to test levels we will remove this from menu later!
                    Level7();
                    break;
                case "2":
                    Level2(); //Takes you to level 2
                    break;
                case "3":
                    Character();
                    break;
                case "4":
                    DeathScreen();
                    break;
                case "5":
                    Bonfire();
                    break;
                case "6":
                    RussianRoulette();
                    break;
                case "7":
                    slots();
                    break;
                case "8":
                    Level5();
                    break;
                case "9":
                    break;
            }
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

        public static void Menu(string menuOptions)//quick options-creation method to save time.
        {
            string[] split;
            split = menuOptions.Split(',');//Same as credits, saves me having to format menu options
            for (int i = 0; i < split.Length; i++)

            {
                Console.WriteLine(split[i].Trim());
            }

        }
        public static void Combat(string creature, int difficulty, int speed)//handles combat in general
        {
            hpAtCombat = vitality;
            coward = false;
            monsterName = creature;
            bool combat = true;
            monHp = difficulty * 10;
            monPanic = (difficulty * 10) - (difficulty * 8);
            monSpeed = speed;
            int spoils = difficulty * rand.Next(20, 50);

            if (speed >= difficulty + 1)
            {
                mAttack = difficulty + speed;
            }
            else
            {
                mAttack = difficulty * 2;
            }


            while (combat)
            {
                if (monHp <= 0 || coward == true)
                {
                    combat = false;
                    if(coward == false)
                    {
                        Console.WriteLine($"{monsterName} drops {spoils} gold!");
                        gold = gold + spoils;
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"you are fighting {creature}.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"--[ {creature} ]-- \nVitality: {monHp} ");
                    for (int i = 0; i <= (monHp / 2); i++)
                    {
                        Console.Write("|");
                    }
                    Console.WriteLine("");
                    Menu($"DEF. {monSpeed} ");
                    Console.WriteLine("\n\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    PlayerRound(true);
                    MonsterRound();
                    Console.Clear();
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MonsterAttacks(int powerLevel, int attkType)//different attacks for monsters, more powerful monsters have access to higher tiers of attacks.
        {
            int damage, attack;

            attack = rand.Next(0, 10);
            damage = rand.Next(0, mAttack);



            if (attkType == 1)
            {
                switch (rand.Next(0, mAttack))
                {
                    case 0:
                        Console.WriteLine($"{monsterName} takes a swing at you, but misses.");
                        break;
                    case <= 6:
                        Console.WriteLine($"{monsterName} takes a swipe at you, dealing {damage} damage.");
                        vitality = vitality - damage;
                        break;
                    case <= 9:
                        Console.WriteLine($"{monsterName} hurls a chunk of loose debris at you, dealing {damage + 2} damage.");
                        vitality = vitality - (damage + 2);
                        break;
                    case <= 12:
                        Console.WriteLine($"{monsterName} applies some kind of poison, increasing their future damage.");
                        mAttack = mAttack + 1;
                        break;
                    case <= 15:
                        Console.WriteLine($"{monsterName}'s hands glow, firing off two quick bolts of energy that burn your skin for {attack} & {damage} damage!");
                        vitality = vitality - (damage + attack);
                        break;
                    case <= 18:
                        Console.WriteLine($"{monsterName} sucks in a deep breath before unleashing a stream of fire! You take {damage * 2} damage and are set on fire!");
                        vitality = vitality - damage * 2;
                        break;
                    case <= 40:
                        Console.WriteLine($"Screams ring on the wind, as {monsterName} summons the baleful legions of hell to his service.\n" +
                            $"they tear across you in an endless torrent!");
                        for (int i = 0; i < 20; i++)
                        {
                            attack = rand.Next(0, 11);
                            vitality = vitality - attack;
                            Console.WriteLine($"You take {attack} damage!");
                            Thread.Sleep(250);

                        }
                        break;
                    default:
                        Console.WriteLine($"{monsterName} gestures towards you, then spreads their limbs out in an easy pose, daring you to take your best shot.");
                        break;
                }


            }
            else if (attkType == 2)
            {
                switch (rand.Next(0, mAttack))
                {
                    case <= 2:
                        Console.WriteLine($"{monsterName} takes a swing at you, but misses.");
                        break;
                    case <= 3:
                        Console.WriteLine($"{monsterName} winds up and takes a mighty swing at you, dealing {damage + 2} damage.");
                        vitality = vitality - damage + 2;
                        break;
                    case <= 6:
                        Console.WriteLine($"{monsterName} pierces you with a sudden lunge, dealing {damage + mAttack} damage.");
                        vitality = vitality - (damage + mAttack);
                        break;
                    case <= 9:
                        Console.WriteLine($"{monsterName} glows with energy, increasing their future damage.");
                        mAttack = mAttack + 2;
                        break;
                    case <= 12:
                        Console.WriteLine($"{monsterName} roars, limbs glowing with hellish energy, and swipes you for {attack * 2} & {damage} damage!");
                        vitality = vitality - (damage + attack * 2);
                        break;
                    case <= 18:
                        Console.WriteLine($"{monsterName} points a finger, and you feel your insides rot. It's agonizing, as your vitality is reduced in half! \n" +
                            $"{monsterName}'s wounds close before your eyes, as they regain {vitality / 2} health!");
                        monHp = monHp + (vitality / 2);
                        vitality = vitality - (vitality / 2);
                        break;
                    case <= 40:
                        Console.WriteLine($"{monsterName}'s heads writhe around, half-way pulling himself from the ice to loom over you,\n" +
                            $"before unleashing three streams of ice, lava, and lightning. The elemental beams tear across you for {damage * 2}, {damage},\n" +
                            $"and {attack * 5} damage!");
                        vitality = vitality - (damage * 3 + attack * 5);
                        break;
                    default:
                        Console.WriteLine($"{monsterName} points at you, then spreads its limbs out in an easy pose, daring you to take your best shot.");
                        break;
                }

            }
        }

        public static void PlayerRound(bool playerRound)//handles the player's round during combat
        {
            int damage = 0, attack = 0;
            string combatAction = " ";
            string[] def = { "dives", "dodges", "swerves", "slides", "weaves", "leaps" };
            string[] atk = { "lunge", "stab", "swing", "cut", "thrust", "slash" };
            if (vitality > 0)
            {
                do
                {
                    Console.Write($"\n\nIt is {name}'s turn.\n--[ {name} ]-- \nVitality: {vitality} ");
                    for (int i = 0; i <= (vitality / 2); i++)
                    {
                        Console.Write("|");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n");
                    Menu("1. Light Attack, 2. Heavy Attack, 3. Flee");
                    Console.ForegroundColor = ConsoleColor.White;
                    combatAction = Console.ReadLine();

                    switch (combatAction)
                    {
                        case "1":
                            attack = rand.Next(2, 11) + 2;
                            damage = rand.Next(0, strength / 2) + weapon;
                            if (attack <= monSpeed)
                            {
                                Console.WriteLine($"You {atk[rand.Next(atk.Length)]} with your {weaponName}, but unfortunately {monsterName} {def[rand.Next(def.Length)]} out of the way.");
                                playerRound = false;
                                damage = 0;

                            }
                            else
                            {
                                if (attack == 12)
                                {
                                    Console.WriteLine($"CRITICAL HIT! You {atk[rand.Next(atk.Length)]} with your {weaponName}, dealing {damage * 2} damage!");
                                    damage = damage * 2;
                                    playerRound = false;
                                }
                                else
                                {
                                    Console.WriteLine($"you {atk[rand.Next(atk.Length)]} your {weaponName} at {monsterName}, dealing {damage} damage.");
                                    playerRound = false;
                                }
                            }

                            break;
                        case "2":
                            attack = rand.Next(1, 11);//determines whether an atack hits
                            damage = rand.Next(0, strength) + weapon * 2;
                            if (attack <= monSpeed)
                            {
                                Console.WriteLine($"You wind up a mighty {atk[rand.Next(atk.Length)]} with your {weaponName}, but unfortunately {monsterName} {def[rand.Next(def.Length)]} out of the way of your \n" +
                                    $"telegraphed move.");
                                damage = 0;
                                playerRound = false;
                            }
                            else
                            {
                                if (attack == 10)//TOD: implement dodging
                                {
                                    Console.WriteLine($"CRITICAL HIT! You {atk[rand.Next(atk.Length)]} with your {weaponName}, dealing {damage * 2} damage!");
                                    damage = damage * 2;
                                    playerRound = false;
                                }
                                else
                                {
                                    Console.WriteLine($"you {atk[rand.Next(atk.Length)]} your {weaponName} at {monsterName}, dealing {damage} damage.");
                                    playerRound = false;
                                }
                            }

                            break;
                        case "3":
                            attack = rand.Next(0, 11);
                            if (attack >= monSpeed)
                            {
                                Console.WriteLine("You turn tail and leave the fight behind you.");
                                coward = true;
                                playerRound = false;

                            }
                            else
                            {
                                Console.WriteLine($"You try to run but {monsterName} is too fast!");
                                playerRound = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Please input a valid key.");
                            break;
                    }
                    monHp = monHp - damage;
                } while (playerRound == true);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{monsterName} was too much. You have been felled.\n");
                vitality = hpAtCombat;
                DeathScreen();
            }

        }

        public static void MonsterRound()//monster's turn
        {
            int damage, attack, block = 2;
            if (monHp >= 0 && coward == false)
            {
                Console.WriteLine($"\n\nIt is {monsterName}'s turn.\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }

                Console.WriteLine('\n');

                attack = rand.Next(0, 10) + mAttack;// determines whether an attack hits
                damage = rand.Next(0, mAttack); // determines monster damage
                switch (rand.Next(0, 4))
                {
                    case <=1:
                        MonsterAttacks(mAttack, 1);
                        break;
                    case 2:
                        MonsterAttacks(mAttack, 2);
                        break;
                    case 3:
                        if (monHp <= monPanic)
                        {
                            Console.WriteLine($"{monsterName} throws some gold at you. While you are distracted, {monsterName} flees.");
                            monHp = monHp - (monHp + 1);
                        }
                        else
                        {
                            if (blocking == true)
                            {
                                Console.WriteLine($"{monsterName} drops their defensive stance.");
                                monSpeed = (monSpeed - block);
                                mAttack = mAttack + block;
                                blocking = false;
                            }
                            else
                            {
                                Console.WriteLine($"{monsterName} takes a defensive stance.");
                                monSpeed = monSpeed + block;
                                mAttack = mAttack - block;
                                blocking = true;
                            }
                        }
                        break;
                }
            }
            else if (coward == true)
            {
                Console.Write($"You hear {monsterName} shrieking behind while you run for your life.\n");
            }
            else
            {
                Console.WriteLine($"{monsterName} has been defeated!\nYou are victorious!\n");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }




        public static void NameCreation()// Basic menu to set player name
        {
            string temp = " ";
            bool correctName = false;


            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PLEASE TYPE YOUR NAME.");
                temp = Console.ReadLine();
                name = temp;

                Console.WriteLine($"\nYOUR NAME IS ---| {temp} |---, IS THAT CORRECT?\n");//error correction
                Menu("1. Yes, 2. No");

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

            //LoadAnimation();

            Level1();//Onto the first level
        }

        public static void Level1()// Circle 9: Treachery
        {
            string menuOptions = "1. Yes, 2. No", temp = " ";
            bool choiceBreak = false, fought = false, toldName = false;
            weapon = 0;
            level = 1;

            Console.WriteLine("'Nothingness shouldn't hurt so much, should it?'\n\n" +
                "The voice drags you awake, prompting you to pull your head up and look around, blinking open your sleep-encrusted eyes.\n" +
                "In front of you is an elderly man, hunched over, with a wispy beard drooping down his chin.\n" +
                "It's a bit creepy how he's staring down at you.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("1. Stand Up, 2. Attack, 3. Question");
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("You " + (temp == "3" ? "start to speak, " : (temp == "2" ? "HATE old people, so you try to attack, " : "try to get up, ")) + "but something stops you.\n" +
                "Looking down, you see that your limbs are encased in thick, frigid rimes of ice. \n" +
                "No sooner have you noticed than the pain sets in--It's both numbing and agonizing at the same time; every \n" +
                "cell of your body demands that you MAKE IT STOP.\n");
            Thread.Sleep(200);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("1. Work your way out, 2. Attack, 3. Ask for help");
            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            switch (temp)//the first choice to alter stats
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your intelligence has increased by 1. In this game, certain choices can alter your stats.\n" +
                        "Other choices may require you to have certain stats to succeed.\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("You squirm around, systematically testing for weaknesses in your bindings.\n" +
                   "At first it feels impossible, but eventually you feel it begin to give way. Slowly, the ice loosens,\n" +
                   "until you finally pull an arm free. After that, it's a simple matter of working your way free.");
                    intelligence = intelligence + 1;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your strength has increased by 1. In this game, certain choices can alter your stats.\n" +
                        "Other choices may require you to have certain stats to succeed.\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("You writhe around with brute force,throwing your will against the ice that binds you.\n" +
                    "It pushes back, but then, with a sudden crack, it gives way.\n");
                    strength = strength + 1;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your intelligence has increased by 1. In this game, certain choices can alter your stats.\n" +
                        "Other choices may require you to have certain stats to succeed.\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("'Okay, hold tight.'\n\n" +
                         "The old man pulls out a knife and begins chipping at your binds with a rusty knife. It takes several firm blows,\n" +
                    "but eventually, you feel the ice loosen all at once, then shatter.\n");
                    intelligence = intelligence + 1;
                    karmaScore = karmaScore + 1; //treachery is decreased by trust
                    break;
            }

            Console.WriteLine("You push yourself upright, looking around. You are standing on a vast plain of ice, like you've seen in depictions\n" +
                "of Antarctica, with howling wind hurling great billowing clouds of snow against your face. Your toes still feel numb,\n" +
                "but what really chills you are the frozen statues dotting the ice, each vaguely moulding to the shape of the person \n" +
                "inside.\n" +
                "That could have been you.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("1. Where are we?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

            do
            {
                choiceBreak = true;
                Console.Clear();
                Console.WriteLine("'Hell'.\n\n" +
               "The old man replies quickly.\n\n" +
               "'No, seriously. Actual H-E-Double-Hockeystick Hell. Look, there's the Devil over there.'\n\n" +
               "He points into the distance, and you can see a great looming shape that you had thought was a mountain.\n" +
               "It's not the red man in tights that you had always thought he would be, no, it's a massive serpentine\n" +
               "shape, half-frozen in ice, with three writhing heads coiling into the air like the mythological hydra.\n" +
               "The details are hidden by the blustering snow, but the sillhouette is enough to make you shiver.\n\n" +
               "'Anyway, my name is Bryan.'\n\n" +
               "It's clear from the way he says it that Bryan is expecting you to give your name.\n");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu($"1. My name is {name}, 2. Attack, 3. Say nothing");
                temp = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                switch (temp)
                {
                    case "1":
                        Console.WriteLine("'Oh, just like that, huh?'\n\n" +
                            "Bryan seems surprised by your frank honesty.\n\n" +
                            $"'Well, it's a pleasure to meet you, {name}.'\n");
                        karmaScore = karmaScore + 1;
                        toldName = true;
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ARE YOU SURE?\n");
                        Menu($"1. Yes, 2. No");
                        Level1_1(ref fought);//lets people rethink their decisions
                        choiceBreak = fought;
                        break;
                    case "3":
                        Console.WriteLine("'The silent type, hmmm? I suppose that's the name of the game, isn't it?'\n");
                        intelligence++;
                        break;
                }
            } while (choiceBreak == false);

            if (fought == true)//if they attacked Bryan they have to go face Satan
            {
                if (coward == true)
                {
                    Console.WriteLine("You flee across the ice, leaving Bryan behind. Directionless, there's only one\n" +
                        "place left to go--towards the great serpentine form in the distance.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bryan's knife gained.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    karmaScore = karmaScore - 5;

                    Console.WriteLine("With a final blow, Bryan sprawls across the icy ground, gasping up at the sky. Before your eyes\n" +
                        "the ice grows over him, like a mold. He struggles, but nothing is able to save him from slowly being swallowed by \n" +
                        "the snow. It's a horrible fate. But at least something good came of your violent tendencies-- Bryan's knife lies\n" +
                        "blade-down in the snow, and you stoop down to retrieve it. \nIt's spotted with rust, but the metal seems solid enough.\n");
                    weapon = 2;
                    weaponName = "rusty knife";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                }


            }
            else
            {

                Console.WriteLine("The old man steps up closer to you, pausing just within arm's length. He holds out " + (intelligence > 10 && karmaScore > -10 ? "his" : "a") + " rusty knife towards you.\n\n" +
                            "'Take it, you probably need it more than I do.'\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("1. Take the knife, 2. I'll pass.");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch (temp)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Bryan's knife gained.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("The knife is spotted with rust, but the steel itself is firm, and the blade tapers to a sharp point.\n" +
                            "You need a weapon, if this really is Hell. Honestly, the feeling of something solid in your hands is a lifeline.\n" +
                            "It helps keep the panic at just how messed up this situation is at bay.\n");
                        weapon = 2;
                        weaponName = "rusty knife";
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Your Intelligence has increased.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("If this is Hell, you can only assume that everyone down here are the worst people imaginable.\n" +
                            "If someone is offering you a gift, then it's probably wise to refuse. Thinking logically like this feels good,\n" +
                            "like your mind is a shield against the terrible wind. It makes you feel just that much more confident.\n");
                        break;

                }
                Console.WriteLine("'It sounds counterintuitive, but I think our best way out is to talk to the Devil.'\n\n" +
                            "Bryan destroys your budding confidence, just like that. He must have seen the look on your face,\n" +
                            "because he quickly explains.\n\n" +
                            "'I mean we have to talk to the one on top, right?'\n\n" +
                            "He pauses, then chuckles.\n\n" +
                            "'Or the one down below, I suppose.'\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("1. That makes sense, 2. I'm going my own way");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();

                switch (temp)
                {
                    case "1":
                        Console.WriteLine("Everything about this situation is insane. Why not add one more thing to the pile? What could go wrong?\n\n" +
                            "'Let's go, before we freeze to death.'\n");
                        break;
                    case "2":
                        Console.WriteLine("You aren't going to go speak to the LITERAL devil. What sort of insane plan is that?\n" +
                            "Just looking at him makes your skin crawl; speaking to that THING will be so much worse. Besides, why would that work?\n" +
                            "If escaping hell was as simple as talking to someone, people would be coming back to life all the time.\n" +
                            "Bryan tries to make you reconsider, but your mind is made up.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("You head out across the ice.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("It's cold. It's so cold. The ice never ends. The cold never stops. You're sure that if you were alive,\n" +
                            "you would be at risk of severe hypothermia. But for some reason you are able to just keep going, and going, and going.\n" +
                            "You pass by unfortunate souls, trapped in their own personal coffins; the bones of creatures you don't recognize,\n" +
                            "and the ruins of cities that don't exist. It quickly becomes apparent that you can't rest; \n" +
                            "each time you stop, the ice tries to swallow you as well.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Infernum non habet misericordiam.\r");
                        Thread.Sleep(150);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("It's cold. It's so cold. The ice never ends. The cold never stops. You're sure that if you were alive,\n" +
                            "you would be at risk of severe hypothermia. But for some reason you are able to just keep going, and going, and going.\n" +
                            "You pass by unfortunate souls, trapped in their own personal coffins; the bones of creatures you don't recognize,\n" +
                            "and the ruins of cities that don't exist. It quickly becomes apparent that you can't rest;\n" +
                            "each time you stop, the ice tries to swallow you as well.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("But eventually, you have to stop. You can't go on. Your body refuses to move.");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Infernum non habet misericordiam, Gementes in tenebris perpetuis, damnati ululant.");
                        Thread.Sleep(250);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("But eventually, you have to stop. You can't go on. Your body refuses to move.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("The ice finds you quickly, crawling up your legs like the most persistent of predators. It's not long before\n" +
                            "you are fully encased, and the pain is back. Numbing, agonizing, wracking your nerves. Yet there is no respite. It just\n" +
                            "goes on and on and on. Is this your eternity? Is this your torment?\n\n" +
                            $"But eventually, {name} stops thinking.\n\n");
                        weapon = 0;
                        DeathScreen();
                        break;

                }
            }
            Console.WriteLine("You" + (fought == false ? " and Bryan" : "") + " set out across the ice, towards the looming shape\n" +
                "in the distance. The snowy winds increase with each step, blustering you about, but oddly, it feels\n" +
                "like it's getting . . . \n\n");
            Thread.Sleep(1000);
            Console.WriteLine("Warmer.\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            do
            {
                choiceBreak = true;
                Console.WriteLine("It's practically hot by the time you get to the Devil himself. Three-headed and vast, \n" +
                "his skin is scaled and red, and beneath the steaming ice you see the outline of shadowed wings.\n" +
                "You feel violently ill just looking at him.\n\n" +
                "'What do you want?'\n\n" +
                "One massive reptilian head lowers to look you in the eye, and you hear the sound of crunching and screaming \n" +
                "when he talks. You realize that there's a person trapped between those jaws, being casually chewed on while he speaks\n" +
                "in the same way you might chew on gum.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu((fought == true ? "1. I want out of hell, 2. Attack " : "1. I want out of hell, 2. Attack, 3. Let Bryan speak"));
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();

                switch (temp)
                {
                    case "1":
                        if (intelligence >= 11)
                        {
                            Console.WriteLine("You may be speaking to the literal source of everything wrong with the world, an ancient\n" +
                                "evil who might as well regard you as an ant. But you also lived through Capitalism, so this is familiar\n" +
                                "territory, honestly. You manage to keep your wits about you, and explain that you want to leave, please\n" +
                                "and thank you. It's not like you're asking to just be let go, either: you're willing to bargain.\n" +
                                "The Devil loves to bargain, right?\n\n" +
                                "'You seem to think I'm the king of this place, and not the most condemned prisoner. I do love company\n" +
                                "in my misery.\n\n" +
                                "The red-scaled serpent pauses to chew, causing a cacophany of screams.\n\n" +
                                "'But there is something I want, after all.'\n");
                        }
                        else
                        {
                            Console.WriteLine("You want to get out, and stuff. Honestly your mouth is just moving at this point. You're\n" +
                                "literally speaking to the root of all evil, and it feels like all the moisture is being pulled from your\n" +
                                "body just from the gaze of a single cross-pupiled eye.\n\n" +
                                "'ENOUGH.'\n\n" +
                                "The head snaps, and the poor person wedged between his teeth makes a horrid gurgling noise.\n\n" +
                                "'I know what you want, despite your best efforts.'\n");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("THIS IS A BAD IDEA. ARE YOU SURE THAT YOU WANT TO DO THIS?\n");
                        Menu($"1. Yes, 2. No");
                        choiceBreak = false;
                        Console.ForegroundColor = ConsoleColor.White;
                        temp = Console.ReadLine();
                        if (temp == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("You lunge forwards and attack Satan. The dragon bites down, all three heads swivelling to\n" +
                                "look down at you with their baleful presence, fire flaring from their nostrils.\n\n" +
                                $"'Treachery may be your damnation, but arrogance will be your undoing. {name}, I INVENTED arrogance.'\n\n" +
                                "It's a fight!\n");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                            Combat("Satan, the Fallen Star", 66, 9);

                        }
                        else
                        {
                            Console.Clear();
                        }
                        break;
                    case "3":
                        Console.WriteLine("You push Bryan forwards, who stammers and then straightens up.\n\n" +
                            "'We don't belong here, uh, your Wickedness...?'\n\n" +
                            "He doesn't seem to have much of a case, but one of the serpentine heads writhes down to peer at him,\n" +
                            "fixing Bryan with a glare hot enough to melt the snow." +
                            "'Belong here? You misguided mortal. You paid your way here with a \n" +
                            "lifetime of Sin. But perhaps I can help. It could be amusing.'\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
            } while (choiceBreak == false);

            Console.WriteLine("'Judas.'\n\n" +
                "One of the titanic heads sweeps past, leaving a trail of heat and the scent of blood and sulphur in its wake.\n" +
                "As he does, you can see the man inside, wedged between his teeth.\n\n" +
                "'Brutus.'\n\n" +
                "The second head sweeps by, displaying another man with roman features, pierced by several teeth. The devil\n" +
                "keeps his mouth open just long enough for you to get a good look, before the head rears back, and the third\n" +
                "slinks down before your eyes, opening great jaws to display a third man.\n\n" +
                "'And Gaius Cassius. All the greatest traitors in history. For that is the nature of this place, the circle\n" +
                "of...'\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\\__   __/(  ____ )(  ____ \\(  ___  )(  ____ \\|\\     /|(  ____ \\(  ____ )|\\     /|\r\n   ) (   | (    )|| (    \\/| (   ) || (    \\/| )   ( || (    \\/| (    )|( \\   / )\r\n   | |   | (____)|| (__    | (___) || |      | (___) || (__    | (____)| \\ (_) / \r\n   | |   |     __)|  __)   |  ___  || |      |  ___  ||  __)   |     __)  \\   /  \r\n   | |   | (\\ (   | (      | (   ) || |      | (   ) || (      | (\\ (      ) (   \r\n   | |   | ) \\ \\__| (____/\\| )   ( || (____/\\| )   ( || (____/\\| ) \\ \\__   | |   \r\n   )_(   |/   \\__/(_______/|/     \\|(_______/|/     \\|(_______/|/   \\__/   \\_/\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("'But truthfully...'\n\n" +
                "The Devil shudders when he says the word, all three long necks rearing back as if he had eaten something\n" +
                "distasteful.\n\n" +
                "'No one even remembers who Gaius is, or what treachery he wrought. He's staring to lose his flavor.'\n\n" +
                "The middle head slinks back down over you, puffing a putrid breath over you" + (fought == false ? "and Bryan.\n\n" : ".\n\n") +
                "'So here's what I want, mortal. Find me a sweeter flavor to chew on, and I'll let you pass into the next circle.'\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            if (fought == false)
            {
                Console.WriteLine("No sooner has the Devil finished speaking, than Bryan turns towards you.\n\n" +
                    "'Sorry" + (toldName == true ? $" {name}," : ",") + " but this is the name of the game.'\n\n" +
                    "He advances on you quickly, seizing you by the shoulders, and starts to wrestle you towards the dragon's mouth.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("1. Fight back, 2. Do not resist");
                Console.ForegroundColor = ConsoleColor.White;
                Level1_1(ref fought);
                switch (fought)
                {
                    case true:
                        Console.WriteLine("With a final blow, it is over. Bryan tries to flee, but he stumbles backwards, towards the Devil's waiting jaws.");
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Your Intelligence has increased.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        karmaScore++;
                        Console.WriteLine("You think about fighting back, but you realize something; the Devil wants a traitor. by betraying you, \n" +
                            "Bryan might be making himself a more appealing flavor than you. Instead you go limp, allowing Bryan\n" +
                            "to heft you towards Satan's waiting jaws. He drags you forwards, yelling.\n\n" +
                            "'Here! Oh Ancient Serpent! The soul of a man condemned to Treachery!'\n\n" +
                            "With a quick motion, the Devil spits out the body of Cassius, flinging him across the snow, and then lunges.\n" +
                            "You hear the snap of jaws, and feel a flash of scalding heat.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
                Console.WriteLine("You hear Bryan's screams as the dragon pulls him up into the air, jaws clamped about his midsection.\n\n" +
                            "'Oh what sweet treachery, to betray even in the pit of hell!'\n\n" +
                            "The Devil exults, pulling Bryan up into the air, and then shaking him around like a dog with a toy.\n" +
                            "One of the other heads turns towards you, slithering up across the snow.\n\n" +
                            $"'Done well enough, {name}, and so I open up Hell unto you.'\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You try to think of any well-know traitors that might catch Satan's interest.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu($"1. Bryan, 2. Benedict Arnold, 3. {name}");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch(temp)
                {
                    case "1":
                        Console.WriteLine("You remember the old man that you met earlier. If he was in this level of Hell,\n" +
                            "surely he must have committed some act of treachery, right? So you turn around and head back, finding\n" +
                            "the frozen sarcophagus that contains Bryan's body. It's hard to chip him free, and even harder to drag him \n" +
                            "all the way back to where the devil waits.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("'No.'\n\n" +
                            "One draconic head huffs in disgust, taking a short whiff of the frigid air around you. The atmosphere darkens,\n" +
                            "and feeling of intense dread washes over you.\n\n" +
                            "'You have offered me gruel when I asked for fine meat. You, however, have a much finer flavor.'\n\n" +
                            "A second head growls, then opens its mouth. You don't have much time to feel fear. The pain, however, lasts for eternity.\n");
                        DeathScreen();
                        break;
                    case "2":
                        Level1_2();
                        break;
                    case "3":
                        karmaScore = karmaScore + 1;
                        Console.WriteLine("You know... maybe you don't deserve to leave Hell. This might just be where you belong. Satan hesitates,\n" +
                            "for the briefest moment, as if he suspects a trap. But then his jaws flash forwards, and the pain begins.\n");
                        DeathScreen();
                        break;

                }


            }
            Console.WriteLine("It crunches down on Judas, and blood steams against the snow. The steam does not dissapate.\n" +
                    "Instead, it rises and congeals, warping the air. You realize that it is creating a door in thin air!\n" +
                    "Through it, you can see what looks like a dense forest, murky and dark. Satan huffs.\n\n" +
                    "'Go on. Claim your reward.'\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("1. Pass through the gate");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("As you step forwards, you hear Satan laugh behind you.\n\n" +
                "'I'll see you soon.'\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Level2();


        }
        public static bool Level1_1(ref bool fought)
        {
            fought = false;
            string temp = " ";

            temp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            if (temp == "1")
            {
                Console.WriteLine("A pulse of adrenaline staves off the cold, as you swing your fist at Bryan, taking him by surprise.\n" +
                    "Your blow lands with a satisfying crack, and he rocks back in the snow, wobbling on dazed feet. But he recovers quickly,\n" +
                    "a dangerous glint coming to his eyes--made worse by the line of blood dribbling down his chin.\n\n" +
                    "'So that's how it's going to be, huh? I'll get you back for that.'\n\n" +
                    (weapon == 2 ? "He clenches his fists at you;" : "He brandishes " + (intelligence > 10 && karmaScore > -10 ? "his" : "a") + " rusty knife towards you;") + " it's a fight!\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("In this game you will face enemies. You have two combat options, light attacks and heavy attacks. Light attacks are\n" +
                    "more accurate, but do less damage. Heavy attacks are less accurate, but can potentially end a fight sooner.\n" +
                    "Finally, you have the option to flee. Be careful--some enemies will catch you!\n\n" +
                    "Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                if (weapon == 0)
                {
                    Combat("Bryan", 2, 2);
                }
                else
                {
                    Combat("Bryan", 1, 2);
                }
                fought = true;
                return fought;
            }
            fought = false;
            return fought;
        }
        public static void Level1_2()
        {
            bool choicebreak = false;
            string temp;
            Console.WriteLine("You wander away from the warmth while you ponder, the ice growing firmer beneath your bare feet. It's painful,\n" +
                "but the cold is better than the heat. You remember at least one traitor from history. His name is still used as a \n" +
                "euphemism for traitor; that would be the villain of the Revolutionary War, Benedict Arnold. but how do you plan on \n" +
                "finding him?\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("1. Use your brain, 2. Use your muscles");
            Console.ForegroundColor = ConsoleColor.White;
            temp = Console.ReadLine();
            Console.Clear();
            switch (temp)
            {
                case "1":
                    if (intelligence > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Intelligence check passed., Your Intelligence has increased.");
                        intelligence = intelligence + 1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYou notice that some people are buried far deeper in the ice than others. You don't know exactly\n" +
                            "how Hell works, but the worse the sin, the worse the torment, right? So you set out on a lonely trek across the icy\n" +
                            "fields, hugging yourself for warmth. It's almost dreamlike in its misery: the landscape you are witnessing is too\n" +
                            "cruel, too oppressive, to be real. But the sharp cuts across your feet remind you that it is real.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("But at long last you find something unusual; a frozen lump like the others, but pierced with great\n" +
                            "iron spikes. Only the tip of a head-like shape protrudes from the snow. It is clear that whoever is buried here\n" +
                            "was never meant to leave.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Intelligence check failed.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nThe ice is dotted with the frozen-over shapes of men contorted in the throes of agony. There must\n" +
                            "be some sort of pattern, right? Some sort of method to the madness? You approach one such frozen sarcophagus, and take a\n" +
                            "look inside. The face that peers back haunts you, eyes daring this way and that through the pallid frost. You pull back,\n" +
                            "uncomfortable, and move to the next, then the next. It's a kalaeidoscope of human agony, each face blurring to the next.\n" +
                            "But there is no constant. There is no center. It's all just suffering and pain.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Your feet are numb. You must have checked thousands of these frozen tombs by now, but you don't dare\n" +
                            "return to face the Devil empty-handed. You run your hands, blackened by the bitter cold, over yet another frozen person.\n" +
                            "Except... this one, this shape in the ice, is empty. It's just a hole in the snow, human-shaped, as if a human had once lain\n" +
                            "here but been pulled out. It looks... comfortable, out of reach of the biting wind.\n" +
                            "You swear that you'll only rest a moment. You have plenty of time to find an appropriate traitor. In the meantime,\n" +
                            "this hole is meant for you.\n");
                        DeathScreen();
                    }
                    break;
                case "2":
                    if (strength > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Strength check passed., Your Strength has increased.");
                        strength = strength + 1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You don't really hold with all that thinking and logic. Instead, you simply approach the first of the\n" +
                            $"person-shaped forms of ice that jut from the barren, endless ice-fields. Using your {weaponName}, you bash open\n" +
                            $"the section where it's face should be. A long, thin scream escaped the ice, but when you peer inside, there's a\n" +
                            $"woman staring back at you, thrashing in her prison. Not  Benedict Arnold. Oh well. On to the next.");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Again and again you bash in the frozen ice. Your muscles ache. Your legs want to give up. But eventually,\n" +
                            "you find something unusual; this icy sarcophagus is almost entirely buried in the snow, down to the neck, and pierced\n" +
                            "several thick spikes of iron. It is clear that whoever was buried here was never meant to leave.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Strength check failed.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYou don't really hold with all that thinking and logic. Instead, you simply approach the first of the\n" +
                            $"person-shaped forms of ice that jut from the barren, endless icefields. Using your {weaponName}, you bash open\n" +
                            $"the section where it's face should be. It's hard work, and your arms are burning by the time you pry it open.\n" +
                            $"When you do, you are greeted by a warbling scream of pure agony, the voice of a young man writhing in the ice.\n" +
                            $"Clearly that's not Benedict Arnold; you'll have to try again.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("After only a few tries, your arms are numb. Sweat is beading from your brow, only to freeze, sticking\n" +
                            "to your forehead and back. YOu take another swing, but your exhausted hands slip off the sarcophagus, and you slide\n" +
                            "face-down into the snow. You lie there a moment, panting, feeling your body scream. Maybe it's time to try a\n" +
                            "a different method. But when you try to rise, something stops you. Ice has grown around your hands, crawled\n" +
                            "over your back; it's pinning you to the snowy ground. And this time, you're too exhausted to escape.\n");
                        DeathScreen();
                    }
                    break;

            }
            while (choicebreak == false)
            {
                Console.WriteLine("There's an inscription over the small mound, connected by dark metal plates to some sort of mechanism. It seems\n" +
                    "to be a riddle.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("1. Solve the riddle, 2. Brute force");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch(temp)
                {
                    case "1":
                        Console.WriteLine("The inscription reads:\n\n" +
                            "'I have a mouth but no teeth, a body but no bones; I can fall but never rise. What am I?\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Menu("Write your answer then press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp = Console.ReadLine().ToLower();
                        Console.Clear();
                        if(temp == "river"||temp == "a river")
                        {
                            choicebreak = true;
                            Console.WriteLine("As soon as you speak the words, the spikes click, then withdraw from the ice with a repeated whir");
                        }
                        else
                        {
                            Console.WriteLine("You whisper into the wind, but it swallows your words. You must have been wrong.\n");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "2":
                        Console.WriteLine($"You move forwards and start going ham with your {weaponName}, bashing up and down the mechanism.");
                        if(strength >= 12)
                        {
                            Console.WriteLine("At first, it looks as if nothing is happening, but, after several repeated blows, something makes\n" +
                                "a very satisfying PING.");
                            choicebreak = true;
                        }
                        else
                        {
                            Console.WriteLine("Unfortunately, the ice resists your blows, and no matter how hard you try to hit it, nothing happens.\n" +
                                "You might need to try something else.\n");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                }

            }
            Console.WriteLine("The ice splits, and then a gust of cold air blasts your hair back. Emerging from below the ice\n" +
                   "like Dracula from his coffin, comes a man in a Revolutionary War uniform, bound by a multitude of red tassels.\n" +
                   "Slowly, the tassels spread from his body, before the man's eyes snap open--it's a fight!\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Combat("Benedict Arnold", 3, 3);
            if(coward == true)
            {
                Console.WriteLine("You flee across the ice, leaving Benedict Arnold behind. Unfortunately, you now have no offering to\n" +
                    "give Satan. Maybe he will offer you some other task instead.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("He doesn't.\n");
                DeathScreen();
            }
            else
            {
                Console.WriteLine($"You knock the traitorous revolutionary unconscious with a final blow from your {weaponName},\n" +
                    $"and then it's a simple matter of dragging him all the way back to where the titanic form of Satan waits. He regards you\n" +
                    $"eagerly as you approach, heads coiling and lashing over each other. The middle head approaches, steaming the snow, \n" +
                    $"and takes a deep whiff. The moment of truth.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("'This one has such a delicious scent, what treachery he fermented in his heart.'\n\n" +
                    "He lunges, snapping the man between razor-sharp teeth, before savoring the crunching and screaming. A second head\n" +
                    "lowers to your level.");
            }
        }










        public static void Level2()// Circle 8: Violence
        {
            Console.WriteLine("As you leave Treachery, you notice the temperature cooling down to a bearable heat.");
            Console.WriteLine("You enter a rocky mountain range and see a long red river far away.");
            Console.WriteLine("A roar echoes in the distance\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear ();

            //Going to attempt to foreshadow the Minotaur. Will add a fight
            Level2_1();
        }
        public static void Level2_1()// Circle 8: Violence River
        {
           
            int decision;
            level = 2;
            Console.Clear();
            Console.WriteLine("You descend down the cliff and are met with a river of blood and fire. Across is a dark and twisted forest.");
            Console.WriteLine("The River is guarded by a Centaur armed with a sword");
            Console.WriteLine("Those who have sinned to a certain degree will be hunted by the Centaur if they try to cross the river.\n\nWill you attempt to cross?\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Cross the river");
            Console.WriteLine("2. Attack the Centaur");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (decision == 1) //If they cross the river
            {
                if (karmaScore < -10)
                {
                    Console.WriteLine("You step into the river, but the Centaur takes notice and gallops to you with his sword out");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Combat("The Centaur", 3, 3);
                    Console.WriteLine("After defeating the Centaur, you are able to cross the river to the forest safely.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Step in to the river and the Centaur has no reaction. It makes eye contact with you, but does not approach.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear() ;
                }

            }

            if (decision == 2) //If they Attack
            {

                Console.WriteLine("You gesture at the Centaur to get his attention and give him an intense stare. ");
                Console.WriteLine("He gallops over to you, and pulls out his sword. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Combat("Centaur", 4, 1); //Heavy but slow
                Console.WriteLine("After defeating the Centaur, you are able to cross the river to the forest safely.");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }

            Level2_2();
        }

        public static void Level2_2() //Violence Forest
        {
            Console.WriteLine("You enter the forest. The colourless trees are warped and thorny. They remind you of people in agony");
            Console.WriteLine("The cold dark forest gives you a feeling of uneasiness, like anything could jump out and get you"); 
            Console.WriteLine("Would you like to gather some wood to make a fire? Or would you like to carry on moving?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Gather Wood\n2. Carry on moving through the forest");
            Console.ForegroundColor = ConsoleColor.White;
            int decision = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (decision == 1) //If the player decides to gather wood
            {
                Console.WriteLine("You walk to a tree with many branches that looks like it would be good to start a fire.");
                Console.WriteLine("As you snap the branch off, blood spills out and the tree screams");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AAAAAAARRHHHGHH!"); Thread.Sleep(1500);
                Console.WriteLine("WHY WOULD YOU RIP OFF THAT BRANCH!"); Thread.Sleep(1500);
                Console.WriteLine("DO YOU HAVE ANY EMPATHY?"); Thread.Sleep(1500);
                Console.WriteLine("WHAT IS WRONG WITH YOU!"); Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("The screams of the tree appear to have alerted something. A Harpy was alerted by the screaming and is ready to attack you");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                //Fight goes here
                Combat("Harpy", 2, 4);
                Console.WriteLine("After defeating the harpy, you are able to go back to the tree and set up a bonfire");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Bonfire();
            }
            else //If the player decides to leave the forest
            {
                Console.WriteLine("You decide that your best priority is getting out of the forest as soon as possible"); 
            }
            Console.WriteLine("You venture through the forest until you find a clearing. \nYou arrive at an empty field surrounded by mountains. \nAt the other end of the field, you notice a tunnel. \nBetween you an the tunnel is a big fearsome beast, who you recognize as the infamous Minotaur. \nThe only way out of Violence is through The Minotaur.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Combat("Minotaur", 6, 2);
            Console.WriteLine("After landing your final blow against the Minotaur, he unleashes a ground-shaking roar before falling to the ground.\nYou walk through the gate through to the next layer of Hell");
            Console.ReadLine();
            //Was thinking of putting ASCII text art for "HERESY" after here
            //Also just putting 'Satan Says' here for testing it
            SatanSays();
        }
        public static void Level3()// Circle 7: Heresy
        {
            level = 3;










        }

        static void SatanSays()
        {
            string guess = "", currentSequence = "", temp = "";
            int[] sequence = new int[7]; //Change this to change the amount of Simon Says levels you have to do
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = rand.Next(4);
            }
            for (int i = 0; i < sequence.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i >= 1)
                    {
                        switch (sequence[j])
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(" RED ");
                                Console.Beep(915, 500);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "r";
                                break;
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" BLUE ");
                                Console.Beep(794, 500);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "b";
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(" GREEN ");
                                Console.Beep(646, 500);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "g";
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" YELLOW ");
                                Console.Beep(1298, 500);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "y";
                                break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                Console.Clear();
                currentSequence = currentSequence + temp;
                if (i == 0)
                {
                    Console.WriteLine("Press 1 to begin Satan Says\nPress 2 for the rules");
                    guess = Console.ReadLine();
                    if (guess == "2") //Tutorial
                    {
                        Console.Clear();
                        Console.WriteLine("Will explain later. Press enter to start");
                        Console.ReadLine();
                    }
                }
                else //Playing the Game
                {
                    Console.WriteLine("Please enter the sequence");
                    guess = Console.ReadLine();
                }
                if (guess != currentSequence && i != 0) //Checking Answer
                {
                    Console.WriteLine("Wrong!");
                    Console.WriteLine($"The correct sequence is {currentSequence}");
                    Console.ReadLine();
                }
                Console.Clear();
            }
            Console.WriteLine("You win! Congratulations!");

        }
        public static void Level4()// Circle 6: Anger
        {
            level = 4;
            









        }







        public static void Level5()// Circle 5: Greed
        {
            Console.Clear();
            string decision;
            level = 5;
            Console.WriteLine("You enter Hell’s Casino—a palace of false promise and endless debt.\n" +
                "Gold-lined walls shimmer under flickering neon, masking the desperation in the air.\n" +
                "Fortune teases, greed consumes, and the deeper you go, the harder it is to escape.\n\n");
           Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.WriteLine("1. Play Slots\n2. Play Russian Roulette\n3. Fight in the pits\n4. Loan Shark\n5. Gate Keeper ( Leave )");
            
            decision = Console.ReadLine();
           
            switch (decision)
            {
                case "1":
                    slots();
                    break;
                case "2":
                    RussianRoulette();
                    break;
                case "3":
                    FightingPits();
                    break;
                case "4":
                    LoanShark();
                    break;
                case "5":
                    Level6();
                    break;

            }




        }

        public static void LoanShark()
        {}

        public static void slots()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            string[] symbols = { "7", "♥", "☺", "Ω", "✶" };
            bool gamble = true;
            string decision;
            int count = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n\n\t\t\t{symbols[1]}  --  {symbols[1]}  --  {symbols[1]}\n\n");
            while (gamble)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"|   Gold:{gold}   |");
                Console.WriteLine("|   1.Bet 25   |   2.Bet 50   |   3.Bet 100  |  4.Leave   |");
               
                decision = Console.ReadLine();
                int bet = 0;

                switch (decision)
                {
                    case "1":
                        if (gold >= 25)
                        {
                            gold -= 25;
                            bet = 25;
                            count++;
                        }
                        else
                        {
                            Console.WriteLine("You are too poor for this bet!");
                            
                        }
                        break;
                    case "2":
                        if (gold >= 50)
                        {
                            gold -= 50;
                            bet = 50;
                            count++;
                        }
                        else
                        {
                            Console.WriteLine("You are too poor for this bet!");
                            break;
                        }
                        break;
                    case "3":
                        if (gold >= 100)
                        {
                            gold -= 100;
                            bet = 100;
                            count++;
                        }
                        else
                        {
                            Console.WriteLine("You are too poor for this bet!");
                            continue;
                        }
                        break;
                    case "4":
                        gamble = false;
                        Level5();
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please enter a number between 1 and 4.");
                        break; 
                }

                if (count == 30)

                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You hear a glorious booming voice rippling inside your head.\n'You have become a degenerate gambler, now you pay the ultimate price'\n\n" +
                    "A piece of your soul has been removed -5 karma \n\nPress ENTER to Continue");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    karmaScore = karmaScore - 5;
                    Console.ReadLine();
                }
                    if (count == 60)

                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You hear a glorious booming voice rippling inside your head.\n'I see you have not learned anything young degenerate..'\n" +
                            "'Addiction is a fickle mistress'\n" +
                        "A piece of your soul has been removed -10 karma \n\nSecret Accolade Unlocked!\nPress ENTER to Continue");
                    degen = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        karmaScore = karmaScore - 10;
                        Console.ReadLine();
                    }
                if (bet > 0)
                {
                    int slot1 = rand.Next(0, symbols.Length);
                    int slot2 = rand.Next(0, symbols.Length);
                    int slot3 = rand.Next(0, symbols.Length);
                    int winnings = bet * 25;

                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine($"\n\n\t\t\t{symbols[slot1]}  --  {symbols[slot2]}  --  {symbols[slot3]}\n");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    if (symbols[slot1] == symbols[slot2] && symbols[slot2] == symbols[slot3])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\t\tJackpot baby!! All slots match!\n\t\t         You gain +5 Karma!\n\t\t           And {winnings} gold!\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        gold += winnings;
                        karmaScore = karmaScore + 5;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\t\t\t -{bet} gold.\n\n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }

                
            }
        }

        


        public static void FightingPits()
        {
            int winnings = 2000;
            string decision;
            bool def = false;
            


            if (champion == false)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" the fighting pits roar with blood-soaked desperation. Once gamblers now brawl for survival,\ntheir futures forged not by luck, but by grit, skill, and an unyielding will to live.\n" +
                    "A grizzled pitmaster leans against the iron gate, his voice filled with sadistic amusement.\n" +
                    "'Care to try your luck, stranger? The house pays well... if you survive.'\n\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Fight!(350 gold)\n2. Leave");
                decision = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                while (def == false)
                {
                    switch (decision)
                    {

                        case "1":
                            def = true;
                            gold = gold - 350;
                            break;
                        case "2":
                            def = true;
                            Level5();
                            break;
                        default:
                            Console.WriteLine("Invalid input! Please enter a number between 1 and 2");
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine("'Stepping into the ring—the Young Nephilim. Born just three days ago, yet already thrown into the fight.\n" +
                    "' Will his divine blood save him, or will he fall like the rest?'\n\n\n");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Press ENTER to fight!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Combat("Infant Nephilim", 1, 1);
                Console.WriteLine($"{name} triumphs, the Nephilim little more than a memory now. But next… \nthe Cursed Vagabond. A lost soul, too weak for true battle but too stubborn to die.\nWill {name} put him out of his misery?");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press ENTER to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Combat("Cursed Vagabond", 2, 2);
                Console.WriteLine($"'{name} stands victorious—the Cursed Vagabond is no more, his struggle ending like all the others before him.\nBut the air shifts, the crowd quiets, and a new presence looms at the edge of the arena.\nHugh Capet.\n" +
                    "\nOnce a king, now a wretched soul bound by the weight of greed.\n Gold chains coil around his arms like serpents, their links forged from the wealth he hoarded in life.\nHe fights not for survival, but because he is cursed to do so.\n" +
                    $"'Will {name} break the chains, or be crushed beneath them?'");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press ENTER to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Combat("Hugh Capet", 3, 3);
                Console.WriteLine($"'{name} stands victorious, bloodied but unbeaten. Three challengers have fallen—the young Nephilim, the desperate Vagabond, and the cursed king, Hugh Capet.'" +
                    "'Tonight, he is crowned Champion of the Pits, and with that title comes glory… and {winnings}.'\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"+ {winnings} gold!");
                gold = gold + winnings;
                champion = true;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press ENTER to leave");
                Console.ReadLine();
                Level5();
            }
            else
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"'The Champion returns… but there are no challengers left.\n The pit stands empty, fear outweighing ambition. For now {name}, earths mightiest traveller reigns uncontested.'\n\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Press ENTER to leave");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Level5();
        }


        public static void RussianRoulette()
        {
            string decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("you enter the Russian Roulette lounge, where silence weighs heavier than fate.\n" +
                "A polished revolver rests on the table, and every click of the trigger is a heartbeat stolen.\n" +
                "A demonic figure looms across from a trembling young lady.\n" +
                "With a slow squeeze of the trigger, her fate is sealed. her body jerks, then stillness.\n" +
                "The demon clicks his fingers, and with a flash of fire, she vanishes into the abyss, claimed by the inferno\n" +
                "He leans back, turning his burning gaze toward you. His voice drips with amusement, thick with menace:\n" +
                "'Step up if you dare, {name}.'\n\n\n");

            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("1. Play (250 gold)\n2.Leave");
            decision = Console.ReadLine();
           
            bool game = true;
            int shots = 6;
            int roll = rand.Next(0, shots);
            int round = 1;
            


            
            
                switch (decision)
                {
                    case "1":
                        gold = gold - 250;
                        break;

                    case "2":
                        Level5();
                        break;

                        
                }
                if (decision == "1")
                {
                    while (game == true)
                    {
                        Console.WriteLine("Demons turn");
                        roll = rand.Next(0, shots);
                        if (roll == 0)
                        {
                            Console.WriteLine("public static void RussianRoulette()
        {
            string decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("you enter the Russian Roulette lounge, where silence weighs heavier than fate.\n" +
                "A polished revolver rests on the table, and every click of the trigger is a heartbeat stolen.\n" +
                "A demonic figure looms across from a trembling young lady.\n" +
                "With a slow squeeze of the trigger, her fate is sealed. her body jerks, then stillness.\n" +
                "The demon clicks his fingers, and with a flash of fire, she vanishes into the abyss, claimed by the inferno\n" +
                "He leans back, turning his burning gaze toward you. His voice drips with amusement, thick with menace:\n" +
                "'Step up if you dare, {name}.'\n\n\n");

            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("1. Play (250 gold)\n2.Leave");
            decision = Console.ReadLine();
           
            bool game = true;
            int shots = 6;
            int roll = rand.Next(0, shots);
            int round = 1;


            
            
                switch (decision)
                {
                    case "1":
                        gold = gold - 250;
                                    decision = "0";
                        break;

                    case "2":
                        Level5();
                        break;

                        
                }
                if (decision == "1")
                {
                    while (game = true)
                    {
                        Console.WriteLine("Demons turn\n\n");
                        roll = rand.Next(0, shots);
                        if (roll == 0)
                        {
                            Console.WriteLine("he gun erupts. The demon’s skull splits like cracked stone,\nfragments sizzling as they hit the floor. His body jerks once, then nothing.");
                            game = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("The demon puts the revolver to his head and pulls the trigger without hesitation\n" +
                                "you hear a click -- Damn! The demon has survived");
                            shots--;
                            Console.WriteLine("You press the cold steel of the revolver to your head\n");
                                        Console.WriteLine("|    1. Pull the trigger    |");
                            roll = rand.Next(0, shots);
                            
                           if (roll == 0)
                            {
                                Console.WriteLine("A deafening blast. Your thoughts splatter, immortalized in a grotesque mural.");
                                            Console.ReadLine();
                                DeathScreen();
                            }
                           else
                            {
                                shots--;
                                Console.WriteLine("You squeeze the trigger… Click.\n" +
                                    "Luck still lingers in your grasp.");
                            

                            }
                            round++;
                        }
                        Console.ReadLine();
");
                        Console.WriteLine
                            game = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("The demon puts the revolver to his head and pulls the trigger without hesitation\n" +
                                "you hear a click -- Damn! The demon has survived");
                            shots--;
                            Console.WriteLine("You put the revolver to your head");
                            roll = rand.Next(0, shots);
                            
                           if (roll == 0)
                            {
                                Console.WriteLine("You slowly squeeze the trigger" +
                                    "the echo of a scream can be heard" +
                                    "as you make a brain mural on the wall");
                                DeathScreen();
                            }
                           else
                            {
                                shots--;
                                Console.WriteLine("You slowly squeeze the trigger\n" +
                                    "You hear a click - its your lucky day!");
                            

                            }
                            round++;
                        }
                        Console.ReadLine();







                    }

                }


            }

            

        
            
         
                


                    
          
            

        



        public static void Level6()// Circle 4: Gluttony
        {
            level = 6;










        }














        public static void Level7()// Circle 3: Lust
        {
            level = 7;
            int decision;

            Console.WriteLine($"level 7 - Welcome {name}");
            Console.WriteLine("You land on your feet but cannot see anything. Slowly the fog of war clears,\n" +
                "you are standing in the pit of a rocky chasm. The sky above is an iridescent\n" +
                "purple with lines of black almost tearing up the sky. You are in some kind of anomaly unlike \n" +
                "anything you have ever experienced.\n\nTo your left you see a path stretching up the chasm leading to higher ground\n" +
                "It is unclear what lies straight ahead as the path is shrouded by a cloud of dust and debris.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
            Console.WriteLine("1. Ascend to higher ground, where the air grows thin and the unseen stir.\n2. Press forward, into the shrouded unknown.");
            decision = Convert.ToInt32(Console.ReadLine()); // decision now equals user input
            if (decision == 1) // if user enters "1"

            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You tread the worn path to the left ramp, you feel the air pressure lessen as you progress");
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
            Console.WriteLine("You follow the left path, rising steadily until you're about 100 meters above the chasm’s depths.\n" +
                "The ground beneath you narrows, forcing cautious steps. Pressing forward, you reach a rope bridge,\n" +
                "its worn strands shifting in the breeze. Glancing back, you spot the leftmost edge of the wall—rough,\n" +
                "but climbable.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
            Console.WriteLine("1. Climb the rocky wall.\n2. Step onto the rope bridge.");
            decision = Convert.ToInt32(Console.ReadLine()); // decision now equals user input
            Console.Clear();
            if (decision == 2)
            {

                Level7_3();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You begin climbing the chasm’s side wall when a noise rises from below.\n" +
                    "Looking down, you spot a scaled figure moving upward with unnerving speed. Before you can react,\n" +
                    "it closes the gap, its presence looming just beneath you.");
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
                Console.WriteLine("1. Scramble upward, pushing your limits as the demon closes in.\n2. Lash out with a desperate kick, aiming straight for its stupid face.");

                decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("The demon’s claws tear into you, ripping you from the wall.\n" +
                        "Together, you plummet—seven meters of uncontrolled descent.\n" +
                        "You hit the ground with a thump as dust and debris settle around you. Only one choice remains:\n\nKill or be killed.");
                    Console.ReadLine();

                    Combat("Gnarled abomination", 5, 5);

                    Console.Clear();
                    Console.WriteLine("You press on, scaling the rugged wall with steady determination.\n" +
                        "Before you know it, your hand finds the final ledge, and you pull yourself up.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n Press ENTER to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ReadLine();
                    Level7_4();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Your foot connects with the demon’s stupid face, its crooked nose collapsing under the force.\n" +
                        "It tumbles backward, crashing hard into the ground. Dust settles, silence lingers—it’s not moving.\n" +
                        "You press on, scaling the rugged wall with steady determination.\n" +
                        "Before you know it, your hand finds the final ledge, and you pull yourself up.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n Press ENTER to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    Level7_4();
                }
            }
            Console.ReadLine();
        }
        public static void Level7_2()// Circle 3: Lust - continuing straight ahead

        {
            int decision;
            Console.Clear(); // clearing console
            Console.ForegroundColor = ConsoleColor.White; // setting text color to white
            Console.WriteLine("The wind howls as you push forward. As the dust settles, a marble staircase comes into view—pristine, out of place.\n" +
                "Descending, a familiar scent clings to the air—rich meats, overripe fruit,\n" +
                "remnants of excess. Gluttony awaits.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // setting decisions text to "DarkYellow"
            Console.WriteLine("1. Descend the marble stairs (Back to gluttony)\n" +
                "2. Turn back and take the path upward, away from the excess below.");
            decision = Convert.ToInt32(Console.ReadLine()); // Convert to int and accept users input
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
            Console.WriteLine("You step onto the rope bridge, its frayed strands swaying beneath your weight.\n" +
                "The abyss yawns below, but hesitation won’t serve you now.\nfortune favors the bold.");
            Console.Clear();
            //LoadAnimation();
            if (chance < 30)
            {
                Console.WriteLine("You make it across the rope bridge, steadying yourself on solid ground. Turning back,\nyou peer into the abyss" +
                    "100 meters of sheer drop. The realization settles in.\n" +
                    "If that rope had snapped, the fall would have been fatal. ");
            }
            else
            {
                Console.WriteLine("A sharp snap rings out behind you. The world tilts—you fall.\n" +
                    "By sheer luck, your hands grasp the rope, stopping your descent.\n" +
                    "The impact against the chasm wall leaves you breathless, but you’re still hanging on.\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-10 hp\n\n");
                vitality = vitality - 10; // Lowering Vitality
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.WriteLine("You attempt to pull yourself up.. lets just hope you are strong enough\n\nPress ENTER to climb");
                Console.ReadLine();
                Console.Clear();

                if (strength > 9) // This might require a balance change later ~
                {
                    Console.WriteLine("You pull yourself up the rope, muscles straining but growing stronger.\nEvery challenge,every fight—it’s all paying off.\n" +
                        "Bit by bit, you’re becoming tougher for what lies ahead.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+1 Strength");
                    strength = strength + 1;
                    Console.ReadLine();
                    Level7_4(); }
                else
                {
                    Console.WriteLine("Your grip weakens, arms burning. The rope sways—you're running out of time.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Your grip fails. The world tilts as you fall, vertigo consuming you. The abyss rushes up—there’s no stopping it now.");
                    Console.ReadLine();
                    Console.Clear();
                    DeathScreen();
                }
            }

            Console.ReadLine();

        }
        public static void Level7_4()
        {
            int decision = 0;
            Console.ForegroundColor = ConsoleColor.White;
            while (decision != 1)
            {
                Console.WriteLine("The wind howls through the chasm, its breath sharp with the scent of ruin.\n" +
                          "Below, cracked plains stretch into infinity, bones scattered like whispers of past agony.\n" +
                          "The sky, bruised and relentless, presses down, mirroring the hunger within.\n" +
                          "On the horizon, a solitary tower rises—blackened, defiant.\n" +
                          "It calls to you, its whisper threading through the ruinous winds,\n" +
                          "beckoning you forward into the unknown.\n\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Head Towards the Tower");
                decision = Convert.ToInt32(Console.ReadLine());

            }
            decision = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("The wind howls, pushing against you, each step heavier than the last.\n\n" +
                       "Your strength fades, the tower distant, unwavering.\n You spot a nearby bonfire");
            while (decision != 1 && decision != 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Rest by bonfire\n2. Leave");
                decision = Convert.ToInt32(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        Console.Clear();
                        Bonfire();
                        break;
                    case 2:
                        Console.Clear();
                        break;

                }


            }
            decision = 0;
            
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The cracked plains stretch endlessly, each step grinding against fragments of ruin.\n Wind, sharp with whispers of past agony, drives you forward.\n" +
                    "The Carnal Tower looms ahead, its marble spine fractured, clawing at the heavens. \nThe spiral staircase winds upward—worn, broken, defiant.\n" +
                    "At its base stands the gate keeper. His armor, a shiny fusion of metal and sin, exudes an aura of ruin.\n Darkness stares from within his helmet, a silent challenge.\n\n");
             Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("'Mortal, Your journey was long, but futile. This is King Minos' domain and you are unworthy of his gaze. \n" +
                    "Turn back, lest this place strip you bare.There is no salvation here.Only judgment.'\n\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Reason\n2. Attack\n3. Bribe (1000 Gold)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                decision = Convert.ToInt32(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        Console.Clear();
                    if (intelligence >= 20)
                    {
                        Console.WriteLine("'Your words bear the weight of wisdom, an argument as sharp as Minos' tail.\nVery well—pass, but know this: knowledge alone will not shield you from what lies ahead.'\n\n" +
                            "Press ENTER to continue.");
                        Console.ReadLine();
                        Level7_5();
                    }
                    else
                    {
                        Console.WriteLine("'Reason? There is no reason in this place—only judgment. \nYou speak of purpose, of resolve, as if they hold weight here. They do not.'\n" +
                                    "'Turn back, mortal. Your words are wasted.'\n");
                        decision = 0;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("1. Attack\n2. Bribe (1000 Gold)");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        decision = Convert.ToInt32(Console.ReadLine());
                    }
                    if (decision ==1)
                    { Combat("Gate Keeper", 7, 3); }
                    else
                    { 
                    Console.WriteLine("'This is Limbo, the threshold of judgment. No offering can change your fate. For your insult,\n you will face the blade.\n\n'");
                    Console.WriteLine("Press ENTER");
                    Console.ReadLine();
                    Combat("Gate Keeper", 7, 3);

                    }
                        break;
                    case 2:
                    Combat("Gate Keeper", 7, 3);
                    break;
                    case 3:
                    Console.WriteLine("'This is Limbo, the threshold of judgment. No offering can change your fate. For your insult,\n you will face the blade.\n\n'");
                    Console.WriteLine("Press ENTER");
                    Console.ReadLine();
                    Combat("Gate Keeper", 7, 3);
                    break;

            }
            }

        

        public static void Level7_5()
        { }

        public static void Vendor()
        {
            int store;
            bool leave = false;
            while (leave == false) // allows player to interact with menus and leave by choice
            {
                Console.WriteLine(@"
  _   _           __     __             _                       _   _  
 | | | |          \ \   / /__ _ __   __| | ___  _ __           | | | | 
/ __) __)  _____   \ \ / / _ \ '_ \ / _` |/ _ \| '__|  _____  / __) __)
\__ \__ \ |_____|   \ V /  __/ | | | (_| | (_) | |    |_____| \__ \__ \
(   (   /            \_/ \___|_| |_|\__,_|\___/|_|            (   (   /
 |_| |_|                                                       |_| |_|
        
_________________________________________________________________________
");


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"   Gold:{gold}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"_________________________________________________________________________\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("1. Concentration Elixer");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   || Boosts intelligence by 5 ||");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   200 Gold\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("2. Strength Elixer");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   || Boosts Strength by 5 ||");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   300 Gold\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("3. Placeholder Sword");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   || kills stuff pretty well  ||");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   3000000 Gold\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("4. Leave vendor\n");
                Console.ForegroundColor = ConsoleColor.White;





                store = Convert.ToInt32(Console.ReadLine());


                switch (store)
                {
                    case 1:
                        if (gold >= 200) // Making sure player has enough gold for purchace
                        {
                            gold = gold - 200; // Charging player gold
                            intelligence = intelligence + 5; // Adding stats
                            Console.Clear();
                            Console.WriteLine("Item Purchased.");
                            Console.WriteLine("Intelligence +5");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou cannot afford this!");

                        }
                        break;
                    case 2:
                        if (gold >= 300)
                        {
                            gold = gold - 300;
                            strength = strength + 5;
                            Console.Clear();
                            Console.WriteLine("Item Purchased.");
                            Console.WriteLine("Strength +5");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou cannot afford this!");

                        }
                        break;
                    case 3:
                        if (gold >= 1000000)
                        {
                            gold = gold - 1000000;
                            
                            Console.Clear();
                            Console.WriteLine("Item Purchased.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou cannot afford this!");

                        }
                        break;


                    case 4:
                        leave = true;
                        break;
                }
            }
        }



        public static void Bonfire()
        { string decision = "";
            bool leaver = false;
            string[] darkTradeGreetings = {
    "A stranger in the shadows… do you come to barter?",
    "I see the weight of the world upon you. Perhaps a trade will lighten the load?",
    "Your pockets hold secrets, as do mine. Shall we exchange them?",
    "Gold, relics, or something less tangible? What do you seek in trade?",
    "Not all exchanges are fair… but neither is fate. What do you offer?",
    "The cost of survival is steep. Perhaps these can aid you on your journey?",
    "A traveler wise enough to deal is a traveler who lasts. What’s your price?",
    "Give me something of worth, and perhaps I'll give you something of use.",
    "Only fools hoard what they cannot carry. Shall we make a trade?",
    "Every item has a story, and every trade has a consequence. What do you bring?"};
            while (leaver==false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\t   🔥🔥 Bonfire 🔥🔥");
                Console.WriteLine("---------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("As you take rest by the bonfire\na friendly figure appears over the ridge, \nwalking toward you, steady against the storm.\n\n" +
                           "Their presence cuts through the chaos.\n\n" +
                           $"'{darkTradeGreetings[rand.Next(darkTradeGreetings.Length)]}'\n\n" +
                           "And just like that, the weight shifts.\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine("1. Rest (Recovers hp)\n2. Trade \n3. Character Stats\n4. Leave");

                decision = Console.ReadLine();
                switch (decision)
                {
                    case "1":
                        vitality = 100;
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Vendor();
                        break;
                    case "3":
                        Console.Clear();
                        Character();
                        break;
                    case "4":
                        leaver = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                    
            
            }
               
            




            }
        }
    }


