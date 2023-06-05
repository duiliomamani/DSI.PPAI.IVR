using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class TipoInformacion : BaseEnum<TipoInformacion>
    {
        public static readonly TipoInformacion FechaNacimiento = new TipoInformacion("Fecha de Nacimiento");
        public static readonly TipoInformacion CantHijos = new TipoInformacion("Cantidad de Hijos");
        public static readonly TipoInformacion CodPostal = new TipoInformacion("Codigo Postal");

        public TipoInformacion() { }
        public TipoInformacion(string descripcion) :base(descripcion) { }
       

    }
}
