using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class Accion : BaseEnum<Accion>
    {
        public static readonly Accion Accion1 = new ("Comunicar un saldo");
        public static readonly Accion Accion2 = new ("Dar baja una tarjeta");
        public static readonly Accion Accion3 = new ("Denunciar robo");
        public Accion() : base()
        {

        }
        public Accion(string descripcion) : base(descripcion)
        {

        }
    }
}