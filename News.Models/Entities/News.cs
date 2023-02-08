using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.Entities
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string NewsHeader { get; set; }    
        public string NewsContent { get; set; }
    }
}
