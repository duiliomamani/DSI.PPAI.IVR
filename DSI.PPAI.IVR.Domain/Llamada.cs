namespace DSI.PPAI.IVR.Domain
{
    public class Llamada
    {
        private string _descripcionOperador;
        private string _detalleAccionRequerida;
        private double _duracion;
        private bool _encuestaEnviada;
        private string _observacionAuditor;
        private OpcionLlamada? _opcionSeleccionada;
        private SubOpcionLlamada? _subOpcionSeleccionada;
        private IList<CambioEstado> _cambioEstado;
        private IList<RespuestaDeCliente>? _respuestaDeCliente;
        private Cliente _cliente;
        private Usuario? _auditor;
        private Usuario? _operador;

        public Llamada(Cliente cliente, Estado estado)
        {
            _cliente = cliente;
            crearNvoCambioEstado(estado);
        }

        public void crearNvoCambioEstado(Estado estado)
        {
            _cambioEstado ??= new List<CambioEstado>();

            if (_cambioEstado.Any())
            {
                var estadoActual = getEstadoActual();

                estadoActual.setFechaHoraFin();
            }

            _cambioEstado.Add(new CambioEstado(fechaHoraInicio: DateTime.Now, estado: estado));
        }

        public string getDatosLlamada()
        {
            return _cliente.getNombre();
        }

        public CambioEstado getEstadoActual() {
            return _cambioEstado.Where(x => x.esActual()).First();
        }
    }
}
