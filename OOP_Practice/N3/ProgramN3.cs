int n = Convert.ToInt32(Console.ReadLine());
int[] numbers = new int[n];
for (int i = 0; i < n; i++)
{
    numbers[i] = Random.Shared.Next(n);
}
Console.WriteLine(Median(numbers));
foreach (var item in numbers)
{
    Console.WriteLine(item);
}

static int Median(int[] nums)
{
    Array.Sort(nums);
    return nums[nums.Length / 2];
}