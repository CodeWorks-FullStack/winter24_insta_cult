namespace winter24_insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _cultMembersRepository;

  public CultMembersService(CultMembersRepository cultMembersRepository)
  {
    _cultMembersRepository = cultMembersRepository;
  }
}