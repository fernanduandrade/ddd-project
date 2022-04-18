using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : BaseEntity
    {
        public string? Name { get; init; }   
        public string? Email { get; init; }
        public string? Password { get; init; }
    }
}
