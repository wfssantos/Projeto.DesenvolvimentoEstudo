using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Enums;
using Projeto.DesenvolvimentoEstudo.Model.Enums;

namespace Projeto.DesenvolvimentoEstudo.ORM.DefaultTestData;

public class SeedData
{
    public void Development(DefaultContext db)
    {
        var userId = Guid.Parse("8db85f64-2222-1111-b3fc-2c963f66afa6");
        if (!db.Users.Any(u => u.Id == userId))
        {
            db.Users.Add(new User
            {
                Id = userId,
                Username = "admin_user",
                Password = "$2a$11$aHFJM1Pfz8YoALGM0Qrq4.cIjLRoddKcbKINj1BU0UqJx5gmuC9/u",
                Email = "admin@example.com",
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow
            });
        }

        if (!db.Companies.Any(c => c.Id == Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b")))
        {
            db.Companies.Add(new Company
            {
                Id = Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b"),
                Name = "ZODIAC MARITIME LTD"
            });
        }

        db.SaveChanges(); 

        var company = db.Companies
            .Include(c => c.Addresses)
            .Include(c => c.Emails)
            .Include(c => c.Phones)
            .Include(c => c.Products)
            .Include(c => c.Sales)
            .First(c => c.Id == Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b"));

        company.Addresses.Add(new CompanyAddress
        {
            Address = "Portman House, 2 Portman Street",
            City = "London",
            Code = "W1H 6DU",
            Country = "United Kingdom"
        });

        company.Emails.Add(new CompanyEmail
        {
            Email = "vishnu.suresh@zodiac-maritime.com",
            Contact = "Vishnu Suresh / Tech Assistant"
        });

        company.Phones.Add(new CompanyPhone
        {
            Phone = 442073332221,
            Contact = "Vishnu Suresh / Tech Assistant",
            Type = "Tel"
        });
        db.SaveChanges();
        
        var product = new CompanyProduct {
            Name = "Apple IPhone 17 - 256 GB",
            Description = "The latest generation of Apple’s smartphone...",
            Price = 799.98m,
            StockQuantity = 17,
            Status = ProductStatus.Active,
            CreatedAt = DateTime.UtcNow
        };
        company.Products.Add(product);
        db.SaveChanges();

        var sale = new CompanySale {
            SaleNumber = 20259999,
            CreatedAt = DateTime.UtcNow,
            Status = SaleStatus.Processing,
            UserId = userId
        };
        sale.CompanySaleItem.Add(new CompanySaleItem
        {
            CompanyProductId = product.Id,
            Quantity = 2,
            Discount = 0m
        });
        company.Sales.Add(sale);
        db.SaveChanges(); 
    }
}
