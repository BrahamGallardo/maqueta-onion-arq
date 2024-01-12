namespace Onion.Arq.Application.Common.Parameters
{
    public class BasicTableParameter
    {
        public string Search { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;
        public string Sort { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
