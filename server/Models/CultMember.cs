namespace winter24_insta_cult.Models;

// NOTE the many-to-many, just a bunch of IDs
public class CultMember : RepoItem<int>
{
  public int CultId { get; set; }
  public string AccountId { get; set; }
}