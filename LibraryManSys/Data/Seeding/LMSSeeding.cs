using LibraryManSys.Contexts;
using LibraryManSys.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManSys.Data.Seeding
{
    internal static class LMSSeeding
    {
        public static void Seed(LMSContext context)
        {
            if (!context.Authors.Any())
            {
                var AuthorData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\LibraryManSys\\LibraryManSys\\Data\\Seeding\\Authors.json");
                var Authors = JsonSerializer.Deserialize<List<Author>>(AuthorData);

                foreach (var item in Authors)
                {
                    context.Authors.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var CategoryData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\LibraryManSys\\LibraryManSys\\Data\\Seeding\\Categories.json");
                var Categories = JsonSerializer.Deserialize<List<Category>>(CategoryData);

                foreach (var item in Categories)
                {
                    context.Categories.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var BookData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\LibraryManSys\\LibraryManSys\\Data\\Seeding\\Books.json");
                var Books = JsonSerializer.Deserialize<List<Book>>(BookData);

                foreach (var item in Books)
                {
                    context.Books.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Members.Any())
            {
                var MemberData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\LibraryManSys\\LibraryManSys\\Data\\Seeding\\Members.json");
                var Members = JsonSerializer.Deserialize<List<Member>>(MemberData);

                foreach (var item in Members)
                {
                    context.Members.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
