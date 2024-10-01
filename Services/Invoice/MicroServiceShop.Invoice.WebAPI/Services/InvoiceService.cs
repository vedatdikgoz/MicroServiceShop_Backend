using AutoMapper;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Invoice.WebAPI.Dtos;
using MicroServiceShop.Invoice.WebAPI.Services.Interfaces;
using MicroServiceShop.Invoice.WebAPI.Settings;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace MicroServiceShop.Invoice.WebAPI.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IMongoCollection<Entities.Invoice> _invoiceCollection;
        private readonly IMapper _mapper;
        public InvoiceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _invoiceCollection = database.GetCollection<Entities.Invoice>(databaseSettings.InvoiceCollectionName);
            _mapper = mapper;
        }


        public async Task<Response<List<InvoiceDto>>> GetAllAsync()
        {
            var invoices = await _invoiceCollection.Find(comment => true).ToListAsync();

            if (invoices.Count != 0)
            {
                return Response<List<InvoiceDto>>.Success(_mapper.Map<List<InvoiceDto>>(invoices), 200);
            }

            return Response<List<InvoiceDto>>.Fail("Invoice not found", 404);
        }

        public async Task<Response<InvoiceDto>> CreateAsync(CreateInvoiceDto createInvoiceDto)
        {
            var newComment = _mapper.Map<Entities.Invoice>(createInvoiceDto);
            await _invoiceCollection.InsertOneAsync(newComment);
            return Response<InvoiceDto>.Success(_mapper.Map<InvoiceDto>(newComment), 200); ;
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateInvoiceDto updateInvoiceDto)
        {
            var updateInvoice = _mapper.Map<Entities.Invoice>(updateInvoiceDto);
            var result = await _invoiceCollection.FindOneAndReplaceAsync(x => x.Id == updateInvoiceDto.Id, updateInvoice);
            if (result == null)
            {
                return Response<NoContent>.Fail("Invoice not found", 404);
            }
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _invoiceCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Invoice not found", 404);
            }
        }

        public async Task<Response<InvoiceDto>> GetByIdAsync(string id)
        {
            var invoice = await _invoiceCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (invoice == null)
            {
                return Response<InvoiceDto>.Fail("Invoice not found", 404);
            }
            return Response<InvoiceDto>.Success(_mapper.Map<InvoiceDto>(invoice), 200);
        }
        
    }
}
