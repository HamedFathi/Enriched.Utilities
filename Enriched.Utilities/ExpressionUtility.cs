using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Enriched.Utilities
{
    /*
        var getterNameProperty = ExpressionUtils.CreateGetter<Employee, string>("Name");
        var getterBirthDateProperty = ExpressionUtils.CreateGetter<Employee, DateTime>("BirthDate");
        var name = getterNameProperty(emp1);
        var birthDate = getterBirthDateProperty(emp1);

        var setterNameProperty = ExpressionUtils.CreateSetter<Employee, string>("Name");
        var setterBirthDateProperty = ExpressionUtils.CreateSetter<Employee, DateTime>("BirthDate");
        setterNameProperty(emp, "John");
        setterBirthDateProperty(emp, new DateTime(1990, 6, 5));
    */

    public static class ExpressionUtility<T>
    {
        public static Func<TEntity, TProperty> CreateGetter<TEntity, TProperty>(string name) where TEntity : class
        {
            ParameterExpression instance = Expression.Parameter(typeof(TEntity), "instance");

            var body = Expression.Property(instance, name);

            return Expression.Lambda<Func<TEntity, TProperty>>(body, instance).Compile();
        }

        public static Action<TEntity, TProperty> CreateSetter<TEntity, TProperty>(string name) where TEntity : class
        {
            ParameterExpression instance = Expression.Parameter(typeof(TEntity), "instance");
            ParameterExpression propertyValue = Expression.Parameter(typeof(TProperty), "propertyValue");

            var body = Expression.Assign(Expression.Property(instance, name), propertyValue);

            return Expression.Lambda<Action<TEntity, TProperty>>(body, instance, propertyValue).Compile();
        }

        public static TAttribute GetCustomAttribute<TAttribute>(
                                            Expression<Func<T, TAttribute>> selector) where TAttribute : Attribute
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((PropertyInfo)((MemberExpression)body).Member).GetCustomAttribute<TAttribute>();

                default:
                    throw new InvalidOperationException();
            }
        }

        public static Func<TObject, TProperty> GetProperty<TObject, TProperty>(string propertyName)
        {
            ParameterExpression paramExpression = Expression.Parameter(typeof(TObject), "value");

            Expression propertyGetterExpression = Expression.Property(paramExpression, propertyName);

            return Expression.Lambda<Func<TObject, TProperty>>(propertyGetterExpression, paramExpression).Compile();
        }

        public static PropertyInfo GetProperty(Expression<Func<T, object>> property)
        {
            LambdaExpression lambda = property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression expression)
            {
                memberExpression = (MemberExpression)expression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return (PropertyInfo)memberExpression.Member;
        }

        public static string GetPropertyName(Expression<Func<T, object>> property)
        {
            return GetProperty(property).Name;
        }

        public static void SetDeepValue<TObject>(TObject target, Expression<Func<TObject, T>> propertyToSet, T valueToSet)
        {
            var members = new List<MemberInfo>();

            var exp = propertyToSet.Body;

            // There is a chain of getters in propertyToSet, with at the
            // beginning a ParameterExpression. We put the MemberInfo of
            // these getters in members. We don't really need the
            // ParameterExpression

            while (exp != null)
            {
                if (exp is MemberExpression mi)
                {
                    members.Add(mi.Member);
                    exp = mi.Expression;
                }
                else
                {
                    if (exp is not ParameterExpression pe)
                    {
                        // We support only a ParameterExpression at the base
                        throw new NotSupportedException();
                    }

                    break;
                }
            }

            if (members.Count == 0)
            {
                // We need at least a getter
                throw new NotSupportedException();
            }

            // Now we must walk the getters (excluding the last).
            object targetObject = target;

            // We have to walk the getters from last (most inner) to second
            // (the first one is the one we have to use as a setter)
            for (var i = members.Count - 1; i >= 1; i--)
            {
                var pi = members[i] as PropertyInfo;

                if (pi != null)
                {
                    targetObject = pi.GetValue(targetObject);
                }
                else
                {
                    var fi = (FieldInfo)members[i];
                    targetObject = fi.GetValue(targetObject);
                }
            }

            // The first one is the getter we treat as a setter
            {
                var pi = members[0] as PropertyInfo;

                if (pi != null)
                {
                    pi.SetValue(targetObject, valueToSet);
                }
                else
                {
                    var fi = (FieldInfo)members[0];
                    fi.SetValue(targetObject, valueToSet);
                }
            }
        }

        public static Action<TObject, TProperty> SetProperty<TObject, TProperty>(string propertyName)
        {
            ParameterExpression paramExpression = Expression.Parameter(typeof(TObject));

            ParameterExpression paramExpression2 = Expression.Parameter(typeof(TProperty), propertyName);

            MemberExpression propertyGetterExpression = Expression.Property(paramExpression, propertyName);

            return Expression.Lambda<Action<TObject, TProperty>>
                (Expression.Assign(propertyGetterExpression, paramExpression2), paramExpression, paramExpression2).Compile();
        }
    }
}