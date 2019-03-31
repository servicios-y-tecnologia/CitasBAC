using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace appcitas.Services
{
    public static class BACWS
    {
        #region Public Methods

        public static async Task<HistorialObject> GetAtrasosDeHistorial(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
       // public static HistorialObject GetAtrasosDeHistorial(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
        {
             List<ObjetoDevueltoHistorial> _BACObjectA = await BACWS.GetHistorial(id_cli, type_cli, user, app, referencia1, referencia2, token);
          //  List<ObjetoDevueltoHistorial> _BACObjectA = /*await*/ BACWS.GetHistorial(id_cli, type_cli, user, app, referencia1, referencia2, token);
            HistorialObject objetoHistorial = new HistorialObject();
            foreach (ObjetoDevueltoHistorial _BACObject in _BACObjectA)
            {
                for (int i = 0; i < _BACObject.historia.Length; i++)
                {
                    if (_BACObject.historia[i] == 2)
                        objetoHistorial.atrasosDe30 += 1;
                    if (_BACObject.historia[i] == 3)
                        objetoHistorial.atrasosDe60 += 1;
                    if (_BACObject.historia[i] == 4)
                        objetoHistorial.atrasosDe90 += 1;
                    if (_BACObject.historia[i] == 5)
                        objetoHistorial.atrasosDe120 += 1;
                    if (_BACObject.historia[i] == 6)
                        objetoHistorial.atrasosDe150 += 1;
                    if (_BACObject.historia[i] == 7)
                        objetoHistorial.atrasosDe180 += 1;
                    if (_BACObject.historia[i] == 8)
                        objetoHistorial.atrasosDe181_365 += 1;
                    if (_BACObject.historia[i] == 9)
                        objetoHistorial.atrasosMayoresA365 += 1;
                }
            }
            return objetoHistorial;
        }

        public static async Task<BACObject> GetGeneralByTC(string tarjeta)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings["BACAPIBaseAddress"].ToString()) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(WebConfigurationManager.AppSettings["GetGeneralByTC"].ToString() + tarjeta));

            BACObject _BACObject = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                _BACObject = JsonConvert.DeserializeObject<BACObject>(responseData);

                if (_BACObject.dataList.Count > 0)
                {
                    Producto _producto = await GetDWBIProducto(_BACObject.dataList[0].Cuenta);
                    if (_producto != null)
                    {
                        foreach (var item in _BACObject.dataList)
                        {
                            item.Triad = _producto.ultimo.ToString();
                            item.TriadPenultimo = _producto.penultimo.ToString();
                            item.TriadPromedio = _producto.promedio.ToString();
                            item.RACV = _producto.racv.ToString();
                        }
                    }
                }
            }

            return _BACObject;
        }

        public static async Task<List<ObjetoDevueltoHistorial>> GetHistorial(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
        //public static List<ObjetoDevueltoHistorial> GetHistorial(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
        {
            ObjetoDevueltoHistorial _BACObject = null;
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://localhost/BACScoringWS") };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //string uriString = $"http://localhost/BACScoringWS/api/ScoringService/GetHistorial?id_cli={id_cli}&type_cli={type_cli}&user={user}&app={app}&referencia1={referencia1}&referencia2={referencia2}&token={token}";
                string uriString = $"http://localhost:1734/api/ScoringService/GetHistorial?id_cli={id_cli}&type_cli={type_cli}&user={user}&app={app}&referencia1={referencia1}&referencia2={referencia2}&token={token}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri(uriString));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    _BACObject = JsonConvert.DeserializeObject<ObjetoDevueltoHistorial>(responseData);
                }

                var x = new List<ObjetoDevueltoHistorial>();
                x.Add(_BACObject);
                return x;
            }
            else
            {
                ///////////////////////////////////
                //DESCOMENTAR ESTO PARA PUBLICAR//
                /////////////////////////////////

                var client = new WSAPCBot.WSAPCbotSoapClient();
                var response = client.BAC_APC_Historia(id_cli, type_cli, user, app, referencia1, referencia2, token);
                try
                {
                    List<ObjetoDevueltoHistorial> _BACObjectA = JsonConvert.DeserializeObject<List<ObjetoDevueltoHistorial>>(response); //new List<ObjetoDevueltoHistorial>(a.Count);
                                                                                                                                        //ObjetoDevueltoHistorial _BACObject = JsonConvert.DeserializeObject<ObjetoDevueltoHistorial>(response);
                    return _BACObjectA;
                }
                catch (Exception ex)
                {
                    // si da error en la deserializacioin entenderia que no encontro a la persona en el buro.
                    return new List<ObjetoDevueltoHistorial>();
                }
            }
        }

        public static async Task<BACObject> GetInfoClientByCif(string cuenta)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings["BACAPIBaseAddress"].ToString()) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(WebConfigurationManager.AppSettings["GetInfoClientByCif"].ToString() + cuenta));

            BACObject _BACObject = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                _BACObject = JsonConvert.DeserializeObject<BACObject>(responseData);
            }

            return _BACObject;
        }

        public static async Task<ObjetoDevueltoScore> GetScore(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
      //  public static ObjetoDevueltoScore GetScore(string id_cli, int type_cli, string user, int app, int referencia1, string referencia2, string token)
        {
            ObjetoDevueltoScore _BACObject = null;
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://localhost/BACScoringWS") };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //string uriString = $"http://localhost/BACScoringWS/api/ScoringService/GetScore?id_cli={id_cli}&type_cli={type_cli}&user={user}&app={app}&referencia1={referencia1}&referencia2={referencia2}&token={token}";
                 string uriString = $"http://localhost:1734/api/ScoringService/GetScore?id_cli={id_cli}&type_cli={type_cli}&user={user}&app={app}&referencia1={referencia1}&referencia2={referencia2}&token={token}";
                HttpResponseMessage httpResponseMessage = await  httpClient.GetAsync(new Uri(uriString));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    _BACObject = JsonConvert.DeserializeObject<ObjetoDevueltoScore>(responseData);
                }
            }
            else
            {
                ///////////////////////////////////
                //DESCOMENTAR ESTO PARA PUBLICAR//
                /////////////////////////////////
                                 
                var client = new WSAPCBot.WSAPCbotSoapClient();
                var response = client.BAC_APC_ScorePi(id_cli, type_cli, user, app, referencia1, referencia2, token);
                _BACObject = JsonConvert.DeserializeObject<ObjetoDevueltoScore>(response);
            }

            return _BACObject;
        }

        public static async Task<BACObject> GetValuesByCif(string cuenta)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings["BACAPIBaseAddress"].ToString()) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    

            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(WebConfigurationManager.AppSettings["GetValuesByCif"].ToString() + cuenta));
            BACObject _BACObject = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                _BACObject = JsonConvert.DeserializeObject<BACObject>(responseData);
            }

            return _BACObject;
        }



        public static async Task<Producto> GetDWBIProducto(string pcuenta)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings["BACAPIBaseAddress"].ToString()) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string usuario = WebConfigurationManager.AppSettings["userDWBIProducto"].ToString();
            string password = WebConfigurationManager.AppSettings["passwordDWBIProducto"].ToString();

            //////////////////////////////////////////////////////////////
            client.DefaultRequestHeaders.Add("usu", usuario);
            client.DefaultRequestHeaders.Add("pass", password);
            //////////////////////////////////////////////////////////////
            //var byteArray = Encoding.ASCII.GetBytes(string.Format("usu:{0}, pass:{1}", usuario, password));
            //var byteArray = Encoding.ASCII.GetBytes(usuario+":"+password);
            //var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //client.DefaultRequestHeaders.Authorization = header;
            //////////////////////////////////////////////////////////////

            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(WebConfigurationManager.AppSettings["GetDWBIProducto"].ToString() + pcuenta));

            List<Producto> _BACObject = null;
            Producto valores = new Producto();

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    _BACObject = JsonConvert.DeserializeObject<List<Producto>>(responseData);
                }
                catch(Exception ex)
                {
                     return (new Producto { cuenta= pcuenta, fecha=DateTime.Now, racv=0,   penultimo = 0, ultimo = 0, promedio = 0 ,tipo=ex.Message });
                  //  string msg = ex.Message;
                }
                valores.racv = (_BACObject).Where(X => X.tipo == "RACV").Select(x => x.valor).FirstOrDefault();

                List<Producto> _cantidadtriad = (from c in _BACObject
                           .Where(q=>q.tipo=="TRIAD")
                           select c).ToList();

                if (_cantidadtriad.Count > 0)
                {
                    valores.promedio = (_cantidadtriad).Sum(x => x.valor) / _cantidadtriad.Count;
                    valores.ultimo = (_cantidadtriad).OrderByDescending(x => x.fecha).Select(x => x.valor).FirstOrDefault();

                    if (_cantidadtriad.Count > 1)
                    {
                        Producto _penultimo = (_cantidadtriad).OrderByDescending(x => x.fecha).FirstOrDefault();
                        bool removio = _cantidadtriad.Remove(_penultimo);
                        if (removio)
                        {
                            List<Producto> _penultimolist = (_cantidadtriad).OrderByDescending(x => x.fecha).ToList();
                            valores.penultimo = _penultimolist.FirstOrDefault().valor;
                        }
                    }
                    else
                        valores.penultimo = 0;

                }
                else
                {
                    valores.promedio = 0;
                    valores.ultimo = 0;
                    valores.penultimo = 0;

                }
            }

            return valores;
        }


        #endregion Public Methods
    }

    public class HistorialObject
    {
        #region Public Constructors

        public HistorialObject()
        {
            atrasosDe30 = 0; atrasosDe60 = 0; atrasosDe90 = 0; atrasosDe120 = 0; atrasosDe150 = 0; atrasosDe180 = 0;
        }

        #endregion Public Constructors



        #region Public Properties

        public int atrasosDe120 { get; set; }
        public int atrasosDe150 { get; set; }
        public int atrasosDe180 { get; set; }
        public int atrasosDe181_365 { get; set; }
        public int atrasosDe30 { get; set; }
        public int atrasosDe60 { get; set; }
        public int atrasosDe90 { get; set; }
        public int atrasosMayoresA365 { get; set; }

        #endregion Public Properties
    }
}