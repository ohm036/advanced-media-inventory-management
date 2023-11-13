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
            new Book("Gulliver's Travels", "Adventure", "Jonathan Swift", 1726, "Unknown"),
            new Book("Twenty Thousand Leagues Under the Sea", "Adventure", "Jules Verne", 1870, "Pierre-Jules Hetzel"),
            new Book("Around the World in Eighty Days", "Adventure", "Jules Verne", 1873, "Pierre-Jules Hetzel"),
            new Book("The Adventures of Tintin: The Secret of the Unicorn", "Adventure", "Hergé", 1943, "Casterman"),
            new Book("The Hound of the Baskervilles", "Mystery", "Arthur Conan Doyle", 1902, "George Newnes"),
            new Book("A Study in Scarlet", "Mystery", "Arthur Conan Doyle", 1887, "Ward, Lock & Co."),

            //CDs
            new CD("Thriller", "Pop", "Michael Jackson", 1982, "Epic", new string?[] { "Thriller", "Beat It", "Billie Jean", "Wanna Be Startin' Somethin'", "The Girl Is Mine" }),
            new CD("Abbey Road", "Rock", "The Beatles", 1969, "Apple", new string?[] { "Come Together", "Something", "Here Comes the Sun", "Octopus's Garden", "I Want You (She's So Heavy)" }),
            new CD("The Dark Side of the Moon", "Progressive Rock", "Pink Floyd", 1973, "Harvest", new string?[] { "Speak to Me", "Breathe", "Time", "Money", "Us and Them" }),
            new CD("Rumours", "Soft Rock", "Fleetwood Mac", 1977, "Warner Bros.", new string?[] { "Go Your Own Way", "Dreams", "Don't Stop", "The Chain", "Gold Dust Woman" }),
            new CD("Back in Black", "Hard Rock", "AC/DC", 1980, "Albert", new string?[] { "Hells Bells", "Back in Black", "You Shook Me All Night Long", "Rock and Roll Ain't Noise Pollution", "Shoot to Thrill" }),
            new CD("Starboy", "R&B", "The Weeknd", 2016, "Republic Records", new string?[] { "Starboy", "Party Monster", "I Feel It Coming", "Reminder", "Secrets" }),
            new CD("After Hours", "R&B", "The Weeknd", 2020, "Republic Records", new string?[] { "Blinding Lights", "Save Your Tears", "In Your Eyes", "After Hours", "Heartless" }),
            new CD("The Slim Shady LP", "Hip Hop", "Eminem", 1999, "Aftermath", new string?[] { "My Name Is", "Guilty Conscience", "Role Model", "Just Don't Give a Fuck", "Rock Bottom" }),
            new CD("The Marshall Mathers LP", "Hip Hop", "Eminem", 2000, "Aftermath", new string?[] { "The Real Slim Shady", "Stan", "The Way I Am", "Bitch Please II", "Criminal" }),
            new CD("The Eminem Show", "Hip Hop", "Eminem", 2002, "Aftermath", new string?[] { "Without Me", "Cleanin' Out My Closet", "Sing for the Moment", "Superman", "Business" }),

            // DVDs
            new DVD("The Shawshank Redemption", "Drama", "Frank Darabont", 1994, "Castle Rock Entertainment"),
            new DVD("Inception", "Sci-Fi Action", "Christopher Nolan", 2010, "Syncopy"),
            new DVD("Pulp Fiction", "Crime", "Quentin Tarantino", 1994, "Miramax Films"),
            new DVD("The Matrix", "Sci-Fi Action", "Lana and Lilly Wachowski", 1999, "Warner Bros."),
            new DVD("Forrest Gump", "Drama", "Robert Zemeckis", 1994, "Paramount Pictures"),
            new DVD("Fifty Shades of Grey", "Romance", "Sam Taylor-Johnson", 2015, "Focus Features"),
            new DVD("Fifty Shades Darker", "Romance", "James Foley", 2017, "Universal Pictures"),
            new DVD("Fifty Shades Freed", "Romance", "James Foley", 2018, "Universal Pictures"),
            new DVD("Batman Begins", "Action", "Christopher Nolan", 2005, "Warner Bros."),
            new DVD("The Dark Knight", "Action", "Christopher Nolan", 2008, "Warner Bros."),
            new DVD("The Dark Knight Rises", "Action", "Christopher Nolan", 2012, "Warner Bros."),
            new DVD("Interstellar", "Sci-Fi", "Christopher Nolan", 2014, "Syncopy"),
            new DVD("Dunkirk", "War", "Christopher Nolan", 2017, "Syncopy"),
            new DVD("The Prestige", "Drama", "Christopher Nolan", 2006, "Syncopy"),

            
        };

        private int n_books, n_CDs, n_DVDs;

        public int GetBooksCount () {
            foreach (var media in Inventory) {
                if (media is Book) {
                    n_books++;
                }
            }
            int res = n_books;

            n_books = 0;

            return res;
        }
        public int GetCDsCount () {
            foreach (var media in Inventory) {
                if (media is CD) {
                    n_CDs++;
                }
            }

            int res = n_CDs;
            
            n_CDs = 0;

            return res;
        }
        public int GetDVDsCount () {
            foreach (var media in Inventory) {
                if (media is DVD) {
                    n_DVDs++;
                }
            }

            int res = n_DVDs;
            
            n_DVDs = 0;

            return res;
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
                            //It is needed for the media to be a DVD in order to have a studio attribute. Then type casting has been used
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
                        Console.WriteLine("Enter the title:");
                        string? title = Console.ReadLine();

                        var TitleMatches = Inventory

                        /*
                        In this code,

                        1. Where is used to find the media that match with user's input.

                        2. Lambda expression, media => is used for indicating each and every.

                        */

                        .Where(media => media.Title?

                        /*

                        3. IndexOf checks whether the provided string or piece of string is present in the searcing context irrespective of the letter case (StringComparison.OrdinalIgnoreCase does the job). It returns -1 if match not found and returns 0 if the context string is empty. We will only think about the case when it will return greater than 0.

                        */

                        .IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();



                        if (TitleMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(TitleMatches);
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Enter the genre:");
                        string? genre = Console.ReadLine();

                        var GenreMatches = Inventory
                        .Where(media => media.Genre?
                        .IndexOf(genre, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (GenreMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(GenreMatches);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter release year:");
                        int r_year = Convert.ToInt32(Console.ReadLine());

                        var RYearMatches = Inventory
                        .Where(media => media.ReleaseYear == r_year)
                        .ToList();

                        if (RYearMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(RYearMatches);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter author's name:");
                        string? auth = Console.ReadLine();

                        var AuthMatches = Inventory
                        .Where(media => media is Book && ((Book)media).Author?
                        .IndexOf(auth, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (AuthMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(AuthMatches);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter artist's name:");
                        string? artt = Console.ReadLine();

                        var ArttMatches = Inventory
                        .Where(media => media is CD && ((CD)media).Artist?
                        .IndexOf(artt, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (ArttMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(ArttMatches);
                        } 
                        break;
                    case 6:
                        Console.WriteLine("Enter director's name:");
                        string? dir = Console.ReadLine();

                        var DirMatches = Inventory
                        .Where(media => media is DVD && ((DVD)media).Director?
                        .IndexOf(dir, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (DirMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(DirMatches);
                        } 
                        break;
                    case 7:
                        Console.WriteLine("Enter studio's name:");
                        string? std = Console.ReadLine();

                        var StdMatches = Inventory
                        .Where(media => media is DVD && ((DVD)media).Studio?
                        .IndexOf(std, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (StdMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(StdMatches);
                        } 
                        break;
                    case 8:
                        Console.WriteLine("Enter publisher's name:");
                        string? pub = Console.ReadLine();

                        var PubMatches = Inventory
                        .Where(media => media is Book && ((Book)media).Publisher?
                        .IndexOf(pub, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (PubMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(PubMatches);
                        } 
                        break;
                    case 9:
                        Console.WriteLine("Enter record company's name:");
                        string? rec = Console.ReadLine();

                        var RecMatches = Inventory
                        .Where(media => media is CD && ((CD)media).RecordCompany?
                        .IndexOf(rec, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                        if (RecMatches.Count == 0) {
                            Console.WriteLine("No results found!");
                        } else {
                            ShowMatches(RecMatches);
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

        //ShowMatches() method works privately when called within the class to take a list of media objects as parameter and iterate through every item to print them to console.
        private void ShowMatches (List<Media<string>> matches) {
            int i = 1;
            Console.WriteLine();
            foreach (var media in matches) {

                if (media is Book b) {

                    Console.WriteLine(i + ". Book:");
                    Console.WriteLine($"Title: {b.Title}\nAuthor: {b.Author}\nGenre: {b.Genre}\nRelease Year: {b.ReleaseYear}\nPublisher: {b.Publisher}");

                } else if (media is CD cd) {

                    Console.WriteLine(i + ".CD:");
                    Console.WriteLine($"Title: {cd.Title}\nArtist: {cd.Artist}\nGenre: {cd.Genre}\nRelease Year: {cd.ReleaseYear}\nRecording Comapny: {cd.RecordCompany}");

                } else if (media is DVD dvd) {

                    Console.WriteLine(i + ". DVD:");
                    Console.WriteLine($"Title: {dvd.Title}\nDirector: {dvd.Director}\nGenre: {dvd.Genre}\nRelease Year: {dvd.ReleaseYear}\nStudio: {dvd.Studio}");

                }

                Console.WriteLine();
                i++;
            }
        }

        //Implements all necessary functionaities for listing media of the inventory:
        public void ListItems () {
            Console.WriteLine("\nShowing all items in the inventory:");

            for (int i = 0; i < 70; i++) {
                Console.Write("-");
            }

            ShowMatches(Inventory); //It has the same functionality. It shows all media from a list of media objects. Thus ShowMatches() is also used here.
        }

        //Implements all necessary functionaities for getting insights of to the inventory:
        public void GetInsights () {

            double percent1 = Convert.ToDouble(GetBooksCount())/Convert.ToDouble(Inventory.Count) * 100;
            double percent2 = Convert.ToDouble(GetCDsCount())/Convert.ToDouble(Inventory.Count) * 100;
            double percent3 = Convert.ToDouble(GetDVDsCount())/Convert.ToDouble(Inventory.Count) * 100;

            Console.WriteLine($"Total: {Inventory.Count}");
            Console.WriteLine($"Books: {GetBooksCount()} ({percent1}%)");
            Console.WriteLine($"CDs: {GetCDsCount()} ({percent2}%)");
            Console.WriteLine($"DVDs: {GetDVDsCount()} ({percent3}%)");
        
        } 

        //Implements all necessary functionaities to update a media of the inventory. We will only allow the user to search by title and update it. But here's the catch:

        //There can be several media that may match with user input. So, we will use a list of matches and let the user choose from that list to update any item:
        public void UpdateMedia()
        {
            Console.WriteLine("Enter the title you want to update:");
            string? UTitle = Console.ReadLine();

            var ToUpdate = Inventory
                        .Where(media => media.Title?
                        .IndexOf(UTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

            if (ToUpdate.Count == 0)
            {
                Console.WriteLine("No results found!");
            } else {
                while (true) {
                    Console.WriteLine($"Following matches found:");
                    ShowMatches(ToUpdate);

                    Console.WriteLine("Which media do you want to update?\n");

                    int index = 1;

                    foreach (var media in ToUpdate) {
                        Console.WriteLine($"[{index}] {media.Title}");
                        index++;
                    }

                    Console.WriteLine("Enter your choice (Type -1 to go back):");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    //Make sure the user selects a valid choice:
                    if (choice > 0 && choice <= ToUpdate.Count) {

                        if (ToUpdate[choice - 1] /*Indexing works from 0. But user was shown options starting from 1.Thus subtracting 1 from choice to grab the right media from the list*/ is Book b) {
                            while (true) {
                                Console.WriteLine($"Which property of the book \"{b.Title}\" you want to update?");
                                Console.WriteLine("[1] Title");
                                Console.WriteLine("[2] Genre");
                                Console.WriteLine("[3] Author");
                                Console.WriteLine("[4] Release Year");
                                Console.WriteLine("[5] Publisher");
                                Console.WriteLine("Enter your choice:");

                                int propChoice = Convert.ToInt32(Console.ReadLine());

                                switch (propChoice) {
                                    case 1:
                                        Console.WriteLine("Enter new title:");
                                        string? NewTitl = Console.ReadLine();

                                        int IndexOfBookToUpdateInfo = Inventory.FindIndex(media => media.Title == b.Title);

                                        Inventory[IndexOfBookToUpdateInfo].Title = NewTitl;
                                        Console.WriteLine("Title updated successfully");

                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new genre:");
                                        string? NewGen = Console.ReadLine();

                                        IndexOfBookToUpdateInfo = Inventory.FindIndex(media => media.Genre == b.Genre);

                                        Inventory[IndexOfBookToUpdateInfo].Genre = NewGen;
                                        Console.WriteLine("Genre updated successfully");

                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new author's name:");
                                        string? NewAuth = Console.ReadLine();

                                        IndexOfBookToUpdateInfo = Inventory.FindIndex(media => media is Book && ((Book)media).Author == b.Author);

                                        ((Book)Inventory[IndexOfBookToUpdateInfo]).Author = NewAuth;
                                        Console.WriteLine("Author updated successfully");

                                        break;
                                    case 4:
                                        Console.WriteLine("Enter new release year:");
                                        int NewRY = Convert.ToInt32(Console.ReadLine());

                                        IndexOfBookToUpdateInfo = Inventory.FindIndex(media => media.ReleaseYear == b.ReleaseYear);

                                        Inventory[IndexOfBookToUpdateInfo].ReleaseYear = NewRY;
                                        Console.WriteLine("Release year updated successfully");
                                        
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter new publisher's name:");
                                        string? NewPub = Console.ReadLine();

                                        IndexOfBookToUpdateInfo = Inventory.FindIndex(media => media is Book && ((Book)media).Publisher == b.Publisher);

                                        ((Book)Inventory[IndexOfBookToUpdateInfo]).Publisher = NewPub;
                                        Console.WriteLine("Publisher updated successfully");

                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice!");
                                        continue;
                                }

                                break;
                            }
                        } else if (ToUpdate[choice - 1] is CD cd) {
                            
                            while (true) {
                                Console.WriteLine($"Which property of the CD \"{cd.Title}\" you want to update?");
                                Console.WriteLine("[1] Title");
                                Console.WriteLine("[2] Genre");
                                Console.WriteLine("[3] Artist");
                                Console.WriteLine("[4] Release Year");
                                Console.WriteLine("[5] Record Company");
                                Console.WriteLine("[6] Tracklist");
                                Console.WriteLine("Enter your choice:");

                                int propChoice = Convert.ToInt32(Console.ReadLine());

                                switch (propChoice) {
                                    case 1:
                                        Console.WriteLine("Enter new title:");
                                        string? NewTitl = Console.ReadLine();

                                        int IndexOfCDToUpdateInfo = Inventory.FindIndex(media => media.Title == cd.Title);

                                        Inventory[IndexOfCDToUpdateInfo].Title = NewTitl;
                                        Console.WriteLine("Title updated successfully");

                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new genre:");
                                        string? NewGen = Console.ReadLine();

                                        IndexOfCDToUpdateInfo = Inventory.FindIndex(media => media.Genre == cd.Genre);

                                        Inventory[IndexOfCDToUpdateInfo].Genre = NewGen;
                                        Console.WriteLine("Genre updated successfully");

                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new artist's name:");
                                        string? NewArtist = Console.ReadLine();

                                        IndexOfCDToUpdateInfo = Inventory.FindIndex(media => media is CD && ((CD)media).Artist == cd.Artist);

                                        ((CD)Inventory[IndexOfCDToUpdateInfo]).Artist = NewArtist;
                                        Console.WriteLine("Artist updated successfully");

                                        break;
                                    case 4:
                                        Console.WriteLine("Enter new release year:");
                                        int NewRY = Convert.ToInt32(Console.ReadLine());

                                        IndexOfCDToUpdateInfo = Inventory.FindIndex(media => media.ReleaseYear == cd.ReleaseYear);

                                        Inventory[IndexOfCDToUpdateInfo].ReleaseYear = NewRY;
                                        Console.WriteLine("Release year updated successfully");
                                        
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter new record company's name:");
                                        string? NewRec = Console.ReadLine();

                                        IndexOfCDToUpdateInfo = Inventory.FindIndex(media => media is CD && ((CD)media).RecordCompany == cd.RecordCompany);

                                        ((CD)Inventory[IndexOfCDToUpdateInfo]).RecordCompany = NewRec;
                                        Console.WriteLine("Record company updated successfully");

                                        break;
                                    case 6:
                                        //To implement
                                    default:
                                        Console.WriteLine("Invalid choice!");
                                        continue;
                                }

                                break;
                            }

                        } else if (ToUpdate[choice - 1] is DVD dvd) {
                            while (true) {
                                Console.WriteLine($"Which property of the DVD \"{dvd.Title}\" you want to update?");
                                Console.WriteLine("[1] Title");
                                Console.WriteLine("[2] Genre");
                                Console.WriteLine("[3] Director");
                                Console.WriteLine("[4] Release Year");
                                Console.WriteLine("[5] Studio");
                                Console.WriteLine("Enter your choice:");

                                int propChoice = Convert.ToInt32(Console.ReadLine());

                                switch (propChoice) {
                                    case 1:
                                        Console.WriteLine("Enter new title:");
                                        string? NewTitl = Console.ReadLine();

                                        int IndexOfDVDToUpdateInfo = Inventory.FindIndex(media => media.Title == dvd.Title);

                                        Inventory[IndexOfDVDToUpdateInfo].Title = NewTitl;
                                        Console.WriteLine("Title updated successfully");

                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new genre:");
                                        string? NewGen = Console.ReadLine();

                                        IndexOfDVDToUpdateInfo = Inventory.FindIndex(media => media.Genre == dvd.Genre);

                                        Inventory[IndexOfDVDToUpdateInfo].Genre = NewGen;
                                        Console.WriteLine("Genre updated successfully");

                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new director's name:");
                                        string? NewDir = Console.ReadLine();

                                        IndexOfDVDToUpdateInfo = Inventory.FindIndex(media => media is DVD && ((DVD)media).Director == dvd.Director);

                                        ((DVD)Inventory[IndexOfDVDToUpdateInfo]).Director = NewDir;
                                        Console.WriteLine("Director updated successfully");

                                        break;
                                    case 4:
                                        Console.WriteLine("Enter new release year:");
                                        int NewRY = Convert.ToInt32(Console.ReadLine());

                                        IndexOfDVDToUpdateInfo = Inventory.FindIndex(media => media.ReleaseYear == dvd.ReleaseYear);

                                        Inventory[IndexOfDVDToUpdateInfo].ReleaseYear = NewRY;
                                        Console.WriteLine("Release year updated successfully");
                                        
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter new studio's name:");
                                        string? NewStd = Console.ReadLine();

                                        IndexOfDVDToUpdateInfo = Inventory.FindIndex(media => media is DVD && ((DVD)media).Studio == dvd.Studio);

                                        ((DVD)Inventory[IndexOfDVDToUpdateInfo]).Studio = NewStd;
                                        Console.WriteLine("Studio updated successfully");

                                        break;
                                }

                                break;
                            }
                        }

                    } else if (choice == -1) {
                        Console.WriteLine("\nGoing back...");
                    } else {
                        Console.WriteLine("Invalid choice!");
                        continue; //Loop again.
                    }

                    break;
                }
            }
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
            RecordCompany = company;
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
                Console.WriteLine("\nInventory currently contains:");
                Console.WriteLine(mgr.GetBooksCount() + " books, " + mgr.GetCDsCount() + " CDs and " + mgr.GetDVDsCount() + " DVDs"); //Always show the state of the inventory.

                Console.WriteLine("\nWhat would you like to do?");

                Console.WriteLine("[1] Add Media");
                Console.WriteLine("[2] Remove Media");
                Console.WriteLine("[3] Search");
                Console.WriteLine("[4] List Items");
                Console.WriteLine("[5] Get Insights");
                Console.WriteLine("[6] Update Media");
                Console.WriteLine("[7] Exit");

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
                        mgr.UpdateMedia();
                        continue;
                    case 7:
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