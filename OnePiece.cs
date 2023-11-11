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
        public static List<Media<string>> Inventory = new List<Media<string>>
        {
            // Books
            new Book("To Kill a Mockingbird", "Fiction", "Harper Lee", 1960, "J.B. Lippincott & Co."),
            new Book("1984", "Dystopian Fiction", "George Orwell", 1949, "Secker & Warburg"),
            new Book("The Great Gatsby", "Classic", "F. Scott Fitzgerald", 1925, "Charles Scribner's Sons"),
            new Book("One Hundred Years of Solitude", "Magical Realism", "Gabriel Garcia Marquez", 1967, "Harper & Row"),
            new Book("The Catcher in the Rye", "Coming-of-Age", "J.D. Salinger", 1951, "Little, Brown and Company"),

            //CDs
            new CD("Thriller", "Pop", "Michael Jackson", 1982, "Epic", new string?[] { "Thriller", "Beat It", "Billie Jean", "Wanna Be Startin' Somethin'", "The Girl Is Mine" }),
            new CD("Abbey Road", "Rock", "The Beatles", 1969, "Apple", new string?[] { "Come Together", "Something", "Here Comes the Sun", "Octopus's Garden", "I Want You (She's So Heavy)" }),
            new CD("The Dark Side of the Moon", "Progressive Rock", "Pink Floyd", 1973, "Harvest", new string?[] { "Speak to Me", "Breathe", "Time", "Money", "Us and Them" }),
            new CD("Rumours", "Soft Rock", "Fleetwood Mac", 1977, "Warner Bros.", new string?[] { "Go Your Own Way", "Dreams", "Don't Stop", "The Chain", "Gold Dust Woman" }),
            new CD("Back in Black", "Hard Rock", "AC/DC", 1980, "Albert", new string?[] { "Hells Bells", "Back in Black", "You Shook Me All Night Long", "Rock and Roll Ain't Noise Pollution", "Shoot to Thrill" }),

            // DVDs
            new DVD("The Shawshank Redemption", "Drama", "Frank Darabont", 1994, "Castle Rock Entertainment"),
            new DVD("Inception", "Sci-Fi Action", "Christopher Nolan", 2010, "Syncopy"),
            new DVD("Pulp Fiction", "Crime", "Quentin Tarantino", 1994, "Miramax Films"),
            new DVD("The Matrix", "Sci-Fi Action", "Lana and Lilly Wachowski", 1999, "Warner Bros."),
            new DVD("Forrest Gump", "Drama", "Robert Zemeckis", 1994, "Paramount Pictures"),
        };

        private int n_books, n_CDs, n_DVDs;

        public int GetBooksCount () {
            foreach (var media in Inventory) {
                if (media is Book) {
                    n_books++;
                }
            }

            return n_books;
        }
        public int GetCDsCount () {
            foreach (var media in Inventory) {
                if (media is CD) {
                    n_CDs++;
                }
            }

            return n_CDs;
        }
        public int GetDVDsCount () {
            foreach (var media in Inventory) {
                if (media is DVD) {
                    n_DVDs++;
                }
            }

            return n_DVDs;
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
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        Console.WriteLine("Enter Title:");
                        string? title = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media.Title == title) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Genre:");
                        string? genre = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media.Genre == genre) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Release Year:");
                        int releaseyear = Convert.ToInt32(Console.ReadLine());

                        foreach (var media in Inventory) {
                            if (media.ReleaseYear == releaseyear) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter author's name:");
                        string? author = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is Book && (((Book)media).Author) == author) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter artist's name:");
                        string? artist = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is CD && (((CD)media).Artist) == artist) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter director's name:");
                        string? director = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is DVD && (((DVD)media).Director) == director) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter studio's name:");
                        string? studio = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is DVD && (((DVD)media).Studio) == studio) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter publisher's name:");
                        string? publisher = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is Book && (((Book)media).Publisher) == publisher) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("Enter record company's name:");
                        string? recordcompany = Console.ReadLine();

                        foreach (var media in Inventory) {
                            if (media is CD && (((CD)media).RecordCompany) == recordcompany) {
                                Inventory.Remove(media);
                            }
                        }
                        break;
                    case 10:
                        Console.WriteLine("\nGoing back...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                break;
            }
        }
       
        //Implements all necessary functionaities for searching media from the inventory:
        public void Search () {
            while (true) {
                Console.WriteLine("[1] Search by Title");
                Console.WriteLine("[2] Search by Genre");
                Console.WriteLine("[3] Search by Release Year");
                Console.WriteLine("[4] Search by Author");
                Console.WriteLine("[5] Search by Artist");
                Console.WriteLine("[6] Search by Director");
                Console.WriteLine("[7] Search by Studio");
                Console.WriteLine("[8] Search by Publisher");
                Console.WriteLine("[9] Search by Record Company");
                Console.WriteLine("[10] Go back");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5: 
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                    
                }

                break;
            }
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

        public Book (string? titl, string? gen, string? auth, int release, string? pub) {
            Title = titl;
            Genre = gen;
            Author = auth;
            ReleaseYear = release;
            Publisher = pub;
        }
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

        public CD (string? titl, string? gen, string? artt, int release, string? company, string? [] tracklist) {
            Title = titl;
            Genre = gen;
            Artist = artt;
            ReleaseYear = release;
            TrackList = tracklist;
        }
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

        public DVD (string? titl, string? gen, string? dir, int release, string? std) {
            Title = titl;
            Genre = gen;
            Director = dir;
            ReleaseYear = release;
            Studio = std;
        }
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
                Console.WriteLine(mgr.GetBooksCount() + " books, " + mgr.GetCDsCount() + " CDs and " + mgr.GetDVDsCount() + " DVDs");

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