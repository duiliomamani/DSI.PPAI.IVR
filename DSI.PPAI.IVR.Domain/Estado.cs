using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class Estado : BaseEnum<Estado>
    {
        public static readonly Estado Iniciada = new("Iniciada");
        public static readonly Estado Finalizada = new("Finalizada");
        public static readonly Estado EnCurso = new("En curso");
        public static readonly Estado Cancelada = new("Cancelada");

        public Estado() { }

        public Estado(string descripcion) : base(descripcion) { }

        public bool esEnCurso()
        {
            return Equals(EnCurso);
        }
    }
}
