using ProjetoCadastroMVC.Models;

namespace ProjetoCadastroMVC.Repository
{
    public interface ILivroRepository
    {
        List<Livro> BuscarTodos();
        Livro Adicionar(Livro livro);
        Livro? BuscarPorId(int id);
        Livro Atualizar(Livro livro);
        bool Excluir(int id);
    }
}
