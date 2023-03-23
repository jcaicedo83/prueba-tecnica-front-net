using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prueba_tecnica_front.Models;
using System;
using System.Net.Http;
using System.Text;

namespace prueba_tecnica_front.Controllers
{
    public class UsuarioConsultaController : Controller
    {
        private HttpClient _http;
        private const string url = "localhost/prueba-tecnica-dbo/api/usuarios";
        private string _url;
        public IActionResult Index()
        {
            ViewBag.usuarios = ObtenerUsuarios();
            return View();
        }

        private List<UsuarioModel> ObtenerUsuarios() {
            this._url = $"{_url}/consultar";
            _http = new HttpClient();
            HttpResponseMessage _rsp = _http.GetAsync(url).Result;
            return new List<UsuarioModel>();
        }

        public void Editar(UsuarioModel item)
        {
            this._url = $"{_url}/actualizar";
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _http = new HttpClient();
            var _response = _http.PostAsync(this._url, data);
            var result = _response.Result.Content.ReadAsStringAsync();
        }

        public void Eliminar(UsuarioModel item)
        {

            this._url = $"{_url}/eliminar";
            _http = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var _response = _http.PostAsync(this._url, data);
            var result = _response.Result.Content.ReadAsStringAsync();
        }
    }
}
