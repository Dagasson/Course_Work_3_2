using System.Linq;
using Course_Work.Models;
using Course_Work.Context;

namespace Course_Work
{
    public static class SampleData
    {
        public static void Initialize(dbcontext context)
        {
            if (!context.Shops.Any())
            {
                context.Shops.AddRange(
                    new Shop
                    {
                        Name = "Грибной суп",
                        Cost = 500,
                        Info = "Вкусненький супчик из грибов."
                    },
                    new Shop
                    {
                        Name = "Пюре с биточками",
                        Cost = 1000,
                        Info = "Что такое биточки???"
                    },
                    new Shop
                    {
                        Name = "Оливье",
                        Cost = 400,
                        Info = "Главное не упасть лицом"
                    }
                );
                context.SaveChanges();
            }
            if(!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        Email = "Kekus@mail.ru",
                        PasswordHash = "AQAAAAEAACcQAAAAEKh+R8WlkZZgqOCr2vnzQ8vuA4rujj+nDPaF6/Uj75TFdKaye55PHRseXVAOakzIpA=="
                    }
                    );
            }
        }
    }
}