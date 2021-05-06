using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace GoldBoxEditor
{
    public class GenericsHelper
    {
        public static Dictionary<string, Object> GetNamesAndValues(Type type, Object obj, ref List<string> output, ref List<object> checkedObjects)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            propertyInfos = type.GetProperties();

            Dictionary<string, Object> propertyValues = new Dictionary<string, object>();
            //List<object> propertyValues = new List<object>();

            output.Add("Getting properties and values from " + obj.ToString());

            //checkedObjects.Add(obj);

            foreach (var propertyInfo in propertyInfos)
            {
                try
                {
                    Type currentType = propertyInfo.PropertyType;

                    if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        currentType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                    }

                    if (checkedObjects.Contains(propertyInfo.GetValue(obj, null)))
                    {
                        output.Add("Property" + propertyInfo.Name + " of type " + propertyInfo.GetType() + " already serialized. Skipping to avoid recursion.");
                        continue;
                    }
                    else
                    {
                        checkedObjects.Add(propertyInfo.GetValue(obj, null));
                    }

                    if (propertyInfo.Name == "gameObject" || propertyInfo.Name == "transform" || propertyInfo.Name == "parent" || propertyInfo.Name == "root")
                    {
                        //output[output.Count - 1] += ". Skipping recursive property.";
                        output.Add("Skipping recursive property " + propertyInfo.Name + " of type " + propertyInfo.GetType());
                        continue;
                    }

                    if (!currentType.Namespace.StartsWith("System"))
                    {
                        if (currentType.IsEnum)
                        {
                            if (propertyInfo.GetValue(obj, null) == null)
                                propertyValues.Add(propertyInfo.Name, Convert.DBNull);
                            else
                            {
                                int val = (int)propertyInfo.GetValue(obj, null);
                                propertyValues.Add(propertyInfo.Name, val);
                            }
                        }
                        else if (currentType.IsValueType && !currentType.IsEnum)
                        {
                            if (propertyInfo.GetValue(obj, null) == null)
                                propertyValues.Add(propertyInfo.Name, Convert.DBNull);
                            else
                            {
                                string val = propertyInfo.GetValue(obj, null).ToString();
                                propertyValues.Add(propertyInfo.Name, val);
                            }
                        }
                        else
                        {
                            Dictionary<string, Object> subValues = GetNamesAndValues(propertyInfo.PropertyType, propertyInfo.GetValue(obj, null), ref output, ref checkedObjects);

                            foreach (var value in subValues)
                            {
                                if (value.Value == null)
                                    propertyValues.Add(propertyInfo.Name + "_" + value.Key, Convert.DBNull);
                                else
                                    propertyValues.Add(propertyInfo.Name + "_" + value.Key, value.Value);
                            }
                            //propertyValues.AddRange(propertyInfo.Name, subValues);
                        }
                    }
                    else
                    {
                        if (obj != null)
                        {
                            var value = propertyInfo.GetValue(obj, null);
                            if (value == null || (propertyInfo.PropertyType == typeof(DateTime) && value.ToString() == DateTime.MinValue.ToString()))
                                propertyValues.Add(propertyInfo.Name, Convert.DBNull);
                            else
                            {
                                propertyValues.Add(propertyInfo.Name, value);

                                bool isCollection = propertyInfo.PropertyType.GetInterfaces()
                                    .Any(x => x == typeof(IEnumerable));

                                if (isCollection)
                                {
                                    Type itemType = propertyInfo.PropertyType.GetGenericArguments()[0];
                                    output.Add("Added Collection" + propertyInfo.Name + " of type " + propertyInfo.GetType() + " and contains values of type " + itemType);
                                }
                                else
                                {
                                    output.Add("Added " + propertyInfo.Name + " of type " + propertyInfo.GetType());
                                }
                            }
                        }
                        else
                        {
                            propertyValues.Add(propertyInfo.Name, Convert.DBNull);
                        }
                    }
                }
                catch (Exception e)
                {
                    output.Add("Caught exception: " + e.Message);
                }
            }

            return propertyValues;
        }

        public static Dictionary<string, string> GetNamesAndValuesAsString(Type type, System.Object obj)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            propertyInfos = type.GetProperties();

            Dictionary<string, string> propertyValues = new Dictionary<string, string>();
            //List<object> propertyValues = new List<object>();

            foreach (var propertyInfo in propertyInfos)
            {
                //SyndicateMod.Get().setEntityInfo("Show Message", "Test message 3. Property: ");

                //if (propertyInfo.GetMethod.GetParameters() != null && propertyInfo.GetMethod.GetParameters().Length > 0)
                //    continue;
                if (propertyInfo.GetIndexParameters().Any())
                {
                    continue;
                }

                Type currentType = propertyInfo.PropertyType;
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    currentType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                }

                if (currentType.GetType() == typeof(byte[]))
                {
                    propertyValues.Add(propertyInfo.Name, BitConverter.ToString((byte[])propertyInfo.GetValue(obj, null)).Replace("-", ""));
                }
                else
                if (!currentType.Namespace.StartsWith("System"))
                {
                    if (currentType.IsEnum)
                    {
                        if (propertyInfo.GetValue(obj, null) == null)
                            propertyValues.Add(propertyInfo.Name, "Null");
                        else
                        {
                            string val = propertyInfo.GetValue(obj, null).ToString();
                            propertyValues.Add(propertyInfo.Name, val);
                        }
                    }
                    else if (currentType.IsValueType && !currentType.IsEnum)
                    {
                        if (propertyInfo.GetValue(obj, null) == null)
                            propertyValues.Add(propertyInfo.Name, "Null");
                        else
                        {
                            string val = propertyInfo.GetValue(obj, null).ToString();
                            propertyValues.Add(propertyInfo.Name, val);
                        }
                    }
                    else
                    {
                        Dictionary<string, string> subValues = GetNamesAndValuesAsString(propertyInfo.PropertyType, propertyInfo.GetValue(obj, null));

                        foreach (var value in subValues)
                        {
                            if (value.Value == null)
                                propertyValues.Add(propertyInfo.Name + "_" + value.Key, "Null");
                            else
                                propertyValues.Add(propertyInfo.Name + "_" + value.Key, value.Value);

                        }
                        //propertyValues.AddRange(propertyInfo.Name, subValues);
                    }
                }
                else
                {
                    if (obj != null)
                    {
                        if (propertyInfo.PropertyType.GetInterface("IEnumerable`1") != null && propertyInfo.PropertyType != typeof(string)) // "IEnumerable`1"
                        {
                            var collection = (IEnumerable)propertyInfo.GetValue(obj, null);

                            Dictionary<string, string> subValues = new Dictionary<string, string>();

                            int i = 0;
                            if(collection.GetType() == typeof(byte[]))
                                propertyValues.Add(propertyInfo.Name, BitConverter.ToString((byte[])collection).Replace("-", ""));
                            else
                            foreach (var x in collection)
                            {
                                if (x.GetType() == typeof(byte[]))
                                {
                                    propertyValues.Add(propertyInfo.Name + "_Collection_" + i, BitConverter.ToString((byte[])x).Replace("-", ""));
                                }
                                else
                                    foreach (var value2 in GetNamesAndValuesAsString(x.GetType(), x))
                                    {
                                        if (value2.Value == null)
                                            propertyValues.Add(propertyInfo.Name + "_Collection_" + i + "_" + value2.Key, "Null");
                                        else
                                            propertyValues.Add(propertyInfo.Name + "_Collection_" + i + "_" + value2.Key, value2.Value);
                                    }
                                    
                                i++;
                            }
                        }
                        else
                        {
                            var value = propertyInfo.GetValue(obj, null);
                            if (value == null || (propertyInfo.PropertyType == typeof(DateTime) && value.ToString() == DateTime.MinValue.ToString()))
                                propertyValues.Add(propertyInfo.Name, "Null");
                            else
                                propertyValues.Add(propertyInfo.Name, value.ToString());
                        }
                    }
                    else
                    {
                        propertyValues.Add(propertyInfo.Name, "Null");
                    }
                }
            }
            return propertyValues;
        }

        public static Dictionary<string, Type> GetNamesAndTypes(Type type)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            propertyInfos = type.GetProperties();

            // sort properties by name
            //Array.Sort(propertyInfos,
            //        delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
            //        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            Dictionary<string, Type> propertyNamesAndTypes = new Dictionary<string, Type>();

            foreach (var propertyInfo in propertyInfos)
            {
                //if (propertyInfo.GetGetMethod.GetParameters() != null && propertyInfo.GetMethod.GetParameters().Length > 0)
                //    continue;

                Type currentType = propertyInfo.PropertyType;
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    currentType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                }

                if (propertyInfo.Name == "gameObject" || propertyInfo.Name == "transform" || propertyInfo.Name == "parent" || propertyInfo.Name == "root")
                {
                    continue;
                }

                if (!currentType.Namespace.StartsWith("System"))
                {
                    if (currentType.IsEnum)
                    {
                        propertyNamesAndTypes.Add(propertyInfo.Name, typeof(int));
                    }
                    else if (currentType.IsValueType && !currentType.IsEnum)
                    {
                        propertyNamesAndTypes.Add(propertyInfo.Name, typeof(string));
                    }
                    else
                    {
                        Dictionary<string, Type> subNamesAndTypes = GetNamesAndTypes(currentType).ToDictionary(p => propertyInfo.Name + "_" + p.Key, p => p.Value); // .Select(n => (propertyInfo.Name + "_" + n)).ToArray();
                        foreach (var d in subNamesAndTypes)
                            propertyNamesAndTypes.Add(d.Key, d.Value);
                    }
                }
                else
                {
                    propertyNamesAndTypes.Add(propertyInfo.Name, currentType);
                }
            }

            return propertyNamesAndTypes;
        }

        public static Dictionary<string, Type> GetNamesAndTypes(Type type, List<string> namespaceStartsWith)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            propertyInfos = type.GetProperties();

            // sort properties by name
            //Array.Sort(propertyInfos,
            //        delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
            //        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            Dictionary<string, Type> propertyNamesAndTypes = new Dictionary<string, Type>();

            foreach (var propertyInfo in propertyInfos)
            {
                //if (propertyInfo.GetGetMethod.GetParameters() != null && propertyInfo.GetMethod.GetParameters().Length > 0)
                //    continue;

                Type currentType = propertyInfo.PropertyType;
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    currentType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                }

                if (namespaceStartsWith.Where(ns => currentType.Namespace.StartsWith(ns)).Any() || currentType.Namespace.StartsWith("RPSOAPServiceReference"))
                {
                    if (currentType.IsEnum)
                    {
                        propertyNamesAndTypes.Add(propertyInfo.Name, typeof(int));
                    }
                    else if (currentType.IsValueType && !currentType.IsEnum)
                    {
                        propertyNamesAndTypes.Add(propertyInfo.Name, typeof(string));
                    }
                    else
                    {
                        Dictionary<string, Type> subNamesAndTypes = GetNamesAndTypes(currentType, namespaceStartsWith).ToDictionary(p => propertyInfo.Name + "_" + p.Key, p => p.Value); // .Select(n => (propertyInfo.Name + "_" + n)).ToArray();

                        //propertyNamesAndTypes.Concat(subNamesAndTypes).GroupBy(kvp => kvp.Key, propertyNamesAndTypes.Comparer).ToDictionary(grp => grp.Key, grp => grp.First(), propertyNamesAndTypes.Comparer);
                        //propertyNamesAndTypes.Union(subNamesAndTypes)
                        //    .GroupBy(kvp => kvp.Key)
                        //    .Select(grp => grp.FirstOrDefault())
                        //    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        foreach (var d in subNamesAndTypes)
                            propertyNamesAndTypes.Add(d.Key, d.Value);
                        //propertyNamesAndTypes.AddRange(subNamesAndTypes);
                    }
                }
                else
                {
                    propertyNamesAndTypes.Add(propertyInfo.Name, currentType);
                }
            }

            return propertyNamesAndTypes;
        }

        //public static Dictionary<string, Object> GetNamesAndValues(Type type, Object obj, List<string> namespaceStartsWith)
        //{
        //    // get all public static properties of MyClass type
        //    PropertyInfo[] propertyInfos;

        //    propertyInfos = type.GetProperties();

        //    Dictionary<string, Object> propertyValues = new Dictionary<string, object>();
        //    //List<object> propertyValues = new List<object>();

        //    foreach (var propertyInfo in propertyInfos)
        //    {
        //        //if (propertyInfo.GetMethod.GetParameters() != null && propertyInfo.GetMethod.GetParameters().Length > 0)
        //        //    continue;

        //        Type currentType = propertyInfo.PropertyType;
        //        if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            currentType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
        //        }

        //        if (namespaceStartsWith.Where(ns => currentType.Namespace.StartsWith(ns)).Any() || currentType.Namespace.StartsWith("RPSOAPServiceReference"))
        //        {
        //            if (currentType.IsEnum)
        //            {
        //                if (propertyInfo.GetValue(obj, null) == null)
        //                    propertyValues.Add(propertyInfo.Name, Convert.DBNull);
        //                else
        //                {
        //                    int val = (int)propertyInfo.GetValue(obj, null);
        //                    propertyValues.Add(propertyInfo.Name, val);
        //                }
        //            }
        //            else if (currentType.IsValueType && !currentType.IsEnum)
        //            {
        //                if (propertyInfo.GetValue(obj, null) == null)
        //                    propertyValues.Add(propertyInfo.Name, Convert.DBNull);
        //                else
        //                {
        //                    string val = propertyInfo.GetValue(obj, null).ToString();
        //                    propertyValues.Add(propertyInfo.Name, val);
        //                }
        //            }
        //            else
        //            {
        //                Dictionary<string, Object> subValues = GetNamesAndValues(propertyInfo.PropertyType, propertyInfo.GetValue(obj, null), namespaceStartsWith);

        //                foreach (var value in subValues)
        //                {
        //                    if (value.Value == null)
        //                        propertyValues.Add(propertyInfo.Name + "_" + value.Key, Convert.DBNull);
        //                    else
        //                        propertyValues.Add(propertyInfo.Name + "_" + value.Key, value.Value);

        //                }
        //                //propertyValues.AddRange(propertyInfo.Name, subValues);
        //            }
        //        }
        //        else
        //        {
        //            if (obj != null)
        //            {
        //                var value = propertyInfo.GetValue(obj, null);
        //                if (value == null || (propertyInfo.PropertyType == typeof(DateTime) && value.ToString() == DateTime.MinValue.ToString()))
        //                    propertyValues.Add(propertyInfo.Name, Convert.DBNull);
        //                else
        //                    propertyValues.Add(propertyInfo.Name, value);
        //            }
        //            else
        //            {
        //                propertyValues.Add(propertyInfo.Name, Convert.DBNull);
        //            }
        //        }
        //    }
        //    return propertyValues;
        //}
        /*
        public static IEnumerable<String> GetNames(IEnumerable<Object> objects, string nameProperty = "Name")
        {
            foreach (var instance in objects)
            {
                var type = instance.GetType();
                var property = type.GetProperty(nameProperty);
                yield return property.GetValue(instance, null) as string;
            }
        }

        public static string[] GetNames(Type type)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            //propertyInfos = type.GetProperties
            //    (BindingFlags.Public | 
            //    BindingFlags.Static);

            propertyInfos = type.GetProperties();
            //propertyInfos = type.GetProperties(BindingFlags.Default);

            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            List<string> propertyNames = new List<string>();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType.Namespace.StartsWith("RPSOAPServiceReference"))
                {
                    string[] subNames = GetNames(propertyInfo.PropertyType).Select(n => (propertyInfo.Name + "_" + n)).ToArray();
                    propertyNames.AddRange(subNames);
                }
                else
                {
                    propertyNames.Add(propertyInfo.Name);
                }
            }

            return propertyNames.ToArray();
        }

        public static string[] GetValuesAsStrings(Type type, Object obj)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            //propertyInfos = type.GetProperties
            //    (BindingFlags.Public | 
            //    BindingFlags.Static);

            propertyInfos = type.GetProperties();
            //propertyInfos = type.GetProperties(BindingFlags.Default);

            // sort properties by name

            //Array.Sort(propertyInfos,
            //        delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
            //        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            List<string> propertyValues = new List<string>();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType.Namespace.StartsWith("RPSOAPServiceReference"))
                {
                    string[] subValues = GetValuesAsStrings(propertyInfo.PropertyType, propertyInfo.GetValue(obj, null)).ToArray();
                    propertyValues.AddRange(subValues);
                }
                else
                {
                    //DefinedTypes.FirstOrDefault(x => x.GetDeclaredProperty("functionCode") != null && 
                    //!x.IsAbstract && x.BaseType == typeof(MyClass) && 
                    //(byte)x.GetDeclaredProperty("functionCode").GetValue(Activator.CreateInstance(x.AsType()), null) == val);
                    if (obj != null)
                    {
                        var value = propertyInfo.GetValue(obj);
                        if (value == null)
                            propertyValues.Add(null);
                        else
                            propertyValues.Add(value.ToString());
                    }
                    else
                    {
                        propertyValues.Add(null);
                    }
                }
            }
            return propertyValues.ToArray();
        }

        public static object[] GetValues(Type type, Object obj)
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;

            propertyInfos = type.GetProperties();

            List<object> propertyValues = new List<object>();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType.Namespace.StartsWith("RPSOAPServiceReference"))
                {
                    if (propertyInfo.PropertyType.IsEnum)
                    {
                        int val = (int)propertyInfo.GetValue(obj, null);
                        propertyValues.Add(val);
                    }
                    else if (propertyInfo.PropertyType.IsValueType && !propertyInfo.PropertyType.IsEnum)
                    {
                        string val = propertyInfo.GetValue(obj, null).ToString();
                        propertyValues.Add(val);
                    }
                    else
                    {
                        object[] subValues = GetValues(propertyInfo.PropertyType, propertyInfo.GetValue(obj, null)).ToArray();
                        propertyValues.AddRange(subValues);
                    }
                }
                else
                {
                    if (obj != null)
                    {
                        var value = propertyInfo.GetValue(obj);
                        if (value == null)
                            propertyValues.Add(null);
                        else
                            propertyValues.Add(value);
                    }
                    else
                    {
                        propertyValues.Add(null);
                    }
                }
            }
            return propertyValues.ToArray();
        }
        */
        private List<Type> _systemTypes;
        public List<Type> SystemTypes
        {
            get
            {
                if (_systemTypes == null)
                {
                    _systemTypes = Assembly.GetExecutingAssembly().GetType().Module.Assembly.GetExportedTypes().ToList();
                }
                return _systemTypes;
            }
        }

        //public static string ConvertToCsv<T>(IEnumerable<T> items)
        //{
        //    foreach (T item in items.Where(i => SystemTypes.Contains(i.GetType())))
        //    {
        //        // is system type
        //    }
        //}
    }
    public class GenericPropertyFinder<TModel> where TModel : class
    {
        public void PrintTModelPropertyAndValue(TModel tmodelObj)
        {
            //Getting Type of Generic Class Model
            Type tModelType = tmodelObj.GetType();

            //We will be defining a PropertyInfo Object which contains details about the class property 
            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

            //Now we will loop in all properties one by one to get value
            foreach (PropertyInfo property in arrayPropertyInfos)
            {
                Console.WriteLine("Name of Property is\t:\t" + property.Name);
                if (property.GetValue(tmodelObj, null) != null)
                    Console.WriteLine("Value of Property is\t:\t" + property.GetValue(tmodelObj, null).ToString());
                else
                    Console.WriteLine("Value of Property is\t:\t null");

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
