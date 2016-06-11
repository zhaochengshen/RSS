using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSS2MVC.Models
{
    public class UserInfoModel
    {
        [DisplayName("编号")]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [DisplayName("用户名")]
        [Required]
        public string UserName { get; set; }
        [DisplayName("密码")]
        [Required]
        public string UserPwd { get; set; }
        [DisplayName("电子邮件")]
        public string Email { get; set; }
        [DisplayName("创建时间")]
        [ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; }
        [DisplayName("最后一次登录时间")]
        [ScaffoldColumn(false)]
        public DateTime? LastLoginDate { get; set; }

    }
}
