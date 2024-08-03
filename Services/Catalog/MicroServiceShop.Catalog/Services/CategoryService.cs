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
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<Response<CategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var newCategory = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(newCategory);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(newCategory), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _categoryCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Category not found", 404);
            }
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == updateCategoryDto.Id, category);

            if (result == null)
            {
                return Response<NoContent>.Fail("Category not found", 404);
            }

            return Response<NoContent>.Success(204);
        }
    }
}
