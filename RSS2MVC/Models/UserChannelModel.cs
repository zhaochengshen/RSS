using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSS2MVC.Models
{
    public class UserChannelModel
    {
        [DisplayName("编号")]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [DisplayName("用户编号")]
        [Required]
        public int UserID { get; set; }
        [DisplayName("频道编号")]
        [Required]
        public int ChannelID { get; set; }
    }
}
