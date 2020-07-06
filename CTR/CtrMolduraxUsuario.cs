using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;
namespace CTR
{
    public class CtrMolduraxUsuario
    {
        DaoMolduraxUsuario  objDaoSXM;

        public CtrMolduraxUsuario()
        {
        objDaoSXM = new DaoMolduraxUsuario();
        }

        public void registrarNuevaMoldura(DtoMolduraxUsuario objDtoMolduraxUsuario)
        {
            objDaoSXM.InsertarMolduraxUsuario(objDtoMolduraxUsuario);
        }
        public DataTable listarMoldurasxusuario(DtoMolduraxUsuario objdtoMolduraxUsuario)
        {
            return objDaoSXM.ListarMXU(objdtoMolduraxUsuario);
        }
        public void obtenerMoldura(DtoMolduraxUsuario objdtoMolduraxUsuario,DtoMoldura objm,DtoTipoMoldura tm)
        {
            objDaoSXM.ObtenerMXU(objm, objdtoMolduraxUsuario, tm);
        }
        public void eliminarMXU(DtoMolduraxUsuario objdtoMolduraxUsuario)
        {
            objDaoSXM.eliminarMXU(objdtoMolduraxUsuario);
        }
        public void actualizarMXU(DtoMolduraxUsuario objdtoMolduraxUsuario)
        {
            objDaoSXM.actualizarMXU(objdtoMolduraxUsuario);
        }
    }
}
