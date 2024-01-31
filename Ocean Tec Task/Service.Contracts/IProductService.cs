using Ocean_Tec_Task.Models;
using Ocean_Tec_Task.Shared;

namespace Ocean_Tec_Task.Service.Contracts
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid productId);
        Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto updatedProductDto);
        Task<HttpResponseMessage> DeleteProductAsync(Guid productId);
        Task<ProductDto> CreateProductWithUnitsAndCharsAsync(ProductDto productDto, UnitDto mainUnitDto, UnitDto mediumUnitDto, UnitDto smallUnitDto, CharacteristicsDto characteristicsDto);
    }

}
