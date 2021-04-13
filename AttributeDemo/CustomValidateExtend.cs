using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public static class CustomValidateExtend
    {
        // v1
        ///// <summary>
        ///// 校验
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public static bool Validate<T>(T entity)
        //    where T : class
        //{
        //    Type type = entity.GetType();
        //    var properties = type.GetProperties();// 通过反射获取所有属性
        //    foreach (var item in properties)
        //    {
        //        // 判断该属性是否被RequiredAttribute特性进行标识
        //        if (item.IsDefined(typeof(RequiredAttribute), true))
        //        {
        //            var value = item.GetValue(entity);// 反射获取属性
        //            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))// 如果字段为null或空，则验证不通过
        //                return false;
        //        }

        //        // 判断该属性是否被StringLengthAttribute特性进行标识
        //        if (item.IsDefined(typeof(StringLengthAttribute), true))
        //        {
        //            var value = item.GetValue(entity);// 反射获取属性值
        //            // 反射实例化StringLengthAttribute
        //            var attribute = item.GetCustomAttribute(typeof(StringLengthAttribute), true) as StringLengthAttribute;
        //            if (attribute == null)
        //                throw new Exception("StringLengthAttribute not instantiate");
        //            if (value == null || value.ToString().Length < attribute.minLength || value.ToString().Length > attribute.maxLength)
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        // v2
        ///// <summary>
        ///// 校验
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //public static bool Validate<T>(this T entity) where T : class
        //{
        //    Type type = entity.GetType();
        //    foreach (var item in type.GetProperties())
        //    {
        //        if (item.IsDefined(typeof(AbstractCustomAttribute), true))
        //        {
        //            foreach (AbstractCustomAttribute attribute in item.GetCustomAttributes(typeof(AbstractCustomAttribute), true))
        //            {
        //                if (attribute == null)
        //                {
        //                    throw new Exception("StringLengthAttribute not instantiate");
        //                }
        //                if (!attribute.Validate(item.GetValue(entity)))
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        // v3
        /// <summary>
        /// 校验
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ValidateResultEntity Validate<T>(this T entity) where T : class
        {
            var validate = new ValidateResultEntity();
            validate.IsValidateSuccess = true;
            var fieldList = new List<FieldEntity>();
            var type = entity.GetType();
            foreach (var item in type.GetProperties())
            {
                if (item.IsDefined(typeof(AbstractCustomAttribute), true))
                {
                    foreach (AbstractCustomAttribute attribute in item.GetCustomAttributes(typeof(AbstractCustomAttribute), true))
                    {
                        if (attribute == null)
                            throw new Exception("AbstarctCustomAttribute not instantiate");

                        var result = attribute.Validate(item.GetValue(entity));
                        if (result != null) // 校验不通过
                        {
                            result.FieldName = item.Name;// 获取字段名称
                            result.FieldType = item.PropertyType.Name;// 获取字段类型
                            fieldList.Add(result);// 信息加入集合
                            break;
                        }
                    }


                }
            }
            if (fieldList.Count > 0)
            {
                validate.ValidateMessage = fieldList;
                validate.IsValidateSuccess = false;
            }
            return validate;
        }
    }
}
