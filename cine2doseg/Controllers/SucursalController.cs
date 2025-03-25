using System.Web.Http; // ESTA es la correcta para Web API
using cine2doseg.Models;
using Newtonsoft.Json.Linq;
using System;


namespace cine2doseg.Controllers
{
    [RoutePrefix("cine/sucursal")]
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("vwrptsucursales")]
        public clsApiStatus vwRptSucursales()
        {
            clsApiStatus api = new clsApiStatus();
            try
            {
                clsSucursalDAO dao = new clsSucursalDAO();
                var ds = dao.vwRptSucursales();
                JArray datos = JArray.FromObject(ds.Tables[0]);
                api.statusExec = true;
                api.msg = "Consulta exitosa";
                api.ban = 0;
                api.datos = new JObject { ["sucursales"] = datos };
            }
            catch (Exception ex)
            {
                api.statusExec = false;
                api.msg = "Error: " + ex.Message;
                api.ban = -1;
                api.datos = null;
            }
            return api;
        }

        [HttpPost]
        [Route("spinssucursales")]
        public clsApiStatus spInsSucursales([FromBody] clsSucursal suc)
        {
            clsApiStatus api = new clsApiStatus();
            try
            {
                clsSucursalDAO dao = new clsSucursalDAO();
                int bandera = dao.spInsSucursales(suc.nombre, suc.direccion, suc.url, suc.logo);
                api.statusExec = (bandera == 0);
                api.msg = bandera == 0 ? "Insertado correctamente" :
                          bandera == 1 ? "Nombre ya existe" :
                          "URL ya existe";
                api.ban = bandera;
                api.datos = null;
            }
            catch (Exception ex)
            {
                api.statusExec = false;
                api.msg = "Error: " + ex.Message;
                api.ban = -1;
                api.datos = null;
            }
            return api;
        }
    }
}
