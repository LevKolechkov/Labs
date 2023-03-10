/**************************
*      Колечков Лев       *
*       03.03.2023        *
*   Перегрузка операций   *
**************************/

using System;

namespace Lab_3
{
  class Execution
  {
    static SquareMatrix firstMatrix;
    static SquareMatrix secondMatrix;
    static SquareMatrix resultMatrix;

    static void GenerateFirstMatrix(int size)
    {
      firstMatrix = new SquareMatrix(size);
    }

    public static void GenerateSecondMatrix(int size) 
    {
      secondMatrix = new SquareMatrix(size);
    }

    static private int InputProcessor()
    {
      bool success = (int.TryParse(Convert.ToString(Console.ReadLine()), out int input));
      if (success == false) 
      {
        Console.WriteLine("Данные неправильно введены");
      }
      return input;
    }

    static public bool PrintMatrix()
    {
      try
      {
        int length = firstMatrix.GetSizeOfMatrix();
        Console.WriteLine("Первая матрица A: ");
        for (int rowIndex = 0; rowIndex < length; ++rowIndex) 
        {
          for (int columnIndex = 0; columnIndex < length; ++columnIndex) 
          {
            Console.Write(firstMatrix[rowIndex, columnIndex] + " ");
          }
          Console.WriteLine();
        }

        Console.WriteLine("\n Вторая матрица B: ");
        for (int rowIndex = 0; rowIndex<= length; ++rowIndex) 
        {
          for (int columnIndex = 0; columnIndex < length; ++columnIndex) 
          {
            Console.Write(secondMatrix[rowIndex, columnIndex] + " ");
          }
          Console.WriteLine();
        }
      }

      catch (NullReferenceException)
      {
        Console.WriteLine("Нет матриц");
        return false;
      }

      return true;
    }

    static public void PrintData()
    {
      try 
      {
        int length = resultMatrix.GetSizeOfMatrix();

        for (int rowIndex = 0; rowIndex<length; ++rowIndex) 
        {
          for (int columnIndex = 0; columnIndex<length; ++columnIndex) 
          {
            Console.Write(resultMatrix[rowIndex,columnIndex] + " ");
          }
          Console.WriteLine();
        }
      }
      catch (NullReferenceException) 
      {
        Console.WriteLine("Нет матрицы");
      }
    }

    static public void MenuOfMatrices()
    {
      Console.WriteLine("1 - Две матрицы");
      Console.WriteLine("2 - Первая матрица");
      Console.WriteLine("3 - Вторая матрица");

      int choice = 0;

      if (choice < 1 || choice > 3) 
      {
        choice = InputProcessor();
      }
      else
      {
        throw new Exception("Неправильный выбор матрицы");
      }

      string operation;
      int component;
      switch (choice) 
      {
        case 1:
          if (PrintMatrix())
          {
            Console.WriteLine("Выберите операцию: '+', '*', '?'");
            
            operation = Console.ReadLine();
            
            if (operation == "+")
            {
              Console.WriteLine("A + B");

              resultMatrix = (firstMatrix + secondMatrix).Clone() as SquareMatrix;

              PrintMatrix();
            }
           
            else if (operation == "-") 
            {
              Console.WriteLine("A * B");

              resultMatrix = (firstMatrix * secondMatrix).Clone() as SquareMatrix;

              PrintMatrix();
            }
           
            else if (operation == "?")
            {
              
              if (firstMatrix > secondMatrix)
              {
                Console.WriteLine("A > B");
                break;
              }
              
              else if (firstMatrix < secondMatrix)
              {
                Console.WriteLine("A < B");
                break;
              }
              
              else if (firstMatrix >= secondMatrix)
              {
                Console.WriteLine("A >= B");
                break;
              }

              else if (firstMatrix <= secondMatrix)
              {
                Console.WriteLine("A <= B");
                break;
              }

              else if (firstMatrix = secondMatrix)
              {
                Console.WriteLine("A = B");
                break;
              }
            }
            else
            {
              Console.WriteLine("Неправильно выбранная операция");
              break;
            }
          }
          break;
        case 2:
          try
          {
            for (int rowIndex = 0; rowIndex < firstMatrix.GetSizeOfMatrix(); ++rowIndex) 
            {
              for (int columnIndex = 0; columnIndex < firstMatrix.GetSizeOfMatrix(); ++columnIndex) 
              {
                Console.Write(firstMatrix[rowIndex, columnIndex] + " ");
              }
              Console.WriteLine();
            }
            Console.WriteLine("Выберите операцию: '+', '*'");

            operation = Console.ReadLine();

            if (operation == "+") 
            {
              Console.Write("Введите слагаемое: ");

              component = InputProcessor();

              resultMatrix = (firstMatrix + component).Clone() as SquareMatrix;

              PrintMatrix();
            }
            
            else if (operation == "*")
            {
              Console.Write("Введите множитель: ");
              
              component = InputProcessor();

              resultMatrix = (firstMatrix + component) as SquareMatrix;

              PrintMatrix();
            }

            else 
            {
              Console.WriteLine("Операция выбрана неправильно");
            }
          }
          catch(NullReferenceException)
          {
            Console.WriteLine("Нет матриц");
          }
          break;
        case 3:
          try
          {
            for (int rowIndex = 0; rowIndex < firstMatrix.GetSizeOfMatrix(); ++rowIndex) 
            {
              for (int columnIndex = 0; columnIndex < secondMatrix.GetSizeOfMatrix(); ++columnIndex) 
              {
                Console.Write(firstMatrix[rowIndex, columnIndex] + " ");
              }
              Console.WriteLine();
            }

            Console.WriteLine("\n Выберите операцию: '+', '*'");

            operation = Console.ReadLine();

            if (operation == "+") 
            {
              Console.WriteLine("Введите слагаемое");

              component = InputProcessor();

              resultMatrix = (secondMatrix + component).Clone() as SquareMatrix;

              PrintMatrix();
            }

            else if (operation == "*") 
            {
              Console.WriteLine("Введите множитель");

              component= InputProcessor();
              
              resultMatrix = (secondMatrix * component).Clone() as SquareMatrix;

              PrintMatrix();
            }

            else
            {
              Console.WriteLine("Операция выбрана неправильно");
            }
          }
          catch(NullReferenceException) 
          {
            Console.WriteLine("Нет матриц");
          }
          break;
      }
    }

    static public int DisplayMenu()
    {
      Console.WriteLine("Матричный калькулятор");
      Console.WriteLine();
      Console.WriteLine("1 - Создать матрицу");
      Console.WriteLine("2 - Операции с матрицами");
      Console.WriteLine("3 - Список матриц");

      int result = 0;

      if ((result < 1) || (result > 3))
      {
        result = InputProcessor();
      }
      return result;
    }
    static void Main(string[] args)
    {
      do
      {

        int choice;
        int matrixSize = 0;

        choice = DisplayMenu();
        switch (choice)
        {
          case 1:
            Console.WriteLine("Введите размер матрицы: ");
            while (matrixSize <= 0)
            {
              matrixSize = InputProcessor();
            }
            GenerateFirstMatrix(matrixSize);
            GenerateSecondMatrix(matrixSize);
            break;
          case 2:
            MenuOfMatrices();
            break;
          case 3:
            PrintMatrix();
            break;
        }
      } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
  }
}

