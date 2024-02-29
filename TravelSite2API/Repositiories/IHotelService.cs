using System.Threading.Tasks;
using TravelSite2API.Entities;

namespace TravelSite2API.Repositiories
{
    public interface IHotelService
    {
        public Task<List<Hotel>> HotelGetDetails(int hotelid);
    }
}
