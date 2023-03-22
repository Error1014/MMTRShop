using Configuration.Repository.Entities;
using System;

namespace Configuration.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IConfigurationRepository ConfigurationItems { get; }
        int Complete();
    }
}
