namespace CpmPedidos.Repository.Repositories
{
    public class BaseRepository
    {
        protected const int TamanhoPagina = 5;
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}