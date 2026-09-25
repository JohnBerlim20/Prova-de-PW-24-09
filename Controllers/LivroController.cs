using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroMVC.Models;
using ProjetoCadastroMVC.Repository;

namespace ProjetoCadastroMVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository livroRep;

        public LivroController(ILivroRepository livroReposi)
        {
            livroRep = livroReposi;
        }

        public IActionResult Index()
        {
            List<Livro> listaLivros = livroRep.BuscarTodos();
            return View(listaLivros);
        }

        public IActionResult Criar()
        {
            ViewBag.TipoTela = "Criar";
            return View("~/Views/Livro/CriarEditar.cshtml");
        }

        public IActionResult Editar(int id)
        {
            Livro? livro = livroRep.BuscarPorId(id);
            ViewBag.TipoTela = "Editar";
            return View("~/Views/Livro/CriarEditar.cshtml", livro);
        }

        [HttpPost]
        public IActionResult Criar(Livro livro)
        {
            livroRep.Adicionar(livro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Livro livro)
        {
            livroRep.Atualizar(livro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            Livro? livro = livroRep.BuscarPorId(id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado!");
            }

            livroRep.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
