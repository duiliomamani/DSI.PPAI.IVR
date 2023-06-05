namespace DSI.PPAI.IVR.Domain
{
    public class Encuesta
    {
        private string _descripcion;
        private DateTime _fechaFinVigencia;
        private IList<Pregunta> _preguntas;
        public Encuesta(string descripcion, DateTime fechaFinVigencia, IList<Pregunta> preguntas)
        {
            _descripcion = descripcion;
            _fechaFinVigencia = fechaFinVigencia;
            _preguntas = preguntas;
        }

        public bool EsVigente() => _fechaFinVigencia <= DateTime.UtcNow;
    }
}
