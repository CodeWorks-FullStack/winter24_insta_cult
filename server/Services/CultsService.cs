namespace winter24_insta_cult.Services;

public class CultsService
{
  private readonly CultsRepository _repository;

  public CultsService(CultsRepository repository)
  {
    _repository = repository;
  }

  internal Cult CreateCult(Cult cultData)
  {
    Cult cult = _repository.Create(cultData);
    return cult;
  }

  internal Cult GetCultById(int cultId)
  {
    Cult cult = _repository.GetById(cultId);

    if (cult == null) throw new Exception($"Invalid id: {cultId}");

    return cult;
  }

  internal List<Cult> GetCults()
  {
    List<Cult> cults = _repository.GetAll();
    return cults;
  }
}