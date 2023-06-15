using Microsoft.EntityFrameworkCore;

namespace api.QueryStringHelpers
{
    public class PagedResponse<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public PaginationData PaginationParams { get; private set; }

        private PagedResponse(IEnumerable<T> data, PaginationData paginationParams)
        {
            Data = data;
            PaginationParams = paginationParams;
        }

        public static async Task<PagedResponse<T>> GetPagedResponse(IQueryable<T> data, PaginationParams? paginationParams)
        {
            if (paginationParams is null)
                paginationParams = new PaginationParams();

            int totalItems = await data.CountAsync().ConfigureAwait(false);
            int pageCount = (int)Math.Ceiling(totalItems / (double)paginationParams.PageSize);

            var paginationData = new PaginationData
            {
                TotalItems = totalItems,
                PageSize = paginationParams.PageSize,
                PageCount = pageCount
            };

            data = data.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);

            return new PagedResponse<T>(await data.ToListAsync(), paginationData);
        }
    }
}
