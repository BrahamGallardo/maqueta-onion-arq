namespace Onion.Arq.Application.Common
{
    public class PaginatedList<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public T TableFooter { get; }

        public PaginatedList(IReadOnlyList<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public PaginatedList(IReadOnlyList<T> items, int count, int pageIndex, int pageSize, T tableFooter)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
            TableFooter = tableFooter;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }
}
