using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class SubOpcionLlamada : BaseEnum<SubOpcionLlamada>
    {
        public static readonly SubOpcionLlamada DatosTarjeta = new("Datos tarjeta", 1, new List<Validacion> { Validacion.CantHijos });
        public static readonly SubOpcionLlamada SinDatosTarjeta = new("Sin datos tarjeta", 2, new List<Validacion> { Validacion.FechaNacimiento });
        public static readonly SubOpcionLlamada ComunicarseConOperador = new("Comunicarse con operador", 3, new List<Validacion> { Validacion.FechaNacimiento, Validacion.CodPostal });
        public static readonly SubOpcionLlamada FinalizarLlamada = new("Finalizar llamada", 4, null);

        //Variables
        private int _nroOrden;
        private IList<Validacion> _validacionesRequeridas;

        public SubOpcionLlamada() : base() { }
        public SubOpcionLlamada(string descripcion, int nroOrden, IList<Validacion> validaciones) : base(descripcion)
        {
            _nroOrden = nroOrden;
            _validacionesRequeridas = validaciones;
        }

        public string getNombreSubopcion() => base.getDescripcion();

        public bool esComunicarConOperador()
        {
            return Equals(SubOpcionLlamada.ComunicarseConOperador);
        }

        public IList<Validacion> getValidacionesSubOpcion() => _validacionesRequeridas;
    }
}
