namespace DSI.PPAI.IVR.Domain
{
    public class Pregunta
    {
        private string _descripcion;
        private IList<RespuestaPosible> _repuestaPosibles;

        public Pregunta(string descripcion, IList<RespuestaPosible> repuestaPosibles)
        {
            _descripcion = descripcion;
            _repuestaPosibles = repuestaPosibles;
        }

        public string Descripcion => _descripcion;
        public IList<RespuestaPosible> RespuestaPosibles => _repuestaPosibles;
    }
}
