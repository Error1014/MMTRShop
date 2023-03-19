using Configuration.Repository.Entities;
using Configuration.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(ConfigurationDbContext context)
        {
            _dbContext = context;
            ConfigurationItems = new ConfigurationRepository(context);
        }

        public IConfigurationRepository ConfigurationItems { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
