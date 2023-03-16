using Microsoft.EntityFrameworkCore;
using AuthorizationMicroservice.Authorization.Repository.Entities;
using AuthorizationMicroservice.Authorization.Repository.Interfaces;

namespace AuthorizationMicroservice.Authorization.Repository.Repositories
{
    public class OperatorRepository:Repository<Operator,Guid>, IOperatorRepository
    {
        private readonly DbContext _userContext;
        public OperatorRepository(DbContext context) : base(context)
        {
            _userContext = context;
        }
    }
}
