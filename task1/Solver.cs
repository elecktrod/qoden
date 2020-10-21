using System;

class Solver
{
    public static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        int[] x = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

        HashTable hashTable = new HashTable();
        hashTable.values = new ListNode<int>[n];

        foreach(int i in x)
        {
            hashTable.Insert(i);
        }

        PrintHashTable(hashTable);
    }

    public static void PrintHashTable(HashTable hashTable)
    {
        for(int i = 0; i < hashTable.values.Length; i++)
        {
            Console.Write(i+":");
            if (hashTable.values[i] != null)
                hashTable.values[i].Print();
            Console.WriteLine();
        }
    }
}

public class HashTable
{
    public ListNode<int>[] values;

    public void Insert(int newValue)
    {
        int index = newValue % values.Length;
        values[index] ??= new ListNode<int>();
        values[index].Insert(newValue);
    }
}

public class ListNode<T>
{
    int value;
    ListNode<int> next;

    public void Insert(int newValue)
    {
        if (next != null)
        {
            next.Insert(newValue);
        }
        else
        {
            value = newValue;
            next = new ListNode<int>();
        }
    }

    public void Print()
    {
        if (next != null)
        {
            Console.Write(" " + value);
            next.Print();
        }
    }
}

