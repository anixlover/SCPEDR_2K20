using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuario
    {
        public string PK_VU_Dni { get; set; }
        public string VU_Nombre { get; set; }
        public string VU_Apellidos { get; set; }
        public int IU_Celular { get; set; }
        public DateTime DTU_FechaNac { get; set; }
        public string VU_Correo { get; set; }
        public string VU_Contraseña { get; set; }
        public int FK_ITU_Cod { get; set; }

        public int error { get; set; }
    }
}
