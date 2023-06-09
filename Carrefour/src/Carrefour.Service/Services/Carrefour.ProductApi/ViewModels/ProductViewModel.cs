using System.ComponentModel.DataAnnotations;

namespace Carrefour.ProductApi.ViewModels;

public class ProductViewModel
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Edict { get; set; }
    public string Comiters { get; set; }

    public string Goal { get; set; }

    public string Increase { get; set; }

    public string Nature { get; set; }

    public string Description { get; set; }
    public string InitialValue { get; set; }
}
