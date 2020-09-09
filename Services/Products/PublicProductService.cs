using Data.EF;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using Services.Dtos.Public;
using Services.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly KattyDbContext _context;
        public PublicProductService(KattyDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.Id
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);

            int totalRow = await query.CountAsync();

            var pageSize = request.PageSize;

            var data = await query.Skip((request.PageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ProductViewModel
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    CreatedDate = x.p.CreatedDate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();


            return new PagedResult<ProductViewModel>
            {
                TotalRecord = totalRow,
                Items = data
            };
        }
    }
}
