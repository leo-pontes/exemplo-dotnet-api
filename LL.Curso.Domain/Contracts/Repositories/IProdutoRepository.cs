using LL.Curso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Curso.Domain.Contracts.Repositories
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByNameAsync(string name);

        Task<IEnumerable<Produto>> GetAllWithCategoriaAsync();

        Task<Produto> GetByIdWithCategoriaAsync(int id);
    }
}
