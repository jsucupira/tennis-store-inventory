using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Common.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("memberExpression");

            PropertyInfo property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("property");

            MethodInfo getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
                throw new ArgumentException("static method");

            return memberExpression.Member.Name;
        }
    }
}