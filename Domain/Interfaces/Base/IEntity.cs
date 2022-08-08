using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Interfaces.Base;

/// <summary>
/// Base interface for ms sql entities
/// </summary>
public interface IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set;}
    public Guid Guid { get; set;}
}