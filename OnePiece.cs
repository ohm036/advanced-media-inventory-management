using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;

namespace Assignment
{
    class Media <T> 
    { 
        //Common attributes are Title, Genre, ReleaseYear
        public T? Title {get; set;}
        public T? Genre {get; set;}
        public int ReleaseYear {get; set;}
    }

    partial class Book : Media <string>
    {
        //Apart from Title, Genre and ReleaseYear, Book also has Author and Publisher info:
        public string? Author {get; set;}
        public string? Publisher {get; set;}

    }

    partial class CD : Media <string>
    {
        //Apart from Title, Genre and ReleaseYear, CD also has Artist, RecordCompany and TrackList info:
        public string? Artist {get; set;}
        public string? RecordCompany {get; set;}
        public static string?[] TrackList = new string?[20]; //This array will contain all the songs that comes with a CD. At most 20 songs.
        private int numberOfSongs = TrackList.Length;
    }

    partial class DVD : Media <string>
    {
        //Apart from Title, Genre and ReleaseYear, DVD also has Director and Studio info:
        public string? Director {get; set;}
        public string? Studio {get; set;}

    }

    class InventoryManager
    {
        //The main container of the inventory:
        public List<Media<string>> Inventory = new List<Media<string>>();

        //To keep count of different types of media present in the inventory:
        public int[] Counter (List<Media<string>> inventory) {
            int [] counts = new int[3] {0, 0, 0}; //Books count, CDs count, DVDs count

            foreach (var m in inventory) {
                if (m is Book) {
                    counts[0] += 1;
                } else if (m is CD) {
                    counts[1] += 1;
                } else if (m is DVD) {
                    counts[2] += 1;
                }
            }

            return counts;
        }

        public void AddMedia () {
            while (true) {
                Console.WriteLine("\nWhat do you want to add?");
                Console.WriteLine("[1] Add Book");
                Console.WriteLine("[2] Add CD");
                Console.WriteLine("[3] Add DVD");
                Console.WriteLine("[4] Go Back");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        Book book = new();
                        Inventory.Add(book);
                        continue;
                    case 2:
                        CD cd = new();
                        Inventory.Add(cd);
                        continue;
                    case 3: 
                        DVD dvd = new();
                        Inventory.Add(dvd);
                        continue;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                break;
            }
        }

        //Implements all necessary functionaities for removing media from the inventory:
        public void RemoveMedia() {
            while (true) {
                Console.WriteLine("[1] Remove by Title");
                Console.WriteLine("[2] Remove by Genre");
                Console.WriteLine("[3] Remove by Release Year");
                Console.WriteLine("[4] Remove by Author");
                Console.WriteLine("[5] Remove by Artist");
                Console.WriteLine("[6] Remove by Director");
                Console.WriteLine("[7] Remove by Studio");
                Console.WriteLine("[8] Remove by Publisher");
                Console.WriteLine("[9] Remove by Record Company");
                Console.WriteLine("[10] Go back");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:

                        continue;
                    case 2:
                        continue;
                    case 3:
                        continue;
                    case 4:
                        continue;
                    case 5:
                        continue;
                    case 6:
                        continue;
                    case 7:
                        continue;
                    case 8:
                        continue;
                    case 9:
                        continue;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                break;
            }
        }

        //Removing different media require different types of functionalities. So a group of remover functions under the delegate RemoverFunctions is being created:
        private delegate void RemoverFunctions (List<Media<string>> inventory, string str);

        private RemoverFunctions RemoveByTitle = (List<Media<string>> inventory, string str) => {

        };

        private RemoverFunctions RemoveByGenre = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByReleaseYear = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByAuthor = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByArtist = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByDirector = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByStudio = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByRecordCompany = (List<Media<string>> inventory, string str) => {
            
        };

        private RemoverFunctions RemoveByPublisher = (List<Media<string>> inventory, string str) => {
            
        };

        private void Remover (List <Media <string>> inventory, RemoverFunctions rf) {
            if (rf is RemoveByTitle)
        }

        //Implements all necessary functionaities for searching media from the inventory:
        public void Search () {

        }

        //Implements all necessary functionaities for listing media of the inventory:
        public void ListItems () {

        }

        //Implements all necessary functionaities for getting insights of to the inventory:
        public void GetInsights () {

        } 
        
    }

//Implementing all necessary steps to initialize an object. Using the respective constructors for this purpose to make things better.
    partial class Book {
        public Book () {

            Console.WriteLine("Enter the Title: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter the Genre:");
            Genre = Console.ReadLine();

            Console.WriteLine("Enter the Author's name:");
            Author = Console.ReadLine();

            Console.WriteLine("Enter Release Year:");
            ReleaseYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Publisher:");
            Publisher = Console.ReadLine();
        }
    }

    partial class CD {
        public CD () {
            Console.WriteLine("Enter the Title: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter the Genre:");
            Genre = Console.ReadLine();

            Console.WriteLine("Enter Artist name:");
            Artist = Console.ReadLine();

            Console.WriteLine("Enter Release Year:");
            ReleaseYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Record Company:");
            RecordCompany = Console.ReadLine();

            Console.WriteLine("How many songs does your CD have? (At most 20):");
            numberOfSongs = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < numberOfSongs; i++) {
                if (i == 1) {
                    Console.WriteLine("Enter 1st song:");
                    TrackList[i] = Console.ReadLine();
                } else if (i == 2) {
                    Console.WriteLine("Enter 2nd song:");
                    TrackList[i] = Console.ReadLine();
                } else if (i == 3) {
                    Console.WriteLine("Enter 3rd song:");
                    TrackList[i] = Console.ReadLine();
                } else {
                    Console.WriteLine("Enter " + i + "th song:");
                    TrackList[i] = Console.ReadLine();
                }
            }
        }
    }

    partial class DVD {
        public DVD () {
            Console.WriteLine("Enter the Title: ");
            Title = Console.ReadLine();

            Console.WriteLine("Enter the Genre:");
            Genre = Console.ReadLine();

            Console.WriteLine("Enter the Director's name:");
            Director = Console.ReadLine();

            Console.WriteLine("Enter Release Year:");
            ReleaseYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Studio:");
            Studio = Console.ReadLine();
        }
    }

    class Driver
    {
        public static void Main ()
        {
            Console.WriteLine("\t\tWelcome to Your Media Inventory");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            InventoryManager mgr = new ();

            while (true) //Lock user into an infinite loop unless he chooses to exit
            {
                Console.WriteLine("Currently contains:");
                Console.WriteLine(mgr.Counter(mgr.Inventory)[0] + " books, " + mgr.Counter(mgr.Inventory)[1] + " CDs and " + mgr.Counter(mgr.Inventory)[2] + " DVDs");

                Console.WriteLine("What would you like to do?");

                Console.WriteLine("[1] Add Media");
                Console.WriteLine("[2] Remove Media");
                Console.WriteLine("[3] Search");
                Console.WriteLine("[4] List Items");
                Console.WriteLine("[5] Get Insights");
                Console.WriteLine("[6] Exit");

                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        mgr.AddMedia();
                        continue;
                    case 2:
                        mgr.RemoveMedia();
                        continue;
                    case 3:
                        mgr.Search();
                        continue;
                    case 4:
                        mgr.ListItems();    
                        continue;
                    case 5:
                        mgr.GetInsights();
                        continue;
                    case 6:
                        Console.WriteLine("\nSuccessfully exited the Inventory");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                break;
            }
        }
    }
}