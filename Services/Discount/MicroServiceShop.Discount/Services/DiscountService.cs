using Dapper;
using MicroServiceShop.Discount.Dtos;
using MicroServiceShop.Discount.Services.Interfaces;
using MicroServiceShop.Discount.Settings;


namespace MicroServiceShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<List<CouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<CouponDto>(query);
            return values.ToList();

        }


        public async Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@id", updateCouponDto.Id);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<CouponDto> GetDiscountCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<CouponDto>(query, parameters);
            return value;
        }

       
    }
}
