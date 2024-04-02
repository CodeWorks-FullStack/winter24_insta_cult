namespace winter24_insta_cult.Models;

// NOTE view model for many-to-many. The rpofile of the CultMember, with the added relationship ID
public class Cultist : Profile // Inherits all members from Profile class (the meat 🥩)
{
  public int CultMemberId { get; set; } // Additional property to add to Profile class (the seasoning 🧂)
}