using FAQs.Data.Entities;

namespace FAQs.Business.Services;

public interface IFAQServices
{
    Task<ICollection<Faq>> GetItems();
    Task<Faq?> GetItem(Guid id);
    Task CreateItem(Faq faq);

    Task UpdateItem(Faq faq);
}