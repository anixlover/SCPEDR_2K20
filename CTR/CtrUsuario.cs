﻿using System;
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
            objuser3.VU_Correo = Objusuario.VU_Correo;
            correcto = !objDaoUsuario.SelectUsuarioXcorreo(objuser4);
            if (!correcto)
            {
                Objusuario.error = 7;
                return;
            }
            objDaoUsuario.InsertarCliente(Objusuario);
            Objusuario.error = 77;
        }
    }
}
