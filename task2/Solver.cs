using System;

public class Program
{
    public class Hash {
        public string word;
        public int count;

        public Hash(string w, int c)
        {
            word = w;
            count = c;
        }
    }

    public static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split(" ");
        int tableSize = words.Length;
        Hash[] hashTable = new Hash[tableSize];

        int maxStringSize = 0;
        int maxCount = 0;

        foreach (var w in words)
        {
            int count = InsertToHashTable(hashTable, w, tableSize);
            if (count > maxCount)
                maxCount = count;
            if (w.Length > maxStringSize)
                maxStringSize = w.Length;
        }
        SortHashTable(hashTable);
        PrintHashTable(hashTable, maxStringSize, words.Length, maxCount);
    }

    public static void SortHashTable(Hash[] hashTable)
    {
        for(int i=0;i< hashTable.Length; i++)
        {
            for (int j = i; j < hashTable.Length; j++)
            {
                if(hashTable[i]!=null && hashTable[j] != null)
                {
                    if(hashTable[i].count > hashTable[j].count)
                    {
                        var temp = hashTable[j];
                        hashTable[j] = hashTable[i];
                        hashTable[i] = temp;
                    }
                }
            }

        }
    }

    public static void PrintHashTable(Hash[] hashTable, int maxStringSize, int wordsСount, int maxCount)
    {
        double coefficient = (10.0 * wordsСount) / maxCount;
        foreach (var ht in hashTable)
        {
            if (ht != null)
            {
                for (int i = 0; i < maxStringSize - ht.word.Length; i++)
                    Console.Write("_");
                Console.Write(ht.word + " ");
                for (int j = 0; j < Round(Convert.ToDouble(ht.count) / wordsСount * coefficient); j++)
                    Console.Write(".");
                Console.WriteLine();
            }
        }
    }

    public static int Round(double number)
    {
        int result = (int)number;
        if (number % 10 != 0)
        {
            if ((int)Char.GetNumericValue(number.ToString()[2]) >= 5)
                result++;
        }
        return result;
    }

    public static int InsertToHashTable(Hash[] hashTable, string word, int tableSize)
    {
        int index = (int)GetHash(word) % tableSize;
        for (;;)
        {
            if(index > tableSize)
            {
                index = 0;
            }
            if (hashTable[index] == null)
            {
                hashTable[index] = new Hash(word, 1);
                return hashTable[index].count;
            }
            else if (hashTable[index].word == word)
            {
                hashTable[index].count++;
                return hashTable[index].count;
            }
            else
            {
                index++;
            }
        }
    }

    public static long GetHash(string word)
    {
        long hash = 1;
        for(int i = 0; i < word.Length; i++)
        {
            hash *= word[i];
        }
        return hash;
    }
}

