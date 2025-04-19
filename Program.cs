using System;
using System.Collections.Generic;

namespace BinaryTree
{
  class Program
  {
    private static BinaryTree<int> tree = new BinaryTree<int>();

    static void Main(string[] args)
    {
      while (true)
      {
        Console.WriteLine("\nСписок опций");
        Console.WriteLine("1. Добавить элемент");
        Console.WriteLine("2. Прямой обход");
        Console.WriteLine("3. Обратный обход");
        Console.WriteLine("4. Центральный обход");
        Console.WriteLine("5. Выход");
        Console.Write("Ваш выбор: ");
        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            AddElement();
            break;

          case "2":
            ForwardTraversal();
            break;

          case "3":
            ReverseTraversal();
            break;

          case "4":
            InOrderTraversalWithDelegate();
            break;
            
          case "5":
            return;
            
          default:
            Console.WriteLine("Некорректный выбор опции!");
            break;
        }
      }
    }

    private static void AddElement()
    {
      Console.Write("Введите число для добавления: ");
      if (int.TryParse(Console.ReadLine(), out int value))
      {
        tree.Add(value);
        Console.WriteLine($"Элемент {value} добавлен в дерево.");
      }
      else
      {
        Console.WriteLine("Некорректный ввод числа!");
      }
    }

    private static void ForwardTraversal()
    {
      Console.WriteLine("Прямой обход дерева (итератор):");
      foreach (var item in tree)
      {
        Console.Write(item + " ");
      }
      Console.WriteLine();
    }

    private static void ReverseTraversal()
    {
      Console.WriteLine("Обратный обход дерева (итератор):");
      foreach (var item in tree.GetReverseEnumerator())
      {
        Console.Write(item + " ");
      }
      Console.WriteLine();
    }

    private static void InOrderTraversalWithDelegate()
    {
      Console.WriteLine("Центральный обход дерева (делегат):");

      BinaryTree<int>.TreeTraversalDelegate processNode = (value) =>
      {
        Console.Write(value + " ");
      };

      tree.InOrderTraversal(processNode);
      Console.WriteLine();
    }
  }
}
