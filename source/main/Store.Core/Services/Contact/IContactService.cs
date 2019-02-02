using System.Threading.Tasks;

namespace Store.Core.Services.Contact
{
    public interface IContactService
    {
         Task AddAsync(string nome, string email);
    }
}