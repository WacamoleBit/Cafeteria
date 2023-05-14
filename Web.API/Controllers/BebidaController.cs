using Cafe.Model;
using Cafe.Model.Cafes;
using Cafe.Persistence.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Web.API.Controllers
{
    public class BebidaController : ApiController
    {
        BebidaManager _bebidaManager;

        public BebidaController()
        {
            _bebidaManager = new BebidaManager();
        }

        [HttpPost]
        [Route("api/registrarBebida")]
        public HttpResponseMessage RegistrarBebida(BebidaResponse bebidaResponse)
        {
            if (bebidaResponse != null)
            {
                try
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK);
                    var bebida = new Bebida()
                    {
                        Id = Guid.NewGuid(),
                        Nombre = bebidaResponse.Nombre,
                        Descripcion = bebidaResponse.Descripcion,
                        Precio = bebidaResponse.Precio
                    };

                    var resultManager = _bebidaManager.CrearBebida(bebida);

                    result.Content = new StringContent(JsonConvert.SerializeObject(resultManager));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    return result;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("api/verBebidas")]
        public HttpResponseMessage VerBebidas()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);

                var resultManager = _bebidaManager.VerBebidas();
                result.Content = new StringContent(JsonConvert.SerializeObject(resultManager));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}