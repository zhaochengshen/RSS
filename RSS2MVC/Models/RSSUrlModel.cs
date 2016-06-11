using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSS2MVC.Models
{
    public class RSSUrlModel
    {
        [DisplayName("编号")]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("频道名称")]
        [Required]
        public string Name { get; set; }

        [DisplayName("频道地址")]
        [Required]
        public string Url { get; set; }

        [DisplayName("创建时间")]
        [DataType(DataType.DateTime)] 
        public DateTime CreateDate { get; set; }
    }
}
