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
        /// Centralize the call to each seeder method
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        public static void CallEachSeeder(DataContext context, JsonSerializerOptions options)
        {
            SeedFirstOrderTables(context, options);
            SeedSecondtOrderTables(context, options);
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
            SeedCareers(context, options);
            SeedSubjectResources(context, options);
            SeedResources(context, options);
        }

        /// <summary>
        /// Seed the database with the tables whose data depends on exatly one table.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedSecondtOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedSubjectsRelationships(context, options);
        }

        /// <summary>
        /// Seed the database with the roles in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedRoles(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Roles?.Any();
            if (result is true or null) return;

            var path = "Src/Data/DataSeeders/RolesData.json";
            var rolesData = File.ReadAllText(path);
            var rolesList = JsonSerializer.Deserialize<List<Role>>(rolesData, options) ??
                throw new Exception("RolesData.json is empty");

            context.Roles?.AddRange(rolesList);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed the database with the subjects in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedSubjects(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Subjects?.Any();
            if (result is true or null) return;

            var path = "Src/Data/DataSeeders/SubjectsData.json";
            var subjectsData = File.ReadAllText(path);
            var subjectsList = JsonSerializer.Deserialize<List<Subject>>(subjectsData, options) ??
                throw new Exception("SubjectsData.json is empty");
            // Normalize the name, code and department of the subjects
            subjectsList.ForEach(s =>
            {
                s.Code = s.Code.ToLower();
                s.Name = s.Name.ToLower();
                s.Department = s.Department.ToLower();
            });

            context.Subjects?.AddRange(subjectsList);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed the database with the careers in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedCareers(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Careers?.Any();
            if (result is true or null) return;
            var path = "Src/Data/DataSeeders/CareersData.json";
            var careersData = File.ReadAllText(path);
            var careersList = JsonSerializer.Deserialize<List<Career>>(careersData, options) ??
                throw new Exception("CareersData.json is empty");
            // Normalize the name and code of the careers
            careersList.ForEach(s =>
            {
                s.Name = s.Name.ToLower();
            });

            context.Careers?.AddRange(careersList);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed the database with the subjects relationships in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedSubjectsRelationships(DataContext context, JsonSerializerOptions options)
        {
            var result = context.SubjectsRelationships?.Any();
            if (result is true or null) return;
            var path = "Src/Data/DataSeeders/SubjectsRelationsData.json";
            var subjectsRelationshipsData = File.ReadAllText(path);
            var subjectsRelationshipsList = JsonSerializer
                .Deserialize<List<SubjectRelationship>>(subjectsRelationshipsData, options) ??
                throw new Exception("SubjectsRelationsData.json is empty");
            // Normalize the codes of the codes
            subjectsRelationshipsList.ForEach(s =>
            {
                s.SubjectCode = s.SubjectCode.ToLower();
                s.PreSubjectCode = s.PreSubjectCode.ToLower();
            });

            context.SubjectsRelationships?.AddRange(subjectsRelationshipsList);
            context.SaveChanges();
        }

        private static void SeedSubjectResources(DataContext context, JsonSerializerOptions options)
        {
            var result = context.SubjectResources?.Any();
            if (result is true or null) return;
            var path = "Src/Data/DataSeeders/SubjectsResourcesData.json";
            var subjectResourcesData = File.ReadAllText(path);
            var subjectResourcesList = JsonSerializer
                .Deserialize<List<SubjectResource>>(subjectResourcesData, options) ??
                throw new Exception("SubjectsResourcesData.json is empty");
            subjectResourcesList.ForEach(s =>
            {
                s.Name = s.Name.ToLower();
                s.Description = s.Description.ToLower();
            });

            context.SubjectResources?.AddRange(subjectResourcesList);
            context.SaveChanges();
        }

        private static void SeedResources(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Resources?.Any();
            if (result is true or null) return;
            var path = "Src/Data/DataSeeders/ResourcesData.json";
            var resourcesData = File.ReadAllText(path);
            var resourcesList = JsonSerializer
                .Deserialize<List<Resource>>(resourcesData, options) ??
                throw new Exception("ResourcesData.json is empty");
            resourcesList.ForEach(s =>
            {
                s.Type = s.Type.ToLower();
            });

            context.Resources?.AddRange(resourcesList);
            context.SaveChanges();
        }

    }
}