using System.Transactions;

internal class Program
{
    static int Invetory = 20, stock = 0;
    static int[] vehicle_IDs = new int[Invetory];
    static string[] vehicle_Make = new string[Invetory];
    static string[] vehicle_Model = new string[Invetory];
    static int[] vehicle_Year = new int[Invetory];
    static double[] price = new double[Invetory];
    static char[] Category = new char[Invetory];

    static Random random = new Random();

    static void Main(string[] args)
    {


        int option;
        bool exit = true, isInteger = false;
        Console.WriteLine("\r\n  ____          _   _     _               ____             ____             _               _     _       \r\n |  _ \\ ___  __| | | |   (_)_ __   ___   / ___|__ _ _ __  |  _ \\  ___  __ _| | ___ _ __ ___| |__ (_)_ __  \r\n | |_) / _ \\/ _` | | |   | | '_ \\ / _ \\ | |   / _` | '__| | | | |/ _ \\/ _` | |/ _ \\ '__/ __| '_ \\| | '_ \\ \r\n |  _ <  __/ (_| | | |___| | | | |  __/ | |__| (_| | |    | |_| |  __/ (_| | |  __/ |  \\__ \\ | | | | |_) |\r\n |_| \\_\\___|\\__,_| |_____|_|_| |_|\\___|  \\____\\__,_|_|    |____/ \\___|\\__,_|_|\\___|_|  |___/_| |_|_| .__/ \r\n                                                                                                   |_|    \r\n");

        do
        {
            Console.WriteLine("\n\nPlease enter the number of the option deseared");
            Console.WriteLine(" 1. Add vehicle\n 2. Update vehicle\n 3. Delete vehicle\n 4. Search Vehicles by ID\n 5. Search vehicle by category\n 6. Generate reports \n 0. Exit\n");
            option = Convert.ToInt32(Console.ReadLine());
            if (isInteger = validationInt(option))            //Here should be a validation that the input entered is an integer
            {
                switch (option)
                {
                    case 1:
                        addIVehicle();

                        break;


                    case 2:

                        EditVehicle();
                        break;


                    case 3:
                        DeleteVehicle();
                        break;


                    case 4:
                        if (stock == 0)
                        {
                            Console.WriteLine("There are no vehicles in the system!");
                            break;
                        }
                        else
                        {
                            Console.Write("Enter vehicle ID: ");
                            int id = int.Parse(Console.ReadLine());
                            SearchVehicleId(id);
                            break;
                        }


                    case 0:
                        exit = false;
                        break;


                    case 6:
                        GenerateReports();
                        break;
                    
                    
                    case 5:
                        if (stock == 0)
                        {
                            Console.WriteLine("There are no items in the system. ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter in uppercase the letter of the vehicle category\\n - (S) sedan\\n - (P) Sport\\n - (C) Convertible\\n - (V) Van\\n - (L) Luxury\"");
                            char searchChar = char.Parse(Console.ReadLine());                           
                            SearchVehicleCategory(searchChar);
                            break;
                        }
                    
                    default:
                        Console.WriteLine("The option entered does not exist, please check the available options and select one.\n");

                        break;
                }
            }
            else
            {
                Console.WriteLine("The option entered is not a number, please check the available options and enter an option number.\n");
            }

        } while (exit);

    }


    static void addIVehicle()
    {
        bool moreItem = false, isInteger = false, isdouble = false, isChar = true, charEntered = true, moreItemEntered = true;
        string moreItemAnswer;
        int year;
        double mountPrice;
        char category;

        if (stock < Invetory)
        {
            do
            {
                Console.WriteLine("To add a new item into the steck you need the follow data\n - Maker\n - Model\n - Manufacture year\n - Price\n - Category\n\n");
                Console.WriteLine("Please enter the vehicle maker name");
                vehicle_Make[stock] = Console.ReadLine();
                Console.WriteLine("Please enter the vehicle model");
                vehicle_Model[stock] = Console.ReadLine();
                do
                {
                    Console.WriteLine("Please enter the vehicle manufacture year");
                    year = Convert.ToInt32(Console.ReadLine());
                    if (isInteger = validationInt(year))            //Here should be a validation that the input entered is an integer
                    {
                        vehicle_Year[stock] = year;
                    }
                    else
                    {
                        Console.WriteLine("Data entered is wrong. The manufacture year must be a number");
                    }
                } while (!isInteger);
                do
                {
                    Console.WriteLine("Please enter the vehicle price");
                    mountPrice = Convert.ToDouble(Console.ReadLine());
                    if (isdouble = validationDouble(mountPrice))            //Here should be a validation that the input entered is a double
                    {
                        price[stock] = mountPrice;
                    }
                    else
                    {
                        Console.WriteLine("Data entered is wrong. The price must be a number");
                    }
                } while (!isdouble);
                do
                {
                    Console.WriteLine("Please enter in uppercase the letter of the vehicle category\n - (S) sedan\n - (P) Sport\n - (C) Convertible\n - (V) Van\n - (L) Luxury");
                    category = Convert.ToChar(Console.ReadLine());
                    if (isChar = !validationChar(category))            //Here should be a validation that the input entered is a char
                    {
                        if ((category == 'S') || (category == 'P') || (category == 'C') || (category == 'V') || (category == 'L'))
                        {
                            Category[stock] = category;
                            charEntered = false;

                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data entered is wrong. The price must be a letter");
                    }
                } while ((isChar && charEntered));

                int id;
                do
                {
                    id = random.Next(1, 999); // Generate a 3-digit random ID

                } while (Array.IndexOf(vehicle_IDs, id, 0, stock) != -1); // Ensure ID is unique
                vehicle_IDs[stock] = id;

                Console.WriteLine("The vehicle was added in the store with the ID {0}. The data of vehicle are: \n - ID: {0}\n - Maker: {1}\n - Model: {2}\n - Manufactured year: {3}\n - Price: {4}\n - Category: {5}", vehicle_IDs[stock], vehicle_Make[stock], vehicle_Model[stock], vehicle_Year[stock], price[stock], Category[stock]);
                stock += 1;

                if (stock < Invetory)
                {
                    do
                    {
                        Console.WriteLine("Do you want to add another item? Yes/No");
                        moreItemAnswer = Console.ReadLine();
                        if ((moreItemAnswer.ToUpper() == "YES") || (moreItemAnswer.ToUpper() == "NO"))
                        {
                            if (moreItemAnswer.ToUpper() == "YES")
                            {
                                moreItem = true;
                            }
                            else
                            {
                                moreItem = false;
                            }
                            moreItemEntered = false;
                        }
                    } while (moreItemEntered);
                }
            } while (moreItem);
        }
        else
        {
            Console.WriteLine("It is not possible to add more vehicles because the store is full");
        }
    }


    static void SearchVehicleId(int id)
    {
        int index = Array.IndexOf(vehicle_IDs, id, 0, stock);
        if (index != -1)
        {

            Console.WriteLine($"Make: {vehicle_Make[index]}");
            Console.WriteLine($"Model: {vehicle_Year[index]}");
            Console.WriteLine($"Year: {vehicle_Year[index]}");
            Console.WriteLine($"Price: {price[index]}");
            Console.WriteLine($"Category: {Category[index]}");
        }
        else
        {
            Console.WriteLine("Vehicle not found!");
        }
    }

    static void SearchVehicleCategory(char searchChar)
    {
        for (int i = 0; i < Category.Length; i++)
        {
          if (searchChar != Category[i])
                {
                continue;
                }
          else
                {
                 Console.WriteLine($"Vehicle ID: {vehicle_IDs[i]}");
                 Console.WriteLine($"Vehicle Make: {vehicle_Make[i]}");
                 Console.WriteLine($"Vehicle Model: {vehicle_Model[i]}");
                 Console.WriteLine($"Vehicle Year: {vehicle_Year[i]}");
                 Console.WriteLine($"Vehicle Price: {price[i]:C}\n");
                 continue;
                }
        }
    }

    static void EditVehicle()
    {

    }

    static void DeleteVehicle()
    {

    }


    static void GenerateReports()
    {
        // Please replace the categories D:
        char[] CategorySymbol = { 'A', 'B', 'C', 'D', 'E' };
        string[] CorrespondingCategory = { "SUV", "Sports car", "Sedan", "Station wagon", "Hatchback" };

        Console.WriteLine("------------------[ STOCK REPORT ]------------------");
        Console.WriteLine($"Current stock = {stock}\n");
        Console.WriteLine("■--------------------------------------------------■");
        for (int i = 0; i < stock; i++)
        {

            Console.WriteLine($"|{(i + 1) + ".",-50}|");
            Console.WriteLine($"|{"Car #:",-10}{vehicle_IDs[i],-40}|");
            Console.WriteLine($"|{"Make:",-10}{vehicle_Make[i],-40}|");
            Console.WriteLine($"|{"Model:",-10}{vehicle_Model[i],-40}|");
            Console.WriteLine($"|{"Year:",-10}{vehicle_Year[i],-40}|");
            Console.WriteLine($"|{"Price:",-10}{price[i],-40:C}|");
            Console.WriteLine($"|{"Category:",-10}{CorrespondingCategory[Array.IndexOf(CategorySymbol, Category[i])],-40}|");
            Console.WriteLine("■--------------------------------------------------■");
        }
    }


    static bool validationInt(int intNumb)
    {
        return true;
    }

    static bool validationDouble(double doubNumb)
    {
        return true;
    }
    static bool validationChar(char letter)
    {
        return false;
    }

}

