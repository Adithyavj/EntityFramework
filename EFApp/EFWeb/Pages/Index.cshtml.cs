using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        // Calling DB using object of PeopleContext
        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            LoadSampleData();

            // query data from 3 tables
            var people = _db.people
                .Include(a => a.Addresses)
                .Include(e => e.EmailAddress)
                //.Where(x => ApprovedAge(x.Age)) // won't work in case of EF
                .Where(x => x.Age >= 18 && x.Age <= 65) // will work
                .ToList();
        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age <= 65);
        }

        // Import some sample data
        private void LoadSampleData()
        {
            // https://www.json-generator.com/ - Generate Random JSON Data
            // If people table's count is 0
            if (_db.people.Count() == 0)
            {
                // Read all values from .json file to a string variable
                string file = System.IO.File.ReadAllText("generated.json");
                // Deserialize the Json file to Person Model and take it into a var
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                // Insert Query
                _db.AddRange(people);
                _db.SaveChanges();
            }
        }
    }
}
