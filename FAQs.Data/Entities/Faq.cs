using System.ComponentModel.DataAnnotations;
using FAQs.Data.DTOs;

namespace FAQs.Data.Entities;

public class Faq
{
    /*
    | COLUMN | TYPE | DESCRIPTION |
    | --- | --- | --- |
    | Id | Guid | id của bản ghi |
    | Question | string | thông tin câu hỏi |
    | Answer | string | thông tin câu trả lời |
    | Language | string, max length: 5 | ngôn ngữ của câu hỏi (đây là ngôn ngữ mặc định là en) |
    | CreatedDate | DateTime | thời gian tạo |
    | ModifiedDate | DateTime | thời gian sửa lần cuối |
    */
    public Guid Id { get; set; }
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    [MaxLength(5)]
    public string Language { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public ICollection<FaqTranslation>? FaqTranslations { get; set; }
}