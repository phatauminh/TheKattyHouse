using Common.Request;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<PagedResult<ProductViewModel>> GetAll();
    }
}
