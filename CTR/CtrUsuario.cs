using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Text.RegularExpressions;

namespace CTR
{
    public class CtrUsuario
    {
        DaoUsuario objDaoUsuario;
        public CtrUsuario()
        {
            objDaoUsuario = new DaoUsuario();
        }
        public void RegistrarUsuario(DtoUsuario Objusuario)
        {
            bool correcto = true;
            string UsuarioNom = "";
            try
            {
                UsuarioNom = Objusuario.VU_Nombre;
                string g = UsuarioNom.Trim();
                for (int i = 0; i < g.Length; i++)
                {
                    correcto = char.IsLetter(g[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                Objusuario.error = 1;
                return;
            }
            string UsuarioApe = "";
            try
            {
                UsuarioApe = Objusuario.VU_Apellidos;
                string g2 = UsuarioApe.Trim();
                for (int i = 0; i < g2.Length; i++)
                {
                    correcto = char.IsLetter(g2[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                Objusuario.error = 2;
                return;
            }
            correcto = Regex.IsMatch(Objusuario.VU_Correo, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            if (!correcto)
            {
                Objusuario.error = 3;
                return;
            }
            string ClienteContra = Objusuario.VU_Contraseña;
            string g3 = ClienteContra.Trim();
            correcto = g3.Length > 5;
            if (!correcto)
            {
                Objusuario.error = 4;
                return;
            }
            DtoUsuario objuser2 = new DtoUsuario();
            objuser2.PK_VU_Dni = Objusuario.PK_VU_Dni;
            correcto = !objDaoUsuario.SelectUsuario(objuser2);
            if (!correcto)
            {
                Objusuario.error = 5;
                return;
            }
            DtoUsuario objuser3 = new DtoUsuario();
            objuser3.IU_Celular = Objusuario.IU_Celular;
            correcto = !objDaoUsuario.SelectUsuarioXcelular(objuser3);
            if (!correcto)
            {
                Objusuario.error = 6;
                return;
            }
            DtoUsuario objuser4 = new DtoUsuario();
            objuser4.VU_Correo = Objusuario.VU_Correo;
            correcto = !objDaoUsuario.SelectUsuarioXcorreo(objuser4);
            if (!correcto)
            {
                Objusuario.error = 7;
                return;
            }
            DtoUsuario objuser5 = new DtoUsuario();
            objuser5.DTU_FechaNac = Objusuario.DTU_FechaNac;
            DateTime nac = objuser5.DTU_FechaNac;
            DateTime hoy = DateTime.Today.Date;
            correcto = objuser5.IU_Celular>0;
            if (nac.AddYears(18)>hoy)
            {
                Objusuario.error = 8;
                return;
            }
            Objusuario.error = 77;
            objDaoUsuario.InsertarCliente(Objusuario);            
        }


        public DtoUsuario Login(DtoUsuario dtoUsuario)
        {

            int persona_id = objDaoUsuario.validacionLogin(dtoUsuario.PK_VU_Dni, dtoUsuario.VU_Contraseña);

            if (persona_id == 0)
            {
                throw new Exception("Usuario y/o contrase&ntilde;a incorrecta(s)");
            }
            else
            {
                return objDaoUsuario.datosUsuario(dtoUsuario.PK_VU_Dni);
            }
        }

        public void EnviarCorreoVendedor(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.EnviarCorreoaVendedor(dtoUsuario);
        }
        //public void EnviarBoletaxCorreo(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        //{
        //    objDaoUsuario.EnviarBoletaxCorreo( objmoldura, objtipo);
        //}

        
        public void CambiarContrasenia(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.CambiarContra(dtoUsuario);
        }

        public void TraePass(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.TraeContra(dtoUsuario);
        }

        public void TraeData(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.TraeData(dtoUsuario);
        }

        public bool ExisteUsuario(DtoUsuario objuser)
        {
           return objDaoUsuario.SelectUsuario(objuser);
        }
    }
}
