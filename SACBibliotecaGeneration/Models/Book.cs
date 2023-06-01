using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACBibliotecaGeneration.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool IsAvailable { get; set; }


        public Book()
        {

        }

        public Book(string name, string author, string description, string imgUrl, bool isAvailable)
        {
            Name = name;
            Author = author;
            Description = description;
            ImgUrl = imgUrl;
            IsAvailable = isAvailable;
        }




    }

}
