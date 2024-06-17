int n = Convert.ToInt32(Console.ReadLine());
MyDerivedClass[] myDerivedClasses1 = new MyDerivedClass[n];
MyDerivedClass[] myDerivedClasses2 = new MyDerivedClass[n];

for (int i = 0; i < n; i++)
{
    myDerivedClasses1[i] = new($"Random {Random.Shared.Next()}", Random.Shared.Next() % 2 == 1);
    myDerivedClasses2[i] = new($"Random {Random.Shared.Next()}", Random.Shared.Next() % 2 == 1);
}

Console.WriteLine(myDerivedClasses1.ToList().FindAll(p => p.MyBool == false)
    .Count >= myDerivedClasses2.ToList().FindAll(p => p.MyBool == false)
    .Count ? "Больше в первом" : "Больше во втором");

Console.WriteLine("1:");
foreach (var item in myDerivedClasses1)
{
    Console.Write($"{item}, ");
}
Console.WriteLine("\n2:");
foreach (var item in myDerivedClasses2)
{
    Console.Write($"{item}, ");
}

class MyClass
{
    public string MyString { get; set; }
    public bool MyBool { get; set; }
    public MyClass(string str, bool b)
    {
        MyBool = b;
        MyString = str;
    }
}

class MyDerivedClass : MyClass
{
    public MyDerivedClass(string str, bool b) : base(str, b)
    { }

    public override string ToString()
    {
        return $"{MyString} - {MyBool}";
    }
}