using Mapster;
using Teklican.Application.Products.Common;
using Teklican.Contracts.Products;

namespace Teklican.API.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductResult, ProductResponse>()
                .Map(dest => dest, scr => scr.Product)
                .Map(dest => dest.Id, scr => scr.Product.Id.Value)
                .Map(dest => dest.CategoryId, scr => scr.Product.CategoryId.Value);
        }
    }
}
