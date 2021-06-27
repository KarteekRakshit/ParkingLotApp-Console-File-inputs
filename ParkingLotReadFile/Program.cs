using BusinessLayer;
using System;
using System.IO;

namespace ParkingLotReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = true;
            string command;

            Console.WriteLine("Welcome to KartOPark.! Seamless Car Parking");
            string output = "";

            while (valid)
            {
                //Console.WriteLine("Enter your command: ");
                //command = Console.ReadLine();

                //if (command == "exit")
                //{
                //    return;
                //}

                try
                {
                    CommandSwitch commandSwitch = new CommandSwitch();

                    var lines = File.ReadLines(@"D:\WEB\EldaHealth\Assignment\FileSolution\ParkingLotReadFile\file_inputs.txt");
                    foreach (var line in lines)
                    {
                        output += commandSwitch.commandSwitcher(line) + '\n';
                    }
                    Console.WriteLine(output);
                    valid = false;
                }
                catch (Exception ex)
                {
                    output = "Something Went Wrong. Error:" + ex;
                    Console.WriteLine(output);
                    valid = false;

                    //throw;
                }


            }
        }
    }
}
