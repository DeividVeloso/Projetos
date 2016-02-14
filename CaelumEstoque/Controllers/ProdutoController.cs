using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using CaelumEstoque.Filtros;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        [Route("Produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            //ViewBag.Produtos = produtos;
            return View(produtos);
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            //Produto produto = new Produto();
            ViewBag.Produtos = new Produto();
            return View();

        }

        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = new Produto();
            produto = dao.BuscaPorId(id);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int IdIgulaAInformatica = 1;

            if (produto.CategoriaId.Equals(IdIgulaAInformatica) && produto.Preco <= 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index");
                //return RedirectToAction("Index", "Home");
            }
            else
            {
                CategoriasDAO dao = new CategoriasDAO();
                IList<CategoriaDoProduto> categorias = dao.Lista();
                ViewBag.Produtos = produto;
                ViewBag.Categorias = categorias;
                return View("Form");

            }
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
        }
    }
}