using System;
using System.IO;
using System.Collections;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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

        public static string name = "Traveler";
        public static int strength = 10;
        public static int vitality = 100; // Max health
        public static int intelligence = 10;
        public static int karmaScore = -10;
        public static int gold = 100;
        public static int death = 0;
        public static int level = 0;
        public static int weapon = 0; //used to derive damage calcs
        public static string weaponName = "fist";

        // Bools tied to level 5 
        public static bool champion = false;
        public static bool degen = false;
        public static bool debt = false;

        //bool for level 3
        public static bool holyRune = false;
        public static bool cultist = false;



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
            Console.WriteLine("   We are Hungry games presents...\n\n");
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
            if (champion == true || degen == true || cultist == true || holyRune == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n--- Accolades ---\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                if(holyRune == true)
                {
                    Console.WriteLine("'Scourge of the Unrighteous'\n");
                }

                if (cultist == true)
                {
                    Console.WriteLine($"'Loathesome Blashphemer'\n");
                }

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
    "You're not you when you're hungry", //Forgot why this is here, but it's staying(It's here because there was a duplicate quote)
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
                    Level2();
                    break;
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
                case 8:
                    Level7_5();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n           ██╗██████╗░██████╗░███████╗██╗░░░██╗███████╗██████╗░███████╗███╗░░██╗░█████╗░███████╗");
                Console.WriteLine("           ██║██╔══██╗██╔══██╗██╔════╝██║░░░██║██╔════╝██╔══██╗██╔════╝████╗░██║██╔══██╗██╔════╝");
                Console.ForegroundColor = ConsoleColor.DarkRed;
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
                        ReadMe();
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

        public static void ReadMe()
        {

            StreamReader sr = new StreamReader(@"README.txt");
            string content = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(content);
            Console.ReadLine();
        }



        public static void DevMenu()
        {

            string decision;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n\n");
            Console.WriteLine("       ██████  ███████ ██    ██ ███████ ██       ██████  ██████  ███████ ██████      ");
            Console.WriteLine("       ██   ██ ██      ██    ██ ██      ██      ██    ██ ██   ██ ██      ██   ██     ");
            Console.WriteLine("       ██   ██ █████   ██    ██ █████   ██      ██    ██ ██████  █████   ██████      ");
            Console.WriteLine("       ██   ██ ██       ██  ██  ██      ██      ██    ██ ██      ██      ██   ██     ");
            Console.WriteLine("       ██████  ███████   ████   ███████ ███████  ██████  ██      ███████ ██   ██     ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                          ███    ███ ███████ ███    ██ ██    ██                         ");
            Console.WriteLine("                          ████  ████ ██      ████   ██ ██    ██                         ");
            Console.WriteLine("                          ██ ████ ██ █████   ██ ██  ██ ██    ██                         ");
            Console.WriteLine("                          ██  ██  ██ ██      ██  ██ ██ ██    ██                         ");
            Console.WriteLine("                          ██      ██ ███████ ██   ████  ██████                          ");
            Console.WriteLine("\n\n\n");



            Console.WriteLine("\t   1. Level 1  |  2. Level 2  |  3. Level 3  |  4. Level 4  |  5. Level 5\n");
            Console.WriteLine("\t   6. Level 6  |  7. Level 7  |  8. King Minos  |  9. Bonfire | 10. Exit ");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            switch (decision)
            {
                case "1":
                    Console.Clear();
                    Level1();
                    break;
                case "2":
                    Console.Clear();
                    Level2();
                    break;
                case "3":
                    Console.Clear();
                    Level3();
                    break;
                case "4":
                    Console.Clear();
                    Level4();
                    break;
                case "5":
                    Console.Clear();
                    Level5();
                    break;
                case "6":
                    Console.Clear();
                    Level6();
                    break;
                case "7":
                    Console.Clear();
                    Level7();
                    break;
                case "8":
                    Console.Clear();
                    Level7_5();
                    break;
                case "9":
                    Console.Clear();
                    Bonfire();
                    break;
                default:
                    Console.Clear();
                    Main();
                    break;

               
            }
            }

        
        public static void Credits()// declare Credits method
        {
            string names = " 1.Cody Brett               |               Developer, 2.Luke Ari Patel           |               Developer, 3.Ryan Field               |               Sound Engineer, 4.Thomas Visser            |               Developer";
            string names = "1.Cody Brett               |               Art Director, 2.Luke Ari Patel           |               Story Direction, 3.Ryan Field               |               Sound Engineer, 4.Thomas Visser            |               Developer";
            string[] split;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n           ██╗██████╗░██████╗░███████╗██╗░░░██╗███████╗██████╗░███████╗███╗░░██╗░█████╗░███████╗");
            Console.WriteLine("           ██║██╔══██╗██╔══██╗██╔════╝██║░░░██║██╔════╝██╔══██╗██╔════╝████╗░██║██╔══██╗██╔════╝");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("           ██║██████╔╝██████╔╝█████╗░░╚██╗░██╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║██║░░╚═╝█████╗░░");
            Console.WriteLine("           ██║██╔══██╗██╔══██╗██╔══╝░░░╚████╔╝░██╔══╝░░██╔══██╗██╔══╝░░██║╚████║██║░░██╗██╔══╝░░");
            Console.WriteLine("           ██║██║░░██║██║░░██║███████╗░░╚██╔╝░░███████╗██║░░██║███████╗██║░╚███║╚█████╔╝███████╗");
            Console.WriteLine("           ╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝░╚════╝░╚══════╝\n\n\n\n");

            Console.ForegroundColor = ConsoleColor.Green;

            split = names.Split(',');
            foreach (string name in split)//increments names neatly, will assign roles later.
            {
                Console.WriteLine($"\t\t\t{name}");
                Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n                         Press enter key to return to menu.");
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
            monPanic = monHp - (difficulty * 9);
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
                    Console.WriteLine($"You are fighting {creature}.");
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
                                Console.WriteLine($"You wind up a mighty {atk[rand.Next(atk.Length)]} with your {weaponName}, but unfortunately {monsterName}\n" +
                                    $"{def[rand.Next(def.Length)]} out of the way of your telegraphed move.");
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
            int block = 2, damage = 0;
            if (monHp >= 0 && coward == false)
            {
                Console.WriteLine($"\n\nIt is {monsterName}'s turn.\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }

                Console.WriteLine('\n');

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
                                switch(monsterName)//allows for custom gimmicks
                                {
                                    case "Benedict Arnold":
                                        damage = rand.Next(7, 21);
                                        Console.WriteLine($"{monsterName} fires his musket, dealing {damage} damage!");
                                        vitality = vitality - damage;
                                        blocking = false;
                                        break;

                                    case "Babylon the Great":
                                        Console.WriteLine($"{monsterName} moves close to one of her followers.");
                                        blocking = false;
                                        break;

                                    case "Mystery, the Death of Kings":
                                        Console.WriteLine($"{monsterName} speaks a word of blasphemy, and one of the squirming forms that make up her armor\n" +
                                            $"melts into her own flesh, healing her wounds. She heals, but now she's easier to hit.");
                                        monHp = monHp + mAttack * 2;
                                        monSpeed = monSpeed - 2;
                                        blocking = false;
                                        break;

                                    default:
                                        Console.WriteLine($"{monsterName} drops their defensive stance.");
                                        monSpeed = (monSpeed - block);
                                        mAttack = mAttack + block;
                                        blocking = false;
                                        break;

                                }
                            }
                            else
                            {
                                switch(monsterName)
                                {
                                    case "Benedict Arnold":
                                        Console.WriteLine($"{monsterName} loads his musket!");
                                        blocking = true;
                                        break;

                                    case "Babylon the Great":
                                        Console.WriteLine($"{monsterName} reaches out with her scythe, pulling one of her followers to her. You watch as\n" +
                                            $"the poor unfortunate soul is drained into a husk, his spent life closing Mystery's wounds!");
                                        monHp = monHp + mAttack * 2;
                                        blocking = true;
                                        break;

                                    case "Mystery, the Death of Kings":
                                        damage = rand.Next(10, 30);
                                        Console.WriteLine($"Mystery twirls her scythe around, impaling into her own chest, then whips it out, sending\n" +
                                            $"an arc of boiling blood slicing across you! You take {damage} damage; the good news is, so does she!");
                                        monHp = monHp - damage;
                                        vitality = vitality - damage;
                                        blocking = true;
                                        break;

                                    default:
                                        Console.WriteLine($"{monsterName} takes a defensive stance.");
                                        monSpeed = monSpeed + block;
                                        mAttack = mAttack - block;
                                        blocking = true;
                                        break;
                                }
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
                blocking = false;
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
                        Console.WriteLine("\nYou don't really hold with all that thinking and logic. Instead, you simply approach the first of the\n" +
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
            
            Console.WriteLine("You have now entered the layer of");
            Console.WriteLine("         _________ _______  _        _______  _        _______  _______ \r\n" +
                "|\\     /|\\__   __/(  ___  )( \\      (  ____ \\( (    /|(  ____ \\(  ____ \\\r\n" +
                "| )   ( |   ) (   | (   ) || (      | (    \\/|  \\  ( || (    \\/| (    \\/\r\n" +
                "| |   | |   | |   | |   | || |      | (__    |   \\ | || |      | (__    \r\n" +
                "( (   ) )   | |   | |   | || |      |  __)   | (\\ \\) || |      |  __)   \r\n" +
                " \\ \\_/ /    | |   | |   | || |      | (      | | \\   || |      | (      \r\n" +
                "  \\   /  ___) (___| (___) || (____/\\| (____/\\| )  \\  || (____/\\| (____/\\\r\n" +
                "   \\_/   \\_______/(_______)(_______/(_______/|/    )_)(_______/(_______/\r\n\n\n");
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear ();
            
            //Going to attempt to foreshadow the Minotaur. Will add a fight
            Level2_1();
        }
        public static void Level2_1()// Circle 8: Violence River
        {
            level = 2;
            Console.Clear();
            Console.WriteLine("You descend down the cliff and are met with a river of blood and fire. Across is a dark and twisted forest.");
            Console.WriteLine("The River is guarded by a Centaur armed with a sword");
            Console.WriteLine("Those who have sinned to a certain degree will be hunted by the Centaur if they try to cross the river.\n\nWill you attempt to cross?\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Menu("1. Cross the river, 2. Fight the Centaur");
            Console.ForegroundColor = ConsoleColor.White;
            string decision = Console.ReadLine();
            Console.Clear();
            switch (decision)
            {
                case "2":

                    strength++;
                    karmaScore--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your Strength increased by 1");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("You gesture at the Centaur to get his attention and give him an intense stare. ");
                    Console.WriteLine("He gallops over to you, and pulls out his sword.\n ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Combat("Centaur", 4, 1); //Heavy but slow
                    Console.WriteLine("After defeating the Centaur, you are able to cross the river to the forest safely.\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;

                case "1":
                default:
                    intelligence++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your Intelligence increased by 1\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (karmaScore < -10)
                    {
                        Console.WriteLine("You step into the river, but the Centaur takes notice and gallops to you with his sword out.\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Combat("The Centaur", 3, 3);
                        Console.WriteLine("After defeating the Centaur, you are able to cross the river to the forest safely.\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You Step in to the river and the Centaur has no reaction. It makes eye contact with you, but does not approach.\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;
            }
                
            Level2_2();
        }

        public static void Level2_2() //Violence Forest
        {
            Console.WriteLine("You enter the forest. The colourless trees are warped and thorny. They remind you of people in agony");
            Console.WriteLine("The cold dark forest gives you a feeling of uneasiness, like anything could jump out and get you"); 
            Console.WriteLine("Would you like to gather some wood to make a fire? Or would you like to carry on moving?\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Menu("1. Gather wood for a bonfire, 2. Carry on through the forest");
            Console.ForegroundColor = ConsoleColor.White;
            string decision = Console.ReadLine();
            Console.Clear();
            switch (decision)
            {
                
                case "2":
                    intelligence++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your Intelligence increased by 1\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You decide that your best priority is getting out of the forest as soon as possible.\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "1":
                default:
                    strength++;
                    karmaScore--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your Strength increased by 1");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You walk to a tree with many branches that looks like it would be good to start a fire.");
                    Console.WriteLine("As you snap the branch off, blood spills out and the tree screams!\n");
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
                    Console.WriteLine("The screams of the tree appear to have alerted something. A Harpy was alerted by the screaming and is ready to attack you!\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    //Fight goes here
                    Combat("Harpy", 2, 4);
                    Console.WriteLine("After defeating the harpy, you are able to go back to the tree and set up a bonfire\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Bonfire();
                    break;
            }
                Console.WriteLine("You venture through the forest until you find a clearing. \nYou arrive at an empty field surrounded by mountains. \nAt the other end of the field, you notice a tunnel. \nBetween you an the tunnel is a big fearsome beast, who you recognize as the infamous Minotaur. \nThe only way out of Violence is through The Minotaur.\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            do
            {
                Combat("Minotaur", 6, 2);
                if (coward == true) //If they run from the minotaur
                {
                    Console.WriteLine("The minotaur was far too powerful for you to handle. You run away back in to the forest.\n");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Menu("1. Rest at the bonfire, 2. Go back to the minotaur");
                    Console.ForegroundColor = ConsoleColor.White;
                    decision = Console.ReadLine();
                    if (decision != "2")
                    {
                        Bonfire();
                        Console.WriteLine("Now that you are fully rested, It's time to try again.\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Menu("Press ENTER to fight the Minotaur...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                }
            } while (coward == true); //Makes it so that the player cannot run from the minotaur
            Console.WriteLine("After landing your final blow against the Minotaur, he unleashes a ground-shaking roar before falling to the ground.\nYou walk through the gate through to the next layer of Hell");
            Console.ReadLine();
            //Was thinking of putting ASCII text art for "HERESY" after here
            //Also just putting 'Satan Says' here for testing it
            Level3();
        }
        public static void Level3()// Circle 7: Heresy
        {
            level = 3;
            cultist = false;
            holyRune = false;
            string temp = " ";
            bool choiceloop = false, mystery = false, beatMystery = false;
            string[] cultThings = { "wail and moan", "anoint themselves with fragrant incense", "inscribe names in an unholy tongue across their skin", "weep and gnash their teeth" };



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You have now entered the layer of\n");
            Console.WriteLine("          _______  _______  _______  _______          \r\n|\\     /|(  ____ \\(  ____ )(  ____ \\(  ____ \\|\\     /|\r\n| )   ( || (    \\/| (    )|| (    \\/| (    \\/( \\   / )\r\n| (___) || (__    | (____)|| (__    | (_____  \\ (_) / \r\n|  ___  ||  __)   |     __)|  __)   (_____  )  \\   /  \r\n| (   ) || (      | (\\ (   | (            ) |   ) (   \r\n| )   ( || (____/\\| ) \\ \\__| (____/\\/\\____) |   | |   \r\n|/     \\|(_______/|/   \\__/(_______/\\_______)   \\_/  \n");
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Your ears pop as you ascend from the layer and into the one beyond. It reminds you of being on an airplane,\n" +
                "and with that, you suddenly have a memory, as clear as a crystallized diamond, of sitting in a plane. The 'fasten\n" +
                "seatbelt' signs are flashing, and the sensation of vertigo fills your belly. But as quickly as the memory comes, it\n" +
                "vanishes, leaving you with your now-familiar mental haze. It's probably for the best; there are other things to focus\n" +
                "on.\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Treachery was cold, and Violence was oppressively gloomy. But this layer is scaldingly hot, almost blistering\n" +
                "against your skin. But it's the smell that makes you recoil; the scent of rusty iron, carrying with it the parasitical\n" +
                "taste of blood. A deep orange glow meets your eyes as you take a look around. The landscape is terrifyingly bizzare,\n" +
                "it is best described as a vast cavern. From the ceiling, like enormous stalactites, hang the towering shapes of inverted\n" +
                "skyscrapers, the roads between them suspended in the air. Below is a barren, rocky ground, laced with glowing cracks of\n" +
                "burning lava and pools of boiling blood.\n\n" +
                "This looks like Hell.\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You make your way up the winding path towards the inverted city, listening to the sound of crackling and\n" +
                "screams wafting up from the plains below. The road is narrower than it looked, and more than once you come close to\n" +
                "tumbling down into the fire. And the city ahead doesn't seem like it will offer much more comfort; the multitudinous\n" +
                "windows reflecting the color of the flames gives the appearance of a hundred baleful eyes, pinning you with their gaze.\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Menu("1. Jump off the road, 2. Continue");
            Console.ForegroundColor = ConsoleColor.White;
            temp = Console.ReadLine();
            if (temp == "1")
            {
                Console.Clear();
                Console.WriteLine("You take a flying leap off the road, and the wind whirls in your ears. You were told we all float down\n" +
                    "here.\n\n" +
                    "So that was a lie.\n\n");
                DeathScreen();
            }
            Console.Clear();
            choiceloop = true;
            while (choiceloop == true)
            {
                Console.WriteLine("But as you walk through the city, you begin to hear a noise that you hadn't realized you missed: the sound\n" +
                    "of voices. Ahead of you, in the middle of an open plaza, stand a group of people. Not demons, people, dressed in loose,\n" +
                    "flowing robes. Their voices flow across the wind, sonorous and overlapping. You don't understand the words, but they\n" +
                    "carry meaning. They are surrounding someone in the center, a woman with red hair that whips in the hot wind.\n\n" +
                    "This...looks a lot like a cult.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("1. Approach the cult, 2. Carry on");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch (temp)
                {
                    case "1":
                        Console.WriteLine("You deviate from your path, approaching the plaza. As you approach, you see many of the\n" +
                            "cloaked figures eyeing you, but they do not stop their chanting. It's eerie, as if they have traded their\n" +
                            "individuality for a single, sonorous voice. The red-haired woman in the center, however, lowers her arms as\n" +
                            "you approach.\n\n" +
                            "'Even in hell, the chain that is humanity remains unbroken. King Minos sends us a gift.'\n\n" +
                            "What's your next move?\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("1. Question, 2. Attack");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp = Console.ReadLine();
                        Console.Clear();
                        switch (temp)
                        {
                            case "1":
                                if (intelligence > 12)
                                {
                                    Console.WriteLine("You manage to shake off the surreal feeling and buckle down. Who is King Minos? Who is she?\n" +
                                        "What is she doing here?\n\n" +
                                        "'Does thou not remember King Minos? He who condemned you unto eternal torment? It is he that chooses\n" +
                                        "unto what Circle thou art condemned, as is his right, given unto him by God.'\n\n" +
                                        "You have another memory, this one disjointed and blurry; You remember being wrapped in layers of cloth,\n" +
                                        "so confused after your death.\n");
                                }
                                else
                                {
                                    Console.WriteLine("You have many questions, thrashing in your mouth, but you only manage to ask one. Who are these\n" +
                                        "people, and what are they doing chanting in a circle?\n");
                                }
                                Console.WriteLine("'I am Mystery, Babylon the Great, and these, my children.'\n\n" +
                                    "The woman is beautiful, and her voice soft, but something about her sets you on edge. You are in Hell, after all:\n" +
                                    "there is no comfort to be found in this place.\n\n" +
                                    "'We perform a ritual to learn the name of God, and together, we shall leave this place.'\n\n" +
                                    "Mystery holds out her hand, decorated with many rings, and smiles at you. It's a clear invitation.\n");
                                mystery = true;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("1. Join, 2. Refuse");
                                Console.ForegroundColor = ConsoleColor.White;
                                temp = Console.ReadLine();
                                Console.Clear();
                                switch (temp)
                                {
                                    case "1":
                                        Level3_2(0);
                                        break;
                                    case "2":
                                        Console.WriteLine("You think about it, before shaking your head. Mystery smiles sadly before withdrawing.\n\n" +
                                            "'Free will is thy right, after all.'\n\n" +
                                            "You see her return to her spot in the center of the circle before you leave.\n");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Menu("Press ENTER to continue...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Level3_1(1);
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine($"You lunge at the woman, anticipating the crunch of bone, but your {weaponName} glances off a pane\n" +
                                    $"of invisible energy. The woman's eyes flash with arcane power, and you are lifted up off your feet." +
                                    $"\n\n'Thou art a brute, and I have no use for you. Return to me when hell has broken you.'\n\n" +
                                    $"A great force sweeps across you, like a wind, and you find yourself tumbling end-over-end through the air.\n" +
                                    $"One of those eerie floating roads spins into your view, and then everything goes black.");
                                choiceloop = false;
                                Console.ReadLine();
                                Level3_1(2);
                                break;
                        }
                        choiceloop = false;
                        break;
                    case "2":
                        Console.WriteLine("You know enough to avoid getting involved with cults. You move on.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        choiceloop = false;
                        Level3_1(1);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Incorrect input, please choose a valid option.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

            }

            choiceloop = true;
            if (cultist == false)
            {
                while (choiceloop)
                {
                    Console.Clear();
                    Console.WriteLine("You stand in the center of the city plaza, surrounded by the sonorous chanting of the worshippers.\n" +
                       $"As they {cultThings[rand.Next(cultThings.Length)]}, " + (mystery == true ? "Mystery" : "the red-haired woman") + " steps down to meet you.\n\n" +
                       "'Thou hast returned, stranger. Hast thou changed thy mind? Wilst thee join us?'\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("1. Join, 2. Attack, 3. Question, 4. Leave");
                    Console.ForegroundColor = ConsoleColor.White;
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "1":
                            Level3_2(1);
                            choiceloop = false;
                            break;
                        case "2":
                            if (holyRune == true)
                            {
                                Console.Clear();
                                Console.WriteLine("You step forwards, feeling the heat of the rune across your chest. It washes away your fear.\n\n" +
                                    "'What is that, Stranger? Dost thou believe that thee can escape damnation with the blessing of a condemned angel?'\n\n" +
                                    "Despite her words, you can see fear entering her expression, even as she summons her wicked scythe to her side.\n" +
                                    "It's a fight!\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                Combat("Babylon The Great", 5, 4);
                                if (!coward)
                                {
                                    Console.WriteLine("'No, this cannot be! This cannot!'\n\n" +
                                        "With a scream, the woman falls back, and for a moment you think she might flee. But then she holds out her hands,\n" +
                                        "and the ground shakes. You stumble, trying to keep you balance. But the followers, those men and women who swore their\n" +
                                        "souls into Mystery's service, they begin to melt. Their flesh sloughs away like putty, flowing and wrapping and pooling\n" +
                                        "about Mystery's feet. She is subsumed, a writhing mass of limbs embracing her like armor.\n\n" +
                                        "'I AM MYSTERY, THE DEATH OF KINGS!'\n\n" +
                                        "She looms over you, towering now. But you feel something in your chest tingle.\n");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Menu("1. Unleash the Holy Rune");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("It feels like something is tearing its way out of you, a force of immense power. The darkness of hell\n" +
                                        "washes away from a pure radiant light bursting from your eyes and mouth, sending Mystery skidding back from you\n" +
                                        $"in shock. The taste of spice fills your mouth, just as your {weaponName} fills with holy power.\n" +
                                        $"Mystery, surrounded in her loathesome armor, crawls towards you with all her power, but this time you have the strength\n" +
                                        $"to meet her.\n");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Menu("Press ENTER to continue...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.Clear();
                                    weapon = 10;
                                    weaponName = $"Light-Infused {weaponName}";
                                    vitality = 100;
                                    Combat("Mystery, the Death of Kings", 8, 8);
                                    beatMystery = true;
                                    choiceloop = false;

                                }
                                else
                                {
                                    Console.WriteLine("'Thou hast seen the power I wield.'\n\n" +
                                       "Mystery dismisses her scythe, her chest heaving. She fixes you with a glare, while you see her wounds\n" +
                                       "closing even as her followers wail, their own bodies opening up gaping pores. They writhe, but they seem to find\n" +
                                       "the experience rapturous.\n\n" +
                                       "'Next time I may not be so generous.'\n");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Menu("Press ENTER to continue...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"You rush Mystery, {weaponName} drawn back. But she's unnaturally fast, back-stepping away from your swing with a\n" +
                                    $"dancer's grace. She looks at you, tilting her head almost quizzically, but you can see the surge of bloodlust come into her eyes." +
                                    $"'If that is thy wish...'\n\n" +
                                    $"She hold out her hands, and a shimmery red scythe coalesces in her hands. It's taller than her, and wickedly sharp, but" +
                                    $"she twirls it around easily.\n\n" +
                                    $"'I, Babylon the Great, shall happily indulge you.'\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                Combat("Babylon the Great", 8, 5);
                                if (coward == true)
                                {
                                    Console.WriteLine("'Thou hast seen the power I wield.'\n\n" +
                                        "Mystery dismisses her scythe. Although you just attacked her, she doesn't seem angry. In fact, you can see her wounds\n" +
                                        "closing even as her followers wail, their own bodies opening up gaping pores. They writhe, but they seem to find\n" +
                                        "the experience rapturous.\n\n" +
                                        "'Perhaps thee shall reconsider where thou stands.'\n");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Menu("Press ENTER to continue...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case "3":
                            CultMenu();
                            break;
                        case "4":
                            Console.Clear();
                            Level3_1(3);
                            break;
                    }
                }
            }

            if(beatMystery)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("War Scythe Gained, Karma increased");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nThe light steaming off you finally fades, as Mystery's blood pools across the ground.\n" +
                    "You gasp, feeling your injuries now that the angelic power filling your body is gone. But something catches\n" +
                    "your eye. It's Mystery's scythe, tip-down in the earth. You heft it up. It's a fine weapon.\n");
                weapon = 4;
                weaponName = "War Scythe";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("You know the name of God");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nBut that's not all. As you touch the weapon, something flashes into your mind, a Truth too vast\n" +
                    "for the Universe. All that's left is to return to Uriel. There is nothing but ruin left here.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Level3_1(5);
                
            }
            else 
            {
                Level3_1(6);
            }
            Level4();
        }
        public static void Level3_1(int route)//The layer guardian
        {
            string temp = " ", angelName = "The Angel";
            bool choiceloop = false;
            string nameOfGod = rand.Next(0, 999).ToString();
            int encounter = 0;

            Console.Clear();
            switch (route)
            {
                case 1:
                    Console.WriteLine("You hike up the winding road, carefully keeping your balance on the narrow path. The atmosphere is\n" +
                    "becoming increasingly stuffy as you climb; all the hot air is gathering at the roof of the cave. It feels like\n" +
                    "forever when you finally find something of note. But what a 'something' it is! Before you stands a massive door\n" +
                    "built into the roof of the cave, easily large enough to usher through a construction crane. But before the door\n" +
                    "stands something... otherworldy.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("It's a being of immense splendor; a titan formed of light and flame, with wings spread to block the\n" +
                        "gate and a flaming sword planted tip down in the road. It can only be an angel, but the pure, blazing radiance of\n" +
                        "its face is a little like the sun: blinding. Behind its head hovers a wheel of fire, rimmed with multitudes of eyes,\n" +
                        "and as you approach, those eyes roll to focus down on you.\n\n" +
                        "'WHO APPROACHES?'\n\n" +
                        "The angel bellows, a challenge.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("1. State your name, 2. Attack, 3. Pause");
                    Console.ForegroundColor = ConsoleColor.White;
                    temp = Console.ReadLine();
                    Console.Clear();
                    switch (temp)
                    {
                        case "1":
                            Console.WriteLine("The Angel's halo spins, and you can see it scanning you. It's radiant face darkens.\n\n" +
                                "'A SINNER COME TO ESCAPE THEIR FATE? NOT SO EASILY IS HELL BESTED.'\n\n" +
                                "Despite his harsh words, he makes no move to attack you.\n\n" +
                                "'I AM URIEL, AND ONLY THOSE WHO PASS MY CHALLENGE SHALL MAKE IT THROUGH THE GATE.'\n");
                            angelName = "Uriel";
                            break;
                        case "2":
                            Console.WriteLine($"You surge forwards, {weaponName} ready. Yes. he's large, but you are faster. All you--\n" +
                            $"You don't even have time to react as Uriel swings, and you are reduced to nothing but atoms.\n");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You Are Dead.\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine($"\n\"From a small spark comes a flame.\"");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Soothing warmth surrounds you, and you find yourself lying on your back, staring at the inverted\n" +
                                "city once more. The angel withdraws his hands, his angelic power knitting your body back from the ether.\n\n" +
                                $"'THAT WAS NOT THE CHALLENGE, {name.ToUpper()}'\n");
                            angelName = "The Angel";
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            death++;
                            Console.Clear();
                            break;
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("-10 Vitality");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nSlowly, you come to, feeling woozy and unsure of yourself. Light is washing over you, a touch\n" +
                        "of relief in the agony of Hell. When you look for it's source, you see it-- a titanic being formed of light and\n" +
                        "flame, holding out an armored hand in your direction. As you stand up, it withdraws.\n\n" +
                        $"'YOU HAVE NOT PERISHED YET, {name.ToUpper()}. I AM URIEL, GUARDIAN OF THE GATE.'\n\n" +
                        $"It stands upright, and you see what stands behind it: a truly massive gate built into the ceiling.");
                    angelName = "Uriel";
                    break;
                case 5:
                    Console.WriteLine("Anointed with the Name of God, you leave the ruined plaza behind. Mystery was right about just one.\n" +
                        "thing; it's time to leave this desolate place;\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 6:
                    Console.WriteLine("You open your mouth, the blasphemed truth on your lips; and Mystery reels. You don't have time to waste,\n" +
                        "you turn away, leaving the screaming woman with her followers. It's time to go, one way or another. It's a long walk,\n" +
                        "until you finally find the gate, and it's holy guardian.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("You turn away from the plaza, leaving it behind and hiking back up to the gate.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Press ENTER to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
            choiceloop = true;
            while (choiceloop)
            {
                Console.WriteLine($"{angelName} stands before you, blade planted between his feet. The heat from that weapon scalds your\n" +
                    "skin even at this distance, and in sheer size, it's larger than your whole body.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("1. Challenge, 2. Attack, 3. Question, 4. Return to the Cult");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch (temp)
                {
                    case "1":
                        Console.WriteLine($"{angelName}'s wings spread, and he speaks in a voice like trumpets.\n\n" +
                            "'WHAT IS THE NAME OF GOD?'\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("" + (route == 5||route == 6 ? $"{nameOfGod}. Speak the Name of God," : "Type your response then press ENTER to continue..."));
                        Console.ForegroundColor = ConsoleColor.White;
                        temp = Console.ReadLine();
                        Console.Clear();
                        if (temp == nameOfGod)
                        {
                            if (route == 5)
                            {
                                karmaScore = karmaScore + 5;
                                Console.WriteLine("Uriel's wings spread, and a burst of radiant flame explodes from his body. A sound like a clear trumpet\n" +
                                    "rings out. The titan of flame nods, a smile spreading across his face.\n\n" +
                                    "'THAT IS THE CORRECT ANSWER. WELL DONE, TO WALK THE PATH OF RIGHTEOUSNESS.'\n\n" +
                                    "The gate behind him shudders, and you feel a wash of air across your face. It's time to go. You earned it.\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else 
                            {
                                Console.WriteLine("The Angel blanches, the light that radiates from his body dimming.\n\n" +
                                    "'WHAT HAVE YOU DONE? DEFILER! BLASPHEMER! YOU HAVE STOLEN THAT WHICH WAS MOST SACRED!'\n\n" +
                                    "For the first time, you feel genuine hatred coming from his voice, as he yanks the sword from the ground and\n" +
                                    "charges you. Your blasphemy has consequences; it's a fight!\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                Combat("Uriel the Guardian", 4, 7);
                                if (coward == true)
                                {
                                    Console.WriteLine("You flee, but where is there to go? Only death awaits you.\n");
                                    DeathScreen();
                                }
                                Console.WriteLine("Uriel stumbles, but catches himself on one hand. His armor shatters, and he is no longer shaped\n" +
                                    "like a man, but an unbound flame.\n\n" +
                                    "'I WILL NOT ALLOW YOU TO PASS'.\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                Combat("Uriel the Guardian", 5, 0);
                                if (coward == true)
                                {
                                    Console.WriteLine("You flee, but where is there to go? Only death awaits you.\n");
                                    DeathScreen();
                                }
                                Console.WriteLine("The gateway is silent, whispering, holding the echoes of the heresy that you have committed. It is\n" +
                                    "a forlorn feeling. But something calls to you from the place where Uriel once stood, something glimmering a dull\n" +
                                    "gold.\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Angelic Splinter gained");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nIt's a piece of his armor, sharp and jagged, but still holding remnants of angelic power.\n" +
                                    "It will make a fine weapon. As you pick it up, the gate creaks, then, with a terrific rumbling, it breaks open.\n" +
                                    "Air rushes against your face, blowing away the scent of ash, and you take one last look at the Circle of Heresy.\n" +
                                    "It's time to leave.");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                weapon = 4;
                                weaponName = "Angelic Splinter";

                            }

                            choiceloop = false;
                        }
                        else
                        {
                            Console.WriteLine($"{angelName} shakes his radiant head.\n\n" +
                                "'THAT IS NOT THE NAME OF GOD.'\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "2":
                        Console.WriteLine($"You surge forwards, {weaponName} ready. Maybe if you try--\n" +
                            $"You don't even have time to react as Uriel swings, and you are reduced to nothing but atoms.\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You Are Dead.\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($"\n\"Follow your own path, wherever it may lead you.\"");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Soothing warmth surrounds you, and you find yourself lying on your back, staring at the inverted\n" +
                            "city once more. Uriel withdraws his hands, his angelic power knitting your body back from the ether.\n\n" +
                            $"'THAT WAS NOT THE CHALLENGE, {name.ToUpper()}'\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        death++;
                        break;
                    case "3":
                        AngelMenu();
                        break;
                    case "4":
                        Console.WriteLine("The Angel nods as you leave, and you make the lonely trek back to the city.");
                        if(route == 5 || route == 6)
                        {
                            Console.WriteLine("The sound of desolate whispers and screams of fury meet you; there is nothing but ruin here now.\n" +
                                "You should leave.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to return");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (holyRune)
                        {
                            Console.WriteLine("On the way back, you see a glimmering, wavering light that you hadn't noticed before. It\n" +
                                "beckons to you.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Bonfire();
                            choiceloop = false;
                        }
                        else
                        {
                            encounter = rand.Next(0, 20);
                            if (encounter == 1)
                            {
                                Console.WriteLine("On the way back, you are ambushed by a shrieking demon!\n");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Menu("Press ENTER to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Combat("The Shrieking Demon", 2, 5);
                            }
                            choiceloop = false;
                        }
                        break;
                }
            }
    
        }
        public static void Level3_2(int route)//Join the cult
        {
            string temp = "";
            bool choiceloop = false;

            Console.Clear();
            switch(route)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Karma lowered");
                    karmaScore = karmaScore - 5;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nYou place your hand in Mystery's, and she smiles, all white teeth and red lips. She pulls\n" +
                        "you into the center of the Plaza, and her followers begin to sing. You don't understand the words, but\n" +
                        "you can feel the power pulsing into your chest with each beat.");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Menu("Karma lowered");
                    karmaScore = karmaScore - 5;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nYou've made your choice. This woman may be a sinner, but she's definitely more personable\n" +
                        "than Uriel. And frankly, you don't care what you have to do; as long as you get out of here, you're happy.\n\n" +
                        "'Thou art wise.'\n\n" +
                        "Mystery steps forwards, and places a gentle hand on your wrist, drawing you further into the circle of adulant\n" +
                        "worshippers.");
                        break;
                case 3:
                   Console.WriteLine( "You already did that, silly.");
                    break;

            }
            if (route != 3)
            {
                Console.WriteLine("When you stand in the center, Mystery turns to face you.\n" +
                    "She's holding a knife.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("Press ENTER to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("'Take up this blade, and inscribe the secret name upon thy brow, and together we shall commune.'\n\n" +
                    "She hands you the knife, glinting in the reddish light. The worshippers around you raise their hands, some\n" +
                    "brushing you with their fingertips, while others chant in increasingly sonorous tones. The energy is mounting.\n" +
                    (intelligence >= 15 ? "However, you notice that they all bear the same mark across their foreheads, but not a single wound has healed.\n" : ""));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("1. Inscribe the mark, 2. Refuse, " + (intelligence > 15 ? "3. Fake the mark," : ""));
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();
                switch (temp)
                {
                    case "1":
                        Console.WriteLine("You grip the knife, and inscribe a mark across your forehead. You cannot see it, but\n" +
                            "Mystery smiles, letting you know all you need. At once, you can feel your mind expand, and the voices\n" +
                            "of the choir around you snap into clarity. The words carry meaning now, drifting along, tugging at your\n" +
                            "consiousness. And Mystery...\n\n" +
                            "She glows.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("You cannot help but worship, as if you are in a daze. The words flow past, one after the\n" +
                            "other. Words shouldn't multiply meaning, but these do: stacked one atop the other like stones.\n" +
                            "Meaning expands your mind.\n\n" +
                            "You are one, and you are home. Perhaps, in this form, you do escape Hell, riding the back of Babylon the Great.\n" +
                            "But at that point, it's no longer you.\n");
                        DeathScreen();
                        break;
                    case "2":
                        Console.WriteLine("Mystery frowns.\n\n" +
                            "'I'm afraid that this is a requirement. Do not stop at the threshold, the cusp of greatness.'\n\n" +
                            "Several of her followers approach you, suddenly trying to hold you down, while another takes the\n" +
                            "knife, attempting to mark you by force. You throw them aside, and prepare to fight back!\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Combat("Cultist", 1, 1);
                        break;
                    case "3":
                        Console.WriteLine("You inscribe the mark on your forehead, but you carefully add a few extra lines to it.\n" +
                            "HOnestly, you have no idea what this will do, but the mindless cultists kind of give you the creeps.\n" +
                            "Mystery smiles, and then the world spins.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("At once, you can feel your mind expand, and the voices\n" +
                            "of the choir around you snap into clarity. The words carry meaning now, drifting along, tugging at your\n" +
                            "consiousness. Multiplying. Combining. Your brain touches the edge of a truth so vast you nearly black out.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("You have stolen the Name of God");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYou snap back to consciousness, and everything feels different. The cult feels it too,\n" +
                            "looking about themselves with confused expressions. Mystery looks at you, and her smile is gone.\n\n" +
                            "'Thou hast profaned the ritual!'\n\n" +
                            "She points at you, and the cultists lumber towards you, hands outstretched.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        Combat("Cultist", 1, 2);
                        Combat("Cultist", 1, 2);
                        Combat("Cultist", 1, 2);
                        Console.WriteLine("As the first wave falls, Mystery herself approaches, a shimmering, blood-red scythe\n" +
                            "manifesting in her hands. Fighting her alone would be trouble enough, but she has her whole army\n" +
                            "with her. It is time to leave.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        cultist = true;
                        break;


                }
            }

        }
        public static void AngelMenu()
        {
            string temp = " ";
            bool godQuestion = false, cultQuestion = false, choiceLoop = true;

            

            while (choiceLoop == true)
            {
                Console.Clear();
                Console.WriteLine($"What would you like to question?\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu((godQuestion == false ? "1. How do I pass your challenge?," : "1. And how do I learn that?,") + (cultQuestion == false ? "2. Tell me about the cult, " : "2. How do I beat them when they have plot armor?, ") + "3. Can I really leave hell?, 4. Return");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();

                switch (temp)
                {
                    case "1":
                        if (godQuestion == false)
                        {
                            Console.WriteLine("'YOU MUST LEARN THE NAME OF GOD.'\n\n" +
                                "The Angel replies cryptically.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            godQuestion = true;
                        }
                        else
                        {
                            Console.WriteLine("'SLAY THE CULT IN THE NAME OF RIGHTEOUSNESS, AND IT WILL BE REVEALED.'\n\n" +
                                "The Angel's wings blaze, and the orange glow radiating up from the ground, miles below, increases.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        if (cultQuestion == false)
                        {
                            Console.WriteLine("'DEFILERS. THE HARLOT OF BABYLON OFFERS FALSE TRUTH, WHILE BLEEDING DRY THE SOULS OF HER MISERABLE FOLLOWERS. MANY ARE\n" +
                                "THE BONES THAT LITTER HER WAKE.'\n\n" +
                                "The Angel drives his blade harder into the earth, wings blazing.\n\n" +
                                "'SHOULD THEY BE SLAIN, I WOULD CONSIDER IT SERVICE'\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            cultQuestion = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Holy Rune gained.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n'BABYLON DRAWS HER POWER FROM THE PROFANE RITUALS OF HER FOLLOWERS. I CAN GRANT YOU A POWER'\n" +
                                "THAT WILL UNDO HER WICKED SPELL.'\n\n" +
                                "He reaches forwards, and you feel a scalding power surge across your chest. When you look down, you see a glowing.\n" +
                                "rune across your chest, thrumming with power. It burns, but it feels good.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Menu("Press ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            holyRune = true;
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("'PEHAPS YOU CAN FIND REDEMPTION OF A SORT, BUT I WARN YOU THAT THE PATH WILL NOT BE EASY.'\n\n" +
                            "The Angel seems regretful, the intense light of his countenance dimming. He looks down at you, and sighs.\n");
                        if(karmaScore <=0)
                        {
                            Console.WriteLine("'YOU HAVE A LONG WAY TO GO YET.'\n");
                        }
                        else
                        {
                            Console.WriteLine("'YOUR SOUL IS LIGHTENING ALREADY.'\n");
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "4":
                        choiceLoop = false;
                        Console.Clear();
                        break;
                }
            }
        }
        public static void CultMenu()
        {
            string temp = " ";
            bool choiceLoop = true;
            Console.Clear();

            while (choiceLoop == true)
            {
                Console.Clear();
                Console.WriteLine($"What would you like to question?\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Menu("1. Who are you?, 2. What is your group here doing?, 3. How do I get past the Angel?, 4. Can I leave hell?, 5. Return");
                Console.ForegroundColor = ConsoleColor.White;
                temp = Console.ReadLine();
                Console.Clear();

                switch (temp)
                {
                    case "1":
                        Console.WriteLine("'I am Mystery, Babylon the Great, god of mankind.'\n\n" +
                            "The Woman replies enigmatically, walking around behind you with a tinkling of jewelry.\n" +
                            "She lowers her voice, looking out over the burning plain.\n\n" +
                            "'Thou has known me in thy own life, known me by my works, for I am she who would become as a God.'\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("'Together we will create the Arcanum, and leave this cursed place.'\n\n" +
                            "She gestures to where her followers gyrate in unison, murmuring their sacred songs. Their rythm\n" +
                            "draws your eyes, carrying with it a building sense of power. But their eyes... look vacant.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("'Thou hast not the strength. The angel has been given the strength to halt all who\n" +
                            "would seek to leave this wretched place. But together, if thee and I combined our strength, we could\n" +
                            "wrest the name of God from the aether, and speak it in Profanity.'\n\n" +
                            "Mystery genstures to the gate in the distance, then smiles.\n\n" +
                            "'That will weaken him, I think.'\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Strength gained.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n'Most certainly. Hell is not for us, but a prison for the Angels, those who in ancient\n" +
                            "times did defy the will of God. But we art built to rule; it is our birthright, should only we have the\n" +
                            "will to claim it.'\n\n" +
                            "Her words feel right somehow, like they are burrowing past your skin and inflaming your muscles.\n");
                        if (strength < 15)
                        {
                            strength = strength + 1;
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Menu("Press ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("That's a lot to think about.");
                        choiceLoop = false;
                        break;

                }

            }
        }



        static void SatanSays(ref bool playAgain)
        {
            string guess = "", currentSequence = "", temp = "";
            Random rand = new Random();
            int[] sequence = new int[8]; //Change this number to change the length of 'Satan Says'

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
                                Console.Beep(915, 700);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "r";
                                break;
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" BLUE ");
                                Console.Beep(794, 700);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "b";

                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(" GREEN ");
                                Console.Beep(646, 700);
                                Console.BackgroundColor = ConsoleColor.Black;
                                temp = "g";
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" YELLOW ");
                                Console.Beep(1298, 700);
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
                    do
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Menu("1. Begin Satan Says, 2. Read the Rules");
                        Console.ForegroundColor = ConsoleColor.White;
                        guess = Console.ReadLine();
                        if (guess != "1" && guess != "2") // Invalid Input
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("INVALID INPUT");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Enter to try again");
                            Console.ReadLine();
                        }
                    } while (guess != "1" && guess != "2");

                    if (guess == "2") // If the player wants to read the rules
                    {
                        Console.Clear();
                        Console.WriteLine("You will be presented with a sequence of colours. \nYou must type out the first letter of each color\nFor Example:\n");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" RED ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" BLUE ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" RED ");
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("GREEN \n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("Would mean that you would have to type rbrg and then press Enter\n\nPress enter when you're ready");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else //Input the guess
                {
                    Console.WriteLine("Please enter the sequence");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("r. Red");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("b. Blue");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("g. Green");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("y. Yellow");
                    Console.ForegroundColor = ConsoleColor.White;
                    guess = Console.ReadLine().ToLower();

                }
                if (guess != currentSequence && i != 0) // Wrong Answer
                {
                    Console.WriteLine("Wrong!");
                    Console.WriteLine(currentSequence);
                    playAgain = true;
                    Console.ReadLine();
                    i = sequence.Length; //Ends
                }
                else // Correct Answer
                {
                    if (i > 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Menu("Correct! Press Enter to continue");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                    playAgain = false;
                }
                Console.Clear();
            }
            playAgain = false; // Added to fix loopback errors after final boss fight
        }



        static void RockPaperScissors(ref int timesLost)
        {
            Random rand = new Random();
            int round = 1, computerInput, computerScore = 0, playerScore = 0; // I'm feeling nice and not making it so you need to beat them x times IN A ROW. That would be horrible for people who get stuck on Satan Says
            string guess, computerGuess = "";
            do
            {
                Console.WriteLine($"Your score is currently: {playerScore}/{timesLost}");
                Console.WriteLine("Input your guess! Rock, Paper, or Scissors!\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Menu("r. Rock, p. Paper, s. Scissors");
                Console.ForegroundColor = ConsoleColor.White;
                guess = Console.ReadLine().ToLower();
                Console.Clear();

                computerInput = rand.Next(3); //Decide what the Shadow chooses
                switch (computerInput)
                {
                    case 0:
                        computerGuess = "rock";
                        break;
                    case 1:
                        computerGuess = "paper";
                        break;
                    case 2:
                        computerGuess = "scissors";
                        break;
                }

                //Convert the player's guess to Rock, Paper, or Scissors to make it eso I can do less switch statements
                switch (guess)
                {
                    case "r":
                        guess = "rock";
                        break;
                    case "p":
                        guess = "paper";
                        break;
                    case "s":
                        guess = "scissors";
                        break;
                }

                if (guess == computerGuess) //If the player chose rock
                {
                    Console.WriteLine($"You both decided to choose {guess}! That's a draw!");
                }
                else
                {
                    switch (guess)
                    {
                        case "rock":
                            if (computerGuess == "scissors")
                            {
                                Console.WriteLine($"You decided to go {guess}, and the Shadow decided to go {computerGuess}! You win!");
                                playerScore++;
                            }
                            else
                            {
                                Console.WriteLine($"You decided to play {guess}, but the shadow played {computerGuess}! You lose!");
                            }
                            break;
                        case "scissors":

                            if (computerGuess == "paper")
                            {
                                Console.WriteLine($"You decided to go {guess}, and the Shadow decided to go {computerGuess}! You win!");
                                playerScore++;
                            }
                            else
                            {
                                Console.WriteLine($"You decided to play {guess}, but the shadow played {computerGuess}! You lose!");
                            }
                            break;
                        case "paper":
                            if (computerGuess == "rock")
                            {
                                Console.WriteLine($"You decided to go {guess}, and the Shadow decided to go {computerGuess}! You win!");
                                playerScore++;
                            }
                            else
                            {
                                Console.WriteLine($"You decided to play {guess}, but the shadow played {computerGuess}! You lose!");
                            }
                            break;

                    }
                }
            } while (playerScore < timesLost);

        }

        public static void Level4()// Circle 6: Anger
        {
            level = 4;
            int timesLost = 0;
            bool playAgain = false;
            string decision;
            Console.WriteLine("You enter a dark black room, where the only visible thing is a large door");
            Console.WriteLine("A large light pointing down at the center of the room turns on");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You have entered the layer of:");
            Console.WriteLine(" _______  _        _______  _______  _______ \r\n" +
                "(  ___  )( (    /|(  ____ \\(  ____ \\(  ____ )\r\n" +
                "| (   ) ||  \\  ( || (    \\/| (    \\/| (    )|\r\n" +
                "| (___) ||   \\ | || |      | (__    | (____)|\r\n" +
                "|  ___  || (\\ \\) || | ____ |  __)   |     __)\r\n" +
                "| (   ) || | \\   || | \\_  )| (      | (\\ (   \r\n" +
                "| )   ( || )  \\  || (___) || (____/\\| ) \\ \\__\r\n" +
                "|/     \\||/    )_)(_______)(_______/|/   \\__/\r\n" +
                "                                             ");
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("A humanoid figure emerges from the floor.\nIt looks totally black and has no visible features, like a living standing shadow\n");
            Console.WriteLine("The dark figure stands still for a few seconds and looks around. \nHis head then turns towards your direction and erupts in laughter");
            Console.WriteLine("\"Wow. You really think you can just walk through the Anger layer and just leave?");
            Console.WriteLine("If you want to go through that door, you have to go through me.");
            Console.WriteLine("I will simply challenge you to a game. That's it! Just... Try not to get too angry. You will be punished.\"\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            do
            {
                SatanSays(ref playAgain);
                timesLost++;
                Combat("Shadow", 4, 2);
                
            } while (playAgain == true);

            Console.WriteLine("You have successfully beaten Satan Says! You may now pass the door to enter the next layer!\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Menu("Press ENTER to go through the door...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You begin walking to the door, but just before you reach it you hear the dark figure slowly applauding");
            Console.WriteLine("\"Impressive. You beat Satan Says. Now before you go, I'm going to challenge you to a game of Rock, Paper, Scissors.");
            Console.WriteLine("After all, I am the only one who can open the door.");
            Console.WriteLine($"Based off of your performance on Satan Says, you must beat me {timesLost} times!\"\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            RockPaperScissors(ref timesLost);
            Console.Clear();
            Console.WriteLine("After beating the Shadow at his games, he gives a smile");
            Console.WriteLine("\"Congratulations. It's quite rare that I've seen someone get through both of these challenges. You have proved that you're worthy to cross the door. Good luck.\"");
            Console.WriteLine("The Shadow points his arm at the door and it opens.\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Menu("Press ENTER to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Level5();








        }







        public static void Level5()// Circle 5: Greed
        {
            Console.Clear();
            string decision;
            level = 5;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You enter Hell’s Casino—a palace of false promise and endless debt.\n" +
                "Gold-lined walls shimmer under flickering neon, masking the desperation in the air.\n" +
                "Fortune teases, greed consumes, and the deeper you go, the harder it is to escape.\n\n");

           
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. Play Slots");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\t\t\t\t\t\tGold:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{gold}\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("2. Play Russian Roulette\n3. Fight in the pits\n4. Loan Shark\n5. Gate Keeper ( Leave )");
            

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
                    Level5_1();
                    break;

            }




        }

        public static void LoanShark()
        {
            string decision;
            Console.Clear();

            if (debt == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You enter the loan shark’s office. The place is cramped, dimly lit, \nand reeks of stale cigars. He leans forward, fingers drumming against a ledger of debts.\n" +
                                 "'You want a loan, eh? Fine. But make sure you pay it back before you leave… or else.'\n\n");
              
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("|   1. Take the loan (1000 gold)   |   2. Leave   |");

                decision = Console.ReadLine();

                switch (decision)
                {
                    case "1":
                        Console.WriteLine("You take the loan, hoping fortune provides the means to pay it back. The loan shark’s stern gaze makes one thing clear—he isn’t the forgiving type.\n\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("+1000 Gold!");
                        gold += 1000;
                        debt = true;
                        Console.ReadLine();
                        Level5();
                        break;

                    case "2":
                        Level5();
                        break;

                    default:
                        LoanShark();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You enter the loan shark’s office. The place is cramped, dimly lit, \nand reeks of stale cigars. He leans forward, fingers drumming against a ledger of debts.\n" +
                                "'Ohh, you're here to repay your debt, eh? About time. I hope, for your sake, you brought enough.'\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("|   1. Repay debt (1200 Gold)   |   2. Leave   |");

                decision = Console.ReadLine();

                switch (decision)
                {
                    case "1":
                        if (gold >= 1200)
                        {
                            Console.WriteLine("You place the gold on the desk. The Shark looks shocked, but with a grin slides the money into a drawer. \n" +
                                              "'Good doing business with you.'\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-1200 Gold!");
                            gold -= 1200;
                            debt = false;
                            Console.ReadLine();
                            Level5();
                        }
                        else
                        {
                            Console.WriteLine("You cannot afford this!");
                            Console.ReadLine();
                            Level5();
                        }
                            break;

                    case "2":
                        Level5();
                        break;

                    default:
                        LoanShark();
                        break;
                }
            }
        }


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
                        Console.WriteLine($"\t\tJackpot baby!! All slots match!\n\t\t         You gain +1 Karma!\n\t\t           And {winnings} gold!\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        gold += winnings;
                        karmaScore = karmaScore + 1;
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

            if (!champion)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"The fighting pits roar with blood-soaked desperation...\n" +
                    "A grizzled pitmaster leans against the iron gate, his voice filled with sadistic amusement.\n" +
                    "'Care to try your luck, stranger? The house pays well... if you survive.'\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Fight! (350 gold)\n2. Leave");
                Console.ForegroundColor = ConsoleColor.White;
                decision = Console.ReadLine();

                while (!def)
                {
                    switch (decision)
                    {
                        case "1":
                            def = true;
                            gold -= 350;
                            break;
                        case "2":
                            def = true;
                            Level5();
                            return;
                        default:
                            Console.WriteLine("Invalid input! Please enter a number between 1 and 2");
                            decision = Console.ReadLine();
                            break;
                    }
                }

                Console.Clear();
                Console.WriteLine("'Stepping into the ring—the Young Nephilim...'");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press ENTER to fight!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                // Ensuring player fights the same enemy until they stop fleeing
                do
                {
                    Combat("Infant Nephilim", 1, 1);
                    if (coward)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("'Run? Ha! There's no escaping the Pits, whelp.' The pitmaster sneers as the crowd roars.");
                        Console.WriteLine("You must fight again!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (coward);

                Console.WriteLine($"{name} triumphs, but next… the Cursed Vagabond.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press ENTER to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                // Repeat combat for next enemy if fleeing occurs
                do
                {
                    Combat("Cursed Vagabond", 2, 2);
                    if (coward)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("'Cowardice won't save you now. The crowd demands blood!'");
                        Console.WriteLine("You must fight again!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (coward);

                Console.WriteLine($"'{name} stands victorious, but a new presence looms… Hugh Capet, once a king, now a wretched soul bound by greed.'");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press ENTER to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                // Final fight loop
                do
                {
                    Combat("Hugh Capet", 3, 3);
                    if (coward)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("'You will fight, whether by choice or fate. The Pit swallows all.'");
                        Console.WriteLine("You must fight again!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (coward);

                Console.WriteLine($"'{name} stands victorious—Champion of the Pits! You win {winnings} gold.'\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"+ {winnings} gold!");
                gold += winnings;
                champion = true;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press ENTER to leave");
                Console.ReadLine();
                Level5();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"'The Champion returns… but the pit stands empty.'\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Press ENTER to leave");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Level5();
            }
        }





        public static void RussianRoulette()
        {
            string decision;
            bool game = true;
            int shots = 6;
            int round = 1;
            int winnings;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You enter the Russian Roulette lounge, where silence weighs heavier than fate.\n" +
                              "A polished revolver rests on the table, and every click of the trigger is a heartbeat stolen.\n" +
                              "A demonic figure looms across from a trembling young lady.\n" +
                              "With a slow squeeze of the trigger, her fate is sealed. Her body jerks, then stillness.\n" +
                              "The demon clicks his fingers, and with a flash of fire, she vanishes into the abyss, claimed by the inferno.\n" +
                              "He leans back, turning his burning gaze toward you. His voice drips with amusement, thick with menace:\n" +
                              $"'Step up if you dare, {name}.'\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("1. Play (250 gold)\n2. Leave");
            decision = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (decision == "1")
            {
                if (gold >= 250)
                {
                    gold -= 250;
                    game = true;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to play!");
                    Console.ReadLine();
                    return; 
                }
            }
            else
            {
                return; 
            }

            while (game && shots > 1)
            {
                winnings = round * 250;
                Console.Clear();
                Console.WriteLine($"\nRound {round}: {shots} shots remaining\n");

                // Demon’s Turn
                Console.WriteLine("Demon's turn...");
                Console.ReadLine();
                int roll = rand.Next(0, shots);

                if (roll == 0)
                {
                    Console.WriteLine("The gun erupts. The demon’s skull splits like cracked stone,\nfragments sizzling as they hit the floor. His body jerks once, then nothing.");
                    gold += winnings;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"+{winnings} gold!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    game = false;
                }
                else
                {
                    Console.WriteLine("The demon presses the revolver to his head... Click. He lives.");
                }

                if (game)
                {
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"\nRound {round}: {shots} shots remaining");
                    Console.WriteLine("Your turn.\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("1. Pull the trigger\n2. Quit while you are ahead");
                    decision = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    if (decision == "2")
                    {
                        Console.WriteLine("Pocketing your winnings, you rise from the table and step away.\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"+{winnings} gold!");
                        gold += winnings;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        game = false;
                    }
                    else
                    {
                        roll = rand.Next(0, shots);
                        if (roll == 0)
                        {
                            Console.WriteLine("You press the cold steel to your temple... Slowly you squeeze the trigger.");
                            Console.ReadLine();
                            Console.WriteLine("A deafening blast. Your thoughts splatter, immortalized in a grotesque mural.");
                            Console.ReadLine();
                            Console.Clear();
                            DeathScreen();
                            game = false;
                        }
                        else
                        {
                            Console.WriteLine("Click. Luck still lingers in your grasp.");
                        }
                    }
                }

                if (shots > 1)
                {
                    shots--;
                }

                round++;
            }

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();

        }
        public static void Level5_1()
        {
            string decision;

            if (debt == true) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("As you approach the gatekeeper, you feel something grab your shoulder.\n" +
                                  "Trying to pull a fast one on me, eh? Bold move. But you know how this works. Debts don’t just disappear.\n" +
                                  "The loan shark casts a menacing shadow over you.\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("|   1. Repay debt   |   2. Suffer the consequences   |");
                decision = Console.ReadLine();

                switch (decision)
                {
                    case "1":
                        if (gold >= 1200)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("'Fine. But don’t think this means we're square. I’ll remember you hesitated.'");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Gold -1200\nKarma -5");
                            gold -= 1200; 
                            debt = false;
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough to repay the debt!");
                            Console.ReadLine();
                            goto case "2";
                        }
                        break;

                    case "2":

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Bad call. You’ll regret this.\n");

                        Console.WriteLine("Before you can even process what's happening, a fist slams into your gut.\n" +
                                          "The world tilts as you're sent sprawling, each blow driving the lesson home—you don’t walk away from debt.\n\n");
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Health -50\nKarma -10\nGold -{gold}");
                        gold = 0;
                        vitality -= 50;
                        karmaScore -= 10;
                        debt = false;
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("\nInvalid Input!");
                        break;
                }
            }
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'Ah, another traveler seeking passage! Fear not, for these stairs demand no toll—only the courage to climb.\n" +
                "Greed has weighed down many souls, but ahead lies gluttony, where excess takes a different form.\n Step into our dining hall, Where everyone is well-fed'\n\n");
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("|    1. Proceed   |   2. Stay in greed   |");
            Console.ForegroundColor = ConsoleColor.White;

            decision =Console.ReadLine();
            switch (decision)
            {
                case "1":
                    Level6();
                    break;
                case "2":
                    Level5();
                    break;
            }
        }


        public static void Level6()// Circle 4: Gluttony
        {

            
            level = 6;
            string decision;
            Console.Clear();
            Character();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
           
            Console.WriteLine("You enter Gluttony. A vast dining hall sprawls before you, tables overflowing with lavish feasts—roasted meats, golden loaves, and goblets of wine.\n" +
                "All around, bloated figures gorge themselves, shoveling food into their mouths without pause.\n Plates refill endlessly, trapping them in a cycle of indulgence that never satisfies.\n" +
                "Press ENTER to continue");


                Console.WriteLine("Choose your meal:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Lentil Stew – A warm, hearty bowl of slow-cooked lentils,\n infused with fragrant herbs and spices, offering a rich, earthy flavor.\n\n");
            Console.WriteLine("2. Veal Cutlet – A tender, delicately breaded piece of meat,\n pan-seared to a golden crisp and served with a savory sauce.\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            Console.Clear();

            switch (decision)
            {
                case "1":
                    karmaScore += 1;
                    Console.WriteLine("You feel nourished, yet grounded.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                case "2":
                    karmaScore -= 1;
                    Console.WriteLine("The richness lingers, but something feels off.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!");
                    break;
            }

            Console.WriteLine("\nChoose your next meal:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Fresh Garden Salad – Crisp greens, vibrant vegetables, and a drizzle of dressing,\n refreshing and light on the palate.\n");
            Console.WriteLine("2. Foie Gras – A silky-smooth delicacy, served atop toasted bread\n with a subtle, buttery richness that melts in the mouth.\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            Console.Clear();
            switch (decision)
            {
                case "1":
                    karmaScore += 1;
                    Console.WriteLine("Fresh, crisp, and satisfying.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                case "2":
                    karmaScore -= 1;
                    Console.WriteLine("Decadent, yet heavy.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!");
                    break;
            }

            Console.WriteLine("\nChoose your final meal:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Whole Grain Bread & Hummus – A rustic loaf with a crunchy crust,\n paired with creamy hummus that carries a nutty, tangy depth.\n");
            Console.WriteLine("2. Shark Fin Soup – A clear, aromatic broth simmered to perfection,\n featuring delicate strands with a subtle, oceanic taste.\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            Console.Clear();
            switch (decision)
            {
                case "1":
                    karmaScore += 1;
                    Console.WriteLine("Simple yet fulfilling.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                case "2":
                    karmaScore -= 1;
                    Console.WriteLine("A rare taste, but uneasy feelings linger.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-1 Karma");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!");
                    break;
            }

            Console.Clear();
            Console.WriteLine("You step forward, weighed down by indulgence. The gatekeeper eyes you with amusement.");
            Console.WriteLine("\n\n Press ENTER to Proceed to Lust");
            Console.ReadLine();
            Console.WriteLine("The moment you nod, he grips a massive lever and pulls. A rush of weightlessness overtakes you—suddenly,\n" +
                " you're soaring. Vision fades, replaced only by the sensation of wind rushing past," +
                "\n lifting you effortlessly into the unknown.");
            Console.ReadLine();
            Level7();


        }



        










        public static void Level7()// Circle 3: Lust
        {
            level = 7;
            vitality += 1; // Added to avoid being trapped if loan shark is used twice without repayment.
            string decision;

            Console.Clear();
            Console.WriteLine("You land on your feet but cannot see anything. Slowly the fog of war clears,\n" +
                "you are standing in the pit of a rocky chasm. The sky above is an iridescent\n" +
                "purple with lines of black almost tearing up the sky. You are in some kind of anomaly unlike \n" +
                "anything you have ever experienced.\n\nTo your left you see a path stretching up the chasm leading to higher ground\n" +
                "It is unclear what lies straight ahead as the path is shrouded by a cloud of dust and debris.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to Dark yellow
            Console.WriteLine("1. Ascend to higher ground, where the air grows thin and the unseen stir.\n2. Press forward, into the shrouded unknown.");
            decision = Console.ReadLine(); // decision now equals user input
            
            switch (decision)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You tread the worn path to the left ramp, you feel the air pressure lessen as you progress");
                    Level7_1();
                    break;
                case "2":
                    Level7_2();
                    break;
                default:
                    Level7();
                    break;

            }


        }

        public static void Level7_1() // Circle 3: Lust - Taking the path to high ground
        {
            string decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You follow the left path, rising steadily until you're about 100 meters above the chasm’s depths.\n" +
                "The ground beneath you narrows, forcing cautious steps. Pressing forward, you reach a rope bridge,\n" +
                "its worn strands shifting in the breeze. Glancing back, you spot the leftmost edge of the wall—rough,\n" +
                "but climbable.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Climb the rocky wall.\n2. Step onto the rope bridge.");

            decision = Console.ReadLine(); 

            Console.Clear();

            switch (decision)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You begin climbing the chasm’s side wall when a noise rises from below.\n" +
                        "Looking down, you spot a scaled figure moving upward with unnerving speed. Before you can react,\n" +
                        "it closes the gap, its presence looming just beneath you.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("1. Scramble upward, pushing your limits as the demon closes in.\n2. Lash out with a desperate kick, aiming straight for its stupid face.");

                    decision = Console.ReadLine();

                    Console.Clear();

                    if (decision == "1")
                    {
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
                    break;

                case "2":
                    Level7_3();
                    break;

                default:
                    Level7_1();
                    break;
            }
        }



        public static void Level7_2()// Circle 3: Lust - continuing straight ahead

        {
            int decision;
            Console.Clear(); // clearing console
            Console.ForegroundColor = ConsoleColor.White; // setting text color to white
            Console.WriteLine("The wind howls as you push forward. As the dust settles, a marble staircase comes into view—pristine, out of place.\n" +
                "Descending, a familiar scent of cigar smoke fills the air.\n" +
                "remnants of excess. Greed awaits.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // setting decisions text to "DarkYellow"
            Console.WriteLine("1. Descend the marble stairs (Back to greed)\n" +
                "2. Turn back and take the path upward, away from the excess below.");
            decision = Convert.ToInt32(Console.ReadLine()); // Convert to int and accept users input
            if (decision == 1)
            { Level5(); } // calls Level6 method
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
            Console.ReadLine();
            Console.Clear();
           
            if (chance < 30)
            {
                Console.WriteLine("You make it across the rope bridge, steadying yourself on solid ground. Turning back,\nyou peer into the abyss" +
                    "100 meters of sheer drop. The realization settles in.\n" +
                    "If that rope had snapped, the fall would have been fatal. ");
                Level7_4();
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
                    Console.WriteLine("+2 Strength");
                    strength = strength + 2;
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
            string decision;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("The wind howls through the chasm, its breath sharp with the scent of ruin.\n" +
                      "Below, cracked plains stretch into infinity, bones scattered like whispers of past agony.\n" +
                      "The sky, bruised and relentless, presses down, mirroring the hunger within.\n" +
                      "On the horizon, a solitary tower rises—blackened, defiant.\n" +
                      "It calls to you, its whisper threading through the ruinous winds,\n" +
                      "beckoning you forward into the unknown.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Head Towards the Tower");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("The wind howls, pushing against you, each step heavier than the last.\n\n" +
                       "Your strength fades, the tower distant, unwavering.\n You spot a nearby bonfire");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Rest by bonfire\n2. Leave");
            decision = Console.ReadLine();
            switch (decision)
            {
                case "1":
                    Console.Clear();
                    Bonfire();
                    break;
                case "2":
                    Console.Clear();
                    break;
                default:
                    Level7_4();
                    break;

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The cracked plains stretch endlessly, each step grinding against fragments of ruin.\n Wind, sharp with whispers of past agony, drives you forward.\n" +
                "The Carnal Tower looms ahead, its marble spine fractured, clawing at the heavens. \nThe spiral staircase winds upward—worn, broken, defiant.\n" +
                "At its base stands the gate keeper. His armor, a shiny fusion of metal and sin, exudes an aura of ruin.\n Darkness stares from within his helmet, a silent challenge.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("'Mortal, Your journey was long, but futile. This is King Minos' domain and you are unworthy of his gaze. \n" +
                "Turn back, lest this place strip you bare. There is no salvation here. Only judgment.'\n\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Reason\n2. Attack\n3. Bribe (1000 Gold)");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            decision = Console.ReadLine();
            switch (decision)
            {
                case "1":
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

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("1. Attack\n2. Bribe (1000 Gold)");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        decision = Console.ReadLine();
                    }

                    if (decision == "1")
                    {
                        Combat("Gate Keeper", 7, 3);
                        Console.WriteLine("You step over the fallen gatekeeper, his armor—once gleaming—now darkened with blood.\n" +
                            "Climbing the spiral staircase, you reach the tower’s entrance. As you press your hand against the door,\n" +
                            "a wave of unease washes over you. With a deep breath, you push it open.");
                        Level7_5();
                    }
                    else
                    {
                        Console.WriteLine("'This is Limbo, the threshold of judgment. No offering can change your fate. For your insult,\n you will face the blade.\n\n'");
                        Console.WriteLine("Press ENTER");
                        Console.ReadLine();
                        Combat("Gate Keeper", 7, 3);
                        Console.WriteLine("You step over the fallen gatekeeper, his armor—once gleaming—now darkened with blood.\n" +
                           "Climbing the spiral staircase, you reach the tower’s entrance. As you press your hand against the door,\n" +
                           "a wave of unease washes over you. With a deep breath, you push it open.");
                        Level7_5();
                    }
                    break;

                case "2":
                    Combat("Gate Keeper", 7, 3);
                    Console.WriteLine("You step over the fallen gatekeeper, his armor—once gleaming—now darkened with blood.\n" +
                           "Climbing the spiral staircase, you reach the tower’s entrance. As you press your hand against the door,\n" +
                           "a wave of unease washes over you. With a deep breath, you push it open.");
                    Level7_5();
                    break;

                case "3":
                    Console.WriteLine("'This is Limbo, the threshold of judgment. No offering can change your fate. For your insult,\n you will face the blade.\n\n'");
                    Console.WriteLine("Press ENTER");
                    Console.ReadLine();
                    Combat("Gate Keeper", 7, 3);
                    Console.WriteLine("You step over the fallen gatekeeper, his armor—once gleaming—now darkened with blood.\n" +
                           "Climbing the spiral staircase, you reach the tower’s entrance. As you press your hand against the door,\n" +
                           "a wave of unease washes over you. With a deep breath, you push it open.");
                    Level7_5();
                    break;
            }
        }




        public static void Level7_5() // FINAL BOSS FIGHT
        {
            level = 8;
            string decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  \n\n\n      ▄█   ▄█▄  ▄█  ███▄▄▄▄      ▄██████▄                       ");
            Console.WriteLine("        ███ ▄███▀ ███  ███▀▀▀██▄   ███    ███                      ");
            Console.WriteLine("        ███▐██▀   ███▌ ███   ███   ███    █▀                       ");
            Console.WriteLine("       ▄█████▀    ███▌ ███   ███  ▄███                              ");
            Console.WriteLine("      ▀▀█████▄    ███▌ ███   ███ ▀▀███ ████▄                       ");
            Console.WriteLine("        ███▐██▄   ███  ███   ███   ███    ███                      ");
            Console.WriteLine("        ███ ▀███▄ ███  ███   ███   ███    ███                      ");
            Console.WriteLine("        ███   ▀█▀ █▀    ▀█   █▀    ████████▀                       ");
            Console.WriteLine("        ▀                                                           ");
            Console.WriteLine("    ▄▄▄▄███▄▄▄▄    ▄█  ███▄▄▄▄    ▄██████▄     ▄████████           ");
            Console.WriteLine("  ▄██▀▀▀███▀▀▀██▄ ███  ███▀▀▀██▄ ███    ███   ███    ███           ");
            Console.WriteLine("  ███   ███   ███ ███▌ ███   ███ ███    ███   ███    █▀            ");
            Console.WriteLine("  ███   ███   ███ ███▌ ███   ███ ███    ███   ███                  ");
            Console.WriteLine("  ███   ███   ███ ███▌ ███   ███ ███    ███ ▀███████████           ");
            Console.WriteLine("  ███   ███   ███ ███  ███   ███ ███    ███          ███           ");
            Console.WriteLine("  ███   ███   ███ ███  ███   ███ ███    ███    ▄█    ███           ");
            Console.WriteLine("   ▀█   ███   █▀  █▀    ▀█   █▀   ▀██████▀   ▄████████▀            ");
            Console.WriteLine("\n\n\n\t   |    Press ENTER to continue    |");


            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n\nThe chamber is vast, its marble floor smooth and reflective. Soft silver light filters down, illuminating crimson banners that hang motionless.\n" +
                "Tall obsidian pillars line the path, engraved with ancient symbols.\n\n" +
                "At the far end, King Minos sits upon his throne, watching in silence.\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   |   1. Approach Minos   |   2. Visit the Bonfire   |");
            Console.ForegroundColor = ConsoleColor.White;
            decision = Console.ReadLine();
            switch (decision)
            {
                case "1":

                    break;
                case "2":
                    Bonfire();
                    Level7_5();
                    break;
                default:
                    Level7_5();
                    break;



            }
            do
            {
                strength += 1000; /// just testing
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You approach the throne. King Minos looms above,\n" +
                    "his coiled tails writhing like the damned souls he judges. His hollow eyes burn with ancient knowledge,\n" +
                    "his throne a twisted mass of marble and tree roots. His voice rumbles like distant thunder.\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Your sins are weighed, your fate determined. There is no escape.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press ENTER to fight for your life");
                Console.ReadLine();

                Combat("King Minos", 5, 5);

            } while (coward);
            do
            {
                Console.WriteLine("After his defeat, the throne crumbles, and Minos lets out a guttural roar.\n" +
                    "His massive frame coils inward, his form unraveling into a monstrous serpent.\n" +
                    "Scales, dark as obsidian, ripple across his body as his tails fuse into a singular, writhing mass.\n" +
                    "His hollow eyes burn anew, now slitted like those of a beast ancient and unrelenting.\n\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You thought judgment was done? No mortal escapes the coils of fate!");
                Console.ForegroundColor = ConsoleColor.White;
                vitality = 100;
                Console.ReadLine();

                Combat("Serpent Minos", 8, 5);

            } while (coward);
            Level7_6();
        }
        public static void Level7_6()
        {
            string decision;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Minos writhes in agony, his serpent form collapsing into dust and shadow.");
            Console.WriteLine("His body reshapes, sinew and bone snapping into place as he returns to his human form.");
            Console.WriteLine("Weakened and trembling before you, his hollow eyes flicker with desperation.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\"You... you would cast me down so easily?\" Minos gasps, clutching at the ruins of his throne.");
            Console.WriteLine("\"Without a Gatekeeper, chaos will consume Limbo. The souls will wander lost, unjudged, untethered.");
            Console.WriteLine("The abyss will spill into the world itself!\"\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("He kneels, bloodied and broken, his once-imposing figure reduced to a pleading shell.");
            Console.WriteLine("Then, lifting his gaze, he fixes you with a knowing stare.\n");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\"Spare me, and I will continue my duty.");
            Console.WriteLine("Kill me, and you will unleash madness.");
            Console.WriteLine("Or... you may take my place, if you have the strength to bear it.\"\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your choice:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("1. Kill Minos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Spare Minos");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("3. Become the new Gatekeeper\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Make your final decision:\n");
            
            decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    BadEnding();
                    break;

                case "2":
                    GoodEnding();
                    break;

                case "3":
                    NeutralEnding();
                    break;

                default:
                    Level7_6();
                    break;
            }
        }


        

















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
                Console.Write("   300 Gold\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("2. Strength Elixer");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   || Boosts Strength by 5 ||");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   500 Gold\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("3. Arclight Blade of Obliteration");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   || A radiant blade that erases existence.  ||");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   8000 Gold\n\n");

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
                        if (gold >= 8000)
                        {
                            gold = gold - 8000;
                            
                            Console.Clear();
                            Console.WriteLine("Item Purchased.");
                            weapon = 20;
                            weaponName = "Arclight Blade of Obliteration";
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
        {
            string decision = "";
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
            while (leaver == false)
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




        public static void GoodEnding()
        {
            Console.Clear();
            Console.WriteLine("You've fought your way out of hell, through traitors, murderers, defilers; You know that King Minos is right.\n" +
                "Unlike everyone else you fought, he was the only one not condemned here, the only one here by choice. Hell is a place of\n" +
                $"punishment, and maybe you deserved to be there. You withdraw your {weaponName}, and step back, letting out a long breath.\n\n" +
                $"Then, you offer King Minos your hand.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Menu("Press ENTER to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("'You're sparing me?'\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("He heaves himself up onto his throne, but you turn away. In front of you are wrought gates of black iron,\n" +
                "reading 'ABANDON ALL HOPE, YE WHO ENTER HERE;' The gates of Hell itself. You wonder if sparing King Minos means\n" +
                "that you don't deserve to be here anymore. You turn back to the fallen King, and he grimaces... but then waves his hand.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Menu("Press ENTER to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("The gates of hell swing open.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Menu("Press ENTER to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("The world beyond is full of sorrow, despair, and desolation. You remember it, the shades falling from your eyes;\n" +
                "the war, the famine, the bloodshed. But it's also a place where the sun plays across riverbeds, where stars glimmer\n" +
                "between silver-lined clouds, where mothers sing songs to their children. As you step beyone the threshold, you feel\n" +
                "something warm return to you, something you hadn't even realized you had missed.\n\n" +
                "Hope.\n\n" +
                "It's time to see what the future really holds.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Menu("Press ENTER to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Epilogue();


        }






        public static void BadEnding()
        { }














        public static void NeutralEnding()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The weight of the final choice settles upon you.\nPerhaps redemption is not for all, but servitude bears its own honor.\n\n");
            Console.WriteLine("Minos, once judge and executioner, lies defeated before you—yet you do not cast him aside.\n" +
                "With a steady hand, you pull him from the depths, offering not exile, but purpose.\nA disciple, bound not by chains, but by duty.\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You speak the sacred oath, your voice resonating through the hollow expanse of Limbo:\n\n");
            Console.ReadLine();
            Console.WriteLine("\"The veil lifts, and my burden begins. It shall not end until eternity wanes.\n" +
                "I shall claim no throne,\nwield no dominion, nor seek redemption.\nI shall pass no judgments, nor crave absolution." +
                "\nI shall stand at the gates, an unyielding sentinel. \rI am the voice in the void, the keeper of the lost." +
                "\nI am the shade against the abyss, the final whisper before descent.\nI am the balance that binds the wandering souls, the sentinel of Limbo’s threshold." +
                "\nI pledge my existence and vigilance to this duty—for all who come, and all who shall remain.\"");
            Console.WriteLine("The oath is sealed. Minos bows his head, accepting his place at your side. The throne of Limbo is no longer empty.\r\nThe cycle does not end—but now, you stand as its guardian.");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n                              The End.");
            Console.ReadLine();
            Console.Clear();
            Credits();










        }













        public static void Epilogue()
        { 
        
        }


            }
        }
    

