using AutoMapper;
using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Catalog.Entities;
using MicroServiceShop.Catalog.Services.Interfaces;
using MicroServiceShop.Catalog.Settings;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace MicroServiceShop.Catalog.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<ProductImageDto>> CreateAsync(CreateProductImageDto createProductImageDto)
        {
            var newProductImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(newProductImage);
            return Response<ProductImageDto>.Success(_mapper.Map<ProductImageDto>(newProductImage), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productImageCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ProductImage not found", 404);
            }
        }

        public async Task<Response<List<ProductImageDto>>> GetAllAsync()
        {
            var productImages = await _productImageCollection.Find(productImage => true).ToListAsync();
            return Response<List<ProductImageDto>>.Success(_mapper.Map<List<ProductImageDto>>(productImages), 200);
        }

        public async Task<Response<ProductImageDto>> GetByIdAsync(string id)
        {
            var productImage = await _productImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (productImage == null)
            {
                return Response<ProductImageDto>.Fail("Product not found", 404);
            }
            return Response<ProductImageDto>.Success(_mapper.Map<ProductImageDto>(productImage), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductImageDto updateProductImageDto)
        {
            var updateProductImage = _mapper.Map<ProductImage>(updateProductImageDto);
            var result = await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageDto.Id, updateProductImage);
            if (result == null)
            {
                return Response<NoContent>.Fail("ProductImage not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
    }
}
