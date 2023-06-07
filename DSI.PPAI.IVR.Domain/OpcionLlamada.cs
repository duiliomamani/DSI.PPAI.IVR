using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class OpcionLlamada : BaseEnum<OpcionLlamada>
    {
        public static readonly OpcionLlamada InfRoboNvaTarjeta = new("Informar robo y solicitar nueva tarjeta de credito", 1, null, null,
            new List<SubOpcionLlamada> { SubOpcionLlamada.DatosTarjeta, SubOpcionLlamada.SinDatosTarjeta, SubOpcionLlamada.ComunicarseConOperador, SubOpcionLlamada.FinalizarLlamada }
            , null);
        public static readonly OpcionLlamada InfRoboCancelarTarjeta = new("Informar robo y anular tarjeta de credito", 2, null, null, null, new List<Validacion> { Validacion.CodPostal });
        public static readonly OpcionLlamada DesbloquearTarjeta = new("Desbloquear Tarjeta", 1, null, null, null, new List<Validacion> { Validacion.FechaNacimiento });
        public static readonly OpcionLlamada ComunicarseConOperador = new("Comunicarse con Operador", 2, null, null, null, new List<Validacion> { Validacion.FechaNacimiento, Validacion.CodPostal });
        public static readonly OpcionLlamada FinalizarLlamada = new("Finalizar llamada", 4, null, null, null, null);

        //Variables
        private int _nroOrden;
        private IList<string>? _mensajeSubOpciones;
        private IList<byte[]>? _audioMensajeSubOpciones;
        private IList<SubOpcionLlamada>? _subOpcionLlamadas;
        private IList<Validacion>? _validacionesRequeridas;

        public OpcionLlamada() : base() { }
        public OpcionLlamada(string descripcion, int nroOrden, IList<string> mensajeSubOpciones, IList<byte[]> audioMensajeSubOpciones, IList<SubOpcionLlamada>? subOpcionLlamadas, IList<Validacion>? validacionesRequeridas) : base(descripcion)
        {
            _nroOrden = nroOrden;
            _mensajeSubOpciones = mensajeSubOpciones;
            _audioMensajeSubOpciones = audioMensajeSubOpciones;
            _subOpcionLlamadas = subOpcionLlamadas;
            _validacionesRequeridas = validacionesRequeridas;
        }

        public string getNombreOpcionLlamada() => base.getDescripcion();
        public bool esComunicarConOperador()
        {
            return Equals(OpcionLlamada.ComunicarseConOperador);
        }
    }
}
