using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<TablaViewModel> lst;
            using (SistemaMatriculaEntities db = new SistemaMatriculaEntities())
            {
                lst = (from d in db.Curso
                       select new TablaViewModel
                       {
                           idCurso = d.IIDCURSO,
                           nombre = d.NOMBRE,
                           descripcion = d.DESCRIPCION,
                           bhabilitado = d.BHABILITADO
                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(NuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SistemaMatriculaEntities db = new SistemaMatriculaEntities())
                    {
                        var tNuevo = new Curso();
                        tNuevo.IIDCURSO = model.idCurso;
                        tNuevo.NOMBRE = model.nombre;
                        tNuevo.DESCRIPCION = model.descripcion;
                        tNuevo.BHABILITADO = model.bhabilitado;

                        db.Curso.Add(tNuevo);
                        db.SaveChanges();
                    }
                    return Redirect("/tabla");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            NuevoViewModel model = new NuevoViewModel();

            using (SistemaMatriculaEntities db = new SistemaMatriculaEntities())
            {
                var tEditar = db.Curso.Find(id);
                model.idCurso = tEditar.IIDCURSO;
                model.nombre = tEditar.NOMBRE;
                model.descripcion = tEditar.DESCRIPCION;
                model.bhabilitado = tEditar.BHABILITADO;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(NuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SistemaMatriculaEntities db = new SistemaMatriculaEntities())
                    {
                        var tEditar = db.Curso.Find(model.idCurso);
                        tEditar.IIDCURSO = model.idCurso;
                        tEditar.NOMBRE = model.nombre;
                        tEditar.DESCRIPCION = model.descripcion;
                        tEditar.BHABILITADO = model.bhabilitado;

                        db.Entry(tEditar).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/tabla");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            NuevoViewModel model = new NuevoViewModel();

            using (SistemaMatriculaEntities db = new SistemaMatriculaEntities())
            {
                var tEliminar = db.Curso.Find(id);
                db.Curso.Remove(tEliminar);
                db.SaveChanges();
            }
            return Redirect("/tabla");
        }
    }
}
