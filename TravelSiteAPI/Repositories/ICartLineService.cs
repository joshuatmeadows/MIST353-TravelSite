using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Repositories
{
    public interface ICartLineService
    {
        public Task<List<CartLine>> CartViewByCartID(string cartid);
    }
}
