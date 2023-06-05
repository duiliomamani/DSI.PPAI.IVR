using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class OpcionValidacion : BaseEnum<OpcionValidacion>
    {
        public static readonly OpcionValidacion Opcion1 = new(false, "Opcion 1");
        public static readonly OpcionValidacion Opcion2 = new(false, "Opcion 2");
        public static readonly OpcionValidacion Opcion3 = new(true, "Opcion 3");
        public static readonly OpcionValidacion Opcion4 = new(false, "Opcion 4");
        public static readonly OpcionValidacion Opcion5 = new(false, "Opcion 5");
        public static readonly OpcionValidacion Opcion6 = new(true, "Opcion 6");
        private bool _correcta;
        public OpcionValidacion() : base() { }
        public OpcionValidacion(bool correcta, string descripcion) : base(descripcion)
        {
            _correcta = correcta;
        }
    }
}
