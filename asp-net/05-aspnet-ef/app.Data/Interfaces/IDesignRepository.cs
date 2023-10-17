using app.Data.Models;

namespace app.Data.Interfaces;

public interface IDesignRepository
{
  Task<IEnumerable<Design>> GetAll();
  Task<Design> GetById(string id);
  Task<Design> Create(Design newDesign);
  Task<Design> Update(string id, Design updateDesign);
  Task<bool> Delete(string id);
}