namespace BicycleRental.Server.Helpers
{
    public static class HttpContextExtension
    {
        public static async Task InsertPaginationParameterInResponse<T>(this HttpContext context, IQueryable<T> queryable, int pageSize)
        {
            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pageSize);
            context.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
    }
}
