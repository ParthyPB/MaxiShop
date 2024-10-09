using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Model.Common
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime createdOn { get; set; }= DateTime.UtcNow;
    }
}
