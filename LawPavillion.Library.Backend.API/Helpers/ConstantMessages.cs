namespace LawPavillion.Library.Backend.API.Helpers
{
    /// <summary>
    /// Centralized constant messages for API responses.
    /// Keeps responses consistent and reduces magic strings.
    /// </summary>
    public static class ConstantMessages
    {
        #region General Error
        public const string OperationSuccess = "Operation successful";
        public const string InvalidData = "Invalid entry";
        public const string Failed = "Unable to process request";
        #endregion

        #region Authentication
        public const string RegistrationSuccess = "User registered successfully";
        public const string LoginFailed = "Invalid username or password";
        #endregion

        #region Book
        public const string BookNotFound = "Book does not exist";
        public const string BookCreated = "Book created successfully";
        public const string BookUpdated = "Book updated successfully";
        public const string BookDeleted = "Book deleted successfully";
        #endregion

        #region Mapping
        public const string MappingFailed = "Unable to map data. Please try again later.";
        #endregion

        #region Search
        public const string SearchSuccess = "Books retrieved successfully";
        public const string SearchEmpty = "No books matched the search criteria";
        #endregion

        #region Pagination
        public const string PaginationSuccess = "Books paginated successfully";
        public const string PaginationEmpty = "No books found for the specified page";
        #endregion
    }
}
