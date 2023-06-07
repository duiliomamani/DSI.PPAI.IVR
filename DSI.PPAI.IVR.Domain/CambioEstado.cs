namespace DSI.PPAI.IVR.Domain
{
    public class CambioEstado
    {
        private DateTime _fechaHoraInicio;
        private DateTime? _fechaHoraFin;
        private Estado _estado;

        public CambioEstado(DateTime fechaHoraInicio,
            Estado estado)
        {
            _fechaHoraInicio = fechaHoraInicio;
            setEstado(estado);
        }

        private void setEstado(Estado estado)
        {
            _estado = estado;
        }

        public string getNombreEstado() => _estado.getDescripcion();
        public bool esActual() => !_fechaHoraFin.HasValue;
        public void setFechaHoraFin(DateTime fechaFinalizada) => _fechaHoraFin = fechaFinalizada;

        public DateTime getFechaHoraInicio() => _fechaHoraInicio;
    }
}
