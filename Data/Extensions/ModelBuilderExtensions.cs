using Data.Entities.Items;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of TheKattyHouse" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of TheKattyHouse" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of TheKattyHouse" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Mèo Anh Lông Ngắn", LanguageId = "vi", SeoAlias = "meo-anh-long-ngan", SeoDescription = "Giống mèo anh lông ngắn", SeoTitle = "Mèo Anh Lông Ngắn" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "British Shorthair", LanguageId = "en", SeoAlias = "british-shorthair", SeoDescription = "British Shorthair Cat", SeoTitle = "British Shorthair Cat" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Mèo Ba Tư", LanguageId = "vi", SeoAlias = "meo-ba-tu", SeoDescription = "Giống Mèo Ba Tư", SeoTitle = "Mèo Ba Tư" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Persian ", LanguageId = "en", SeoAlias = "persian", SeoDescription = "Persian Cat", SeoTitle = "Persian Cat" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               CreatedDate = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Mèo Anh Lông Ngắn Tai Cụp",
                     LanguageId = "vi",
                     SeoAlias = "meo-anh-long-ngan-tai-cup",
                     SeoDescription = "Mèo Anh Lông Ngắn Tai Cụp",
                     SeoTitle = "Mèo Anh Lông Ngắn Tai Cụp",
                     Details = "Mèo Anh Lông Ngắn Tai Cụp",
                     Description = "Mèo Anh Lông Ngắn Tai Cụp"
                 },
                 new ProductTranslation()
                  {
                     Id = 2,
                     ProductId = 1,
                     Name = "British Shorthair Folds",
                     LanguageId = "en",
                     SeoAlias = "british-shorthair-folds",
                     SeoDescription = "British Shorthair Folds",
                     SeoTitle = "British Shorthair Folds",
                     Details = "British Shorthair Folds",
                     Description = "British Shorthair Folds"
                 });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "phat.auminh@gmail.com",
                NormalizedEmail = "phat.auminh@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Phat1234"),
                SecurityStamp = string.Empty,
                FirstName = "Phat",
                LastName = "Au",
                Dob = new DateTime(1993, 08, 01)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
