using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class CategoriaLlamada : BaseEnum<CategoriaLlamada>
    {
        public static readonly CategoriaLlamada Robo = new("Robo", 1,
            new List<string> { "1. Informar robo y solicitar nueva tarjeta de credito \n 2. Informar robo y anular tarjeta de credito" },
            new byte[500],
            new List<OpcionLlamada> { OpcionLlamada.InfRoboNvaTarjeta, OpcionLlamada.InfRoboCancelarTarjeta }
            );
        public static readonly CategoriaLlamada TarjetaBloqueada = new("Tarjeta Bloqueada", 2,
            new List<string> { "1. Desbloquear tarjeta de credito \n 2. Comunicarse con operador" },
            new byte[500],
            new List<OpcionLlamada> { OpcionLlamada.DesbloquearTarjeta, OpcionLlamada.ComunicarseConOperador }
            );

        //Variables
        private int _nroOrden;

        private IList<string> _mensajeOpciones;

        private byte[] _audioMensajeOpciones;

        private IList<OpcionLlamada> _opcionLlamadas;

        public CategoriaLlamada() : base() { }
        public CategoriaLlamada(string descripcion, int nroOrden, IList<string> mensajeOpciones, byte[] audioMensajeOpciones, IList<OpcionLlamada> opcionLlamadas) : base(descripcion)
        {
            _nroOrden = nroOrden;
            _mensajeOpciones = mensajeOpciones;
            _audioMensajeOpciones = audioMensajeOpciones;
            _opcionLlamadas = opcionLlamadas;
        }

        public string getNombreCategoria() => base.getDescripcion();
    }
}
