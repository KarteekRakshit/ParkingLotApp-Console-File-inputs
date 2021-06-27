using DataLayer;
using System;
using System.Collections;

namespace BusinessLayer
{
    public class CommandSwitch
    {

        public string commandSwitcher(string command)
        {
            Hashtable parkingLot = Data.parkingLot;
            Hashtable carDetails = Data.carDetails;

            string[] element = command.Split(' ');
            string elementCommand = element[0];
            string outputMessage = "";
            switch (elementCommand)
            {
                case "create_parking_lot":
                    //create_parking_lot 6
                    try
                    {
                        parkingLot = new Hashtable(int.Parse(element[1]));
                        carDetails = new Hashtable(int.Parse(element[1]));
                        Data.totalParkingSize = int.Parse(element[1]);
                        outputMessage = "Created a parking lot with " + element[1] + " slots";
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                case "park":
                    //park KA-01-HH-7777 Red
                    try
                    {
                        int availableParkingSpot = 0;
                        for (int i = 0; i < Data.totalParkingSize; i++)
                        {
                            if (!parkingLot.ContainsKey(i + 1))
                            {
                                availableParkingSpot = i + 1;
                                break;
                            }
                        }
                        if (availableParkingSpot == 0)
                        {
                            outputMessage = "Sorry, parking lot is full";
                        }
                        else
                        {
                            parkingLot.Add(availableParkingSpot, element[1]);
                            carDetails.Add(element[1].ToString(), element[2].ToString());
                            outputMessage = "Allocated slot number: " + availableParkingSpot;
                        }
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;


                case "leave":
                    //leave 4
                    try
                    {
                        var parkingLotValue = "";
                        var carDetailsIndex = "";
                        if (parkingLot.ContainsKey(int.Parse(element[1])))
                        {
                            parkingLotValue = (string)parkingLot[int.Parse(element[1])];
                            parkingLot.Remove(int.Parse(element[1]));
                        }
                        if (carDetails.ContainsKey(parkingLotValue))
                        {
                            carDetails.Remove(parkingLotValue);
                        }
                        outputMessage = "Slot number " + element[1] + " is free";
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                case "status":
                    //status
                    try
                    {
                        IDictionaryEnumerator e = parkingLot.GetEnumerator();
                        outputMessage = "Slot No.\tRegistration\tNo Colour\n";

                        while (e.MoveNext())
                        {
                            outputMessage += e.Key + "\t\t" + parkingLot[e.Key] + "\t" + carDetails[e.Value] + "\n";
                        }
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                case "registration_numbers_for_cars_with_colour":
                    //registration_numbers_for_cars_with_colour White
                    try
                    {
                        int count = 0;
                        IDictionaryEnumerator e = parkingLot.GetEnumerator();
                        while (e.MoveNext())
                        {
                            if (carDetails[e.Value].ToString().ToLower() == element[1].ToString().ToLower())
                            {
                                count++;
                                outputMessage += parkingLot[e.Key] + ",";
                            }
                        }
                        if (count == 0)
                        {
                            outputMessage = "Not found";
                        }
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                case "slot_numbers_for_cars_with_colour":
                    //slot_numbers_for_cars_with_colour White
                    try
                    {
                        int count = 0;
                        IDictionaryEnumerator e = parkingLot.GetEnumerator();
                        while (e.MoveNext())
                        {
                            if (carDetails[e.Value].ToString().ToLower() == element[1].ToString().ToLower())
                            {
                                count++;
                                outputMessage += e.Key + ",";
                            }
                        }
                        if (count == 0)
                        {
                            outputMessage = "Not found";
                        }
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                case "slot_number_for_registration_number":
                    //slot_number_for_registration_number KA-01-HH-3141
                    try
                    {
                        int count = 0;
                        IDictionaryEnumerator e = parkingLot.GetEnumerator();
                        while (e.MoveNext())
                        {
                            if (parkingLot[e.Key].ToString().ToLower() == element[1].ToString().ToLower())
                            {
                                count++;
                                outputMessage += e.Key + ",";
                            }
                        }
                        if (count == 0)
                        {
                            outputMessage = "Not found";
                        }
                    }
                    catch
                    {
                        return commandCriteriaFailureMessage();
                    }
                    return outputMessage;

                default:
                    return "Unrecognized command";
            }
        }


        private string commandCriteriaFailureMessage()
        {
            return "Invalid Command: Command does not meet the required criteria";
        }
    }
}
