using winter24_insta_cult.Interfaces;

namespace winter24_insta_cult.Repositories;

public class CultsRepository : IRepository<Cult> // implements interface and supplies type for interface
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

    // NOTE Profile class does not include email from sql table
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
    string sql = @"
    SELECT
    cult.*,
    account.*
    FROM cults cult 
    JOIN accounts account ON account.id = cult.leaderId
    WHERE cult.id = @id;";

    Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
    {
      cult.Leader = profile;
      return cult;
    }, new { id }).FirstOrDefault();

    return cult;
  }

  public Cult Update(Cult data)
  {
    throw new NotImplementedException();
  }
}