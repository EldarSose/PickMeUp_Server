using Microsoft.EntityFrameworkCore;
using System.IO;
using PickMeUp.Repository;

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
        }
    }
}