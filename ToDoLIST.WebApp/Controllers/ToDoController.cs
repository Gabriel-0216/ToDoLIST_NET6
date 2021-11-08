using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ToDoLIST.WebApp.Models;

namespace ToDoLIST.WebApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IHttpClientFactory _client;

        public ToDoController(IHttpClientFactory client)
        {
            _client = client;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var usuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(usuario == null)
            {
                throw new Exception("Usuário não está logado");
            }

            var client = _client.CreateClient("Api");
            var response = await client.GetAsync($"api/ToDo/GetUser?userId={usuario}");

            if (response.IsSuccessStatusCode)
            {
                var list = JsonConvert.DeserializeObject<List<Models.ToDoModel>>(await response.Content.ReadAsStringAsync());
                if (list != null)
                {
                    return View(list);
                }
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.ToDoModel model)
        {
          if(model != null)
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var client = _client.CreateClient("Api");
                var request = await client.PostAsJsonAsync($"api/ToDo/Create/", model);
                if (request.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
