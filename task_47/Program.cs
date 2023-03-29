int m = GetUserNumber("Введите число строк массива: ", "Ошибка ввода!");    // Способ задания m и n выбран произвольно, т.к. не оговорен в условии
int n = GetUserNumber("Введите число столбцов массива: ", "Ошибка ввода!");

double[,] matrix = GetMatrix(m, n, -100, 100);       // диапазон [-100, 100] взят произвольно, т.к. не оговорено условиями 
PrintArray(matrix);


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

double[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    double[,] resultMatrix = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            double elOfMatrix = (new Random().NextDouble()) * (maxValue - minValue) - (maxValue - minValue) / 2;
            resultMatrix[i, j] = Math.Round(elOfMatrix, 2);                     // 2 знака после запятой так же взяты произвольно
        }
    }
    return resultMatrix;
}




//--------------------------Вывод двумерного массива на экран

void PrintArray(double[,] inArray)
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