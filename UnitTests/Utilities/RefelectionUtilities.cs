using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Utilities
{
    public class RefelectionUtilities
    {
        public static T2 GetStaticMethodResult<T1, T2>(string methodName, object[] parameters)
        {
            MethodInfo dynMethod = typeof(T1).GetMethod(methodName,
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            // ReSharper disable once PossibleNullReferenceException
            var result = dynMethod.Invoke(null, parameters);

            return (T2)result;
        }

        public static void SetFieldValue(object target, string fieldName, object newValue)
        {
            FieldInfo field = GetFieldReference(target.GetType(), fieldName);
            field.SetValue(target, newValue);
        }

        public static FieldInfo GetField(object target, string fieldName)
        {
            FieldInfo field = GetFieldReference(target.GetType(), fieldName);
            return field;
        }

        private static FieldInfo GetFieldReference(Type targetType, string fieldName)
        {
            FieldInfo field = targetType.GetField(fieldName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            if (field == null && targetType.BaseType != null)
            {
                return GetFieldReference(targetType.BaseType, fieldName);
            }

            return field;
        }
    }
}

