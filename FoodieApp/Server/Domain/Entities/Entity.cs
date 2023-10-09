namespace FoodieApp.Server.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
