using System.Reflection;

typeof(MyClass).GetMethod("PrintMyString", BindingFlags.NonPublic | BindingFlags.Static)?.Invoke(null, new object[] { "Hello from Outside!" });

class MyClass
{
    private static void PrintMyString(string s)
    {
        Console.WriteLine(s);
    }
}