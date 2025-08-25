namespace Projeto.DesenvolvimentoEstudo.Domain.Common
{
    public class PagedResponse<T>
    {
        /// <summary>
        /// Total number of records
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Number of records per page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Query result
        /// </summary>
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
