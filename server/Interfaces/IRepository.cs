public interface IRepository<T>
{
  public List<T> GetAll();

  public T GetById();

  public T Create();

  public T Update();

  public void Destroy();
}