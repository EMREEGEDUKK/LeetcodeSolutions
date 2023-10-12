using System.Net;
using System.Security.Cryptography;

namespace LeetcodeSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

        }

        public static int[] CountBits(int n)
        {
            int[] arr = new int[n+1];

           
            for (int i = 0; i <= n; i++)
            {
                
                int count = 0;
                string binaryRep = Convert.ToString(i, 2);

                foreach (var item in binaryRep.ToArray())
                {
                    if(item=='1')
                    {
                        count++;

                    }
                }

                arr[i] = count;
            }

            return arr;
        }

        public static  int Fib(int n)
        {
            int fib0 = 0;
            int fib1 = 1;

            if(n==0)
            {
                return fib0;
            }

            else if (n==1)
            {
                return (fib0+fib1);
            }

            else
            {
                int temp=0;
                for (int i = 2;i <= n;i++)
                {
                    temp = fib0+ fib1;
                    fib0 = fib1;
                    fib1 = temp;

                }
                return temp;
            }

           

        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] minCost = new int[n];

            minCost[0] = cost[0];
            minCost[1] = cost[1];

            for (int i = 2; i < n; i++)
            {
                minCost[i] = cost[i] + Math.Min(minCost[i - 1], minCost[i - 2]);
            }

            return Math.Min(minCost[n - 1], minCost[n - 2]);
        }

        public static int Tribonacci(int n)
        {
            if(n==1) { return 1; }
            else if(n==2) { return 1;}
            else if(n==3) {  return 2;}
            int temp = 0;
            int fib1 =0;
            int temp2;
            int fib2 = 1;
            int fib3 = 1;
            for (int i = 3; i <= n; i++)
            {
                temp2 = fib1 + fib2;
                temp = temp2 +  fib3;
                fib1 = fib2;
                fib2 = fib3;
                fib3 = temp;
            }

            return temp;
        }

        public static IList<int> GetRow(int rowIndex)
        {
            List<int> row = new List<int>();

            for (int i = 0; i <= rowIndex; i++)
            {
                row.Add(1);

                for (int j = i - 1; j > 0; j--)
                {
                    row[j] += row[j - 1];
                }
            }

            return row;
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices.SequenceEqual(prices.OrderByDescending(x => x).ToArray()))
            {
                return 0;
            }
            
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int[] before = prices.Take(i + 1).ToArray();
                int[] after = prices.Skip(i).ToArray();
                int min = before.Min();
                int max = after.Max();
                if(max-min > profit)
                {
                    profit = max - min;
                }
            }
            return profit;
        }

        public static int Factorial(int n)
        {
            if(n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            int temp = 1;

            for (int i = 1; i <= n; i++)
            {
                temp*=i;
            }

        return temp;
        }

        

        public static bool IsSubsequence(string s, string t)
        {
            
            var list = t.ToList();
            var listS = s.ToList();
            int count = 0;

            for (int i = 0; i <= list.Count(); i++)
            {
                var condition = listS.Skip(count).ToList().IndexOf(list[i]);
                if (condition== -1)
                {
                    return false;
                }
                count = condition + 1;
            }

            return true;
        }

        public static string DefangIPaddr(string address) =>   string.Join("[.]", address.Split('.'));

        public static  int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;
            foreach (var item in operations)
            {
                if(item.Contains('-'))
                {
                    result--;
                }
                else
                {
                    result++;
                }
            }

            return result;
        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            int result = 0;

            foreach (var item in jewels.ToList())
            {
                result += stones.Count(x => x == item);
            }

            return result;
        }

        public static string Interpret(string command)
        {
            var arr = command.ToArray();
            string newStr = string.Empty;

           

            for (int i = 0; i < arr.Length; i++)
            {
               
                 if (arr[i] == 'G')
                {
                    newStr += 'G';
                    
                }
                else if (arr[i] == '(' && arr[i+1] =='a')
                {
                    newStr += "al";
                    i += 3;
                }
                else
                {
                    newStr += 'o';
                    i += 1;
                }
            }

            return newStr;
        }

        public static int MostWordsFound(string[] sentences)
        {
            int maxLength = 0;
            foreach (var sentence in sentences)
            {
                string[] words = sentence.Split(' ');
                if(words.Length > maxLength)
                {
                    maxLength = words.Length;
                }
            }

            return maxLength;
        }

        public static int BalancedStringSplit(string s)
        {
            int balancedSubStr = 0;
            int temp = 2;

            while (temp <= s.Length-2)
            {
                for (int i = 0; i <= s.Length - temp-1; i+=temp)
                {
                    var substr = s.Substring(i, temp);
                    int rCount = substr.Count(c => c == 'R');
                    int lCount = substr.Count(c => c == 'L');

                    if (rCount == lCount)
                    {
                        balancedSubStr++;
                    }
                }
                temp += 2;
            }

            return balancedSubStr;
        }

        public static string RestoreString(string s, int[] indices)
        {
            char[] result = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                result[indices[i]] = s[i];
            }

            return new string(result);
        }

        public static int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int count = 0;
            foreach (var item in items)
            {
                if(ruleKey=="type")
                {
                    if (item[0] == ruleValue) count++;

                }

                else if (ruleKey=="color")
                {
                    if (item[1] == ruleValue) count++;

                }
                else
                {
                    if (item[2] == ruleValue) count++;

                }
            }
            return count;

        }

        public static string TruncateSentence(string s, int k)
        {

            return string.Join(" ", s.Split(" ").Take(k));

        }

        public static void CellsInRange(string s)
        {
            string[] alphabetical =s.Split(':');
            int first = alphabetical[0][1];
            int last =  alphabetical[1][1];

            foreach (var item in alphabetical) 
            {
                for (int i = first;i<=last;i++)
                {
                    Console.WriteLine(i);
                }
            }

            
        }
        public static string DecodeMessage(string key, string message)
        {
            key = string.Join("", key.Distinct());
            List<char> alphabet = new List<char>();

            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabet.Add(c);
            }

            List<char> newMessage = new List<char>();

            foreach (var item in message.ToCharArray())
            {
                if (item == ' ')
                {
                    newMessage.Add(' ');
                    continue;
                }

                int index = key.IndexOf(item) - 1;
                if (index < 0)
                {
                    newMessage.Add(' ');
                }
                else
                {
                    newMessage.Add(alphabet[index]);
                }
            }

            return new string(newMessage.ToArray());
        }

        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string mergedWord1 = string.Join("", word1);
            string mergedWord2 = string.Join("", word2);


            return mergedWord1 == mergedWord2;
        }

        public static string SortSentence(string s)
        {
           
            string[] splittedString = s.Split(' ');
            string[] arr =new string [splittedString.Length];

            foreach (string word in splittedString)
            {
                arr[int.Parse(word[word.Length - 1].ToString()) - 1]   = string.Join("", word.Take(word.Length - 1));
            }

            return string.Join(' ',arr);
        }

        public static bool CheckIfPangram(string sentence)
        {
         

            return string.Join("", sentence.Distinct()).Length == 26;
        }








    }
}