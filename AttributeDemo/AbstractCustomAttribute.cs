using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    // V2
    public abstract class AbstractCustomAttribute : Attribute // 继承Attribute特性类
    {
        /// <summary>
        /// 定义校验抽象方法
        /// </summary>
        /// <param name="value">需要校验的值</param>
        /// <returns></returns>
        public abstract FieldEntity Validate(object value);
    }
}
