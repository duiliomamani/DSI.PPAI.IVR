namespace DSI.PPAI.IVR.Domain
{
    public class RespuestaPosible
    {
        private string _descripcion;
        private string _valor;

        public RespuestaPosible(string descripcion, string valor)
        {
            _descripcion = descripcion;
            _valor = valor;
        }

        public string Descripcion => _descripcion;
        public string Valor => _valor;
    }
}
