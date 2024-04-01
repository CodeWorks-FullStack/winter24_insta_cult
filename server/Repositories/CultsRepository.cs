

namespace winter24_insta_cult.Repositories;

public class CultsRepository : IRepository<Cult>
{
  private readonly IDbConnection _db;

  public CultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Cult Create(Cult data)
  {
    throw new NotImplementedException();
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Cult> GetAll()
  {
    throw new NotImplementedException();
  }

  public Cult GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Cult Update(Cult data)
  {
    throw new NotImplementedException();
  }
}