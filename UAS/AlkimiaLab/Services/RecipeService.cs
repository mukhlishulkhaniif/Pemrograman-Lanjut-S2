using AlkimiaLab.Models;
using AlkimiaLab.Repositories;

namespace AlkimiaLab.Services
{
 
    /// Service untuk mengecek kombinasi recipe dua elemen.
  
    public class RecipeService
    {

        private readonly RecipeRepository repository;

        public RecipeService()
        {
            repository = new RecipeRepository();
        }

        /// Mengecek apakah kombinasi dua elemen menghasilkan elemen baru.

        public Element FindResult(int elementId1, int elementId2)
        {
            return repository.FindResult(elementId1, elementId2);
        }
    }
}
