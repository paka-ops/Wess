using FlotteApplication.Data;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Repositories.Implementation
{
    public class QuotationRepository : IQuotation
    {
        public Boolean IsQuotationExist(int quotationId)
        {
            var quotationContext = new DataSource();
            var existQuotation = quotationContext.Quotation.Where(e => e.quotationId == quotationId);
            if (existQuotation.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<String> createQuotation(Quotation quotation)
        {
            var IsExist = IsQuotationExist(quotation.quotationId);
            if (IsExist == true)
            {
                return "Il existe déjà";
            }
            else
            {
                try
                {
                    using (var quotationContext = new DataSource())
                    {
                        quotationContext.Add(quotation);
                        await quotationContext.SaveChangesAsync();
                    }
                    return "Enregistrement effectué avec succes";
                }
                catch (Exception ex)
                {
                    return " erreur " + ex.InnerException;
                }
            }
        }

        public async Task<Quotation> getQuotation(int quotationId)
        {
            using (var quotationContext = new DataSource())
            {
                var quotation = await quotationContext.Quotation
                .FirstOrDefaultAsync(e => e.quotationId == quotationId);

                if (quotation != null)
                {
                    return quotation;
                }
                else
                {
                    return null;
                }
            }
        
        }

        public Task<Quotation> updateQuotation(int quotationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Quotation> deleteQuotation(int quotationId)
        {
            using (var quotationContext = new DataSource())
            {
                var quotation = await quotationContext.Quotation
                    .FirstOrDefaultAsync(e => e.quotationId == quotationId);

                if (quotation != null)
                {
                    quotationContext.Quotation.Remove(quotation);
                    await quotationContext.SaveChangesAsync();
                    return quotation;
                }

                return null;
            }
        }
    }
}
