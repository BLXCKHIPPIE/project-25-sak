namespace Wah
{
    internal class Program
    {
        
        
        static void Main() // Declare main method
        {
            Console.WriteLine("Keep me empty pls"); // placeholder
			
			Console.ReadLine(); // pause
            menu(); // calls menu

        }


        static void menu() // Declare title method
        {

            int decision; // define decision variable
            do
            {

                Console.WriteLine("Menu\n1. New Game\n2. Credits\n3. Exit"); // presenting options
                decision = Convert.ToInt32(Console.ReadLine());// taking user input and assigning to decision
                Console.Clear(); // clearing screen
                switch (decision) // switch statement for different options
                {

                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                }
                Console.Clear(); // clear screen
            }
            while (decision != 0); // exit command - placeholder to be worked on
            Console.ReadLine(); // pause


        }
    }
}
