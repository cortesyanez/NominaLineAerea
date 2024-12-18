using Microsoft.AspNetCore.Mvc;
using NominaLinAerea.Data;
using NominaLinAerea.Models;

namespace NominaLinAerea.Controllers
{
    public class AccionesController : Controller
    {
        TrabajadorDatos traDat = new TrabajadorDatos();

        // Método para listar trabajadores
        public IActionResult ListarTrabajadores()
        {
            var ListaTrab = traDat.Listar(0, 1); // 0 = Todos los trabajadores, 1 = operación listar
            return View(ListaTrab);
        }

        // GET: Mostrar formulario para guardar un trabajador
        public IActionResult GuardarTrabajador()
        {
            return View();
        }

        // POST: Guardar un nuevo trabajador
        [HttpPost]
        public IActionResult GuardarTrabajador(modeloTrabajadores recTrabajador)
        {
            if (!ModelState.IsValid)
                return View();

            var Respuesta = traDat.GuardaModificaTrabajador(recTrabajador, 1); // 1 = Agregar

            if (Respuesta)
                return RedirectToAction("ListarTrabajadores");
            else
                return View();
        }

        // GET: Mostrar formulario para editar un trabajador
        public IActionResult EditarTrabajador(Int16 IdTrabajador)
        {
            var Trabajador = traDat.RegresaTrabajador(IdTrabajador, 2); // 2 = Consultar específico
            return View(Trabajador);
        }

        // POST: Editar un trabajador existente
        [HttpPost]
        public IActionResult EditarTrabajador(modeloTrabajadores modTrabajador)
        {
            if (!ModelState.IsValid)
                return View();

            var Respuesta = traDat.GuardaModificaTrabajador(modTrabajador, 2); // 2 = Modificar

            if (Respuesta)
                return RedirectToAction("ListarTrabajadores");
            else
                return View();
        }

        // GET: Mostrar formulario para eliminar un trabajador
        public IActionResult EliminarTrabajador(Int16 IdTrabajador)
        {
            var Trabajador = traDat.RegresaTrabajador(IdTrabajador, 2); // Consultar por ID
            return View(Trabajador);
        }

        // POST: Eliminar un trabajador
        [HttpPost]
        public IActionResult EliminarTrabajador(modeloTrabajadores delTrabajador)
        {
            var Respuesta = traDat.EliminaTrabajador(delTrabajador.IdEmp_mod);

            if (Respuesta)
                return RedirectToAction("ListarTrabajadores");
            else
                return View();
        }
    }
}