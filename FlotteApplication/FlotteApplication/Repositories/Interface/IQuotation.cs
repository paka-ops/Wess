using FlotteApplication.Models;

namespace FlotteApplication.Repositories.Interface
{
    public interface IQuotation
    {
        public Task<String> createQuotation(Quotation quotation);
        public Task<Quotation> updateQuotation(int quotationId);
        public Task<Quotation> getQuotation(int quotationId);
        public Task<Quotation> deleteQuotation(int quotationId);
    }
}
