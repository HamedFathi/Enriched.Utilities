using System;
using System.Reflection;

namespace Enriched.Utilities
{
    public static class ReflectionUtility
    {
        public static TProperty GetProperty<TClass, TProperty>(TClass classInstance, string propertyName)
                                                                      where TClass : class
        {
            if (propertyName == null || string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName), "Value can not be null or empty.");

            object obj = null;
            var type = classInstance.GetType();
            var info = type.GetTypeInfo().GetProperty(propertyName);
            if (info != null)
                obj = info.GetValue(classInstance, null);
            return (TProperty)obj;
        }

        public static void SetProperty<TClass>(TClass classInstance, string propertyName, object propertyValue)
                                                                    where TClass : class
        {
            if (propertyName == null || string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName), "Value can not be null or empty.");

            var type = classInstance.GetType();
            var info = type.GetTypeInfo().GetProperty(propertyName);

            if (info != null)
                info.SetValue(classInstance, Convert.ChangeType(propertyValue, info.PropertyType), null);
        }
    }
}