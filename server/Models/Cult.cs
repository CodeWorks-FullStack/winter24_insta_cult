namespace winter24_insta_cult.Models;

public class Cult : RepoItem<int> // NOTE inherits all members from RepoItem, and we supply a type for the Id
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string CoverImg { get; set; }
  public string LeaderId { get; set; }
  public Profile Leader { get; set; }
}