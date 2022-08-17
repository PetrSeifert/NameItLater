using System.Collections.Generic;
using System;
using System.Reflection;

public class ReflectionHelper
{
    public static List<Type> FindDerivedTypes(Type baseType)
    {
        List<Type> typeList = new List<Type>();
        Assembly assembly = baseType.Assembly;
        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsSubclassOf(baseType)) typeList.Add(type);
        }
        return typeList;
    }
}
