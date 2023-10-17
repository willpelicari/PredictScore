using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace PredictScore.Repository.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed<T>(this ModelBuilder modelBuilder) where T : class
        {
            //Debugger.Launch();

            var fileName = $"{typeof(T).Name}s.json";
            return Seed<T>(modelBuilder, fileName);
        }

        public static ModelBuilder Seed<T>(this ModelBuilder modelBuilder, string fileName) where T : class
        {
            var fullFileName = $"PredictScore.Repository.Seeds.{fileName}";
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullFileName);
            using var reader = new StreamReader(stream!);

            var jsonString = reader.ReadToEnd();
            var listOfEntities = JsonSerializer.Deserialize<ICollection<T>>(jsonString);

            modelBuilder
                .Entity<T>()
                .HasData(listOfEntities!);

            return modelBuilder;
        }
    }
}
