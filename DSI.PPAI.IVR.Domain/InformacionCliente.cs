namespace DSI.PPAI.IVR.Domain
{
    public class InformacionCliente
    {
        private string _datoAValidar;
        private OpcionValidacion? _opcionCorrecta;
        private TipoInformacion _tipoInformacion;
        private Validacion _validacion;
        public InformacionCliente(string datoAValidar, OpcionValidacion? opcionCorrecta, TipoInformacion tipoInformacion,
            Validacion validacion)
        {
            _datoAValidar = datoAValidar;
            _opcionCorrecta = opcionCorrecta;
            _tipoInformacion = tipoInformacion;
            _validacion = validacion;
        }
        public bool esInformacionCorrecta(Validacion validacion, string datoAValidar) { 
            if(esValidacion(validacion)){
                return datoAValidar.Equals(_datoAValidar);
            }
            return false;
        }
        private bool esValidacion(Validacion validacion) => _validacion.Equals(validacion);
    }
}
