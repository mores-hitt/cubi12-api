using System.Text.Json;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Data
{
    public class Seed
    {
        /// <summary>
        /// Seed the database with examples models in the json files if the database is empty.
        /// </summary>
        /// <param name="context">Database Context </param>
        public static void SeedData(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CallEachSeeder(context, options);
        }

        /// <summary>
        /// Centralize the call to each seeder method and save changes.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        public static void CallEachSeeder(DataContext context, JsonSerializerOptions options)
        {
            SeedFirstOrderTables(context, options);
        }

        /// <summary>
        /// Seed the database with the tables that don't depend on other tables.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedFirstOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedRoles(context, options);
            SeedSubjects(context, options);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed the database with the roles in the json file if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedRoles(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Roles?.Any();
            if (result is true or null) return;
            // Fix the path of ReadAllText to the correct one
            var path = "Src/Data/DataSeeders/RolesData.json";
            var rolesData = File.ReadAllText(path);
            var rolesList = JsonSerializer.Deserialize<List<Role>>(rolesData, options) ??
                throw new Exception("RolesData.json is empty");

            context.Roles?.AddRange(rolesList);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed the database with the subjects in the json file if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedSubjects(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Subjects?.Any();
            if (result is true or null) return;
            // Fix the path of ReadAllText to the correct one
            var path = "Src/Data/DataSeeders/SubjectsData.json";
            var subjectsData = File.ReadAllText(path);
            var subjectsList = JsonSerializer.Deserialize<List<Subject>>(subjectsData, options) ??
                throw new Exception("SubjectsData.json is empty");
            // Normalize the name and department of the subjects
            subjectsList.ForEach(s =>
            {
                s.Name = s.Name.ToLower();
                s.Department = s.Department.ToLower();
            });

            context.Subjects?.AddRange(subjectsList);
            context.SaveChanges();
        }

    }
}