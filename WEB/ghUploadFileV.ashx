<%@ WebHandler Language="C#" Class="ghUploadFileV" %>

using System;
using System.Web;
using System.IO;

using DTO;
using CTR;

public class ghUploadFileV : IHttpHandler {
    Log _Log = new Log();
    public void ProcessRequest (HttpContext context) {
      _Log.CustomWriteOnLog("Realizar venta 1", "Entro a metodo ashx ");
        try
        {
            if (context.Request.Files.Count > 0)
            {
                Ctr_Solicitud oBLAPISol = new Ctr_Solicitud();
                _Log.CustomWriteOnLog("Realizar venta 1", "1");
                string ID = context.Request.QueryString["Id"].ToString();

                byte[] fileData = null;
                _Log.CustomWriteOnLog("Realizar venta 1", " 2");
                using (var binaryReader = new BinaryReader(context.Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                }
                _Log.CustomWriteOnLog("Realizar venta 1", "3");
                _Log.CustomWriteOnLog("Realizar venta 1", "Valor de Id a actualizar es" + ID);

                oBLAPISol.RegistrarImgSolicitudP(fileData, int.Parse(ID));
                _Log.CustomWriteOnLog("Realizar venta 1", "4");
            }
            _Log.CustomWriteOnLog("Realizar venta 1", "5");

        }
        catch (Exception ex)
        {
            _Log.CustomWriteOnLog("Realizar venta 1", "Error" + ex.Message);
        }
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}