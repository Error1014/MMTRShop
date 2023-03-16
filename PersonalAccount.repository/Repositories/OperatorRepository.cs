using Microsoft.EntityFrameworkCore;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;
using PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Repositories
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
