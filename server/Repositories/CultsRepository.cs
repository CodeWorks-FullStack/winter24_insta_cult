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
    string sql = @"
    INSERT INTO
    cults(name, description, leaderId, coverImg)
    VALUES(@Name, @Description, @LeaderId, @CoverImg);
    
    SELECT
    cult.*,
    account.*
    FROM cults cult
    JOIN accounts account ON account.id = cult.leaderId
    WHERE cult.id = LAST_INSERT_ID();";

    Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
    {
      cult.Leader = profile;
      return cult;
    }, data).FirstOrDefault();
    return cult;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Cult> GetAll()
  {
    string sql = @"
    SELECT
    cult.*,
    account.*
    FROM cults cult
    JOIN accounts account ON cult.leaderId = account.id;";

    List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
    {
      cult.Leader = profile;
      return cult;
    }).ToList();

    return cults;
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