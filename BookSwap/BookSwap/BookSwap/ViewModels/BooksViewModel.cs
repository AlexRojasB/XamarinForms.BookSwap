using BookSwap.Models;
using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookSwap.ViewModels
{
    public class BooksViewModel : ObservableObject
    {
        public IList<Book> Books { get; set; }

        public BooksViewModel()
        {
            Books = new ObservableCollection<Book>()
            {
                new Book()
                {
                    Title = "Everything is Illuminated",
                    Author = "Jonathan Safran Foer",
                    AccentColor = "#0FF4C3",
                    CoverImage = "everything"
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "ulysses"
                },
                //new Book()
                //{
                //    Title = "Extremely Loud and Incredibly Close",
                //    Author = "Jonathan Safran Foer",
                //    AccentColor = "#0FF4C3",
                //    CoverImage = "everything"
                //},
                new Book()
                {
                    Title = "Flowers for Algernon",
                    Author = "Daniel Keyes",
                    AccentColor = "#FF848C",
                    CoverImage = "alergon"
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "ulysses"
                },
                //new Book()
                //{
                //    Title = "Extremely Loud and Incredibly Close",
                //    Author = "Jonathan Safran Foer",
                //    AccentColor = "#0FF4C3",
                //    CoverImage = "everything"
                //},
                new Book()
                {
                    Title = "Flowers for Algernon",
                    Author = "Daniel Keyes",
                    AccentColor = "#FF848C",
                    CoverImage = "alergon"
                }, new Book()
                {
                    Title = "Everything is Illuminated",
                    Author = "Jonathan Safran Foer",
                    AccentColor = "#0FF4C3",
                    CoverImage = "everything"
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "ulysses"
                }
            };
        }
    }
}
