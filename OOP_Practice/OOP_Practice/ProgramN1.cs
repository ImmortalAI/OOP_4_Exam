int a = Convert.ToInt32(Console.ReadLine());
MyClass[] myClasses = new MyClass[a];

for (int i = 0; i < myClasses.Length; i++)
{
    myClasses[i] = new(Random.Shared.Next(), $"Hello {Random.Shared.Next()}");
}
foreach (MyClass myClass in myClasses)
{
    Console.WriteLine(myClass);
}

class MyClass
{
    int MyInt { get; set; }
    string MyString { get; set; }
    public MyClass(int myInt, string myString)
    {
        MyInt = myInt;
        MyString = myString;
    }

    public override string ToString()
    {
        return $"{MyInt}: {MyString}";
    }
}