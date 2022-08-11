using System.ComponentModel.DataAnnotations;

namespace FAQs.Data.DTOs;

public class FaqTranslationDto : FaqTranslationByFaqIdDto
{
    public Guid Id { get; set; }
}

public class FaqTranslationByFaqIdDto
{
    public string Language { get; set; } = null!;
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

public class CreateFaqTranslationDto
{
    [Required]
    [StringLength(5, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 1)]
    public string Language { get; set; } = null!;
    [Required]
    public string Question { get; set; } = null!;
    [Required]
    public string Answer { get; set; } = null!;
}

// public class CNCreateFaqTranslationDto
// {
//     public string Language { get; set; } = "cn";
//     public string Question { get; set; } = null!;
//     public string Answer { get; set; } = null!;
// }
//
// public class JPCreateFaqTranslationDto
// {
//     public string Language { get; set; } = "jp";
//     public string Question { get; set; } = null!;
//     public string Answer { get; set; } = null!;
// }
//
// public class VICreateFaqTranslationDto
// {
//     public string Language { get; set; } = "vi";
//     public string Question { get; set; } = null!;
//     public string Answer { get; set; } = null!;
// }