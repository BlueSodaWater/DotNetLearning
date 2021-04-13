using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    // v1,v2
    //public class UserEntity
    //{
    //    [Required]
    //    public string Name { get; set; }

    //    public int Age { get; set; }

    //    public string Address { get; set; }

    //    public string sex { get; set; }

    //    [Required]
    //    [StringLength(11, 11)]
    //    public string PhoneNum { get; set; }

    //    public string Email { get; set; }
    //}

    // v3
    public class UserEntity
    {
        [Required("姓名不能为空")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string sex { get; set; }

        [Required]
        [StringLength(11, 11, "手机号码必须等于11位")]
        public string PhoneNum { get; set; }

        public string Email { get; set; }
    }
}

// 繁琐的校验数据的方式
//if (entity != null)
//{
//    if (string.IsNullOrWhiteSpace(entity.Name))
//    {
//        throw new Exception("姓名不能为空");
//    }
//    if (entity.Age <= 0 || entity.Age > 120)
//    {
//        throw new Exception("年龄不合法");
//    }
//    if (string.IsNullOrWhiteSpace(entity.Address))
//    {
//        throw new Exception("家庭地址不能为空");
//    }
//    .....
//}

