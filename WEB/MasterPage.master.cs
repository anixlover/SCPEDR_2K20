using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Log Log = new Log();
	protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
            Log.WriteOnLog("-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
            Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                int perfil = int.Parse(Session["id_perfil"].ToString());
        }
        catch (Exception)
        {

            throw;
        }

	}
}
