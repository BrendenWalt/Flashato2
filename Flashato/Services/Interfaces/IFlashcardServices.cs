using Flashato.Models.Requests;

namespace Flashato.Services
{
    public interface IFlashcardServices
    {
        int Insert(CardInsertRequest card);
    }
}