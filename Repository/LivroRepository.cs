using ProjetoCadastroMVC.Data;
using ProjetoCadastroMVC.Models;

namespace ProjetoCadastroMVC.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DatabaseContext dbContext;

        public LivroRepository(DatabaseContext contexto)
        {
            dbContext = contexto;
        }

        public List<Livro> BuscarTodos()
        {
            return dbContext.Livros.ToList();
        }

        public Livro Adicionar(Livro livro)
        {
            dbContext.Livros.Add(livro);
            dbContext.SaveChanges();
            return livro;
        }

        public Livro? BuscarPorId(int id)
        {
            return dbContext.Livros.FirstOrDefault(x => x.Id == id);
        }

        public Livro Atualizar(Livro livro)
        {
            Livro? livroBanco = BuscarPorId(livro.Id);

            if (livroBanco == null)
            {
                throw new Exception("Houve um problema ao atualizar!");
            }

            livroBanco.Titulo = livro.Titulo;
            livroBanco.ISBN = livro.ISBN;
            livroBanco.Autor = livro.Autor;
            livroBanco.Editora = livro.Editora;
            livroBanco.AnoPublicacao = livro.AnoPublicacao;

            dbContext.Livros.Update(livroBanco);
            dbContext.SaveChanges();

            return livroBanco;
        }

        public bool Excluir(int id)
        {
            Livro livro = BuscarPorId(id);

            if (livro == null)
            {
                throw new Exception("Nenhum livro encontrado para exclusão!");
            }

            dbContext.Livros.Remove(livro);
            dbContext.SaveChanges();

            return true;
        }
    }
}
