using Newtonsoft.Json;
using System;

namespace AttributeDemo
{
    class Program
    {
        // v1
        //static void Main(string[] args)
        //{
        //    var entity = new UserEntity();
        //    entity.Name = "张三";
        //    entity.PhoneNum = "1111111";
        //    var validateResult = CustomValidateExtend.Validate(entity);
        //    if (validateResult)
        //        Console.WriteLine("验证通过");
        //    else
        //        Console.WriteLine("验证不通过");
        //    Console.ReadLine();
        //}

        // v2
        //static void Main(string[] args)
        //{
        //    var entity = new UserEntity();
        //    entity.Name = "张三";
        //    entity.PhoneNum = "1887065752";
        //    var validateResult = entity.Validate();//校验方法
        //    if (validateResult)
        //        Console.WriteLine("验证通过");
        //    else
        //        Console.WriteLine("验证不通过");
        //    Console.ReadKey();
        //}

        // v3
        static void Main(string[] args)
        {
            var entity = new UserEntity();
            var validateResult = entity.Validate();//校验方法
            if (validateResult.IsValidateSuccess)
            {
                Console.WriteLine("验证通过");
            }
            else
            {
                Console.WriteLine("验证不通过");
                Console.WriteLine("================================================================");
                var data = JsonConvert.SerializeObject(validateResult.ValidateMessage);
                Console.WriteLine(data);
            }
            Console.ReadKey();
        }
    }
}
