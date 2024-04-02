namespace winter24_insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _cultMembersRepository;
  private readonly CultsService _cultsService;

  public CultMembersService(CultMembersRepository cultMembersRepository, CultsService cultsService)
  {
    _cultMembersRepository = cultMembersRepository;
    _cultsService = cultsService;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    Cultist cultMember = _cultMembersRepository.CreateCultMember(cultMemberData);
    return cultMember;
  }

  internal CultMember GetCultMemberById(int cultMemberId)
  {
    CultMember cultMember = _cultMembersRepository.GetCultMemberById(cultMemberId);

    if (cultMember == null) throw new Exception($"Invalid id: {cultMemberId}");

    return cultMember;
  }

  internal string ExcommunicateCultMember(int cultMemberId, string userId)
  {
    // NOTE only the leader of the cult can excommunicate a member
    // REVIEW might not be a great reference for most deletes, but having services talk to each other can be helpful (maybe you could check to make sure only the creator of a recipe can add ingredients!)

    CultMember cultMember = GetCultMemberById(cultMemberId);

    Cult cult = _cultsService.GetCultById(cultMember.CultId);

    if (cult.LeaderId != userId) throw new Exception($"ALERTING {cult.Leader.Name.ToUpper()} THAT YOU ARE TRYING TO INADVERTENTLY UPSET OUR BELOVED LEADER. PLEASE COME TO THE {cult.Name.ToUpper()} 'BAD PERSON' CHAMBER");

    _cultMembersRepository.DestroyCultMember(cultMemberId);

    return $"{cult.Name} has lost a beloved member, but they live on in {cult.Leader.Name}'s heart.";
  }

  internal List<Cultist> GetCultistsByCultId(int cultId)
  {
    List<Cultist> cultists = _cultMembersRepository.GetCultistsByCultId(cultId);
    return cultists;
  }
}