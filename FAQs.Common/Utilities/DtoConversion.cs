using FAQs.Data.DTOs;
using FAQs.Data.Entities;

namespace FAQs.Common.Utilities;

public static class DtoConversion
{
    public static IEnumerable<FaqDto> ConvertToDto(this IEnumerable<Faq> faqs)
    {
        return (from faq in faqs
                select new FaqDto
                {
                    Id = faq.Id,
                    Question = faq.Question,
                    Answer = faq.Answer,
                    Language = faq.Language,
                    CreatedDate = faq.CreatedDate,
                    ModifiedDate = faq.ModifiedDate,
                    FaqTranslations = (from faqTranslation in faq.FaqTranslations
                            select new FaqTranslationDto
                            {
                                 Id = faqTranslation.Id,
                                 Question = faqTranslation.Question,
                                 Answer = faqTranslation.Answer,
                                 Language = faqTranslation.Language,
                                 CreatedDate = faqTranslation.CreatedDate,
                                 ModifiedDate = faqTranslation.ModifiedDate
                            }).ToList()
                });
    }

    public static FaqByIdDto ConvertToDto(this Faq faq)
    {
        return new FaqByIdDto()
        {
            Question = faq.Question,
            Answer = faq.Answer,
            Language = faq.Language,
            CreatedDate = faq.CreatedDate,
            ModifiedDate = faq.ModifiedDate,
            FaqTranslations = (from faqTranslation in faq.FaqTranslations
                select new FaqTranslationByFaqIdDto()
                {
                    Question = faqTranslation.Question,
                    Answer = faqTranslation.Answer,
                    Language = faqTranslation.Language,
                    CreatedDate = faqTranslation.CreatedDate,
                    ModifiedDate = faqTranslation.ModifiedDate
                }).ToList()
        };
    }

    public static Faq ConvertToDto(this CreateFaqDto dto, Guid faqId)
    {
        return new Faq
        {
            Id = faqId,
            Question = dto.Question,
            Answer = dto.Answer,
            Language = "en",
            CreatedDate = DateTime.UtcNow,
            FaqTranslations = (from faqTranslation in dto.Translations
                    select new FaqTranslation
                    {
                        Id = Guid.NewGuid(),
                        FaqId = faqId,
                        Question = faqTranslation.Question,
                        Answer = faqTranslation.Answer,
                        Language = faqTranslation.Language,
                        CreatedDate = DateTime.UtcNow
                    }).ToList()
        };
    }
}