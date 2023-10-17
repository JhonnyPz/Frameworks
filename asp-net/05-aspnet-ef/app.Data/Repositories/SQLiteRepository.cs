using Microsoft.EntityFrameworkCore;
using app.Data.Models;
using app.Data.Interfaces;

namespace app.Data.Repositories;

public class SQLiteRepository : IDesignRepository
{
  private readonly SQLiteContext _context;

  public SQLiteRepository(SQLiteContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Design>> GetAll()
  {
    return await _context.Designs.ToListAsync();
  }

  public async Task<Design> GetById(string id)
  {
    var design = await _context.Designs.FirstOrDefaultAsync(d => d.Id == id);
    return design!;
  }

  public async Task<Design> Create(Design newDesign)
  {
    newDesign.Id = Guid.NewGuid().ToString();
    _context.Add(newDesign);
    await _context.SaveChangesAsync();

    return await GetById(newDesign.Id!);
  }

  public async Task<Design> Update(string id, Design updateDesign)
  {
    _context.Update(updateDesign);
    await _context.SaveChangesAsync();

    return await GetById(updateDesign.Id!);
  }

  public async Task<bool> Delete(string id)
  {
    var design = await _context.Designs.FindAsync(id);
    _context.Designs.Remove(design!);
    await _context.SaveChangesAsync();

    return true;
  }
}