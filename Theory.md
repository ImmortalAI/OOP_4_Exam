1. Описание языка программирования С# и платформы .NET. 

C# является языком с Си-подобным синтаксисом и близок в этом отношении к C++ и Java.

C# является объектно-ориентированным и в этом плане много перенял у Java и С++. Например, C# поддерживает полиморфизм, наследование, перегрузку операторов, статическую типизацию.

Можно выделить следующие основные черты .NET:

- Поддержка нескольких языков. 
  Основой платформы является общеязыковая среда исполнения Common Language Runtime (CLR), ; при компиляции код на любом из этих языков компилируется в сборку на общем языке CIL (Common Intermediate Language).
- Кроссплатформенность. 
  .NET является переносимой платформой (с некоторыми ограничениями).
- Мощная библиотека классов. 
  .NET представляет единую для всех поддерживаемых языков библиотеку классов.
- Разнообразие технологий. 
  Общеязыковая среда исполнения CLR и базовая библиотека классов являются основой для целого стека технологий, которые разработчики могут задействовать при построении тех или иных приложений. Например, ADO.NET и Entity Framework Core для работы с базами данных, для построения графических приложений - технология WPF и WinUI (попроще, Windows Forms), для разработки кроссплатформенных мобильных и десктопных приложений - Xamarin/MAUI, для создания веб-сайтов и веб-приложений - ASP.NET и т.д.
- Производительность. 
  Согласно ряду тестов веб-приложения на .NET в ряде категорий сильно опережают веб-приложения, построенные с помощью других технологий.

Нередко приложение, созданное на C#, называют **управляемым кодом** (managed code). Это значит, что данное приложение создано на основе платформы .NET и поэтому управляется общеязыковой средой CLR, которая загружает приложение и при необходимости очищает память.

Код на C# компилируется в приложения или сборки с расширениями exe или dll на языке CIL. Далее при запуске на выполнение подобного приложения происходит JIT-компиляция (Just-In-Time) в машинный код, который затем выполняется. При этом, поскольку наше приложение может быть большим и содержать кучу инструкций, в текущий момент времени будет компилироваться лишь та часть приложения, к которой непосредственно идет обращение. Если мы обратимся к другой части кода, то она будет скомпилирована из CIL в машинный код. При том уже скомпилированная часть приложения сохраняется до завершения работы программы. В итоге это повышает производительность.

2. Основные принципы объектно-ориентированного программирования и примеры их реализации в языке программирования C#.

Объектно-ориентированное программирование основано на **четырех основных принципах**:

- Абстракция: абстрактное поведение объектов обобщается в классах
  ```csharp
  public abstract class Vehicle
    {
        public abstract void StartEngine();
        public abstract void StopEngine();

        public void Drive()
        {
            StartEngine();
            Console.WriteLine("Driving...");
            StopEngine();
        }
    }

    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started");
        }

        public override void StopEngine()
        {
            Console.WriteLine("Car engine stopped");
        }
    }
  ```

- Инкапсуляция данных: свойства и методы инкапсулируются в виде классов и скрыты от внешнего доступа.
  public class BankAccount
  ```csharp
  {
    private decimal balance;

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
  }
  ```

- Наследование: свойства и методы могут быть унаследованы одним классом от другого класса
  ```csharp
  public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
    }
  ```

- Полиморфизм: множество форм - объекты могут принимать различные формы в зависимости от их использования
  ```csharp
  public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }
  ```

3. Ссылочный и значимый типы данных. Примеры, объявление и инициализация переменных. Понятие nullable типов данных.

Все типы данных можно разделить на типы значений, еще называемые значимыми типами (value types), и ссылочные типы (reference types).

Типы значений:

- Целочисленные типы (`byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`)
- Типы с плавающей запятой (`float`, `double`)
- Тип `decimal`
- Тип `bool`
- Тип `char`
- Перечисления `enum`
- Структуры (`struct`)

Ссылочные типы:

- Тип `object`
- Тип `string`
- Классы (`class`)
- Интерфейсы (`interface`)
- Делегаты (`delegate`)

Для понимания разницы между ними необходимо знать организацию памяти в .NET. Здесь память делится на два типа: стек и куча (heap). 

Параметры и переменные метода, которые представляют типы значений, размещают свое значение в стеке. Причем в стеке будет храниться непосредственное значение этого параметра или переменной. 

Ссылочные типы хранятся в куче, или хипе, которую можно представить как неупорядоченный набор разнородных объектов. Физически это остальная часть памяти, которая доступна процессу.

При создании объекта ссылочного типа в стеке помещается ссылка на адрес в куче (хипе). Когда объект ссылочного типа перестает использоваться, в дело вступает автоматический сборщик мусора: он видит, что на объект в хипе нету больше ссылок, условно удаляет этот объект и очищает память - фактически помечает, что данный сегмент памяти может быть использован для хранения других данных.

Кроме стандартных значений типа чисел, строк, язык C# имеет специальное значение - `null`, которое фактически указывает на отсутствие значения как такового, отсутствие данных. До сих пор значение `null` выступает как значение по умолчанию для ссылочных типов.

В различных ситуациях бывает удобно, чтобы объекты могли принимать значение null, то есть были бы не определены. Стандартный пример - работа с базой данных, которая может содержать значения null. И мы можем заранее не знать, что мы получим из базы данных - какое-то определенное значение или же null.

При этом подобные ссылочные типы, которые допускают присвоение значения null, доступно только в nullable-контексте. Для nullable-контекста характерны следующие особенности:

- Переменную ссылочного типа следует инициализировать конкретным значением, ей не следует присваивать значение null
- Переменной ссылочного nullable-типа можно присвоить значение null, но перед использование необходимо проверять ее на значение null.

```csharp
string? name = null;
PrintUpper(name); // NullReferenceException

void PrintUpper(string? text)
{
    Console.WriteLine(text.ToUpper());
}
```

В отличие от ссылочных типов переменным/параметрам значимых типов нельзя напрямую присвоить значение `null`. Чтобы присвоения переменной или параметру значимого типа значения `null`, эти переменная/параметр значимого типа должны представлять тип nullable.

Стоит отметить, что фактически запись ? для значимых типов является упрощенной формой использования структуры `System.Nullable<T>`.

Структура `Nullable<T>` имеет два свойства:

`Value` : значение объекта

`HasValue` : возвращает `true`, если объект хранит некоторое значение, и `false`, если объект равен `null`.

1. Преобразование ссылочных и значимых типов данных. 

**Неявное преобразование типов (implicit conversion)**

Неявное преобразование типов происходит автоматически компилятором, когда выполняется преобразование от типа с меньшей точностью к типу с большей точностью. Оно безопасно и не теряет данных.

В C# неявные преобразования допустимы для следующих пар типов:

- От меньшего к большему целому типу (`byte` -> `short`, `short` -> `int`, `int` -> `long`, и т.д.)
- От целого типа к типу с плавающей точкой (`int` -> `float`, `float` -> `double`)
- От типа, реализующего интерфейс, к интерфейсу (например, класс `MyClass` к интерфейсу `IMyInterface`)
- От производного класса к базовому классу

**Явное преобразование типов (explicit conversion)**

Явное преобразование требует указания типа для преобразования. Оно используется, когда существует вероятность потери данных или когда требуется явное указание на преобразование типов.

**Перегрузка операторов преобразования**

В C# можно перегружать операторы преобразования для пользовательских типов. Это позволяет создавать пользовательские преобразования, как явные, так и неявные. Для этого используются ключевые слова `implicit` и `explicit`.

Пример неявного преобразования:

```csharp
public class Celsius
{
    public double Degrees { get; }
    
    public Celsius(double degrees)
    {
        Degrees = degrees;
    }
    
    // Неявное преобразование от Celsius к double
    public static implicit operator double(Celsius c)
    {
        return c.Degrees;
    }
    
    // Неявное преобразование от double к Celsius
    public static implicit operator Celsius(double d)
    {
        return new Celsius(d);
    }
}
```

Пример явного преобразования:

```csharp
public class Fahrenheit
{
    public double Degrees { get; }

    public Fahrenheit(double degrees)
    {
        Degrees = degrees;
    }
    
    // Явное преобразование от Fahrenheit к Celsius
    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((f.Degrees - 32) * 5 / 9);
    }
    
    // Явное преобразование от Celsius к Fahrenheit
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit(c.Degrees * 9 / 5 + 32);
    }
}
```

В этом примере можно использовать преобразования следующим образом:

```csharp
Celsius celsius = new Celsius(25);
double degrees = celsius; // Неявное преобразование
Celsius celsius2 = degrees; // Неявное преобразование

Fahrenheit fahrenheit = new Fahrenheit(77);
Celsius celsius3 = (Celsius)fahrenheit; // Явное преобразование
Fahrenheit fahrenheit2 = (Fahrenheit)celsius; // Явное преобразование
```

5. Массивы (одномерные, многомерные, ступенчатые\рваные\зубчатые). Объявление и инициализация массивов. Методы класса Array

**Массив** представляет набор однотипных данных. Объявление массива похоже на объявление переменной за тем исключением, что после указания типа ставятся квадратные скобки:

```
тип_переменной[] название_массива;
```

Например, определим массив целых чисел:

```csharp
int[] numbers;

int[] numbers2 = new int[4] { 1, 2, 3, 5 };
 
int[] numbers3 = new int[] { 1, 2, 3, 5 };
 
int[] numbers4 = new[] { 1, 2, 3, 5 };
 
int[] numbers5 = { 1, 2, 3, 5 };
```

Массивы характеризуются таким понятием как **ранг** или количество измерений. Выше мы рассматривали массивы, которые имеют одно измерение (то есть их ранг равен 1) - такие массивы можно представлять в виде ряда (строки или столбца) элемента. Но массивы также бывают многомерными. У таких массивов количество измерений (то есть ранг) больше 1.

Массивы которые имеют два измерения (ранг равен 2) называют **двухмерными**. Например, создадим одномерный и двухмерный массивы, которые имеют одинаковые элементы:

```csharp
int[] numbers1 = new int[] { 0, 1, 2, 3, 4, 5 };
 
int[,] numbers2 = { { 0, 1, 2 }, { 3, 4, 5 } };
```

От многомерных массивов надо отличать массив массивов или так называемый **"зубчатый массив"**:

```csharp
int[][] numbers = { 
    new int[] { 1, 2 }, 
    new int[] { 1, 2, 3 }, 
    new int[] { 1, 2, 3, 4, 5 } 
};
```

Используя вложенные циклы, можно перебирать зубчатые массивы. Например:

```csharp
foreach(int[] row in numbers)
{
    foreach(int number in row)
    {
        Console.Write($"{number} \t");
    }
    Console.WriteLine();
}
```

**Основные понятия массивов**

- Ранг (rank): количество измерений массива
- Длина измерения (dimension length): длина отдельного измерения массива
- Длина массива (array length): количество всех элементов массива

**Методы класса Array**

* `GetLength(int)` - длина массива
* `GetUpperBound(int)` - индекс последнего элемента **в указанной размерности**

6. Условные операторы и операторы цикла. Примеры.

**Условные конструкции** - один из базовых компонентов многих языков программирования, которые направляют работу программы по одному из путей в зависимости от определенных условий.

**`if`..`else`**

```csharp
string name = "Alex";
 
if (name == "Tom")
    Console.WriteLine("Вас зовут Tomas");
else if (name == "Bob")
    Console.WriteLine("Вас зовут Robert");
else if (name == "Mike")
    Console.WriteLine("Вас зовут Michael");
else
    Console.WriteLine("Неизвестное имя");
```

**Тернарная операция**

```csharp
int x = 3;
int y = 2;
 
int z = x < y ? (x+y) : (x-y);
Console.WriteLine(z);   // 1
```

**Циклы** являются управляющими конструкциями, позволяя в зависимости от определенных условий выполнять некоторое действие множество раз. В C# имеются следующие виды циклов:

- `for`
- `foreach`
- `while`
- `do`..`while`

```csharp
for (int i = 1; i < 4; i++)
{
    Console.WriteLine(i);
}
```

```csharp
int i = 6;
do
{
    Console.WriteLine(i);
    i--;
}
while (i > 0);
```

```csharp
int i = 6;
while (i > 0)
{
    Console.WriteLine(i);
    i--;
}
```

```csharp
foreach(char c in "Tom")
{
    Console.WriteLine(c);
}
```

Иногда возникает ситуация, когда требуется выйти из цикла, не дожидаясь его завершения. В этом случае мы можем воспользоваться оператором `break`. А если мы хотим, чтобы при проверке цикл не завершался, а просто пропускал текущую итерацию, тогда мы можем воспользоваться оператором `continue`.

7. Классы. Определение класса, объявление и инициализация переменных типа класса. Элементы класса. Примеры.

Описанием объекта является **класс**, а объект представляет **экземпляр** этого класса.

По сути класс представляет новый тип, который определяется пользователем. Класс определяется с помощью ключевого слова `class`. Класс может хранить некоторые данные, для этого в классе применяются поля. 

```csharp
class Person 
{
    public string name = "Undefined";
    public int age;
 
    public void Print()
    {
        Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }
}
```

В классе `Person` определен метод `Print()`. Методы класса имеют доступ к его полям, и в данном случае мы обращаемся к полям класса `name` и `age` для вывода их значения на консоль. Чтобы этот метод был виден вне класса, он также определен с модификатором `public`.

После определения класса мы можем создавать его объекты. Для создания объекта применяются **конструкторы**.

```csharp
new конструктор_класса(параметры_конструктора);
```

Кроме обычных методов в языке C# предусмотрены специальные методы доступа, которые называют **свойства**. Они обеспечивают простой доступ к полям классов и структур, чтобы узнать их значение или выполнить их установку.

```csharp
public string Property { get; set; }
```

8. Модификаторы передаваемых в методы параметров (in, out, ref). Примеры. 

При **передаче параметров по ссылке** перед параметрами используется модификатор `ref`

```csharp
void Increment(ref int n)
{
    n++;
}
 
int number = 5;
Increment(ref number); // number = 6
```

Параметры могут быть также **выходными**. Чтобы сделать параметр выходным, перед ним ставится модификатор `out`:

```csharp
void Sum(int x, int y, out int result)
{
    result = x + y;
}
 
Sum(10, 15, out int number); // number = 25
```

При этом, если нам неизвестен тип значений, которые будут присвоены параметрам, то мы можем для их определения использовать оператор `var`:

```csharp
void GetRectangleData(int width, int height, out int rectArea, out int rectPerimeter)
{
    rectArea = width * height;  
    rectPerimeter = (width + height) * 2; 
}

GetRectangleData(10, 20, out var area, out var perimeter);
```

Кроме выходных параметров с модификатором `out` метод может использовать **входные параметры** с модификатором `in`. Модификатор `in` указывает, что данный параметр будет передаваться в метод по ссылке, однако внутри метода его значение параметра нельзя будет изменить. Например:

```csharp
void GetRectangleData(in int width, in int height, out int rectArea, out int rectPerimeter)
{
    //width = 25; // нельзя изменить, так как width - входной параметр
    rectArea = width * height;      
    rectPerimeter = (width + height) * 2;
}
 
int w = 10;
int h = 20;
GetRectangleData(w, h, out var area, out var perimeter);
```

9. Организация наследования в языке программирования C#. Механизмы запрета наследования.

**Наследование** (inheritance) является одним из ключевых моментов ООП. Благодаря наследованию один класс может унаследовать функциональность другого класса.

```csharp
class Person
{
    private string _name = "";
 
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public void Print()
    {
        Console.WriteLine(Name);
    }
}

class Employee : Person
{
     
}
```

Для класса `Employee` базовым является `Person`, и поэтому класс `Employee` наследует все те же свойства, методы, поля, которые есть в классе `Person`. Единственное, что не передается при наследовании, это конструкторы базового класса с параметрами.

Таким образом, наследование реализует отношение is-a (является), объект класса Employee также является объектом класса Person

```csharp
Person person = new Employee { Name = "Tom" };
```

По умолчанию все классы наследуются от базового класса `Object`, даже если мы явным образом не устанавливаем наследование. Поэтому выше определенные классы `Person` и `Employee` кроме своих собственных методов, также будут иметь и методы класса `Object`: `ToString()`, `Equals()`, `GetHashCode()` и `GetType()`.

Все классы по умолчанию могут наследоваться. Однако здесь есть ряд ограничений:

- Не поддерживается множественное наследование, класс может наследоваться только от одного класса.
- При создании производного класса надо учитывать тип доступа к базовому классу - тип доступа к производному классу должен быть таким же, как и у базового класса, или более строгим. То есть, если базовый класс у нас имеет тип доступа internal, то производный класс может иметь тип доступа internal или private, но не public.
- Если класс объявлен с модификатором sealed, то от этого класса нельзя наследовать и создавать производные классы. Например, следующий класс не допускает создание наследников

  ```csharp
  sealed class Admin
  { }
  ```

- Нельзя унаследовать класс от статического класса.

10. Специальные методы: конструктор и финализатор. Объявление и вызов. Наследование специальных методов.

Как правило, **конструктор** выполняет инициализацию объекта. При этом если в классе определяются свои конструкторы, то он лишается конструктора по умолчанию.

На уровне кода конструктор представляет метод, который называется по имени класса, который может иметь параметры, но для него не надо определять возвращаемый тип.

```csharp
Person sam = new("Sam", 25); 
sam.Print(); // Имя: Sam  Возраст: 25

class Person 
{
    public string name;
    public int age;
    public Person()
    {
        Console.WriteLine("Создание объекта Person");
        name = "Tom";
        age = 37;
    }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}
```

Если конструкторов несколько, мы можем не дублировать их функциональность, а просто обращаться из одного конструктора к другому через ключевое слово this, передавая нужные значения для параметров:

```csharp
class Person 
{
    public string name;
    public int age;
    public Person() : this("Неизвестно")
    { }
    public Person(string name) : this(name, 18)
    { }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}
```

Большинство объектов, используемых в программах на C#, относятся к **управляемым** или **managed-коду**. Такие объекты управляются CLR и легко очищаются сборщиком мусора. Однако вместе с тем встречаются также и такие объекты, которые задействуют **неуправляемые объекты** (подключения к файлам, базам данных, сетевые подключения и т.д.).

Освобождение неуправляемых ресурсов подразумевает реализацию одного из двух механизмов:

* Создание деструктора
* Реализация классом интерфейса `System.IDisposable`

Например, определим в классе Person простейший деструктор:

```csharp
class Person
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    ~Person()
    {
        Console.WriteLine($"{Name} has deleted");
    }
}
```

На деле при очистке сборщик мусора вызывает не деструктор, а метод `Finalize`. Данный метод уже определен в базовом для всех типов классе `Object`, однако данный метод нельзя так просто переопределить, и фактическая его реализация происходит через создание деструктора.

Обратите внимание, что даже после завершения метода и соответственно удаления из стека ссылки на объект `Person` в куче, может не последовать немедленного вызова деструктора. С .NET 5 и в последующих версиях при завершении программы деструкторы также не вызываются. Поэтому для очистки памяти и вызова деструктора применяется метод `GC.Collect`.

Второй подход к освобождению неуправляемых ресурсов - интерфейс `IDisposable`

Интерфейс `IDisposable` объявляет один единственный метод `Dispose`, в котором при реализации интерфейса в классе должно происходить освобождение неуправляемых ресурсов. 

```csharp
Test();
 
void Test()
{
    Person? tom = null;
    try
    {
        tom = new Person("Tom");
    }
    finally
    {
        tom?.Dispose();
    }
}
 
public class Person : IDisposable
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    public void Dispose()
    {
        Console.WriteLine($"{Name} has been disposed");
    }
}
```

Microsoft предлагает нам использовать следующий формализованный шаблон с комбинацией обоих методов:



```csharp
public class SomeClass: IDisposable
{
    private bool disposed = false;
 
    // реализация интерфейса IDisposable.
    public void Dispose()
    {
        // освобождаем неуправляемые ресурсы
        Dispose(true);
        // подавляем финализацию
        GC.SuppressFinalize(this);
    }
 
    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            // Освобождаем управляемые ресурсы
        }
        // Освобождаем неуправляемые объекты
        disposed = true;
    }
 
    // Деструктор
    ~SomeClass()
    {
        Dispose (false);
    }
}
```

Общие рекомендации по использованию `Finalize` и `Dispose`:

* Деструктор следует реализовывать только у тех объектов, которым он действительно необходим, так как метод `Finalize` оказывает **сильное влияние на производительность**;
* После вызова метода Dispose необходимо блокировать у объекта вызов метода `Finalize` с помощью `GC.SuppressFinalize(this)`;
* При создании производных классов от базовых, которые реализуют интерфейс `IDisposable`, следует также вызывать метод `Dispose` базового класса;
* Отдавайте предпочтение **комбинированному шаблону**, реализующему как метод `Dispose`, так и деструктор.

11. Виртуальные элементы класса. Переопределение методов и операторов. Примеры.

При наследовании нередко возникает необходимость изменить в классе-наследнике функционал метода, который был унаследован от базового класса. В этом случае класс-наследник может переопределять методы и свойства базового класса.

Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором `virtual`. Такие методы и свойства называют **виртуальными**.

А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором `override`. Переопределенный метод в классе-наследнике должен иметь тот же набор параметров, что и виртуальный метод в базовом классе.

```csharp
Person bob = new Person("Bob");
bob.Print(); // Bob
 
Employee tom = new Employee("Tom", "Microsoft");
tom.Print(); // Tom работает в Microsoft

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }
    public override void Print()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}
```

При переопределении виртуальных методов следует учитывать ряд ограничений:

* Виртуальный и переопределенный методы должны иметь один и тот же модификатор доступа. То есть если виртуальный метод определен с помощью модификатора `public`, то и переопределенный метод также должен иметь модификатор `public`.
* Нельзя переопределить или объявить виртуальным статический метод.

Также как и методы, можно переопределять свойства:

```csharp
class Person
{
    int age = 1;
    public virtual int Age
    {
        get => age;
        set{ if(value > 0 && value < 110) age = value; }
    }
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print() => Console.WriteLine(Name);
}
class Employee : Person
{
    public override int Age
    {
        get => base.Age;
        set { if (value > 17 && value < 110) base.Age = value; }
    }
    public string Company { get; set; }
    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
        base.Age = 18;
    }
}
```

Определение операторов заключается в определении в классе, для объектов которого мы хотим определить оператор, специального метода:

```csharp
public static возвращаемый_тип operator оператор(параметры)
{  }
```

12. Абстрактные классы. Абстрактные элементы классов. 

**Абстрактный класс** похож на обычный класс. Он также может иметь переменные, методы, конструкторы, свойства. Единственное, что при определении абстрактных классов используется ключевое слово `abstract`. Например, определим абстрактный класс, который представляет некое транспортное средство:


```csharp
abstract class Transport
{
    public void Move()
    {
        Console.WriteLine("Транспортное средство движется");
    }
}
```

Но главное отличие абстрактных классов от обычных состоит в том, что мы **не можем** использовать конструктор абстрактного класса для создания экземпляра класса. 

Кроме обычных свойств и методов абстрактный класс может иметь **абстрактные члены классов**, которые определяются с помощью ключевого слова `abstract` и не имеют никакого функционала. В частности, абстрактными могут быть:

- Методы
- Свойства
- Индексаторы
- События

Абстрактные члены классов не должны иметь модификатор `private`. При этом производный класс обязан переопределить и реализовать все абстрактные методы и свойства, которые имеются в базовом абстрактном классе. При переопределении в производном классе такой метод или свойство также объявляются с модификатором `override`. Также следует учесть, что если класс имеет хотя бы один абстрактный метод (или абстрактные свойство, индексатор, событие), то этот класс должен быть определен как **абстрактный**.

Хрестоматийным примером является система геометрических фигур.

```csharp
abstract class Shape
{
    public abstract double GetPerimeter();
    public abstract double GetArea();
}
class Rectangle : Shape
{
    public float Width { get; set; }
    public float Height { get; set; }
 
    public override double GetPerimeter() => Width * 2 + Height * 2;
    public override double GetArea() => Width * Height;
}
class Circle : Shape
{
    public double Radius { get; set; }
 
    public override double GetPerimeter() => Radius * 2 * 3.14;
    public override double GetArea() => Radius * Radius * 3.14;
}
```

13. Интерфейсы. Интерфейсные ссылки. Механизм внедрения зависимостей Dependency Injection (DI).

Для определения интерфейса используется ключевое слово `interface`. Как правило, названия интерфейсов в C# начинаются с заглавной буквы I, например, `IComparable`, `IEnumerable` (так называемая венгерская нотация), однако это не обязательное требование, а больше стиль программирования.

Интерфейсы могут определять следующие сущности:

* Методы
* Свойства
* Индексаторы
* События
* Статические поля и константы (начиная с версии C# 8.0)

Методы и свойства интерфейса могут не иметь реализации, в этом они сближаются с абстрактными методами и свойствами абстрактных классов.

Еще один момент в объявлении интерфейса: если его члены - методы и свойства не имеют модификаторов доступа, то фактически по умолчанию доступ public, так как цель интерфейса - определение функционала для реализации его классом.

```csharp
interface IMovable
{
    const int minSpeed = 0;     // минимальная скорость
    private static int maxSpeed = 60;   // максимальная скорость
    public void Move();
    protected internal string Name { get; set; }    // название
    public delegate void MoveHandler(string message);  // определение делегата для события
    public event MoveHandler MoveEvent;    // событие движения
}
```

Рассмотрим пример:

```csharp
// Все объекты Message являются объектами IMessage
IMessage hello = new Message("Hello!");
Console.WriteLine(hello.Text); // Hello!
 
interface IMessage
{
    string Text { get; set; }
}
interface IPrintable
{
    void Print();
}
class Message : IMessage, IPrintable
{
    public string Text { get; set; }
    public Message(string text) => Text = text;
    public void Print()=> Console.WriteLine(Text);
}
```

**Dependency injection** (DI) или внедрение зависимостей представляет механизм, который позволяет сделать компоненты программы слабосвязанными, а всю программу в целом более гибкой, более адаптируемой и расширяемой.

```csharp
var logger = new Logger(new SimpleLogService());
logger.Log("Hello");
 
logger = new Logger(new GreenLogService());
logger.Log("Hello");
 
interface ILogService
{
    void Write(string message);
}
// простой вывод на консоль
class SimpleLogService : ILogService
{
    public void Write(string message) => Console.WriteLine(message);
}
// сервис, который выводит сообщение зеленым цветом
class GreenLogService : ILogService
{
    public void Write(string message)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ForegroundColor = defaultColor;
    }
}
class Logger
{
    ILogService logService;
    public Logger(ILogService logService) => this.logService = logService;
    public void Log(string message) => logService.Write($"{DateTime.Now}  {message}");
}
```

Класс `Logger` не зависит от конкретной реализации класса `SimpleLogService` - это может быть любая реализация интерфейса `ILogService`. Кроме того, создание сервиса логгера выносится во внешний код. Класс `Logger` больше ничего не знает о сервисе, кроме того, что у него есть метод `Write`, который позволяет логгировать сообщение куда-то каким-то образом.

Все сервисы или зависимости хранятся в механизме DI в .NET хранятся в специальной коллекции сервисов, которая представляет тип IServiceCollection. .NET предоставляет встроенную реализацию этого интерфейса - класс ServiceCollection.

Для получения добавленного сервиса нам нужен провайдер сервисов `IServiceProvider`. Для его получения у коллекции сервисов вызывается метод `BuildServiceProvider()`, который возвращает встроенную реализацию провайдера - объект `ServiceProvider`.

```csharp
using Microsoft.Extensions.DependencyInjection;
 
var services = new ServiceCollection()
    .AddTransient<ILogService, SimpleLogService>()
    .AddTransient<Logger>();
 
using var serviceProvider = services.BuildServiceProvider();
// получаем объект Logger
Logger? logger = serviceProvider.GetService<Logger>();
logger?.Log("Hello");
 
interface ILogService
{
    void Write(string message);
}
class SimpleLogService : ILogService
{
    public void Write(string message) => Console.WriteLine(message);
}
class Logger
{
    ILogService? logService;
    public Logger(ILogService? logService) => this.logService = logService;
    public void Log(string message) => logService?.Write($"{DateTime.Now}  {message}");
}
```

14. Универсальные шаблоны/Generic/Обобщения. Определение классов, содержащих универсальные шаблоны, и объявление переменных типов данных классов. Отличия от механизма boxing\unboxing

Рассмотрим пример:

```csharp
Person tom = new Person(546, "Tom");
Person bob = new Person("abc123", "Bob");
 
int tomId = (int)tom.Id;
string bobId = (string) bob.Id;
 
Console.WriteLine(tomId);   // 546
Console.WriteLine(bobId);   // abc123

class Person
{
    public object Id { get;}
    public string Name { get;}
    public Person(object id, string name)
    {
        Id = id; 
        Name = name;
    }
}
```

Все вроде замечательно работает, но такое решение является не очень оптимальным. Дело в том, что в данном случае мы сталкиваемся с такими явлениями как **упаковка** (boxing) и **распаковка** (unboxing).

Так, при передаче в конструктор значения типа `int`, происходит упаковка этого значения в тип `Object`. Чтобы обратно получить данные в переменную типов `int`, необходимо выполнить распаковку с явным приведением типа. Причем мы можем не знать, какой именно объект представляет `Id`, и при попытке получить число в данном случае мы столкнемся с исключением `InvalidCastException`.

Для решения таких проблем в язык C# была добавлена поддержка **обобщенных типов** (также часто называют универсальными типами). Обобщенные типы позволяют указать конкретный тип, который будет использоваться. Поэтому определим класс Person как обобщенный:

```csharp
Person<int> tom = new Person<int>(546, "Tom");
Person<string> bob = new Person<string>("abc123", "Bob");
 
int tomId = tom.Id;
string bobId = bob.Id;
 
Console.WriteLine(tomId); // 546
Console.WriteLine(bobId); // abc123

class Person<T>
{
    public T Id { get; set; }
    public string Name { get; set; }
    public Person(T id, string name)
    {
        Id = id; 
        Name = name;
    }
}
```

Кроме обобщенных классов можно также создавать **обобщенные методы**, которые точно также будут использовать универсальные параметры. 

```csharp
int x = 7;
int y = 25;
Swap<int>(ref x, ref y); // Swap(ref x, ref y);
Console.WriteLine($"x={x}    y={y}"); // x=25   y=7
 
string s1 = "hello";
string s2 = "bye";
Swap<string>(ref s1, ref s2); // Swap(ref s1, ref s2);
Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello
 
void Swap<T>(ref T x, ref T y)
{
    T temp = x;
    x = y;
    y = temp;
}
```

15. Ограничения обобщений и их наследование.

В качестве ограничений мы можем использовать следующие типы:

- Классы
- Интерфейсы
- `class` - универсальный параметр должен представлять класс
- `struct` - универсальный параметр должен представлять структуру
- `new()` - универсальный параметр должен представлять тип, который имеет общедоступный (public) конструктор без параметров

Если для универсального параметра задано несколько ограничений, то они должны идти в определенном порядке:

1) Название класса, `class`, `struct`. Причем мы можем одновременно определить только одно из этих ограничений;
2) Название интерфейса;
3) `new()`.

Ограничения обобщенных методов:

```csharp
void SendMessage<T>(T message) where T: Message
{ }
```

Ограничения обобщенных классов:

```csharp
class Messenger<T> where T : Message
{ }
```

Если класс использует несколько универсальных параметров, то последовательно можно задать ограничения к каждому из них:

```csharp
class Messenger<T, P> 
    where T : Message
    where P : Person
{ }
```

Один обобщенный класс может быть унаследован от другого обобщенного. При этом можно использовать различные варианты наследования.

Первый вариант:

```csharp
class UniversalPerson<T> : Person<T>
{
    public UniversalPerson(T id) : base(id) { }
}
```

Второй вариант:

```csharp
class StringPerson : Person<string>
{
    public StringPerson(string id) : base(id) { }
}
```

Третий вариант:

```csharp
class IntPerson<T> : Person<int>
{
    public T Code { get; set; }
    public IntPerson(int id, T code) : base(id) 
    {
        Code = code;
    }
}
```

Стоит учитывать, что если на уровне базового класса для универсального параметра установлено ограничение, то подобное ограничение должно быть определено и в производных классах, которые также используют этот параметр:

```csharp
class Person<T> where T : class
{
    public T Id { get;}
    public Person(T id) => Id = id;
}
class UniversalPerson<T> : Person<T> where T: class
{
    public UniversalPerson(T id) : base(id) { }
}
```

16. Делегаты. Определение, объявление и вызов делегатов. Встроенные делегаты Action\Func\Predicate. Отличия от событий.

**Делегаты** представляют такие объекты, которые указывают на методы. То есть делегаты - это указатели на методы и с помощью делегатов мы можем вызвать данные методы.

Для объявления делегата используется ключевое слово `delegate`, после которого идет возвращаемый тип, название и параметры.

```csharp
Message mes;
mes = Hello;
mes();
 
void Hello() => Console.WriteLine("Hello");
 
delegate void Message();
```

Делегат можно определять внутри класса, либо вне класса.

Выше переменной делегата напрямую присваивался метод. Есть еще один способ - создание объекта делегата с помощью конструктора, в который передается нужный метод:

```csharp
Message mes1 = Hello;
Message mes2 = new Message(Hello);
```

В примерах выше переменная делегата указывала на один метод. В реальности же делегат может указывать на множество методов, которые имеют ту же сигнатуру и возвращаемые тип. Все методы в делегате попадают в специальный список - **список вызова** или **invocation list**. И при вызове делегата все методы из этого списка последовательно вызываются. И мы можем добавлять в этот список не один, а несколько методов. Для добавления методов в делегат применяется операция `+=`:

```csharp
Message message = Hello;
message += HowAreYou;  // теперь message указывает на два метода
message();              // вызываются оба метода - Hello и HowAreYou
 
void Hello() => Console.WriteLine("Hello");
void HowAreYou() => Console.WriteLine("How are you?");
 
delegate void Message();
```

Подобным образом мы можем удалять методы из делегата с помощью операций `-=`:

```csharp
Message? message = Hello; 
message += HowAreYou;
message();
message -= HowAreYou;
if (message != null) message(); // Вызывается только метод Hello
```

Другой способ вызова делегата представляет метод `Invoke()`:

```csharp
Message mes;
mes = Hello;
mes.Invoke();
 
void Hello() => Console.WriteLine("Hello");
 
delegate void Message();
```

При вызове делегата всегда лучше проверять, не равен ли он `null`. Либо можно использовать метод `Invoke` и *оператор условного null*.

Если делегат возвращает некоторое значение, то возвращается значение **последнего метода** из списка вызова (если в списке вызова несколько методов).

Делегаты, как и другие типы, могут быть обобщенными, например:

```csharp
Operation<decimal, int> squareOperation = Square;
decimal result1 = squareOperation(5);
Console.WriteLine(result1);  // 25
 
Operation<int, int> doubleOperation = Double;
int result2 = doubleOperation(5);
Console.WriteLine(result2);  // 10
 
decimal Square(int n) => n * n;
int Double(int n) => n + n;
 
delegate T Operation<T, K>(K val);
```

С делегатами тесно связаны анонимные методы. Анонимные методы используются для создания экземпляров делегатов.

```csharp
MessageHandler handler = delegate (string mes)
{
    Console.WriteLine(mes);
};
handler("hello world!");
 
delegate void MessageHandler(string message);
```

Лямбда-выражения представляют упрощенную запись анонимных методов.

```csharp
Message hello = () => Console.WriteLine("Hello");
hello();       // Hello
 
delegate void Message();
```

В .NET есть несколько встроенных делегатов, которые используются в различных ситуациях. И наиболее используемыми, с которыми часто приходится сталкиваться, являются `Action`, `Predicate` и `Func`.

Делегат `Action` представляет некоторое действие, которое ничего не возвращает, то есть в качестве возвращаемого типа имеет тип `void`:

```csharp
public delegate void Action();
public delegate void Action<in T>(T obj);
```

Данный делегат имеет ряд перегруженных версий. Каждая версия принимает разное число параметров: от `Action<in T1>` до `Action<in T1, in T2,....in T16>`. Таким образом можно передать до 16 значений в метод.

Делегат `Predicate<T>` принимает один параметр и возвращает значение типа `bool`:

```csharp
delegate bool Predicate<in T>(T obj);
```

Еще одним распространенным делегатом является `Func`. Он возвращает результат действия и может принимать параметры. Он также имеет различные формы: от `Func<out T>()`, где `T` - тип возвращаемого значения, до `Func<in T1, in T2,...in T16, out TResult>()`, то есть может принимать до 16 параметров.

```csharp
TResult Func<out TResult>();
TResult Func<in T, out TResult>(T arg);
```

**События** сигнализируют системе о том, что произошло определенное действие. И если нам надо отследить эти действия, то как раз мы можем применять события.

Делегаты отличаются от событий гибкостью доступа к данным, которые они хранят. В то время как мы можем присвоить делегату другой делегат или сложить/вычесть одного и другого, события располагают только аксессорами, которые могут добавлять и удалять подписчиков. Причём вызов делегата можно производить из любого места в области видимости и с учетом доступа, вызов события же доступен лишь из самого класса, который его содержит.

17.  Понятия ковариантности и контравариантности делегатов. Примеры.

Делегаты могут быть **ковариантными** и **контравариантными**. 

**Ковариантность** делегата предполагает, что возвращаемым типом может быть производный тип. **Контравариантность** делегата предполагает, что типом параметра может быть более универсальный тип.

Рассмотрим на примере:

```csharp
class Message
{
    public string Text { get; }
    public Message(string text) => Text = text;
    public virtual void Print() => Console.WriteLine($"Message: {Text}");
}
class EmailMessage: Message
{
    public EmailMessage(string text): base(text) { }
    public override void Print() => Console.WriteLine($"Email: {Text}");
}
class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
    public override void Print() => Console.WriteLine($"Sms: {Text}");
}
```

Ковариантность позволяет передать делегату метод, возвращаемый тип которого является производным от возвращаемого типа делегата.

```csharp
MessageBuilder messageBuilder = WriteEmailMessage;
Message message = messageBuilder("Hello");
message.Print();    // Email: Hello

EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);

delegate Message MessageBuilder(string text);
```

Контравариантность позволяет присвоить делегату метод, тип параметра которого является более универсальным по отношению к типу параметра делегата.

```csharp
EmailReceiver emailBox = ReceiveMessage;
emailBox(new EmailMessage("Welcome"));  // Email: Welcome
 
void ReceiveMessage(Message message) => message.Print();
 
delegate void EmailReceiver(EmailMessage message);
```

То есть, если грубо обобщить, ковариантность - это от более производного к более общему типу (EmailMessage -> Message), а контравариантность - от более общего к более производному типу (Message -> EmailMessage).

18. События\Event. Определение, объявление и вызов событий. Методы Add и Remove. Отличия от делегатов. 

**События** сигнализируют системе о том, что произошло определенное действие. И если нам надо отследить эти действия, то как раз мы можем применять события.

**События** — это члены класса, которые нельзя вызывать вне класса независимо от спецификатора доступа. Так, например, событие, объявленное как `public`, позволило бы другим классам использовать `+=` и `-=` для этого события, но запуск события (то есть вызов делегата) разрешен только в классе, содержащем событие.

Также компилятор не позволяет использовать `=` (прямое назначение делегата) для событий. Следовательно, код защищен от риска удаления предыдущих подписчиков, используя `=` вместо `+=`.

С помощью специальных **аксессоров add/remove** мы можем управлять добавлением и удалением обработчиков. Как правило, подобная функциональность редко требуется, но тем не менее мы ее можем использовать.

```csharp
public delegate void AccountHandler(string message);
    AccountHandler? notify;
    public event AccountHandler Notify
    {
        add
        {
            notify += value;
            Console.WriteLine($"{value.Method.Name} добавлен");
        }
        remove
        {
            notify -= value;
            Console.WriteLine($"{value.Method.Name} удален");
        }
    }
```

Делегаты отличаются от событий гибкостью доступа к данным, которые они хранят. В то время как мы можем присвоить делегату другой делегат или сложить/вычесть одного и другого, события располагают только аксессорами, которые могут добавлять и удалять подписчиков. Причём вызов делегата можно производить из любого места в области видимости и с учетом доступа, вызов события же доступен лишь из самого класса, который его содержит.

19. Технологии Object-Relation Mapping (ORM). Технология EF Core. Понятия «контекст» и «миграция»

**Entity Framework** представляет **ORM-технологию** (Object-Relational Mapping - отображения данных на реальные объекты) от компании Microsoft для доступа к данным. **Entity Framework Core** позволяет абстрагироваться от самой базы данных и ее таблиц и работать с данными как с объектами классом независимо от типа хранилища. Если на физическом уровне мы оперируем таблицами, индексами, первичными и внешними ключами, но на концептуальном уровне, который нам предлагает Entity Framework, мы уже работаем с объектами.

Как технология доступа к данным Entity Framework Core работает поверх платформы .NET и поэтому может использоваться на различных платформах стека .NET.

Entity Framework Core поддерживает множество различных систем баз данных. Таким образом, мы можем через EF Core **работать с любой СУБД**, если для нее имеется нужный провайдер. По умолчанию на данный момент Microsoft предоставляет ряд встроенных провайдеров: для работы с MS SQL Server, для SQLite, для PostgreSQL. Также имеются провайдеры от сторонних поставщиков, например, для MySQL.

Отличительной чертой Entity Framework Core, как технологии ORM, является использование запросов **LINQ** для выборки данных из БД. С помощью LINQ мы можем создавать различные запросы на выборку объектов, в том числе связанных различными ассоциативными связями. А Entity Framework при выполнение запроса транслирует выражения LINQ в выражения, понятные для конкретной СУБД (как правило, в выражения SQL).

Для взаимодействия с базой данных через Entity Framework Core необходим контекст данных - класс, унаследованный от класса Microsoft.EntityFrameworkCore.DbContext.

**Контекст** в Entity Framework Core представляет собой основной класс, который управляет взаимодействием с базой данных. Он выполняет роль посредника между приложением и базой данных, обеспечивая механизмы для запроса и сохранения данных.

**Миграция** в Entity Framework Core представляет собой механизм для управления изменениями схемы базы данных. Миграции позволяют отслеживать и применять изменения в структуре базы данных (например, добавление новых таблиц, изменение столбцов) с помощью версионного контроля.

20. Получение, добавление и изменение записей в базе данных используя механизмы EF Core.

Большинство операций с данными так или иначе представляют собой **CRUD операции** (Create, Read, Update, Delete), то есть создание, получение, обновление и удаление. Entity Framework Core позволяет легко выполнять все эти действия.

Например, у нас есть таблица пользователей:

```csharp
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
```

А также контекст БД:

```csharp
using Microsoft.EntityFrameworkCore;
 
public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
```

Добавим все базовые операции над данными:

```csharp
// Добавление
using (ApplicationContext db = new ApplicationContext())
{
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };
 
    // Добавление
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
}
 
// Получение
using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Данные после добавления:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Изменение
using (ApplicationContext db = new ApplicationContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        //обновляем объект
        //db.Users.Update(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Удаление
using (ApplicationContext db = new ApplicationContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
```

21. Загрузка связанных сущностей. Eager\Lazy\Explicit loading определение и отличия. Понятие каскадного удаления связанных сущностей. 

Через навигационные свойства мы можем загружать связанные данные. И здесь у нас три стратегии загрузки:

- Eager loading (жадная загрузка)
- Explicit loading (явная загрузка)
- Lazy loading (ленивая загрузка)

В начале рассмотрим, что представляет собой **Eager Loading** или **жадная загрузка**. Она позволяет загружать связанные данные с помощью метода `Include()`, в который передается навигационное свойство.

```csharp
var users = db.Users
        .Include(u=>u.Company)
        .ToList();
```

Допустим, у каждой компании есть связанная сущность - страна, где находится компания, и вместе с пользователями мы хотим загрузить и страны, в которых базируются компании пользователей. То есть получается, что нам нужно спуститься еще на уровень ниже: User - Company - Country. Для этого нам надо применить метод ThenInclude():

```csharp
var users = db.Users
        .Include(u => u.Company)  // подгружаем данные по компаниям
            .ThenInclude(c => c!.Country)    // к компаниям подгружаем данные по странам
        .ToList();
```

При загрузке связанных данных EF Core гарантирует, что если связанная сущность не установлена, то данное навигационное свойство просто будет игнорироваться. Соответственно никакой ошибки в процессе получения данных не произойдет. Но поскольку компилятор не знает об этом, то он выдает предупреждение. В этом случае мы можем использовать оператор ! (null-forgiving оператор), чтобы указать, что значение null в данной ситуации невозможно.

Стратегия **Explicit Loading** предполагает явную загрузку данных с помощью метода `Load()`.

Выражение `db.Users.Where(p=>p.CompanyId==company.Id).Load()` загружает пользователей в контекст. Подвыражение `Where(p=>p.CompanyId==company.Id)` означает, что загружаются только те пользователи, у которых свойство `CompanyId` соответствует свойству `Id` ранее полученной компании. После этого нам не надо подгружать связанные данные, так как они уже есть в контексте.

Для загрузки связанных данных мы также можем использовать методы `Collection()` и `Reference()`. 

Метод `Collection` применяется, если навигационное свойство представляет коллекцию: `db.Entry(company).Collection(c => c.Users).Load();`, где `Company? company = db.Companies.FirstOrDefault();`.

Если навигационное свойство представляет одиночный объект, то можно применять метод `Reference()`: `db.Entry(user).Reference(u => u.Company).Load();`.

После загрузки данных мы можем повторно обращаться к ним через свойство `Local`.

**Lazy loading** или **ленивая загрузка** предполагает неявную автоматическую загрузку связанных данных при обращении к навигационному свойству. Однако здесь есть ряд условий:

- При конфигурации контекста данных вызвать метод `UseLazyLoadingProxies()`;
- Все навигационные свойства должны быть определены как виртуальные (то есть с модификатором `virtual`), при этом сами классы моделей должны быть открыты для наследования.

Однако при использовании Lazy loading следует учитывать что если в базе данных произошли какие-нибудь изменения, например, другой пользователь изменил данные, то данные не перезагружаются, контекст продолжает использовать те данные, которые были ранее загружены.

**Каскадное удаление** представляет автоматическое удаление зависимой сущности после удаления главной.

По умолчанию для сущностей применяется каскадное удаление, если наличие связанной сущности обязательно.

```csharp
public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<User> Users { get; set; } = new();
}
 
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
```

Здесь свойство внешнего ключа имеет тип int, оно не допускает значения null и требует наличия конкретного значения - id связанного объекта Company.

Например, добавим в базу данных 2 компании и 4 связанных с ними пользователей и затем удалим одну из компаний. Удаление главной сущности - компании, приводит к удалению двух зависимых сущностей - пользователей.

22. Понятие реляционных и нереляционных баз данных и отличия между ними. Примеры. Виды связей между объектами в базах данных. 

**Реляционная база данных** (SQL) — база, где данные хранятся в формате таблиц, они строго структурированы и связаны друг с другом. В таблице есть строки и столбцы, каждая строка представляет отдельную запись, а столбец — поле с назначенным ей типом данных. В каждой ячейке информация записана по шаблону.

**Нереляционная база данных** (NoSQL) — хранит данные без четких связей друг с другом и четкой структуры. Вместо структурированных таблиц внутри базы находится множество разнородных документов, в том числе изображения, видео и даже публикации в социальных сетях. В отличие от реляционных БД, NoSQL базы данных не поддерживают запросы SQL.

Никакого противостояния между реляционными и нереляционными базами данных нет, более того, их часто используют совместно для решения разных задач:

- Реляционные SQL-базы — подходят для хранения структурированных данных, особенно в тех случаях, когда крайне важна их целостность. Также эту модель лучше выбрать, если на проекте нужна технология, основанная на стандартах, при использовании которой можно рассчитывать на большое количество дополнений и большой опыт разработчиков.
- Нереляционные NoSQL-базы данных — нужны, если требования к данным нечеткие, неопределенные, могут меняться с ростом и развитием проекта. А также в тех случаях, когда одно из основных требований к базам данных — высокая скорость работы.

MySQL — одна из самых популярных open source реляционных баз данных.

PostgreSQL — вторая по популярности open source SQL СУБД. Отличается стабильностью, ее практически невозможно вывести из строя или что-то сломать в таблицах. В отличие от MySQL, она подходит для крупных и масштабных проектов.

MongoDB — open source база данных документного типа. Может работать и со структурированными, и с неструктурированными данными.

Redis — может быть использован как самостоятельная СУБД для быстрой работы с небольшими объемами данных либо как кэширующий слой для работы с другой СУБД, то есть как замена memcached. Помогает ускорить работу медленной базы данных, увеличивает скорость обработки запросов. Например, можно использовать в качестве основной базы MySQL, а для кеша — Redis.

**Отношение один к одному** предполагает, что главная сущность может ссылаться только на один объект зависимой сущности. В свою очередь, зависимая сущность может ссылаться только на один объект главной сущности.

Рассмотрим стандартный пример подобных отношений: есть класс пользователя User, который хранит логин и пароль, то есть данные учетных записей. А все данные профиля, такие как имя, возраст и так далее, выделяются в класс профиля UserProfile.

Для настройки подобного отношения с помощью Fluent API применяются методы `HasOne()` и `WithOne()`.

**Отношение один-ко-многим** (one-to-many) представляет ситуацию, когда одна сущность хранит ссылку на один объект другой сущности, а вторая сущность может ссылаться на коллекцию объектов первой сущности. Например, в одной компании может работать несколько сотрудников, а каждый сотрудник в свою очередь может официально работать только в одной компании.

Для настройки подобного отношения с помощью Fluent API применяются методы `HasOne()` и `WithMany()`.

**Отношение многие-ко-многим** (many-to-many) представляет связь, при которой объект одной сущности может ссылаться на множество объектов второй сущности, а объект второй сущности, в свою очередь, может ссылаться на множество объектов первой сущности. Примером подобного отношения может служить посещение студентами университетских курсов. Один студент может посещать сразу несколько курсов, и, в свою очередь, один курс может посещаться множеством студентов.

Для настройки подобного отношения с помощью Fluent API применяются методы `HasMany()` и `WithMany()`, а также `UsingEntity<>()`.

23. Понятие индексов в базах данных. Виды индексов. Примеры использования. Достоинства и недостатки.

По умолчанию в качестве ключа используется свойство, которое называется `Id` или `[имя_класса]Id`.

Для конфигурации ключа с Fluent API применяется метод `HasKey()`. С помощью Fluent API можно создать составной ключ из нескольких свойств: `modelBuilder.Entity<User>().HasKey(u => new { u.PassportSeries, u.PassportNumber});`. 

Альтернативные ключи представляют свойства, которые также, как и первичный ключ, должны иметь уникальное значение. В то же время альтернативные ключи не являются первичными. Для установки альтернативного ключа используется метод `HasAlternateKey()`.

Для увеличения производительности поиска в базе данных применяются индексы. По умолчанию индекс создается для каждого свойства, которое используется в качестве внешнего ключа. Однако Entity Framework также позволяет создавать свои индексы.

Для создания индекса можно использовать атрибут `[Index]`.

Первый и обязательный параметр атрибута указывает на свойство (или набор свойств), с которым будет ассоциирован индекс. В данном случае это свойство PhoneNumber.

Но также он может принимать набор свойств, для которых создается индекс. В этом случае названия свойств просто перечисляются через запятую:

```csharp
using Microsoft.EntityFrameworkCore;
 
[Index("PhoneNumber", "Passport")]
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Passport { get; set; }
    public string? PhoneNumber { get; set; }
}
```

С помощью дополнительных параметров можно настроить уникальность и имя индекса: `[Index("PhoneNumber", IsUnique = true, Name ="Phone_Index")]`.

Для создания индекса через Fluent API применяется метод `HasIndex()`. С помощью дополнительного метода `IsUnique()` можно указать, что индекс должен иметь уникальное значение. Для установки имени индекса применяется метод `HasDatabaseName()`, в который передается имя индекса. 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasIndex(u => u.PhoneNumber)
        .HasDatabaseName("PhoneIndex");
}
```

Достоинства:

* Ускорение поиска данных
* Уникальность данных
* Ускорение сортировки

Недостатки:

* Замедление операций вставки, обновления и удаления
* Дополнительное место на диске
* Сложность управления

24. Понятие транзакции. Примеры использования транзакций. Достоинства и недостатки. 

**Транзакция в базах данных** — это последовательность операций, выполняемых как единое целое. Транзакция обеспечивает принцип ACID, который гарантирует надежность и согласованность данных. ACID расшифровывается как:

* Atomicity (атомарность): Все операции в транзакции выполняются полностью или не выполняются вовсе.
* Consistency (согласованность): Транзакция переводит базу данных из одного согласованного состояния в другое.
* Isolation (изоляция): Одновременно выполняющиеся транзакции не должны влиять друг на друга.
* Durability (устойчивость): После завершения транзакции ее результаты сохраняются и не теряются, даже в случае сбоя системы.

Примером может служить транзакция по переводу денег с одного счета на другой.

Достоинства:

- Согласованность данных
- Атомарность операций
- Изоляция операций
- Устойчивость данных

Недостатки:

- Затраты на производительность
- Сложность управления
- Блокировки ресурсов
- Проблемы с долгими транзакциями

25. Многопоточное программирование. Понятие «поток», отличия от Task. Использование класса Thread. Делегаты ThreadStart и ParametrizedThreadStart. Запуск потока на выполнение. Примеры. Понятие CPU Bound, отличия от I\O Bound. Примеры операций CPU Bound.

Одним из ключевых аспектов в современном программировании является **многопоточность**. Ключевым понятием при работе с многопоточностью является **поток**. Поток представляет некоторую часть кода программы. При выполнении программы каждому потоку выделяется определенный квант времени. И при помощи многопоточности мы можем выделить в приложении несколько потоков, которые будут выполнять различные задачи одновременно.

Основной функционал для использования потоков в приложении сосредоточен в пространстве имен `System.Threading`. В нем определен класс, представляющий отдельный поток - класс `Thread`.

Класс `Thread` определяет ряд методов и свойств, которые позволяют управлять потоком и получать информацию о нем. Основные свойства класса:

- `ExecutionContext`: позволяет получить контекст, в котором выполняется поток
- `IsAlive`: указывает, работает ли поток в текущий момент
- `IsBackground`: указывает, является ли поток фоновым
- `Name`: содержит имя потока
- `ManagedThreadId`: возвращает числовой идентификатор текущего потока
- `Priority`: хранит приоритет потока - значение перечисления `ThreadPriority`:
  - Lowest
  - BelowNormal
  - Normal (default)
  - AboveNormal
  - Highest
- `ThreadState`: возвращает состояние потока

Кроме того статическое свойство `CurrentThread` класса Thread позволяет получить текущий поток

Также класс Thread определяет ряд методов для управления потоком. Основные из них:

- Статический метод `GetDomain` возвращает ссылку на домен приложения
- Статический метод `GetDomainID` возвращает id домена приложения, в котором выполняется текущий поток
- Статический метод `Sleep` останавливает поток на определенное количество миллисекунд
- Метод `Interrupt` прерывает поток, который находится в состоянии WaitSleepJoin
- Метод `Join` блокирует выполнение вызвавшего его потока до тех пор, пока не завершится поток, для которого был вызван данный метод
- Метод `Start` запускает поток

Сравнение `Thread` и `Task`:

- Управление ресурсами
  - Thread: Прямое управление потоками требует ручного контроля над ресурсами и синхронизацией.
  - Task: Автоматическое управление с использованием пула потоков, что упрощает разработку и улучшает производительность.
- Сложность:
  - Thread: Больше контроля, но и больше ответственности за управление потоками и синхронизацией.
  - Task: Выше уровень абстракции, меньше контроля над потоками, но проще в использовании для асинхронных и параллельных операций.
- Параллелизм и асинхронность:
  - Thread: Подходит для низкоуровневого параллелизма и выполнения долгосрочных операций.
  - Task: Оптимизирован для асинхронного программирования и краткосрочных параллельных операций.
- Пул потоков и эффективность:
  - Thread: Не использует пул потоков по умолчанию, создание новых потоков может быть дорогостоящим.
  - Task: Использует пул потоков, что обеспечивает эффективное использование системных ресурсов.

Для создания потока применяется один из конструкторов класса `Thread`:

- `Thread(ThreadStart)`: в качестве параметра принимает объект делегата `ThreadStart`, который представляет выполняемое в потоке действие;
- `Thread(ParameterizedThreadStart)`: в качестве параметра принимает объект делегата `ParameterizedThreadStart`, который представляет выполняемое в потоке действие.

Примеры определения потоков:

```csharp
Thread myThread1 = new Thread(Print); 
Thread myThread2 = new Thread(new ThreadStart(Print));
Thread myThread3 = new Thread(()=>Console.WriteLine("Hello Threads"));
 
void Print() => Console.WriteLine("Hello Threads");
```

Если необходимо передать параметры в поток, то используется делегат `ParameterizedThreadStart`, который передается в конструктор класса `Thread`:

```csharp
Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
Thread myThread2 = new Thread(Print);
Thread myThread3 = new Thread(message => Console.WriteLine(message));

myThread1.Start("Hello");
myThread2.Start("Привет");
myThread3.Start("Salut");

void Print(object? message) => Console.WriteLine(message);
```

**CPU Bound** и **I/O Bound** — это термины, используемые для описания типов задач в программировании и компьютерных системах. Они указывают, какой ресурс (центральный процессор или операции ввода-вывода) является ограничивающим фактором в производительности задачи.

**CPU Bound задачи** ограничены скоростью выполнения центрального процессора (CPU). Эти задачи требуют интенсивных вычислений и используют большую часть времени на выполнение операций обработки данных.

Самым простым примером CPU Bound задачи может быть вычисление n-ого числа Фибоначчи или определение n-ого количества цифр числа Пи, так как с каждым увеличением числа n увеличивается нагрузка на процессор для расчета.

**I/O Bound задачи** ограничены скоростью выполнения операций ввода-вывода (I/O), таких как чтение и запись на диск, сетевые операции и взаимодействие с внешними устройствами. Эти задачи проводят большую часть времени в ожидании завершения операций ввода-вывода.

26. Конкурентный доступ к данным. Механизмы синхронизации потоков – мьютекс. Пример реализации

Инструмент управления синхронизацией потоков представляет класс `Mutex` или **мьютекс**, который располагается в пространстве имен `System.Threading`.

Пример:

```csharp
int x = 0;
Mutex mutexObj = new();

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start(); 
}
 
void Print()
{
    mutexObj.WaitOne();     // Приостанавливаем поток до получения мьютекса
    x = 1;
    for (int i = 1; i < 6; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
    }
    mutexObj.ReleaseMutex();    // освобождаем мьютекс
}
```

27.	Конкурентный доступ к данным. Механизмы синхронизации потоков – семафор. Пример реализации

**Семафоры** являются еще одним инструментом, который предлагает нам платформа .NET для управления синхронизацией. Семафоры позволяют ограничить количество потоков, которые имеют доступ к определенным ресурсам. В .NET семафоры представлены классом `Semaphore`.

```csharp
for (int i = 1; i < 6; i++)
{
    Reader reader = new Reader(i);
}
class Reader
{
    // создаем семафор
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;// счетчик чтения
 
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель {i}";
        myThread.Start();
    }
 
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();  // ожидаем, когда освободиться место
 
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
 
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
 
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
 
            sem.Release();  // освобождаем место
 
            count--;
            Thread.Sleep(1000);
        }
    }
}
```

28.	Конкурентный доступ к данным. Механизмы синхронизации потоков – монитор. Пример реализации

Наряду с оператором `lock` для синхронизации потоков мы можем использовать мониторы, представленные классом `System.Threading.Monitor`.

Стоит отметить, что фактически конструкция оператора `lock` инкапсулирует в себе синтаксис использования мониторов. 

Например:

```csharp
int x = 0;
object locker = new();  // объект-заглушка

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}
 
 
void Print()
{
    lock (locker)
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
}
```

Фактически данный пример будет эквивалентен следующему коду:

```csharp
int x = 0;
object locker = new();  // объект-заглушка

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}
 
void Print()
{
    bool acquiredLock = false;
    try
    {
        Monitor.Enter(locker, ref acquiredLock);
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
    finally
    {
        if (acquiredLock) Monitor.Exit(locker);
    }
}
```

29.	 Асинхронное программирование. Понятие «Task», отличие от потока. Ключевые слова async\await. Отличия Monitor.Wait() \ Task.Delay() \ Thread.Sleep(). Понятие I\O Bound, отличия от CPU Bound. Примеры операций I\O Bound. 

**Асинхронность** позволяет вынести отдельные задачи из основного потока в специальные асинхронные методы и при этом более экономно использовать потоки. Асинхронные методы выполняются в отдельных потоках. Однако при выполнении продолжительной операции поток асинхронного метода возвратится в пул потоков и будет использоваться для других задач. А когда продолжительная операция завершит свое выполнение, для асинхронного метода опять выделяется поток из пула потоков, и асинхронный метод продолжает свою работу.

**Асинхронный метод** обладает следующими признаками:

- В заголовке метода используется модификатор `async`
- Метод содержит одно или несколько выражений `await`
- В качестве возвращаемого типа используется один из следующих:
  - `void`
  - `Task`
  - `Task<T>`
  - `ValueTask<T>`

Также стоит отметить, что слово async, которое указывается в определении метода, **не делает** автоматически метод асинхронным. Оно лишь указывает, что данный метод может содержать одно или несколько выражений `await`.

Отличия Task от потока, а также понятие I/O Bound и его отличия от CPU Bound, были рассмотрены в п. 25

`Monitor.Wait()` используется для координации между потоками. Это один из методов для реализации примитивов синхронизации, таких как блокировки и мьютексы.

`Task.Delay()` используется для создания асинхронной паузы (задержки) в выполнении кода; создает задачу, которая завершится через заданное время. Это не блокирует текущий поток, что позволяет выполнять другие задачи в то же время.

`Thread.Sleep()` используется для приостановки текущего потока на заданное количество времени.

Примером I/O Bound задачи может служить запрос HTTP:

```csharp
using System;
using System.Net.Http;

class Program
{
    public static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        string url = "https://api.github.com";

        // Выполнение HTTP-запроса
        HttpResponseMessage response = client.GetAsync(url).Result;
        string content = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine("Ответ получен.");
        Console.WriteLine(content);
    }
}
```

30.	 REST API. Принципы и описание реализации. HTTP методы и коды состояния. Синхронное и асинхронное взаимодействие сервисов. 

**Архитектура REST** (Representation State Transfer или "передача состояния представления") предполагает применение следующих методов или типов запросов HTTP для взаимодействия с сервером, где каждый тип запроса отвечает за определенное действие:

* GET (получение данных)
* POST (добавление данных)
* PUT (изменение данных)
* DELETE (удаление данных)

**Код состояния ответа HTTP** показывает, был ли успешно выполнен определённый HTTP запрос. Ответы сгруппированы в 5 классов:

* Информационные ответы (100 – 199)
* Успешные ответы (200 – 299)
* Сообщения о перенаправлении (300 – 399)
* Ошибки клиента (400 – 499)
* Ошибки сервера (500 – 599)

**Синхронное взаимодействие** означает, что один сервис делает запрос другому и ожидает ответ до тех пор, пока не получит его. Весь процесс выполнения запроса и получения ответа происходит в рамках одного потока, и вызывающий сервис блокируется до получения ответа.

**Асинхронное взаимодействие** предполагает, что сервис делает запрос другому сервису и продолжает выполнять свои задачи, не дожидаясь ответа. Ответ обрабатывается, когда он становится доступен, что позволяет более эффективно использовать ресурсы.

Для асинхронного взаимодействия используется ключевое слово `async` и `await`, что позволяет не блокировать поток выполнения.

31.	Инструмент Swagger, назначение и использование. Передача параметров в HTTP методы (FromQuery, FromBody). Понятия Stateless и Stateful. 

**Swagger** — это один из типов платформ, который предоставляет возможность доступа к данным API для создания документации, т.е. описания структуры API.

Или, **Swagger** — это машиночитаемое представление RESTful API, которое обеспечивает поддержку интерактивной документации, создание клиентских пакетов SDK и возможности обнаружения.

Для начала работы со Swagger необходимо добавить его в сервисы, а также проинициализировать в собранном приложении. 

```csharp
{
    services.AddSwaggerGen();

    // ...

    app.UseSwagger();
    app.UseSwaggerUi();
}
```

Существует группа атрибутов, позволяющая указать один целевой источник для поиска значений, привязываемых к аргументам метода:

- `[FromQuery]`: данные извлекаются из строки запроса;
- `[FromBody]`: данные извлекаются из тела запроса.

Запрос через Query: example.com/Home/Index?Name=Alice&Age=21, где нас интересует лишь **?Name=Alice&Age=21**.

Понятия Stateless и Stateful отсылают нас к серверной реализации, в которой реакция на запрос от пользователя не зависит или зависит от предыдущих запросов, соответственно.

**Stateful** (с сохранением состояния) — архитектура, при которой система сохраняет информацию о предыдущих состояниях или взаимодействиях с клиентами. Она сохраняет состояние между запросами или сеансами.

**Stateless** (без сохранения состояния) — архитектура, при которой каждый запрос рассматривается как отдельное, изолированное взаимодействие.

32.	 Реализации DI при разработке Web сервисов. Жизненный цикл зависимостей (.AddScoped, .AddSingleton, .AddTransient). 

**Dependency injection** (DI) или внедрение зависимостей представляет механизм, который позволяет сделать взаимодействующие в приложении объекты слабосвязанными. Такие объекты связаны между собой через абстракции, например, через интерфейсы, что делает всю систему более гибкой, более адаптируемой и расширяемой.

ASP.NET Core позволяет управлять жизненным циклом внедряемых в приложении сервисов. С точки зрения жизненного цикла сервисы могут представлять один из следующих типов:

- **Transient**: при каждом обращении к сервису создается новый объект сервиса. В течение одного запроса может быть несколько обращений к сервису, соответственно при каждом обращении будет создаваться новый объект. Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии
- **Scoped**: для каждого запроса создается свой объект сервиса. То есть если в течение одного запроса есть несколько обращений к одному сервису, то при всех этих обращениях будет использоваться один и тот же объект сервиса.
- **Singleton**: объект сервиса создается при первом обращении к нему, все последующие запросы используют один и тот же ранее созданный объект сервиса

На примере `AddTransient`:

```csharp
var builder = WebApplication.CreateBuilder();
 
builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();
 
var app = builder.Build();
 
app.UseMiddleware<CounterMiddleware>();
 
app.Run();
```

33.	Технологии контроля изменений в коде на примере Git. Основные понятия (branch, merge, commit, pull\push, cherry-pick)

**Git** — это распределённая система контроля версий, которая позволяет разработчикам отслеживать изменения в коде и работать совместно над проектами. Рассмотрим основные понятия и технологии контроля изменений в коде на примере Git.

Основные понятия Git:

1. **Branch (ветка)**
    - Ветка в Git — это указатель на коммит (фиксацию изменений). Ветки позволяют разработчикам работать над различными функциями, исправлениями или экспериментами параллельно, не вмешиваясь в основную ветку (обычно это `main` или `master`).
    - Ветку можно создать командой:
        ```bash
        git branch new-feature
        ```
    - Переключиться на ветку можно командой:
        ```bash
        git checkout new-feature
        ```

2. **Commit (коммит)**
    - Коммит — это сохранение изменений в локальный репозиторий. Коммит содержит снимок текущего состояния файлов в проекте и сообщение, описывающее эти изменения.
    - Для создания коммита используются команды:
        ```bash
        git add .
        git commit -m "Описание изменений"
        ```

3. **Merge (слияние)**
    - Слияние объединяет изменения из одной ветки в другую. Это позволяет объединить параллельные разработки.
    - Для слияния ветки `new-feature` в текущую ветку используется команда:
        ```bash
        git merge new-feature
        ```

4. **Pull (получение изменений)**
    - Команда `git pull` используется для получения и интеграции изменений из удалённого репозитория в локальный. Эта команда выполняет `git fetch` и `git merge`.
        ```bash
        git pull origin main
        ```

5. **Push (отправка изменений)**
    - Команда `git push` используется для отправки изменений из локального репозитория в удалённый репозиторий.
        ```bash
        git push origin main
        ```

6. **Cherry-pick (выборка коммитов)**
    - Команда `git cherry-pick` позволяет применить отдельные коммиты из одной ветки в другую.
        ```bash
        git cherry-pick <commit-hash>
        ```

Пример использования основных команд

Предположим, вы работаете над проектом, и вам нужно создать новую ветку для добавления новой функциональности:

1. Создайте и переключитесь на новую ветку:
    ```bash
    git checkout -b new-feature
    ```

2. Внесите изменения в код и зафиксируйте их:
    ```bash
    git add .
    git commit -m "Добавлена новая функциональность"
    ```

3. Переключитесь обратно на основную ветку и слейте изменения из новой ветки:
    ```bash
    git checkout main
    git merge new-feature
    ```

4. Отправьте изменения в удалённый репозиторий:
    ```bash
    git push origin main
    ```

5. Если нужно применить отдельный коммит из другой ветки, используйте cherry-pick:
    ```bash
    git cherry-pick <commit-hash>
    ```

Заключение:

Git предоставляет мощные инструменты для контроля версий, управления ветками и координации работы в команде. Понимание основных понятий, таких как ветки, коммиты, слияние, получение и отправка изменений, а также выборка коммитов, помогает эффективно управлять разработкой и интеграцией кода.