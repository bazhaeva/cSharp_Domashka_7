int m = new Random().Next(1, 10);                   // Число строк, столбцов в массиве не оговорено условиями
int n = new Random().Next(1, 10);

int row = GetUserNumber("Введите номер строки элемента: ", "Ошибка ввода!");
int column = GetUserNumber("Введите номер столбца элемента: ", "Ошибка ввода!");


double[,] matrix = GetMatrix(m, n, -100, 100);       // диапазон [-100, 100] взят произвольно, т.к. не оговорено условиями 
PrintArray(matrix);
string result = CheckingIfElementExists(matrix, row, column);
Console.WriteLine("-----");
Console.WriteLine(result);



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


//-----------------Проверка, существует ли элемент

string CheckingIfElementExists(double[,] inArray, int row, int column)
{
    string result = $"элемента с позицией {row},{column} нет в массиве";
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (i == row && j == column)
            {
                result = $"{row},{column} -> {inArray[i, j]}";
                break;
            }
        }
    }
    return result;
}
