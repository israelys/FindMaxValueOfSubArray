var testArrays = new List<List<int>> 
{ 
    new List<int> { 1 , 2, 3, -3, -4 , -9, 4, 5 },
    new List<int> { -1 , 2, 3, -7, 4, 5, -9 },
    new List<int> { 1 , 2, 3, -7, 4, 10, -2, 100 }, 
    new List<int> { 1 },
};

void findMaxValues(List<int> array)
{
    if (!(array?.Any() ?? false))
    {
        Console.WriteLine("given array is null or empty");
        return;
    }

    var maxValue = int.MinValue;
    var maxValueStartIdx = -1;
    var maxValueEndIdx = -1;

    var currentMaxValue = int.MinValue;
    var currentMaxValueStartIdx = -1;
    var currentMaxValueEndIdx = -1;

    for ( var i = 0; i < array.Count; i++)
    {
        if (currentMaxValue == int.MinValue)
        {
            if (array[i] < 0)
                continue;

            currentMaxValue = array[i];
            currentMaxValueStartIdx = i;
            currentMaxValueEndIdx = i;

            continue;
        }
        else if (currentMaxValue + array[i] < 0)
        {
            if (currentMaxValue > maxValue)
            {
                maxValue = currentMaxValue;
                maxValueStartIdx = currentMaxValueStartIdx;
                maxValueEndIdx = currentMaxValueEndIdx;
            }

            currentMaxValue = int.MinValue;
            currentMaxValueStartIdx = -1;
            currentMaxValueEndIdx = -1;
            
            continue;
        }
        
        currentMaxValue = currentMaxValue + array[i];
        currentMaxValueEndIdx = i;

        if (currentMaxValue > maxValue)
        {
            maxValue = currentMaxValue;
            maxValueStartIdx = currentMaxValueStartIdx;
            maxValueEndIdx = currentMaxValueEndIdx;
        }
    };

    if (currentMaxValue > maxValue)
    {
        maxValue = currentMaxValue;
        maxValueStartIdx = currentMaxValueStartIdx;
        maxValueEndIdx = currentMaxValueEndIdx;
    }

    string arrayToString(List<int> array)
        => string.Join(',', array.Select(a => a.ToString()));

    Console.WriteLine($"test array: {arrayToString(array)}");
    Console.WriteLine($"max value: {maxValue}. start index: {maxValueStartIdx}. end index: {maxValueEndIdx}.");
    Console.WriteLine();
}

testArrays.ForEach(findMaxValues);

Console.ReadKey();