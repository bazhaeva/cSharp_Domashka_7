int m = GetUserNumber("Введите число строк массива: ", "Ошибка ввода!");    // Способ задания массива выбран произвольно, т.к. не оговорен в условии
int n = GetUserNumber("Введите число столбцов массива: ", "Ошибка ввода!");

int[,] matrix = GetMatrix(m, n, -10, 10);       // диапазон [-10, 10] взят произвольно, т.к. не оговорено условиями 
PrintArray(matrix);
double[] result = AverageByColumn(matrix);
Console.WriteLine("-----");
Console.WriteLine(String.Join("; ", result));


//=================Методы==========================

//-----------------Получение числа от пользователя
int GetUserNumber(string messageToUser, string errorMessage)
{
    while (true)
    {
        Console.Write(messageToUser);
        if (int.TryParse(Console.ReadLine(), out int userNumber))
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}



//-----------------Заполнение двумерного массива

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int[,] resultMatrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            resultMatrix[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return resultMatrix;
}




//--------------------------Вывод двумерного массива на экран

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}  ");
        }
        Console.WriteLine();
    }
}


//---------------------------Нахождение среднего арифметического по столбцу

double[] AverageByColumn(int[,] inArray)
{
    double[] resultArray = new double[inArray.GetLength(1)];
    double count = 0;
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        for (int j = 0; j < inArray.GetLength(0); j++)
        {
            count += (double)inArray[j, i];
        }
        resultArray[i] = Math.Round((double)count / inArray.GetLength(0), 1);  // 1 знак после запятой взят произвольно

        count = 0;
    }
    return resultArray;
}
