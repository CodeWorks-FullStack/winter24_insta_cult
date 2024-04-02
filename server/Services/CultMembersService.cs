
namespace winter24_insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _cultMembersRepository;

  public CultMembersService(CultMembersRepository cultMembersRepository)
  {
    _cultMembersRepository = cultMembersRepository;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    Cultist cultMember = _cultMembersRepository.CreateCultMember(cultMemberData);
    return cultMember;
  }
}