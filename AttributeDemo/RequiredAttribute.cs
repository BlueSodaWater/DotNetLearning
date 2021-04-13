using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    // v1
    ///// <summary>
    ///// 自定义验证，验证不为空
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class RequiredAttribute : Attribute
    //{
    //}

    // v2
    ///// <summary>
    ///// 自定义验证，验证不为空
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class RequiredAttribute : AbstractCustomAttribute
    //{
    //    /// <summary>
    //    /// 重写Validate校验方法
    //    /// </summary>
    //    /// <param name="value">需要校验的参数</param>
    //    /// <returns></returns>
    //    public override bool Validate(object value)
    //    {
    //        return value != null && string.IsNullOrWhiteSpace(value.ToString());
    //    }
    //}

    // v3
    /// <summary>
    /// 自定义验证，验证不为空
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : AbstractCustomAttribute
    {
        private string errorMessage = "";

        public RequiredAttribute()
        {
        }

        public RequiredAttribute(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        /// <summary>
        /// 重写Validate校验方法
        /// </summary>
        /// <param name="value">需要校验的参数</param>
        /// <returns></returns>
        public override FieldEntity Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return new FieldEntity()
            {
                ErrorMessage = string.IsNullOrWhiteSpace(this.errorMessage) ? "字段不能为空" : this.errorMessage

            };
        }
    }
}
