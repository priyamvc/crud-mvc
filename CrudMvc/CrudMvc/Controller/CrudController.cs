using System.Web.Mvc;
using CrudMvc.Repository;
using CrudMvc.View;

namespace CrudMvc.Controller {
    public class CrudController<TEntity> : System.Web.Mvc.Controller where TEntity : class {
        protected CrudRepository<TEntity> Repository { get; private set; }

        public CrudController(CrudRepository<TEntity> repository) {
            Repository = repository;
        }

        public ActionResult Index() {
            var models = Repository.GetAll();

            return View(new IndexView(), models);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TEntity entity) {
            if(ModelState.IsValid) {
                Repository.Create(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public ActionResult Edit(int id) {
            TEntity entity = Repository.Get(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(TEntity entity) {
            if(ModelState.IsValid) {
                Repository.Edit(entity);

                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public ActionResult Details(int id) {
            TEntity entity = Repository.Get(id);

            return View(entity);
        }
    }
}
