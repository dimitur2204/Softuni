using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        var classType = Type.GetType(className);
        var fields = classType.GetFields(
            BindingFlags.NonPublic
            | BindingFlags.Instance
            | BindingFlags.Public);
        var hackerObject = Activator.CreateInstance(classType, new object[] { });
        var result = new StringBuilder();
        result.AppendLine($"Class under investigation: {classType.Name}");
        foreach (var field in fields)
        {
            foreach (var fieldName in fieldNames)
            {
                if (fieldName == field.Name)
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(hackerObject)}");
                }
            }
        }
        return result.ToString().Trim();
    }
    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);
        var fields = classType.GetFields();
        var methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        var result = new StringBuilder();
        foreach (var field in fields)
        {
            if (field.IsPublic)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
        }
        foreach (var method in methods)
        {
            if (
                method.Name
                .Split("_")
                .First() == "get")
            {
                if (!method.IsPublic)
                {
                    result.AppendLine($"{method.Name} have to be public!");
                }
            }
        }
        foreach (var method in methods)
        {
            if (
                method.Name
                .Split("_")
                .First() == "set")
            {
                if (method.IsPublic)
                {
                    result.AppendLine($"{method.Name} have to be private!");
                }
            }
        }
        return result.ToString().Trim();
    }
    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);
        var methods = classType.GetMethods(
            BindingFlags.NonPublic | 
            BindingFlags.Instance);
        var result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var method in methods)
        {
            result.AppendLine(method.Name);
        }
        return result.ToString();
    }
    public string CollectGettersAndSetters(string className) 
    {
        var classType = Type.GetType(className);
        var methods = classType.GetMethods(
            BindingFlags.NonPublic | 
            BindingFlags.Instance | 
            BindingFlags.Public);
        var result = new StringBuilder();
        var getters = new List<MethodInfo>();
        var setters = new List<MethodInfo>();
        foreach (var method in methods)
        {
            if (method.Name.StartsWith("get"))
            {
                getters.Add(method);
            }
            else if (method.Name.StartsWith("set"))
            {
                setters.Add(method);
            }
        }
        //{name} will return {Return Type}
        foreach (var getter in getters)
        {
            result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }
        foreach (var setter in setters)
        {
            result.AppendLine($"{setter.Name} will set field of {setter.GetParameters()[0].ParameterType}");
        }
        return result.ToString();
    }
}
