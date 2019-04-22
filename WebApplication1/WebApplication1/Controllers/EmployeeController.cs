using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private IMemoryCache _cache;

        public EmployeeController(IMemoryCache cache)
        {
            _cache = cache;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var result = new List<Employees>();
            if (!_cache.TryGetValue("Employess", out result))
            {
                if (result == null)
                {
                    result = GetEmployeesDataBase();
                    var cacheEntryOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                    _cache.Set("Employess", result, cacheEntryOption);
                }
            }
            return View(result);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<Employees> GetEmployeesDataBase()
        {
            var data = new List<Employees>(){
                    new Employees { Name = "Matthew", DateOfBirth = DateTime.ParseExact("12-15-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Ruisbroek" },
                    new Employees { Name = "Burton", DateOfBirth = DateTime.ParseExact("11-13-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Cassaro" },
                    new Employees { Name = "Jermaine", DateOfBirth = DateTime.ParseExact("03-11-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Sint-Joost-ten-Node" },
                    new Employees { Name = "Jonah", DateOfBirth = DateTime.ParseExact("03-14-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Kester" },
                    new Employees { Name = "Ashton", DateOfBirth = DateTime.ParseExact("09-24-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Aiello Calabro" },
                    new Employees { Name = "Emery", DateOfBirth = DateTime.ParseExact("07-09-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Grosseto" },
                    new Employees { Name = "Hayes", DateOfBirth = DateTime.ParseExact("07-01-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Sahiwal" },
                    new Employees { Name = "Reese", DateOfBirth = DateTime.ParseExact("12-25-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Valley East" },
                    new Employees { Name = "Arsenio", DateOfBirth = DateTime.ParseExact("03-20-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Quarona" },
                    new Employees { Name = "Graham", DateOfBirth = DateTime.ParseExact("09-20-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Radom" },
                    new Employees { Name = "Andrew", DateOfBirth = DateTime.ParseExact("06-12-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Turrialba" },
                    new Employees { Name = "Hashim", DateOfBirth = DateTime.ParseExact("04-01-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Reading" },
                    new Employees { Name = "Kirk", DateOfBirth = DateTime.ParseExact("08-31-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Owensboro" },
                    new Employees { Name = "Alden", DateOfBirth = DateTime.ParseExact("05-31-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Kearney" },
                    new Employees { Name = "Davis", DateOfBirth = DateTime.ParseExact("01-04-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Bellevue" },
                    new Employees { Name = "Scott", DateOfBirth = DateTime.ParseExact("09-26-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Banff" },
                    new Employees { Name = "Gareth", DateOfBirth = DateTime.ParseExact("07-08-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Independencia" },
                    new Employees { Name = "Yoshio", DateOfBirth = DateTime.ParseExact("05-26-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Pointe-aux-Trembles" },
                    new Employees { Name = "Zeph", DateOfBirth = DateTime.ParseExact("12-07-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Colledimacine" },
                    new Employees { Name = "Ulysses", DateOfBirth = DateTime.ParseExact("11-06-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Roccalumera" },
                    new Employees { Name = "Nolan", DateOfBirth = DateTime.ParseExact("03-31-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Signeulx" },
                    new Employees { Name = "Leonard", DateOfBirth = DateTime.ParseExact("07-06-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Rhemes-Saint-Georges" },
                    new Employees { Name = "Howard", DateOfBirth = DateTime.ParseExact("02-06-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Otegem" },
                    new Employees { Name = "Theodore", DateOfBirth = DateTime.ParseExact("01-22-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Loreto" },
                    new Employees { Name = "Philip", DateOfBirth = DateTime.ParseExact("10-01-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "North Las Vegas" },
                    new Employees { Name = "Nicholas", DateOfBirth = DateTime.ParseExact("08-15-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Erdemli" },
                    new Employees { Name = "Kamal", DateOfBirth = DateTime.ParseExact("10-02-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Blankenfelde-Mahlow" },
                    new Employees { Name = "Wing", DateOfBirth = DateTime.ParseExact("10-11-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Bhatpara" },
                    new Employees { Name = "Nissim", DateOfBirth = DateTime.ParseExact("06-07-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Schaarbeek" },
                    new Employees { Name = "Lawrence", DateOfBirth = DateTime.ParseExact("07-09-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Carbonear" },
                    new Employees { Name = "Aristotle", DateOfBirth = DateTime.ParseExact("08-02-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Chelsea" },
                    new Employees { Name = "Linus", DateOfBirth = DateTime.ParseExact("07-29-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Veenendaal" },
                    new Employees { Name = "Addison", DateOfBirth = DateTime.ParseExact("08-25-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Santa Flavia" },
                    new Employees { Name = "Jelani", DateOfBirth = DateTime.ParseExact("04-17-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "LaSalle" },
                    new Employees { Name = "Tyler", DateOfBirth = DateTime.ParseExact("07-06-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Tejar" },
                    new Employees { Name = "Mark", DateOfBirth = DateTime.ParseExact("10-16-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Parkland County" },
                    new Employees { Name = "Thomas", DateOfBirth = DateTime.ParseExact("02-13-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Millet" },
                    new Employees { Name = "David", DateOfBirth = DateTime.ParseExact("07-11-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Burns Lake" },
                    new Employees { Name = "Lewis", DateOfBirth = DateTime.ParseExact("08-23-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Stintino" },
                    new Employees { Name = "Jordan", DateOfBirth = DateTime.ParseExact("05-22-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Roxburgh" },
                    new Employees { Name = "Asher", DateOfBirth = DateTime.ParseExact("06-22-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Wangaratta" },
                    new Employees { Name = "Rogan", DateOfBirth = DateTime.ParseExact("07-15-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Toronto" },
                    new Employees { Name = "Hasad", DateOfBirth = DateTime.ParseExact("06-09-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Spermalie" },
                    new Employees { Name = "Omar", DateOfBirth = DateTime.ParseExact("07-25-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Pietracatella" },
                    new Employees { Name = "Zeph", DateOfBirth = DateTime.ParseExact("11-07-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Pulle" },
                    new Employees { Name = "Luke", DateOfBirth = DateTime.ParseExact("06-04-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Morrovalle" },
                    new Employees { Name = "Dalton", DateOfBirth = DateTime.ParseExact("05-20-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Port Hope" },
                    new Employees { Name = "Gil", DateOfBirth = DateTime.ParseExact("05-19-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Milazzo" },
                    new Employees { Name = "Gabriel", DateOfBirth = DateTime.ParseExact("04-08-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Yellowhead County" },
                    new Employees { Name = "Rooney", DateOfBirth = DateTime.ParseExact("05-19-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Lago Verde" },
                    new Employees { Name = "Ferdinand", DateOfBirth = DateTime.ParseExact("11-11-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "St. Veit an der Glan" },
                    new Employees { Name = "Clark", DateOfBirth = DateTime.ParseExact("02-10-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "New Sarepta" },
                    new Employees { Name = "Maxwell", DateOfBirth = DateTime.ParseExact("06-14-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Castelló" },
                    new Employees { Name = "Basil", DateOfBirth = DateTime.ParseExact("11-22-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Poppel" },
                    new Employees { Name = "Solomon", DateOfBirth = DateTime.ParseExact("01-28-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Bad Neuenahr-Ahrweiler" },
                    new Employees { Name = "Aquila", DateOfBirth = DateTime.ParseExact("03-23-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Dover" },
                    new Employees { Name = "Baker", DateOfBirth = DateTime.ParseExact("08-16-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Tracadie-Shelia" },
                    new Employees { Name = "Steel", DateOfBirth = DateTime.ParseExact("03-28-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Corroy-le-Ch‰teau" },
                    new Employees { Name = "Elmo", DateOfBirth = DateTime.ParseExact("06-30-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Latur" },
                    new Employees { Name = "Amos", DateOfBirth = DateTime.ParseExact("03-25-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Arvier" },
                    new Employees { Name = "Nicholas", DateOfBirth = DateTime.ParseExact("01-22-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Ronciglione" },
                    new Employees { Name = "Hammett", DateOfBirth = DateTime.ParseExact("10-13-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Gambolò" },
                    new Employees { Name = "Armand", DateOfBirth = DateTime.ParseExact("11-21-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Grimsby" },
                    new Employees { Name = "Salvador", DateOfBirth = DateTime.ParseExact("01-10-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Nice" },
                    new Employees { Name = "Hammett", DateOfBirth = DateTime.ParseExact("05-26-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Wansin" },
                    new Employees { Name = "Quinn", DateOfBirth = DateTime.ParseExact("06-30-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Chesapeake" },
                    new Employees { Name = "Tad", DateOfBirth = DateTime.ParseExact("10-06-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Nocciano" },
                    new Employees { Name = "Henry", DateOfBirth = DateTime.ParseExact("04-20-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Saint-Laurent" },
                    new Employees { Name = "Burton", DateOfBirth = DateTime.ParseExact("05-20-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Maizeret" },
                    new Employees { Name = "Brady", DateOfBirth = DateTime.ParseExact("12-31-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Nurallao" },
                    new Employees { Name = "Brendan", DateOfBirth = DateTime.ParseExact("08-03-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Cuddalore" },
                    new Employees { Name = "Yuli", DateOfBirth = DateTime.ParseExact("10-17-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Ottignies" },
                    new Employees { Name = "Harrison", DateOfBirth = DateTime.ParseExact("06-09-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Slijpe" },
                    new Employees { Name = "Harper", DateOfBirth = DateTime.ParseExact("11-16-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Le Cannet" },
                    new Employees { Name = "Hasad", DateOfBirth = DateTime.ParseExact("01-01-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Quirihue" },
                    new Employees { Name = "Adrian", DateOfBirth = DateTime.ParseExact("06-01-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Huizingen" },
                    new Employees { Name = "Warren", DateOfBirth = DateTime.ParseExact("05-20-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Musson" },
                    new Employees { Name = "Yoshio", DateOfBirth = DateTime.ParseExact("10-21-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Ahmedabad" },
                    new Employees { Name = "Davis", DateOfBirth = DateTime.ParseExact("07-30-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Montebello" },
                    new Employees { Name = "Axel", DateOfBirth = DateTime.ParseExact("10-02-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Ficulle" },
                    new Employees { Name = "Porter", DateOfBirth = DateTime.ParseExact("09-15-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Estación Central" },
                    new Employees { Name = "Lionel", DateOfBirth = DateTime.ParseExact("03-06-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Vihari" },
                    new Employees { Name = "Gary", DateOfBirth = DateTime.ParseExact("04-27-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Pontarlier" },
                    new Employees { Name = "Ciaran", DateOfBirth = DateTime.ParseExact("05-08-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Norman" },
                    new Employees { Name = "Dylan", DateOfBirth = DateTime.ParseExact("07-18-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Cottbus" },
                    new Employees { Name = "Samson", DateOfBirth = DateTime.ParseExact("03-17-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Salzburg" },
                    new Employees { Name = "Norman", DateOfBirth = DateTime.ParseExact("12-30-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Bevagna" },
                    new Employees { Name = "Joshua", DateOfBirth = DateTime.ParseExact("05-11-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Virton" },
                    new Employees { Name = "Ralph", DateOfBirth = DateTime.ParseExact("04-22-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Mesa" },
                    new Employees { Name = "Ferdinand", DateOfBirth = DateTime.ParseExact("12-01-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Baddeck" },
                    new Employees { Name = "Macon", DateOfBirth = DateTime.ParseExact("04-08-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Castelseprio" },
                    new Employees { Name = "Zeph", DateOfBirth = DateTime.ParseExact("05-23-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Arlon" },
                    new Employees { Name = "Sawyer", DateOfBirth = DateTime.ParseExact("01-24-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Recoleta" },
                    new Employees { Name = "Lucas", DateOfBirth = DateTime.ParseExact("08-08-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Sarre" },
                    new Employees { Name = "Colin", DateOfBirth = DateTime.ParseExact("08-06-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Mustafakemalpaşa" },
                    new Employees { Name = "Gil", DateOfBirth = DateTime.ParseExact("01-24-20", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Elversele" },
                    new Employees { Name = "Elijah", DateOfBirth = DateTime.ParseExact("09-21-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Prestatyn" },
                    new Employees { Name = "Zachary", DateOfBirth = DateTime.ParseExact("10-14-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Eugene" },
                    new Employees { Name = "Theodore", DateOfBirth = DateTime.ParseExact("06-29-18", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Montjovet" },
                    new Employees { Name = "Graham", DateOfBirth = DateTime.ParseExact("01-22-19", "MM-dd-yy", CultureInfo.InvariantCulture), Nationaly = "Malgesso" }
                };
            return data;
        }

    }
}