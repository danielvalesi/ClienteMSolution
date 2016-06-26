using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteWeb.Models;

namespace ClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (ClienteModel model = new ClienteModel())
            {
                List<Cliente> lista = model.Read();
                return View(lista);
            }
        }

        // FILTRO POR NOMES
        [HttpPost]
        public ActionResult Filter(FormCollection form)
        {
            // Extamente o name do input search <input name="nome"...
            string nome = form["nome"];



            using (ClienteModel model = new ClienteModel())
            {
                List<Cliente> lista = model.Read(nome);
                return View("Index", lista);
            }
            

        }

        //GET: /cliente/create
        public ActionResult Create()
        {
            return View();
        }

        //GET: /cliente/create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Cliente e = new Cliente();
            e.Nome = form["nome"];
            e.Email = form["email"];
            e.Endereco = form["endereco"];
            // Tem que fazer o parse pra puxar o genero correto
            e.Genero = Genero.Masculino;
            e.Nascimento = (DateTime.Parse(form["nascimento"]));
            e.Senha = form["senha"];
            e.Deleted = false;
            e.DataCadastro = DateTime.Now;

            using (ClienteModel model = new ClienteModel())
            {
                model.Create(e);
            }

            //ClienteModel model = new ClienteModel();
            //model.Create(e);
            //model.Dispose();

            // string nome = form["nome"];

            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            //TODO: Acesso e manipulação no BD
            return RedirectToAction("Index");
        }

    }
}