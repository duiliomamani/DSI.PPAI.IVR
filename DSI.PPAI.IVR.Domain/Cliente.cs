namespace DSI.PPAI.IVR.Domain
{
    public class Cliente
    {
        private long _dni;
        private string _nombre;
        private string _apellido;
        private string _nroCelular;
        private IList<InformacionCliente> _informacionCliente;
        public Cliente(long dni, string nombre, string apellido, string nroCelular, IList<InformacionCliente> informacionCliente)
        {
            _dni = dni;
            _nombre = nombre;
            _apellido = apellido;
            _nroCelular = nroCelular;
            _informacionCliente = informacionCliente;
        }

        public string getNombre() => $"{_apellido}, {_nombre}";

        public bool validarDatos(Validacion validacion, string datoAValidar)
        {
            foreach (var info in _informacionCliente)
            {
                if (info.esInformacionCorrecta(validacion, datoAValidar))
                    return true;
                continue;
            }
            return false;
        }
    }
}
