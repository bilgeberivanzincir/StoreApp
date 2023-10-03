namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice> MinPrice; //t,f

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ProductRequestParameters() : this(1,3)
        {
            
        }

        public ProductRequestParameters(int pageNumber=1, int pageSize=3)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}