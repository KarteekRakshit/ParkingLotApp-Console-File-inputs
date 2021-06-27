using BusinessLayer;
using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = true;
            string command;

            Console.WriteLine("Welcome to KartOPark.! Seamless Car Parking");
            string output;

            while (valid)
            {
                Console.WriteLine("Enter your command: ");
                command = Console.ReadLine();

                if (command == "exit")
                {
                    return;
                }

                try
                {
                    CommandSwitch commandSwitch = new CommandSwitch();
                    output = commandSwitch.commandSwitcher(command);
                }
                catch (Exception ex)
                {
                    output = "Something Went Wrong. Error:" + ex;
                    //throw;
                }

                Console.WriteLine(output);

            }
        }
    }
}
