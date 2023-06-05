using DSI.PPAI.IVR.Domain;

namespace DSI.PPAI.IVR.Business
{
    public class GestorLlamada
    {
        private DateTime _fechaHoraActual = DateTime.Now;

        private OpcionLlamada _opcionLlamada;
        private SubOpcionLlamada _subOpcionLlamada;
        private CategoriaLlamada _categoriaLlamada;
        private Llamada _llamada;
        private IList<Estado> _estados;

        public GestorLlamada(CategoriaLlamada categoriaLlamada, OpcionLlamada opcionLlamada, SubOpcionLlamada subOpcionLlamada, Llamada llamada)
        {
            _opcionLlamada = opcionLlamada;
            _subOpcionLlamada = subOpcionLlamada;
            _categoriaLlamada = categoriaLlamada;
            _llamada = llamada;
            _estados = Estado.GetAllValues().ToList();
        }

        public void comunicarseOP()
        {

            if (identificarOpcion())
            {
                var fechaActual = getFechaHoraActual();

                var estadoEnCurso = buscarEstadoEnCurso();

                _llamada.crearNvoCambioEstado(estadoEnCurso);

                var datosLlamada = _llamada.getDatosLlamada();
                
                var nombreSubOpcion = _subOpcionLlamada.getNombreSubopcion();
                var nombreOpcion = _opcionLlamada.getNombreOpcion();
                var nombreCategoria = _categoriaLlamada.getNombreCategoria();

                var datosValidaciones = buscarValidaciones();

                NavigationManager.NavigateTo()
            }
            return;
        }

        private bool identificarOpcion()
        {
            return _opcionLlamada.esComunicarConOperador() || _subOpcionLlamada.esComunicarConOperador();
        }
        private DateTime getFechaHoraActual()
        {
            return _fechaHoraActual;
        }

        private Estado buscarEstadoEnCurso()
        {
            return _estados.Where(x => x.esEnCurso()).First();
        }
        private IList<string> buscarValidaciones()
        {
            return _subOpcionLlamada.getValidacionesSubOpcion();
        }
    }
}