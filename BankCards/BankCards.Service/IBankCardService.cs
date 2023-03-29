using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCards.Service
{
    public interface IBankCardService
    {
        Task<IEnumerable<BankCardDTO>> GetBankCards();
        Task<BankCardDTO> GetBankCard(Guid id);
        Task AddBankCard(BankCardDTO bankCardDTO);
        Task Update(BankCardDTO bankCardDTO);
        Task Remove(Guid id);
        Task Save();
        ObservableCollection<int> GetAllMonth();
        ObservableCollection<int> GetYear(int quantityYear);
    }
}
