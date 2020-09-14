using Common.Request;
using Common.Request.Manage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductCreateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId,decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
        Task<int> AddImages(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImages(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
