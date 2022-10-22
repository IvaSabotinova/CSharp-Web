namespace Library.Data
{
    public static class DataConstants
    {
        public static class ApplicationUserConstants
        {
            public const int UsernameMaxLength = 20;
            public const int UsernameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const string InvalidUserId = "Invalid User Id";

        }


        public static class BookConstants
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AuthorNameMaxLength = 50;
            public const int AuthorNameMinLength = 5;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;

            public const string RatingMin = "0.00";
            public const string RatingMax = "10.00";
            public const string RatingDecimal = "decimal(18,2)";

            public const string InvalidBookMessage = "You have entered invalid or incorrect data!";     
            public const string InvalidBookId = "Invalid Book Id";

        }

        public static class CategoryConstants
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 5;
        }

        public static class ControllerConstants
        {
            public const string GeneralErrorMessage = "Something went wrong. Please try again!";
        }

    }
}
