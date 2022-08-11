using FAQs.Data;
using FAQs.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAQs.Business.Services;

public class FAQServices : IFAQServices
{
    private readonly AppDbContext _dbContext;

    public FAQServices(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Faq>> GetItems()
    {
        var faqs = await _dbContext.Faqs.Include(f => f.FaqTranslations).ToListAsync();

        return faqs;
    }

    public async Task<Faq?> GetItem(Guid id)
    {
        var faq = await _dbContext.Faqs.Include(f => f.FaqTranslations).FirstOrDefaultAsync(f => f.Id == id);

        return faq;
    }

    public async Task CreateItem(Faq faq)
    {
        await _dbContext.Faqs.AddAsync(faq);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateItem(Faq faq)
    {
        _dbContext.Update(faq);
        await _dbContext.SaveChangesAsync();
    }
}