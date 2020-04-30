//Project:  CarsSimpleApplication (Montu's Car Inventory Application)
//Creator:   Montu Patel
//File:      Program.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarsSimpleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program Starts here
            int option1 = DisplayMenu();
            MainCall(option1);
            Console.Read();
        }

        /// <summary>
        /// Containing switch to handle which method to execute
        /// </summary>
        /// <param name="option">Option to Add\Delete\Update Car Information</param>
        public static void MainCall(int option)
        {
            int result = 0;
            int carID1 = 0;

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "CarSimple.csv");
            CarData carRespo = new CarData(fileName);
            var fileContents = carRespo.ReadCarStats();

            switch (option)
            {
                case 1:

                    AddCar(fileContents, carRespo);
                    break;
                case 2:

                    View(fileContents, carRespo);
                    Console.ReadKey();
                    int option1 = DisplayMenu();
                    MainCall(option1);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("  \t ___________________________________");
                    Console.WriteLine("  \t|                                    |");
                    Console.WriteLine("  \t|   Welcome To Edit Car Application  |");
                    Console.WriteLine("  \t|____________________________________|\n");
                    Console.Write("\n\tEnter a Car ID # which you wish to Update: ");
                    carID1 = Convert.ToInt32(Console.ReadLine());
                    result = Edit(carID1, fileContents, carRespo);
                    break;
                case 4:

                    Console.Clear();
                    Console.WriteLine("  \t ______________________________________");
                    Console.WriteLine("  \t|                                      |");
                    Console.WriteLine("  \t|   Welcome To Delete Car Application  |");
                    Console.WriteLine("  \t|______________________________________|\n");
                    Console.Write("\n\tEnter a Car ID # which you wish to Delete: ");
                    carID1 = Convert.ToInt32(Console.ReadLine());
                    result = Delete(carID1, fileContents, carRespo);
                    if (result == 1)
                    {
                        Console.WriteLine("\n\n\tCar with ID # " + carID1 + " has been deleted!!!!!\n");
                        Console.WriteLine("\n\n-------------------End of Delete Car Application----------------------\n");
                        Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                        Console.ReadKey();
                        option1 = DisplayMenu();
                        MainCall(option1);
                    }
                    else
                    {
                        Console.WriteLine("\n\n\tCar with ID # " + carID1 + " does not Exist!!!\n\n");
                        Console.WriteLine("\n\n-------------------End of Delete Car Application----------------------\n");
                        Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                        Console.ReadKey();
                        option1 = DisplayMenu();
                        MainCall(option1);
                    }

                    break;
                case 5:
                    readscv();
                    Console.WriteLine("\n\n-------------------End of Car DataSet File----------------------\n");
                    Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                    Console.ReadKey();
                    option1 = DisplayMenu();
                    MainCall(option1);
                    break;
                case 6:
                    Console.WriteLine("\n\t----------BYEEEEEEEEEEEEEEEEEEEEE!-----------");
                    break;
                default:
                    Console.WriteLine("\n\n----------Invalid Input!!!!!!Re-Enter the Input Value!!!----------\n");
                    option1 = DisplayMenu();
                    MainCall(option1);
                    break;
            }
        }

        /// <summary>
        /// Display Menu - Menu Driven Console Program
        /// Select options from 1 through 6
        /// </summary>        
        public static int DisplayMenu()
        {
            int options = 0;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  \t ________________________________");
            Console.WriteLine("  \t|                                |");
            Console.WriteLine("  \t|   Welcome To Car Application   |");
            Console.WriteLine("  \t|________________________________|\n");
            Console.WriteLine("\t1. Add Car Information");
            Console.WriteLine("\t2. View Car Information");
            Console.WriteLine("\t3. Edit Car Detail");
            Console.WriteLine("\t4. Delete Car Entry");
            Console.WriteLine("\t5. View Import Car Dataset"); // Importated Dataset file from Kaggle
            Console.WriteLine("\t6. Exit\n");
            Console.WriteLine("\t________________________________\n");
            Console.WriteLine("");
            Console.Write("\tEnter Your Selection: ");

            try
            {
                options = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n---------------Some Error has Occured. Please Enter a Valid Entry from" +
                    " 1 through 6:-----------------\n");
            }
            return options;
        }


        /// <summary>
        /// Add Car Information, such as CardId, Year of the car, Make, name of the Model, and a Color
        /// </summary>

        public static List<Cars> AddCar(List<Cars> fileContents, CarData carRespo)
        {

            Cars car = new Cars();

            try
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("  \t ____________________________________");
                Console.WriteLine("  \t|                                    |");
                Console.WriteLine("  \t|   Welcome To Add Car Application   |");
                Console.WriteLine("  \t|____________________________________|\n");
                Console.WriteLine("");
                Console.WriteLine("\n\tEnter the following Information To Add New Car\n");
                Console.WriteLine("________________________________________________________\n");
                Console.Write("\tEnter Car ID: ");
                car.ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tEnter the Year: ");
                car.Year = Console.ReadLine();
                Console.Write("\tEnter the Make (e.g. Honda, BMW) : ");
                car.Make = Console.ReadLine();
                Console.Write("\tEnter the Model Name (e.g Accord, X3) : ");
                car.Model = Console.ReadLine();
                Console.Write("\tEnter the Car Color: ");
                car.Color = Console.ReadLine();
                if (fileContents.Count > 0)
                {
                    if (fileContents.Exists(carDet => carDet.ID == car.ID))
                    {
                        Console.WriteLine("\n\n\tThe Car is already exists with ID #: " + car.ID + "\n");
                    }
                    else
                    {
                        AddCarInfo(car, fileContents, carRespo);
                        Console.WriteLine("\n\n\t----------Car Successfully Added----------\n");
                    }
                }
                else
                {
                    AddCarInfo(car, fileContents, carRespo);
                    Console.WriteLine("\n\n----------Car Successfully Added----------\n");
                }
                Console.Write("\n\n\tDo you wish to add more Car? (Y | N): ");
                char choice = Console.ReadKey().KeyChar;

                switch (char.ToUpper(choice))
                {
                    case 'Y':
                        AddCar(fileContents, carRespo);
                        break;
                    case 'N':
                        int option1 = DisplayMenu();
                        MainCall(option1);
                        break;
                    default:
                        Console.WriteLine("\n\n\t----------Some Error has Occured!! Please select the right option----------\n\n");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        option1 = DisplayMenu();
                        MainCall(option1);
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n\n\t----------Some Error has Occured!! Please select the right option----------\n\n");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                int option1 = DisplayMenu();
                MainCall(option1);
            }
            return fileContents;
        }

        public static void AddCarInfo(Cars carToSave, List<Cars> fileContents, CarData carRespo)
        {
            fileContents.Add(carToSave);
            carRespo.SaveCSV(fileContents);
        }

        // User will be able to view the car information that was entered 
        public static void View(List<Cars> fileContents, CarData carRespo)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  \t      ______________________________");
            Console.WriteLine("  \t     |                              |");
            Console.WriteLine("  \t     |   Welcome To View Car List   |");
            Console.WriteLine("  \t     |______________________________|\n");
            Console.WriteLine("\n-------------------Car List Details----------------------\n");
            foreach (Cars carView in fileContents)
            {
                Console.WriteLine(" Car ID: " + carView.ID +
                                  "\n Car Year: " + carView.Year +
                                  "\n Car Make: " + carView.Make +
                                  "\n Car Model: " + carView.Model +
                                  "\n Car Color: " + carView.Color);
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n\n-------------------Car List Ends----------------------\n");
            Console.Write("\n\n\t\tPress Any Key to Return to Menu");
        }

        /// <summary>
        /// Allow user to edit the Car entry corresponding to Car ID, and make necessary changes
        /// </summary>
        /// <param name="carId">Saves CarId entry</param>
        /// <returns></returns>
        public static int Edit(int carId, List<Cars> fileContents, CarData carRespo)
        {
            int result = 0;
            Cars car = new Cars();
            try
            {
                var carInfo = fileContents.Where(c => c.ID == carId).FirstOrDefault();
                if (carInfo != null)
                {
                    Console.WriteLine("");
                    Console.Write("\n\tEnter the Year: ");
                    car.Year = Console.ReadLine();
                    fileContents.Where(c => c.ID == carId).FirstOrDefault().Year = car.Year;
                    Console.Write("\tEnter the Make (e.g. Honda, BMW) : ");
                    car.Make = Console.ReadLine();
                    fileContents.Where(c => c.ID == carId).FirstOrDefault().Make = car.Make;
                    Console.Write("\tEnter the Model Name (e.g Accord, X3) : ");
                    car.Model = Console.ReadLine();
                    fileContents.Where(c => c.ID == carId).FirstOrDefault().Model = car.Model;
                    Console.Write("\tEnter the Car Color: ");
                    car.Color = Console.ReadLine();
                    fileContents.Where(c => c.ID == carId).FirstOrDefault().Color = car.Color;

                    fileContents.Remove(carInfo);
                    AddCarInfo(carInfo, fileContents, carRespo);

                    Console.Write("\n\n\tCar with ID # " + carId + " updated successfully!\n\n");
                    Console.WriteLine("\n\n-------------------End of Car Edit Application----------------------\n");
                    Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                    Console.ReadKey();

                    int option1 = DisplayMenu();
                    MainCall(option1);
                }
                else
                {
                    Console.Write("\n\n\tCar with ID # " + carId + " does not Exist!!!\n\n");
                    Console.WriteLine("\n\n-------------------End of Car Edit Application----------------------\n");
                    Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                    Console.ReadKey();

                    int option1 = DisplayMenu();
                    MainCall(option1);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("/n\tSome Error Occured!! Please select right option");
                Console.WriteLine("\t------------------------------------------------------");
                Console.WriteLine("\n\n-------------------End of Car Edit Application----------------------\n");
                Console.Write("\n\n\t\tPress Any Key to Return to Menu");
                Console.ReadKey();

                int option1 = DisplayMenu();
                MainCall(option1);
            }
            return result;

        }

        /// <summary>
        /// Allow User to delete the Car Entry corresponding to Car the ID.
        /// </summary>
        /// <param name="carid">Saves Carid entry</param>   
        public static int Delete(int carid, List<Cars> fileContents, CarData carRespo)
        {
            int result;
            {
                result = fileContents.RemoveAll(c => c.ID == carid);
                carRespo.SaveCSV(fileContents);

            }
            return result;
        }

        /// <summary>
        /// Import file from carsDatasetFile.csv dataset
        /// </summary>    
        public static void readscv()
        {
            string[] readLine = File.ReadAllLines(@"carsDatasetFile.csv");

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  \t _________________________________");
            Console.WriteLine("  \t|                                 |");
            Console.WriteLine("  \t|   Welcome To Car Dataset File   |");
            Console.WriteLine("  \t|_________________________________|\n");

            var carList = from historycar in readLine
                          let data = historycar.Split(',')
                          select new
                          {
                              id = data[0],
                              mpg = data[1],
                              hp = data[2],
                              weight = data[3],
                              year = data[4],
                              brand = data[5]
                          };

            foreach (var car in carList)
            {
                Console.WriteLine("");
                Console.WriteLine(car.id + "\t|" + car.mpg + "\t|" + car.hp + "\t|" + car.weight
                                  + "\t|" + car.year + "\t|" + car.brand);
            }
;
        }
    }
}
