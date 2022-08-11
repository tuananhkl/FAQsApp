using FAQs.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FAQs.Data;

public class AppDbContext : IdentityDbContext<ApiUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Faq> Faqs { get; set; }
    public DbSet<FaqTranslation> FaqTranslations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Faq
        modelBuilder.Entity<Faq>().HasData(new Faq
        {
            Id = Guid.Parse("22a30b4d-c055-49ab-98bb-5767dd591c43"),
            Question = "How old are you?",
            Answer = "I'm 23 years old.",
            Language = "en",
            CreatedDate = DateTime.UtcNow
        });
        
        //FaqTranslation
        //vi
        modelBuilder.Entity<FaqTranslation>().HasData(new
        {
            Id = Guid.Parse("301ca0ab-3486-41d5-af94-565a105c7ea1"),
            FaqId = Guid.Parse("22a30b4d-c055-49ab-98bb-5767dd591c43"),
            Question = "Ban bao nhieu tuoi?",
            Answer = "Toi 23 tuoi",
            Language = "vi",
            CreatedDate = DateTime.UtcNow
        });
        //jp
        modelBuilder.Entity<FaqTranslation>().HasData(new
        {
            Id = Guid.Parse("30f467c3-6b6c-4b73-b8d7-696bd317904b"),
            FaqId = Guid.Parse("22a30b4d-c055-49ab-98bb-5767dd591c43"),
            Question = "anata-wa-oikutsu-desu-ka?",
            Answer = "watashi-wa-njusansai-desu.",
            Language = "jp",
            CreatedDate = DateTime.UtcNow
        });
        //cn
        modelBuilder.Entity<FaqTranslation>().HasData(new
        {
            Id = Guid.Parse("8621b5da-0b07-4795-b360-7a898e842037"),
            FaqId = Guid.Parse("22a30b4d-c055-49ab-98bb-5767dd591c43"),
            Question = "nín duō dà suìshu?",
            Answer = "Wǒ èrshísān suì.",
            Language = "cn",
            CreatedDate = DateTime.UtcNow
        });
        
        //User Roles
        //user
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "User",
            NormalizedName = "USER"
        });
        //admin
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        });
    }
}