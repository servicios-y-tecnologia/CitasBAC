using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BACScoringWS.Controllers
{
    public class ScoringServiceController : ApiController
    {
        // GET api/ScoringService/GetScore/0301-111-118/1/5/0/0/Ci18a
        public IHttpActionResult GetScore(string id_cli, string type_cli, string user, string app, string referencia1, string referencia2, string token)
        {
            Random rnd = new Random();
            var scoreRnd = rnd.Next(100, 1000);

            return Ok(new ObjetoDevueltoScore
            {
                ident_clie = id_cli,
                id_tipo_identificacion = type_cli,
                estatus = "4",
                score = scoreRnd.ToString(),
                pi = "11.50"
            });
        }

        // GET api/ScoringService/GetHistorial/0301-111-118/1/5/0/0/Ci18a
        public IHttpActionResult GetHistorial(string id_cli, string type_cli, string user, string app, string referencia1, string referencia2, string token)
        {
            return Ok(new ObjetoDevueltoHistorial
            {
                ident_clie = id_cli,
                id_tipo_identificacion = type_cli,
                estatus = "4",
                num_refer = "2014497378",
                historia = "111111111111111111111111"
            });
        }
    }

    public class ObjetoDevueltoScore
    {
        public string ident_clie { get; set; }
        public string id_tipo_identificacion { get; set; }
        public string estatus { get; set; }
        public string score { get; set; }
        public string pi { get; set; }
        public string Error { get; set; }
    }

    public class ObjetoDevueltoHistorial
    {
        public string ident_clie { get; set; }
        public string id_tipo_identificacion { get; set; }
        public string estatus { get; set; }
        public string num_refer { get; set; }
        public string historia { get; set; }
        public string Error { get; set; }
    }
}