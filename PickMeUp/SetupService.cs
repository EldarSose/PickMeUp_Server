using Microsoft.EntityFrameworkCore;
using System.IO;
using PickMeUp.Repository;
using PickMeUp.Core.Entities;

namespace PickMeUp
{
    public class SetupService
    {
        public void Init(PickMeUpDbContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(PickMeUpDbContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "dataSeed.sql");
            var query = File.ReadAllText(path);


            //context.Database.ExecuteSqlRaw(query);

            var g = new Gender
            {
                description = "M",
                isDeleted = false
            };

            var gf = new Gender
            {
                description = "F",
                isDeleted = false
            };

            context.Genders.Add(g);
            context.Genders.Add(gf);

            context.SaveChanges();
        }
    }
}