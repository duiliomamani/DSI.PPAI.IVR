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
            crearNvoCambioEstado(estado, DateTime.Now);
        }

        public void crearNvoCambioEstado(Estado estado, DateTime fechaActual)
        {
            _cambioEstado ??= new List<CambioEstado>();

            if (_cambioEstado.Any())
            {
                var estadoActual = getEstadoActual();

                estadoActual.setFechaHoraFin(fechaActual);
            }

            _cambioEstado.Add(new CambioEstado(fechaHoraInicio: fechaActual, estado: estado));
        }

        public string getDatosLlamada()
        {
            return _cliente.getNombre();
        }

        public CambioEstado getEstadoActual() {
            return _cambioEstado.Where(x => x.esActual()).First();
        }

        public bool validarDatos(Validacion validacion, string datoAValidar)
        {
            return _cliente.validarDatos(validacion, datoAValidar);
        }

        private void setDescripcionRtaOperador(string descripcionOperador) => _descripcionOperador = descripcionOperador;

        private void setSubOpcionLlamada(SubOpcionLlamada subOpcionLlamada) => _subOpcionSeleccionada = subOpcionLlamada;
        private void setOpcionLlamada(OpcionLlamada opcionLlamada) => _opcionSeleccionada = opcionLlamada;

        //Seteo la duracion dependiendo el minimo y maximo de las fechas inicio
        private void setDuracion()
        {
            var fechaInicio = _cambioEstado.Min(x => x.getFechaHoraInicio());

            var fechaFin = _cambioEstado.Max(x => x.getFechaHoraInicio());

            _duracion = (fechaInicio - fechaFin).TotalMinutes;
        }


        //Realizo las acciones finalizar llamada
        public void finalizarLlamada(DateTime fechaActual, 
            SubOpcionLlamada subOpcionLlamada,
            OpcionLlamada opcionLlamada, 
            string descripcionOperador,
            Estado estadoFinalizado)
        {
            setDescripcionRtaOperador(descripcionOperador);

            setSubOpcionLlamada(subOpcionLlamada);

            setOpcionLlamada(opcionLlamada);

            crearNvoCambioEstado(estadoFinalizado, fechaActual);

            setDuracion();
        }
    }
}
