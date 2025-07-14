namespace LawPavillion.Library.Backend.API.Helpers
{
    /// <summary>
    /// Centralized API route definitions for consistent routing.
    /// Helps avoid magic strings in controllers.
    /// </summary>
    public static class ApiRoute
    {
        public const string Auth = "api/auth";
        public const string Books = "api/books";

        // Optional
        public const string SearchBooks = "search";
        public const string PaginateBooks = "paginate";
    }
}
