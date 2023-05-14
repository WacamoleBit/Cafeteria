using Cafe.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Controllers
{
    public class BebidaController : Controller
    {
        // GET: Bebida
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44375/api/");

                var getTask = client.GetAsync("verBebidas");
                getTask.Wait();

                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string resultJSON = await result.Content.ReadAsStringAsync();
                    var bebidaResult = JsonConvert.DeserializeObject<List<BebidaViewModel>>(resultJSON);

                    return View(bebidaResult);
                }
            }
            return View();
        }

        // GET: Bebida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bebida/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bebida/Create
        [HttpPost]
        public ActionResult Create(BebidaViewModel bebidaViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44375/api/");

                var postTask = client.PostAsJsonAsync("registrarBebida", bebidaViewModel);

                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();

                    return RedirectToAction("Index", "Bebida");
                }
            }

            return View();
        }

        // GET: Bebida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bebida/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bebida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bebida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
