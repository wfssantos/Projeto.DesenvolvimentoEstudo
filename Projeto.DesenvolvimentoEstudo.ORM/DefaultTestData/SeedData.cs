using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Model.Enums;

namespace Projeto.DesenvolvimentoEstudo.ORM.DefaultTestData;

public class SeedData
{
    public void Development(DefaultContext db)
    {
        if (!db.Users.Any(item => item.Id == Guid.Parse("8db85f64-2222-1111-b3fc-2c963f66afa6")))
        {
            db.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("8db85f64-2222-1111-b3fc-2c963f66afa6"),
                    Username = "admin_user",
                    Password = "$2a$11$aHFJM1Pfz8YoALGM0Qrq4.cIjLRoddKcbKINj1BU0UqJx5gmuC9/u",
                    Email = "admin@example.com",
                    Status = UserStatus.Active,
                    //Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        if (!db.Companies.Any(item => item.Id == Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b")))
        {
            db.Companies.AddRange(
                new Company
                {
                    Id = Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b"),
                    Name = "ZODIAC MARITIME LTD"
                }
            );
        }

        db.SaveChanges();

        var company = db.Companies.Find(Guid.Parse("d3b07384-d9a1-4f6a-8a6c-5d7a1f1e8c2b"));
        if (company != null)
        {
            company.Addresses.Add(new CompanyAddress() 
            {
                Address = "Portman House, 2 Portman Street",
                City = "London",
                Code = "W1H 6DU",
                Country = "United Kingdom"
            });

            company.Emails.Add(new CompanyEmail()
            {
                Email = "vishnu.suresh@zodiac-maritime.com",
                Contact = "Vishnu Suresh / Tech Assistant"
            });
            company.Phones.Add(new CompanyPhone()
            {
                Phone = 442073332221,
                Contact = "Vishnu Suresh / Tech Assistant",
                Type = "Tel"
            });

            db.SaveChanges();
        }        
    }
}
