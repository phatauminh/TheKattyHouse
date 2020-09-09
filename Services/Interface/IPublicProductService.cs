using Services.Dtos;
using Services.Dtos.Public;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
