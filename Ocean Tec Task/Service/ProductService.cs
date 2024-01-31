using Ocean_Tec_Task.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ocean_Tec_Task.Service.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using Ocean_Tec_Task.Shared;
using AutoMapper;


namespace Ocean_Tec_Task.Service
{
    public class ProductService : IProductService
    {
        private readonly dbContextClass _dbContext;
        private readonly IMapper _mapper;

        public ProductService(dbContextClass dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);


            _dbContext.Products.Add(productEntity);
            await _dbContext.SaveChangesAsync();

            var createdProductDto = _mapper.Map<ProductDto>(productEntity);
            return createdProductDto;
        }

        public async Task<ProductDto> CreateProductWithUnitsAndCharsAsync(ProductDto productDto, UnitDto mainUnitDto, UnitDto mediumUnitDto, UnitDto smallUnitDto, CharacteristicsDto characteristicsDto)
        {
            // Map the DTOs to entities
            var productEntity = _mapper.Map<Product>(productDto);
            var mainUnitEntity = _mapper.Map<Unit>(mainUnitDto);
            var mediumUnitEntity = _mapper.Map<Unit>(mediumUnitDto);
            var smallUnitEntity = _mapper.Map<Unit>(smallUnitDto);

            // Set relationships
            productEntity.MainUnit = mainUnitEntity;
            productEntity.MediumUnit = mediumUnitEntity;
            productEntity.SmallUnit = smallUnitEntity;

            // Add entities to the context
            _dbContext.Products.Add(productEntity);
            _dbContext.Units.AddRange(mainUnitEntity, mediumUnitEntity, smallUnitEntity);

            // Set Characteristics for Units
            mainUnitEntity.Characteristics = _mapper.Map<Characteristics>(characteristicsDto);
            mediumUnitEntity.Characteristics = _mapper.Map<Characteristics>(characteristicsDto);
            smallUnitEntity.Characteristics = _mapper.Map<Characteristics>(characteristicsDto);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Map the created entities back to DTOs
            var createdProductDto = _mapper.Map<ProductDto>(productEntity);
            var createdMainUnitDto = _mapper.Map<UnitDto>(mainUnitEntity);
            var createdMediumUnitDto = _mapper.Map<UnitDto>(mediumUnitEntity);
            var createdSmallUnitDto = _mapper.Map<UnitDto>(smallUnitEntity);

            // Set the DTO properties
            createdProductDto.MainUnitId = createdMainUnitDto.UnitId;
            createdProductDto.MediumUnitId = createdMediumUnitDto.UnitId;
            createdProductDto.SmallUnitId = createdSmallUnitDto.UnitId;

            return createdProductDto;
        }



        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products
                .Include(p => p.MainUnit)
                .Include(p => p.MediumUnit)
                .Include(p => p.SmallUnit).ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var product = await _dbContext.Products
                .Include(p => p.MainUnit)
                .Include(p => p.MediumUnit)
                .Include(p => p.SmallUnit)
                .FirstOrDefaultAsync(p => p.Id == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto updatedProductDto)
        {
            var existingProduct = await _dbContext.Products.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            // Use AutoMapper to apply the changes from updatedProductDto to existingProduct
            _mapper.Map(updatedProductDto, existingProduct);

            await _dbContext.SaveChangesAsync();

            // Return the updated product as ProductDto
            return _mapper.Map<ProductDto>(existingProduct);
        }


        public async Task<HttpResponseMessage> DeleteProductAsync(Guid productId)
        {
            var productToDelete = await _dbContext.Products.FindAsync(productId);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();

                // Return 200 OK
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                // Return 404 Not Found
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"Product with ID {productId} not found.")
                };
            }
        }

    }


}
