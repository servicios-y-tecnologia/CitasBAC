using System;
using System.Threading.Tasks;

namespace appcitas.Services
{
    public static class EvaluarBuro
    {
        #region Public Methods

        public static async Task<bool> EsBuro(string Clasificacion, decimal Limite, string id_cli, int type_cli, string user,
       // public static bool EsBuro(string Clasificacion, decimal Limite, string id_cli, int type_cli, string user,
            int app, int referencia1, string referencia2, string token)
        {
            try
            {
                if (Clasificacion == "8" || Clasificacion == "H")
                    return true;

                if (Clasificacion == "7" || Clasificacion == "G")
                    if (Limite <= 1500)
                        return true;

                if (Clasificacion == "5" || Clasificacion == "6" || Clasificacion == "7"
                    || Clasificacion == "E" || Clasificacion == "F" || Clasificacion == "G")
                {
                    var bacScoreObject = await BACWS.GetScore(id_cli, type_cli, user, app, referencia1, referencia2, token);
                    if (bacScoreObject != null)
                        if (string.IsNullOrEmpty(bacScoreObject.Error))
                            if (Convert.ToDecimal(bacScoreObject.score) <= 410)
                                return true;
                }

                if (Clasificacion == "6" || Clasificacion == "7" || Clasificacion == "F" || Clasificacion == "G")
                {
                    var atrasosHistorial = await BACWS.GetAtrasosDeHistorial(id_cli, type_cli, user, app, referencia1, referencia2, token);
                    if (atrasosHistorial.atrasosDe60 >= 2)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        #endregion Public Methods
    }
}