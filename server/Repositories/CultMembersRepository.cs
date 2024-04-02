



namespace winter24_insta_cult.Repositories;

public class CultMembersRepository
{
  private readonly IDbConnection _db;

  public CultMembersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    string sql = @"
    INSERT INTO
    cultMembers(accountId, cultId)
    VALUES(@AccountId, @CultId);

    SELECT
    cultMember.*,
    account.*
    FROM cultMembers cultMember
    JOIN accounts account ON cultMember.accountId = account.id
    WHERE cultMember.id = LAST_INSERT_ID();";

    Cultist cultMember = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, cultist) =>
    {
      cultist.CultMemberId = cultMember.Id;
      return cultist;
    }, cultMemberData).FirstOrDefault();
    return cultMember;
  }

  internal void DestroyCultMember(int cultMemberId)
  {
    string sql = "DELETE FROM cultMembers WHERE id = @cultMemberId LIMIT 1;";

    _db.Execute(sql, new { cultMemberId });
  }

  internal List<Cultist> GetCultistsByCultId(int cultId)
  {
    string sql = @"
    SELECT
    cultMember.*,
    account.*
    FROM cultMembers cultMember
    JOIN accounts account ON cultMember.accountId = account.id
    WHERE cultMember.cultId = @cultId;";

    List<Cultist> cultists = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, cultist) =>
    {
      cultist.CultMemberId = cultMember.Id;
      return cultist;
    }, new { cultId }).ToList();

    return cultists;
  }

  internal CultMember GetCultMemberById(int cultMemberId)
  {
    string sql = "SELECT * FROM cultMembers WHERE id = @cultMemberId;";

    CultMember cultMember = _db.Query<CultMember>(sql, new { cultMemberId }).FirstOrDefault();
    return cultMember;
  }
}