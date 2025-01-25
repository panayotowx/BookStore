using Moq;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookService.Tests
{
    public class BookBlServiceTests
    {
        private Mock<IBookService> _bookServiceMock;
        private Mock<IAuthorRepository> _authorRepositoryMock;

        public BookBlServiceTests()
        {
            _bookServiceMock = new Mock<IBookService>();
            _authorRepositoryMock = new Mock<IAuthorRepository>();
        }

        private List<Book> _books = new List<Book>
        {
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 1",
                Year = 2021,
                Authors = ["Author 1", "Author 2"]
            },
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 2",
                Year = 2022,
                Authors = ["Author 3", "Author 4"]
            }
        }; 

        private List<Author> _authors = new List<Author>
        {
            new Author()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Author 1"
            },
            new Author()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Author 2"
            },
            new Author()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Author 3"
            },
            new Author()
            {
                Id = "9badefdc-0714-4581-80ae-161cd0a5abbe",
                Name = "Author 4"
            }
        };

        [Fact]
        public void GetDetailedBooks_Ok()
        {
            //setup
            var expectedCount = 2;

            _bookServiceMock
                .Setup(x => x.GetAllBooks())
                .Returns(_books);
            _authorRepositoryMock.Setup(x => 
                    x.GetById(It.IsAny<string>()))
                .Returns((string id) =>
                    _authors.FirstOrDefault(x => x.Id == id));

            //inject
            var bookBlService = new BookBlService(
                _bookServiceMock.Object,
                _authorRepositoryMock.Object);

            //Act
            var result =
                bookBlService.GetDetailedBooks();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

    }
}