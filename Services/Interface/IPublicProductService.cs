using Common.Request;
using Common.Request.Public;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
