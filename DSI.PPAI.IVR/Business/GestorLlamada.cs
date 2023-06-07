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

        //Comunicarse con Operacdor
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


                //Redirijo a la pantalla del operador
                _navigationManager.NavigateTo("/operator/call");
            }
            return;
        }


        //Identifica la opcion si es comunicarse con operador
        private bool identificarOpcion()
        {
            return _opcionLlamada.esComunicarConOperador() || _subOpcionLlamada.esComunicarConOperador();
        }

        //Fecha Hora Actual
        private DateTime getFechaHoraActual()
        {
            return DateTime.Now;
        }

        //Busco referencia al estado en curso
        private Estado buscarEstadoEnCurso()
        {
            return _estados.Where(x => x.esEnCurso()).First();
        }

        //buscar validaciones correspondientes a la subopcion
        private IList<Validacion> buscarValidaciones()
        {
            return _subOpcionLlamada.getValidacionesSubOpcion();
        }

        //Validamos todos los datos con la validacion correspondiente
        private Dictionary<string, bool> validarDatos(Dictionary<Validacion, string> respuestas)
        {
            Dictionary<string, bool> validaciones = new Dictionary<string, bool>();
            foreach (var r in respuestas)
            {
                validaciones.Add(r.Key.getDescripcion(), _llamada.validarDatos(r.Key, r.Value));
            }
            return validaciones;
        }

        //Voy guardando parcialmente las respuestas del cliente ingresadas por el operador
        public Dictionary<string, bool> tomarRespuesta(Dictionary<Validacion, string> respuestas)
        {
            return validarDatos(respuestas);
        }

        //Guardo la respuesta del operador
        public void tomarDescripcionRespuesta(string respuestaOperador)
        {
            _respuestaOperador = respuestaOperador;
        }

        //busco acciones para registrar en la llamada
        public IList<Accion> buscarAccion()
        {
            return _acciones;
        }

        //Guardo la accion seleccionada
        public void tomarAccion(string accion)
        {
            _accionRequerida = accion;
        }

        //Confirmo la operacion y procedo a finalizar la llamada
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
        //busco el estado finalizado
        private Estado buscarEstadoFinalizado()
        {
            return _estados.Where(x => x.esFinalizada()).First();
        }

        //Llamar al CU28 ejecuto un random de booleans
        private bool LlamarCU28()
        {
            var random = new Random();

            var randomBool = random.Next(2);

            return randomBool == 1;
        }
    }
}