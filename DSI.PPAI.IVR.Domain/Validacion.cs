using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class Validacion : BaseEnum<Validacion>
    {
        public static readonly Validacion FechaNacimiento = new("Fecha de Nacimiento", 1, new byte[500],
            new List<OpcionValidacion> { OpcionValidacion.Opcion1, OpcionValidacion.Opcion2, OpcionValidacion.Opcion3 }
            , TipoInformacion.FechaNacimiento);
        public static readonly Validacion CodPostal = new("Codigo Postal", 2, new byte[500],
            new List<OpcionValidacion> { OpcionValidacion.Opcion5, OpcionValidacion.Opcion4, OpcionValidacion.Opcion6 },
            TipoInformacion.CodPostal);
        public static readonly Validacion CantHijos = new("Cantidad de Hijos", 3, new byte[500],
            new List<OpcionValidacion> { OpcionValidacion.Opcion1, OpcionValidacion.Opcion2, OpcionValidacion.Opcion3 }, 
            TipoInformacion.CantHijos);

        //Variables
        private int _nroOrden;
        private byte[] _audioMensajeValidacion;
        private IList<OpcionValidacion> _opcionesValidacion;
        private TipoInformacion _tipoInformacion;

        public Validacion() : base() { }
        public Validacion(string descripcion, int nroOrden, byte[] audioMensajeValidacion,
            IList<OpcionValidacion> opcionesValidacion, TipoInformacion tipoInformacion) : base(descripcion)
        {
            _nroOrden = nroOrden;
            _audioMensajeValidacion = audioMensajeValidacion;
            _opcionesValidacion = opcionesValidacion;
            _tipoInformacion = tipoInformacion;
        }

        public string getDatosValidacion() => $"{_nroOrden}.{getDescripcion()}";
    }
}
