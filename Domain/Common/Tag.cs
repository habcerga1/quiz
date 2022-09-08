using Domain.Interfaces.Base;

namespace Domain.Common;

public class Tag : IEntity
{
    public Guid Guid { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public Category Category { get; set; }
}