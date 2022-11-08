namespace Library.Data
{
    public static class DataConstants
    {
        public static class User
        {
            public const int UsernameMinLength = 5;

            public const int UsernameMaxLength = 20;

            public const int EmailMinLength = 10;

            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;

            public const int PasswordMaxLength = 20;
        }

        public static class Book
        {
            public const int TitleMinLength = 10;

            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;

            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;

            public const int DescriptionMaxLength = 5000;

            public const string RatingMinValue = "0.00";

            public const string RatingMaxValue = "10.00";
        }

        public static class Category
        {
            public const int NameMinLength = 5;

            public const int NameMaxLength = 50;
        }

        public static class ErrorMessages
        {
            public const string GeneralMessage = "{0} should be between {2} and {1} symbols long";

            public const string RatingMessage = "{0} should be a number between {1} and {2}";

            public const string RequiredMessage = "{0} is required";

            public const string CompareMessage = "{1} and {0} should match";
        }
    }
}
