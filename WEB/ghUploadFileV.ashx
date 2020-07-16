<%@ WebHandler Language="C#" Class="ghUploadFileV" %>

using System;
using System.Web;
using System.IO;

using DTO;
using CTR;

public class ghUploadFileV : IHttpHandler {
    Log _Log = new Log();
    public void ProcessRequest (HttpContext context) {
      _Log.CustomWriteOnLog("pedido personalizado", "Entro a metodo ashx ");
        try
        {
            if (context.Request.Files.Count > 0)
            {
                Ctr_Solicitud oBLAPISol = new Ctr_Solicitud();
                _Log.CustomWriteOnLog("pedido personalizado V", "1");
                string ID = context.Request.QueryString["Id"].ToString();

                byte[] fileData = null;
                _Log.CustomWriteOnLog("pedido personalizado V", " 2");
                using (var binaryReader = new BinaryReader(context.Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                }
                _Log.CustomWriteOnLog("pedido personalizado V", "3");
                _Log.CustomWriteOnLog("pedido personalizado V", "Valor de Id a actualizar es" + ID);

                oBLAPISol.RegistrarImgSolicitudP(fileData, int.Parse(ID));
                _Log.CustomWriteOnLog("pedido personalizado V", "4");
            }
            _Log.CustomWriteOnLog("pedido personalizado V", "5");

        }
        catch (Exception ex)
        {
            _Log.CustomWriteOnLog("pedido personalizado", "Error" + ex.Message);
        }
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}