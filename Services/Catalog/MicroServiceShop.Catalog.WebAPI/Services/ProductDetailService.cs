using AutoMapper;
using MicroServiceShop.Catalog.WebAPI.Dtos;
using MicroServiceShop.Catalog.WebAPI.Entities;
using MicroServiceShop.Catalog.WebAPI.Services.Interfaces;
using MicroServiceShop.Catalog.WebAPI.Settings;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace MicroServiceShop.Catalog.WebAPI.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<ProductDetailDto>> CreateAsync(CreateProductDetailDto createProductDetailDto)
        {
            var newProductDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(newProductDetail);
            return Response<ProductDetailDto>.Success(_mapper.Map<ProductDetailDto>(newProductDetail), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ProductDetail not found", 404);
            }
        }

        public async Task<Response<List<ProductDetailDto>>> GetAllAsync()
        {               
            var productDetails = await _productDetailCollection.Find(productDetail => true).ToListAsync();
            return Response<List<ProductDetailDto>>.Success(_mapper.Map<List<ProductDetailDto>>(productDetails), 200);
        }

        public async Task<Response<ProductDetailDto>> GetByIdAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (productDetail == null)
            {
                return Response<ProductDetailDto>.Fail("ProductDetail not found", 404);
            }
            return Response<ProductDetailDto>.Success(_mapper.Map<ProductDetailDto>(productDetail), 200);
        }

        public async Task<Response<ProductDetailDto>> GetByProductIdAsync(string productId)
        {
            var productDetail = await _productDetailCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            if (productDetail == null)
            {
                return Response<ProductDetailDto>.Fail("ProductDetail not found", 404);
            }
            return Response<ProductDetailDto>.Success(_mapper.Map<ProductDetailDto>(productDetail), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var updateProductDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            var result = await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailDto.Id, updateProductDetail);
            if (result == null)
            {
                return Response<NoContent>.Fail("ProductDetail not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
    }
}
