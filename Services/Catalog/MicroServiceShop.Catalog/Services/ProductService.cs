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
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }


        public async Task<Response<ProductDto>> CreateAsync(CreateProductDto createProductDto)
        {
            var newProduct = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(newProduct);
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(newProduct), 200);
        }


        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }
        }


        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();

            if (products.Count != 0)
            {
                foreach (var product in products)
                {
                    product.Category = await _categoryCollection.Find(x => x.Id == product.CategoryId).FirstAsync();
                }
                return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
            }
        
            return Response<List<ProductDto>>.Fail("Product not found", 404);   
        }


        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return Response<ProductDto>.Fail("Product not found", 404);
            }
            product.Category = await _categoryCollection.Find(y => y.Id == product.CategoryId).FirstAsync();
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<Response<List<ProductDto>>> GetProductsByCategory(string categoryId)
        {
            var products = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            if (products == null)
            {
                return Response<List<ProductDto>>.Fail("Product not found", 404);
            }
            foreach (var product in products)
            {
                product.Category = await _categoryCollection.Find(y => y.Id == product.CategoryId).FirstAsync();
            }
            
            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200); ;
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductDto updateProductDto)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, updateProduct);
            if (result == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
    }
}
