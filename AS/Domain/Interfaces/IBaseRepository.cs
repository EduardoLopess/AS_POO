namespace Domain.Interfaces
{
    public interface IBaseRepository <Entity> where Entity : class
    {
        Entity GetById(int entityId);
        IList<Entity> GetAll();
        void Delete(int entityId);
        void Create(Entity entity);
        void Update(Entity entity);
    }
}