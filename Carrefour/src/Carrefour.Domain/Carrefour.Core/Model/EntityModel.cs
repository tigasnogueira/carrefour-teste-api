namespace Carrefour.Domain.Model;

public abstract class EntityModel
{
    protected EntityModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
