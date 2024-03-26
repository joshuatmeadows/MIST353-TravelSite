using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using TravelSiteAPI.Entities;
using TravelSiteAPI.Data;

namespace TravelSiteAPI.Repositories
{
    public class CartLineService
    {
        private readonly DbContextClass _dbContext;
        public CartLineService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        // view cart by id
        public async Task<List<CartLine>> CartViewByCartID(string cartid)
        {
            var param = new SqlParameter("@CartID", cartid);
            var cartLines = await Task.Run(() => _dbContext.CartLines.FromSqlRaw("spCartViewByCartID @CartID", param).ToListAsync());
            return cartLines;
        }
    }
}
