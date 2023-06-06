using DSI.PPAI.IVR.Domain.BaseTypes;

namespace DSI.PPAI.IVR.Domain
{
    public class TipoInformacion : BaseEnum<TipoInformacion>
    {
        public static readonly TipoInformacion FechaNacimiento = new("Fecha de Nacimiento");
        public static readonly TipoInformacion CantHijos = new("Cantidad de Hijos");
        public static readonly TipoInformacion CodPostal = new("Codigo Postal");

        public TipoInformacion() { }
        public TipoInformacion(string descripcion) : base(descripcion) { }

        public bool esDeTuTipo(string tipo) => base.getDescripcion() == tipo;
    }
}
