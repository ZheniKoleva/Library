using Library.Data;
using System.ComponentModel.DataAnnotations;
using Category = Library.Data.Models.Category;

namespace Library.Models.Book
{
    public class BookAddViewModel
    {
        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [StringLength(DataConstants.Book.TitleMaxLength, MinimumLength = DataConstants.Book.TitleMinLength,
            ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [StringLength(DataConstants.Book.AuthorMaxLength, MinimumLength = DataConstants.Book.AuthorMinLength,
            ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string Author { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [StringLength(DataConstants.Book.DescriptionMaxLength, MinimumLength = DataConstants.Book.DescriptionMinLength,
            ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        public string ImageUrl { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [Range(typeof(decimal), DataConstants.Book.RatingMinValue, DataConstants.Book.RatingMaxValue,
            ConvertValueInInvariantCulture = true, ErrorMessage = DataConstants.ErrorMessages.RatingMessage)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
