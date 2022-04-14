using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UpdateEmailDTO : IDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
