using System;

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

