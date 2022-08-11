using System.ComponentModel.DataAnnotations;

namespace FAQs.Data.DTOs;

public class FaqDto
{
    public Guid Id { get; set; }
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public string Language { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public ICollection<FaqTranslationDto>? FaqTranslations { get; set; }
}

public class FaqByIdDto
{
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public string Language { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public ICollection<FaqTranslationByFaqIdDto>? FaqTranslations { get; set; }
}

public class CreateFaqDto
{
    // public string Language { get; set; } = "en";
    [Required]
    public string Question { get; set; } = null!;
    [Required]
    public string Answer { get; set; } = null!;
    public ICollection<CreateFaqTranslationDto> Translations { get; set; }
    
    // public CNCreateFaqTranslationDto CN { get; set; }
    // public JPCreateFaqTranslationDto JP { get; set; }
    // public VICreateFaqTranslationDto VI { get; set; }
}