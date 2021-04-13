using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    // v3

    /// <summary>
    /// 校验结果实体类
    /// </summary>
    public class ValidateResultEntity
    {
        /// <summary>
        /// 是否校验成功
        /// </summary>
        public bool IsValidateSuccess { get; set; }

        /// <summary>
        /// 校验不通过的字段信息存储字段
        /// </summary>
        public List<FieldEntity> ValidateMessage { get; set; }
    }

    public class FieldEntity
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }

        /// <summary>
        /// 验证错误时提示信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
