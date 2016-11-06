using Flashato.Domain;
using Flashato.Models.Requests;
using System.Collections.Generic;

namespace Flashato.Services.Interfaces
{
    public interface IFlashcardServices
    {
        int Insert(CardInsertRequest card);
        int Update(CardUpdateRequest card);
        int Delete(int id);
        Flashcard GetById(int id);
        List<Flashcard> GetAllCards();
    }
}