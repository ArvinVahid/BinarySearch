var array = Enumerable.Range(1, 100).ToArray();
MyBinarySearch(3, array);

Console.WriteLine(Array.BinarySearch(array, 3));

void MyBinarySearch(int search, int[] array)
{
    int low = 0;
    int high = array.Length - 1;
    int step = 0;

    while (low <= high)
    {
        step++;
        int mid = (low + high) / 2;

        if (array[mid] == search)
        {
            Console.WriteLine($"index: {mid}");
            Console.WriteLine($"steps: {step}");
            break;
        }

        if (array[mid] < search)
        {
            low = mid + 1;
        }

        if (array[mid] > search)
        {
            high = mid - 1;
        }
    }
}