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
        Console.Title = "RedLine Dealership";

        int option;
        bool exit = true, isInteger = false;
        Console.WriteLine("\r\n  ____          _   _     _               ____             ____             _               _     _       \r\n |  _ \\ ___  __| | | |   (_)_ __   ___   / ___|__ _ _ __  |  _ \\  ___  __ _| | ___ _ __ ___| |__ (_)_ __  \r\n | |_) / _ \\/ _` | | |   | | '_ \\ / _ \\ | |   / _` | '__| | | | |/ _ \\/ _` | |/ _ \\ '__/ __| '_ \\| | '_ \\ \r\n |  _ <  __/ (_| | | |___| | | | |  __/ | |__| (_| | |    | |_| |  __/ (_| | |  __/ |  \\__ \\ | | | | |_) |\r\n |_| \\_\\___|\\__,_| |_____|_|_| |_|\\___|  \\____\\__,_|_|    |____/ \\___|\\__,_|_|\\___|_|  |___/_| |_|_| .__/ \r\n                                                                                                   |_|    \r\n");

        do
        {
            Console.WriteLine("\n\nPlease enter the number of the option deseared");
            Console.WriteLine(" 1. Add vehicle\n 2. Update vehicle\n 3. Delete vehicle\n 4. Search Vehicles by ID\n 5. Search vehicle by category\n 6. Generate reports \n 7. Settings \n 0. Exit\n");
            option = Convert.ToInt32(Console.ReadLine());
            if (isInteger = validationInt(option))            //Here should be a validation that the input entered is an integer
            {
                switch (option)
                {
                    case 1:
                        addIVehicle();

                        break;


                    case 2:

                        Vehicle_update();
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
                    case 7:
                            Settings();
                            break;
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
            bool moreItem = false, isdouble = false, isChar = true, charEntered = true, moreItemEntered = true;
            string moreItemAnswer;
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

                    string Q_year = "Please enter the vehicle manufacture year";
                    int year = Var_verify(1, Q_year);
                    vehicle_Year[stock] = year;

                    string Q_price = "Please enter the vehicle price";
                    double mountPrice = Var_verify(2, Q_price);
                    price[stock] = mountPrice;



                    string Q_Cat = "Please enter in uppercase the letter of the vehicle category\n - (S) sedan\n - (P) Sport\n - (C) Convertible\n - (V) Van\n - (L) Luxury";
                    do
                     {
                        category = Var_verify(3, Q_Cat);
                    } while (category == 'S' && category != 'P' && category != 'C' && category != 'V' && category != 'L');
                    
                    Category[stock] = category;

                    

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


    static int Give_Index()
        {
            int index = 0;
            bool Main_valid = true;
            bool valid = true;
            do
            {
                Console.WriteLine("Please choose method to choose vehicle!");
                Console.WriteLine("1) ID");
                Console.WriteLine("2) Make");
                string Choose = Console.ReadLine();




                if (Choose == "1")
                {
                    Main_valid = false;
                    while (valid)
                    {
                        Console.Clear();
                        string Q_ID = "Please enter the ID of the vehicle!!    | type 0 to exit";
                        int User_ID = Var_verify(1, Q_ID);

                        if (User_ID == 0)
                        {
                            index = -2;
                            break;
                        }


                        index = Array.IndexOf(vehicle_IDs, User_ID);


                        if (index != -1)
                            valid = false;
                        else
                        {
                            Console.WriteLine("Please retry!");
                            Console.WriteLine("Press any key to contunie");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else if (Choose == "2")
                {
                    Main_valid = false;
                    while (valid)
                    {
                        int[] Make_Temp = new int[vehicle_Make.Length];



                        int y2 = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the make of the vehicle:    | to exit program type 0");
                            string user_makee = Console.ReadLine().ToLower();

                            if (user_makee == "0")
                            {
                                valid = false;
                                return index = -2;

                            }


                            for (int i = 0; i < vehicle_Make.Length; i++)
                            {
                                if (vehicle_Make[i] != null)
                                {
                                    if (vehicle_Make[i].ToLower() == user_makee)
                                    {
                                        Make_Temp[y2] = i;
                                        y2++;

                                    }
                                }

                            }
                        } while (y2 == 0);



                        bool valid2 = true;
                        while (valid2)
                        {

                            Console.Clear();
                            Console.WriteLine("Car Search list");
                            for (int i = 0; i < y2; i++)
                            {
                                int temp = Make_Temp[i];
                                Console.WriteLine($"{i + 1}. {vehicle_Make[temp]} {vehicle_Model[temp]} {vehicle_Year[temp]}");
                            }

                            Console.WriteLine("Please choose an option:");
                            int choose = Convert.ToInt16(Console.ReadLine());

                            if (choose == 0)
                            {
                                break;
                                index = -2;
                            }
                            else if (choose > 0 && choose <= y2)
                            {
                                index = Make_Temp[choose - 1];
                                valid2 = false;
                                valid = false;
                            }




                        }

                    }
                }
                else
                {
                    Console.WriteLine("\n\nPlease retry entery!");

                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                    Console.Clear();
                }
                    

                
            } while (Main_valid);
            
            return index;
        }

    
    static public void Vehicle_update()
        {
            int index = 0;
            bool valid = true;


            Console.Clear();
            index = Give_Index();

            if (index == -2)
                valid=false;

            while (valid)
            {

                
                Console.Clear();


                Console.WriteLine($"What would you like to update for the\nTitle:    {vehicle_Make[index]} {vehicle_Model[index]} {vehicle_Year[index]} \nprice:    {price[index]:C}\nCategory: {Category[index]}");
                Console.WriteLine("\n1) Vehicle Make");
                Console.WriteLine("2) Vehicle model");
                Console.WriteLine("3) Vehicle Year");
                Console.WriteLine("4) Vehicle Price");
                Console.WriteLine("5) Vehicle Category");
                Console.WriteLine("0) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n\nWhat would you like to change the make to: ");
                        string make = Console.ReadLine();

                        Console.WriteLine($"\nOld Make name: {vehicle_Make[index]}");
                        vehicle_Make[index] = make;
                        Console.WriteLine($"New Make name: {vehicle_Make[index]}");


                        
                        break;
                    case "2":
                        Console.WriteLine("What would you like to change model to: ");
                        string model = Console.ReadLine();

                        Console.WriteLine($"\nOld Make name: {vehicle_Make[index]}");
                        vehicle_Model[index] = model;
                        Console.WriteLine($"New Make name: {vehicle_Model[index]}");
                        
                        break;
                    case "3":
                        string Q_year = "What would you like to change Year to: ";
                        int year = Var_verify(1, Q_year);

                        Console.WriteLine($"\nOld Make name: {vehicle_Year[index]}");
                        vehicle_Year[index] = year;
                        Console.WriteLine($"New Make name: {vehicle_Year[index]}");
                        
                        break;
                    case "4":
                        string Q_price = "What would you like to change price to: ";
                        double Price = Var_verify(2, Q_price);

                        Console.WriteLine($"\nOld Make name: {price[index]}");
                        price[index] = Price;
                        Console.WriteLine($"New Make name: {price[index]}");
                        
                        break;
                    case "5":
                        char cat;
                        string Q_char = "What would you like to change model to: ";
                        do
                        {
                            cat = Var_verify(3, Q_char);
                        } while (cat == 'S' && cat != 'P' && cat != 'C' && cat != 'V' && cat != 'L');
                        
                        Console.WriteLine($"\nOld Make name: {Category[index]}");
                        Category[index] = cat;
                        Console.WriteLine($"New Make name: {Category[index]}");
                        
                        break;
                    case "0":
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Please retry!");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("\n\nPress any key to continue!");
            Console.ReadKey();
            Console.Clear();

        }

    static void DeleteVehicle()
    {

    }


    static void GenerateReports()
    {
        char[] CategorySymbol = {'S', 'P', 'C', 'V', 'L'};
        string[] CorrespondingCategory = { "Sedan", "Sport", "Convertible", "Van", "Luxury" };

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


    public static void Settings()
        {
            Console.Clear();
            Console.WriteLine("1. Change Color");
            string setting_input = Console.ReadLine();

            switch (setting_input) {

                case "1":
                    bool valid = true;

                    while (valid)
                    {
                        Console.Clear();
                        Console.WriteLine("Select a color for the text:");
                        Console.WriteLine("1. Blue");
                        Console.WriteLine("2. Green");
                        Console.WriteLine("3. Red");
                        Console.WriteLine("4. Yellow");
                        Console.WriteLine("5. Cyan");
                        Console.WriteLine("6. Magenta");
                        Console.WriteLine("7. White");
                        Console.WriteLine("0. Exit");

                        Console.Write("Enter your choice (0-7): ");
                        string choice = Console.ReadLine();


                        switch (choice) {

                            case "1":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "3":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "4":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case "5":
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case "6":
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case "7":
                                Console.ForegroundColor= ConsoleColor.White;
                                break;
                            case "0":
                                valid = false;
                                break;
                        }
                    }

                    break;

            }

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


    public static dynamic Var_verify(int type, string question)
        {
            bool isValid = false;
            switch (type)
            {
                case 1:

                    
                    int Int_output = 0;

                    while (!isValid)
                    {
                        Console.WriteLine(question);
                        string user_input = Console.ReadLine();
                        
                        isValid = int.TryParse(user_input, out Int_output);
                        
                    }
                    
                    Console.Clear();
                    return Int_output;

                    break;

                case 2:
                    double Double_output = 0;

                    while (!isValid)
                    {
                        Console.WriteLine(question);
                        string user_input = Console.ReadLine();
                        isValid = double.TryParse(user_input, out Double_output);
                    }

                    Console.Clear();
                    return Double_output;

                    break;

                case 3:
                    char Char_output = 'a';

                    while (!isValid)
                    {
                        Console.WriteLine(question);
                        string user_input = Console.ReadLine();
                        isValid = char.TryParse(user_input, out Char_output) && user_input.Length == 1;
                    }
                    return Char_output;

                    break;
                default:
                    return 0;
                    break;
            }
        }

}

