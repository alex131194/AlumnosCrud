using AlumnosCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlumnosCRUD.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Listado()
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    List<Alumno> lista = db.Alumno.ToList();
                    return View(lista);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new AlumnosContext())
                {
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Listado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al crear el registro", ex);
                return View();
            }

        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno alu = db.Alumno.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno al = db.Alumno.Find(a.Id);
                    al.NombreAlumno = a.NombreAlumno;
                    al.ApellidoAlumno = a.ApellidoAlumno;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;
                    al.FechaIngreso = a.FechaIngreso;

                    db.SaveChanges();

                    return RedirectToAction("Listado");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult Detalles(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno alu = db.Alumno.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public ActionResult Borrar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno alu = db.Alumno.Find(id);
                    db.Alumno.Remove(alu);
                    db.SaveChanges();
                    return RedirectToAction("Listado");
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}