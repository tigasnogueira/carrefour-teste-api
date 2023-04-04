using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Domain.Model;

public abstract class EntityModel
{
    protected EntityModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
