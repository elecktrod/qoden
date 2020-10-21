using System;

public class HashTable
{
    public ListNode<int>[] values;

    public void Insert(int newValue)
    {
        int index = newValue % values.Length;
        if(values[index]==null)
			values[index]=new ListNode<int>();
        values[index].Insert(newValue);
    }
}

