using CpmPedidos.Domain;
using CpmPedidos.Interface;
using CpmPedidos.Repository;

namespace CpmPedidos.Repository
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public dynamic Get()
        {
            return _dbContext.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Uf,
                    x.Ativo,
                })
                .ToList();
        }

        public int Criar(CidadeDTO model)
        {
            var nomeDuplicado = _dbContext.Cidades.Any(x => x.Nome.ToUpper() == model.Nome.ToUpper());

            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = new Cidade
            {
                Nome = model.Nome,
                Uf = model.Uf,
                Ativo = model.Ativo,
            };

            try
            {
                _dbContext.Cidades.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return entity.Id;
        }
    }
}
