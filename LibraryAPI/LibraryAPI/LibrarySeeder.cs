using LibraryAPI.Entities;
using Microsoft.Identity.Client;
using System.Reflection;

namespace LibraryAPI
{
    public class LibrarySeeder
    {
        private readonly LibraryDbContext _dbContext;

        public LibrarySeeder(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if(!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "User"
                }
            };

            return roles;
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Hobbit",
                    Description = "",
                    PageCount = 320,
                    IsAvailable = true,
                    Author = new Author()
                    {
                        Name = "J.R.R. Tolkien",
                        Description = ""
                    },
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Fantasy"
                        },
                        new Category()
                        {
                            Name = "Przygodowe"
                        },
                    }
                },
                new Book()
                {
                    Title = "Dziady",
                    Description = "",
                    PageCount = 200,
                    IsAvailable = true,
                    Author = new Author()
                    {
                        Name = "Adam Mickiewicz",
                        Description = ""
                    },
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Lektury"
                        }
                    }
                },
                new Book()
                {
                    Title = "Pan Tadeusz",
                    Description = "",
                    PageCount = 200,
                    IsAvailable = true,
                    Author = new Author()
                    {
                        Name = "Adam Mickiewicz",
                        Description = ""
                    },
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Lektury"
                        }
                    }
                },
                new Book()
                {
                    Title = "Lalka",
                    Description = "",
                    PageCount = 200,
                    IsAvailable = true,
                    Author = new Author()
                    {
                        Name = "Bolesław Prus",
                        Description = ""
                    },
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Lektury"
                        }
                    }
                },
                new Book()
                {
                    Title = "Ogniem i mieczem",
                    Description = "",
                    PageCount = 200,
                    IsAvailable = true,
                    Author = new Author()
                    {
                        Name = "Henryk Sienkiewicz",
                        Description = ""
                    },
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Historyczne"
                        },
                        new Category()
                        {
                            Name = "Lektury"
                        }
                    }
                }
            };

            return books;
        }
    }
}
