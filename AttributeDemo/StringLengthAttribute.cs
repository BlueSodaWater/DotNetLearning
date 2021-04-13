using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    // v1
    ///// <summary>
    ///// 自定义验证，验证字符长度
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class StringLengthAttribute : Attribute
    //{
    //    public int maxLength;
    //    public int minLength;

    //    public StringLengthAttribute(int minLength, int maxLength)
    //    {
    //        this.maxLength = maxLength;
    //        this.minLength = minLength;
    //    }
    //}

    // v2
    ///// <summary>
    ///// 自定义验证，验证字符长度
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class StringLengthAttribute : AbstractCustomAttribute
    //{
    //    public int maxLength;
    //    public int minLength;

    //    public StringLengthAttribute(int minLength, int maxLength)
    //    {
    //        this.maxLength = maxLength;
    //        this.minLength = minLength;
    //    }

    //    public override bool Validate(object value)
    //    {
    //        return value != null && value.ToString().Length >= this.minLength && value.ToString().Length <= this.maxLength;
    //    }
    //}

    // v3
    /// <summary>
    /// 自定义验证，验证字符长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : AbstractCustomAttribute
    {
        private int maxLength;
        private int minLength;
        private string errorMessage;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="errorMessage"></param>
        public StringLengthAttribute(int minLength, int maxLength, string errorMessage = "")
        {
            this.maxLength = maxLength;
            this.minLength = minLength;
            this.errorMessage = errorMessage;
        }

        /// <summary>
        /// 重写Validate校验方法
        /// </summary>
        /// <param name="value">需要校验的参数</param>
        /// <returns></returns>
        public override FieldEntity Validate(object value)
        {
            if (value != null && value.ToString().Length >= this.minLength && value.ToString().Length <= maxLength)
                return null;

            return new FieldEntity()
            {
                ErrorMessage = string.IsNullOrWhiteSpace(this.errorMessage) ? $"字段的长度必须大于等于{this.minLength}并且小于等于{this.maxLength}" : errorMessage,
            };
        }
    }
}
