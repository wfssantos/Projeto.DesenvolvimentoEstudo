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

        db.SaveChanges();
    }
}
