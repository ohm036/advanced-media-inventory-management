using System;
using System.Collections;
using System.Linq;

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
        public ArrayList TrackList = new (); //This arraylist will contain all the songs that comes with a CD.
    }

    partial class DVD : Media <string>
    {
        //Apart from Title, Genre and ReleaseYear, CD also has Director and Studio info:
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

        //Implements all necessary functionaities for adding media to the inventory:
        public void AddMedia () {

        }

        //Implements all necessary functionaities for removing media from the inventory:
        public void RemoveMedia() {

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
                }

                break;
            }
        }
    }
}