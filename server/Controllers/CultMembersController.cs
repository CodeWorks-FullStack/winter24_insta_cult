namespace winter24_insta_cult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultMembersController
{
  private readonly CultMembersService _cultMembersService;
  private readonly Auth0Provider _auth0Provider;

  public CultMembersController(CultMembersService cultMembersService, Auth0Provider auth0Provider)
  {
    _cultMembersService = cultMembersService;
    _auth0Provider = auth0Provider;
  }

}