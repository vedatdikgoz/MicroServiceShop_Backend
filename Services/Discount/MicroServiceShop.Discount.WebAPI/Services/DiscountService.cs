using Dapper;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Discount.WebAPI.Dtos;
using MicroServiceShop.Discount.WebAPI.Services.Interfaces;
using MicroServiceShop.Discount.WebAPI.Settings;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MicroServiceShop.Discount.WebAPI.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Response<NoContent>> CreateDiscountCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO discount.coupons (code, rate, isactive, validdate) VALUES (@code, @rate, @isactive, @validdate)";
            var parameters = new DynamicParameters();
            parameters.Add("code", createCouponDto.Code);
            parameters.Add("rate", createCouponDto.Rate);
            parameters.Add("isactive", createCouponDto.IsActive);
            parameters.Add("validdate", createCouponDto.ValidDate);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM discount.coupons WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<CouponDto>>> GetAllDiscountCouponAsync()
        {
            string query = "SELECT * FROM discount.coupons";
            using var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<CouponDto>(query);
            return Response<List<CouponDto>>.Success(values.ToList(), 200);
        }


        public async Task<Response<NoContent>> UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE discount.coupons SET code=@code, rate=@rate, isactive=@isactive, validdate=@validdate WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateCouponDto.Code);
            parameters.Add("rate", updateCouponDto.Rate);
            parameters.Add("isactive", updateCouponDto.IsActive);
            parameters.Add("validdate", updateCouponDto.ValidDate);
            parameters.Add("id", updateCouponDto.Id);
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<CouponDto>> GetDiscountCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM discount.coupons WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<CouponDto>(query, parameters);
            if (value == null)
            {
                return Response<CouponDto>.Fail("Discount not found", 404);
            }
            return Response<CouponDto>.Success(value, 200);
        }


        public async Task<Response<CouponDto>> GetByCodeAndUserId(string code)
        {
            string query = "SELECT * FROM discount.coupons WHERE code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code);
            using var connection = _dapperContext.CreateConnection();
            var hasDiscount = await connection.QueryFirstOrDefaultAsync<CouponDto>(query, parameters);
            return hasDiscount == null
                ? Response<CouponDto>.Fail("Discount not found", 404)
                : Response<CouponDto>.Success(hasDiscount, 200);
        }
    }
}
