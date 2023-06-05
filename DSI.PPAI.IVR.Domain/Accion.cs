namespace DSI.PPAI.IVR.Domain
{
    public class Accion
    {
        //Variables
        private string _descripcion;

        public Accion(string descripcion)
        {
            _descripcion = descripcion;
        }

        //Methods
        public string Descripcion => _descripcion;
    }
}
