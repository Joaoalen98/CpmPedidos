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
            catch (Exception)
            {

            }

            return entity.Id;
        }

        public int Alterar(CidadeDTO model)
        {
            if (model.Id <= 0)
            {
                return 0;
            }

            var nomeDuplicado = _dbContext.Cidades
                .Any(x =>
                    x.Ativo
                    && x.Nome.ToUpper() == model.Nome.ToUpper());

            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = _dbContext.Cidades.Find(model.Id);

            if (entity == null)
            {
                return 0;
            }

            entity.Nome = model.Nome;
            entity.Uf = model.Uf;
            entity.Ativo = model.Ativo;

            try
            {
                _dbContext.Cidades.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }

            return entity.Id;
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entity = _dbContext.Cidades.Find(id);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Cidades.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
