using DSI.PPAI.IVR.Domain;
using DSI.PPAI.IVR.Shared;
using Microsoft.AspNetCore.Components;
using System;

namespace DSI.PPAI.IVR.Business
{
    public partial class GestorLlamada
    {
        private OpcionLlamada _opcionLlamada;
        private SubOpcionLlamada _subOpcionLlamada;
        private CategoriaLlamada _categoriaLlamada;
        private Llamada _llamada;
        private IList<Estado> _estados;
        private IList<Accion> _acciones;
        private string _respuestaOperador;
        private string _accionRequerida;

        //Necessary To passing paramerters to page
        private readonly NavigationManager _navigationManager;
        private readonly ContainerValues _containerValues;

        public GestorLlamada(NavigationManager navigationManager, ContainerValues containerValues)
        {
            _estados = Estado.GetAllValues().ToList();
            _acciones = Accion.GetAllValues().ToList();
            _navigationManager = navigationManager;
            _containerValues = containerValues;
        }

        public void comunicarseOP(CategoriaLlamada categoriaLlamada,
            OpcionLlamada opcionLlamada,
            SubOpcionLlamada subOpcionLlamada,
            Llamada llamada)
        {
            _opcionLlamada = opcionLlamada;
            _subOpcionLlamada = subOpcionLlamada;
            _categoriaLlamada = categoriaLlamada;
            _llamada = llamada;

            if (identificarOpcion())
            {
                var fechaActual = getFechaHoraActual();

                var estadoEnCurso = buscarEstadoEnCurso();

                _llamada.crearNvoCambioEstado(estadoEnCurso, fechaActual);

                var datosLlamada = _llamada.getDatosLlamada();

                var nombreSubOpcion = _subOpcionLlamada.getNombreSubopcionLlamada();
                var nombreOpcion = _opcionLlamada.getNombreOpcionLlamada();
                var nombreCategoria = _categoriaLlamada.getNombreCategoria();

                var datosValidaciones = buscarValidaciones();

                _containerValues.SetValue("datosLlamada", datosLlamada);
                _containerValues.SetValue("nombreOpcion", nombreOpcion);
                _containerValues.SetValue("nombreSubOpcion", nombreSubOpcion);
                _containerValues.SetValue("nombreCategoria", nombreCategoria);
                _containerValues.SetValue("datosValidaciones", datosValidaciones);

                _navigationManager.NavigateTo("/operator/call");
            }
            return;
        }

        private bool identificarOpcion()
        {
            return _opcionLlamada.esComunicarConOperador() || _subOpcionLlamada.esComunicarConOperador();
        }
        private DateTime getFechaHoraActual()
        {
            return DateTime.Now;
        }

        private Estado buscarEstadoEnCurso()
        {
            return _estados.Where(x => x.esEnCurso()).First();
        }
        private IList<Validacion> buscarValidaciones()
        {
            return _subOpcionLlamada.getValidacionesSubOpcion();
        }

        private Dictionary<string, bool> validarDatos(Dictionary<Validacion, string> respuestas)
        {
            Dictionary<string, bool> validaciones = new Dictionary<string, bool>();
            foreach (var r in respuestas)
            {
                validaciones.Add(r.Key.getDescripcion(), _llamada.validarDatos(r.Key, r.Value));
            }
            return validaciones;
        }
        public Dictionary<string, bool> tomarRespuesta(Dictionary<Validacion, string> respuestas)
        {
            return validarDatos(respuestas);
        }

        public void tomarDescripcionRespuesta(string respuestaOperador)
        {
            _respuestaOperador = respuestaOperador;
        }

        public IList<Accion> buscarAccion()
        {
            return _acciones;
        }

        public void tomarAccion(string accion)
        {
            _accionRequerida = accion;
        }
        public bool tomarConfirmacionDeOperacion()
        {
            var estado = buscarEstadoFinalizado();

            var fechaActual = getFechaHoraActual();

            //Llamar al CU 28 registar Accion correspondiente
            var resultadoCU28 = LlamarCU28();

            if (!resultadoCU28)
                return false;

            _llamada.finalizarLlamada(fechaActual, _subOpcionLlamada, _opcionLlamada, _respuestaOperador, estado);

            return true;
        }
        private Estado buscarEstadoFinalizado()
        {
            return _estados.Where(x => x.esFinalizada()).First();
        }

        private bool LlamarCU28()
        {
            var random = new Random();

            var randomBool = random.Next(2);

            return randomBool == 1;
        }
    }
}