
public interface IRepository<T> where T : Entity {
    // These would all be async in a real application
    void Add(T entity);

    List<T> ListAll();

    T Find(string id);
    
    void Update(string id, T newValues);

    void Delete(string id);
}