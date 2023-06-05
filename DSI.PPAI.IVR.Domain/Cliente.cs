namespace DSI.PPAI.IVR.Domain
{
    public class Cliente
    {
        private long _dni;
        private string _nombre;
        private string _apellido;
        private string _nroCelular;
        private IList<InformacionCliente> _info;
        public Cliente(long dni, string nombre,string apellido, string nroCelular, IList<InformacionCliente> info)
        {
            _dni = dni;
            _nombre = nombre;
            _apellido = apellido;
            _nroCelular = nroCelular;
            _info = info;
        }

        public string getNombre() => $"{_apellido}, {_nombre}";
    }
}
