using System.ComponentModel.DataAnnotations.Schema;

namespace FAQs.Data.Entities;

public class FaqTranslation
{
     /*
     | COLUMN | TYPE | DESCRIPTION |
     | --- | --- | --- |
     | Id | Guid |  id của bản ghi |
     | FaqId | Guid | (Foreign Key tới bảng im_Faq) |
     | Question |  |  |
     | Answer |  |  |
     | Language |  |  |
     | CreatedDate |  |  |
     | ModifiedDate |  |  |
     */
     public Guid Id { get; set; }
     [ForeignKey(nameof(Faq))]
     public Guid FaqId { get; set; }
     public Faq Faq { get; set; } = null!;
     public string Question { get; set; } = null!;
     public string Answer { get; set; } = null!;
     public string Language { get; set; } = null!;
     public DateTime CreatedDate { get; set; }
     public DateTime? ModifiedDate { get; set; }
}