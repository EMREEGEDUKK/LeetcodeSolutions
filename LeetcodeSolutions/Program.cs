using System.ComponentModel;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace LeetcodeSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"n => {BigON(1000)}");
            Console.WriteLine($"Logn => {BigOLogN(1000)}");
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

        public static bool IsAcronym(IList<string> words, string s)
        {
            string acronym = string.Empty;
            foreach (var item in words)
            {
                acronym +=item[0];
            }
            Console.WriteLine(acronym);

            return acronym == s;
        }

        public static string ReverseWords(string s)
        {
            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = string.Join("",words[i].Reverse());
            }
            return string.Join(" ",words);

           
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>(){
{'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."}, {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"}, {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"}, {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"}, {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"}, {'z', "--.."}, };
            List<string> decoded = new List<string>();
            string str = string.Empty;
            foreach (string word in words) 
            {
                foreach (var letter in word)
                {
                    str += morseCode[letter];
                }
                Console.WriteLine(str);
                decoded.Add(str);
                str = string.Empty;
            }
            
            return decoded.Distinct().Count();
        }

        public static int CountConsistentStrings(string allowed, string[] words)
        {
            int count = 0;
            foreach (var item in words)
            {
                if(string.Join("",item.Distinct().Order())== string.Join("",allowed.Order()) || string.Join("",allowed.Order()).Contains(string.Join("", item.Distinct().Order())))
                {
                    count++;
                }
            }
            return count;
        }

        public static string FinalString(string s)
        {
            string newStr = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i')
                {
                    newStr = new string(s.Take(i+1).Reverse().ToArray());
                    
                   
                    
                }
                else
                {
                    newStr += s[i];
                }
            }

            return newStr;
        }



            public string RemoveOuterParentheses(string s)
            {
                Stack<char> stack = new Stack<char>();
                StringBuilder ans = new("");

                foreach (char c in s.ToCharArray())
                {
                    if (c is '(')
                    {
                        if (stack.Count > 0)
                        {
                            ans.Append('(');
                        }

                        stack.Push(c);
                    }
                    else
                    {
                        if (stack.Count > 1)
                        {
                            ans.Append(')');

                        }

                        stack.Pop();
                    }
                }

                return ans.ToString();
            }



        public static int MaxDepth(string s)
        {
            List<char> paranthesis = new List<char>();
            foreach (var item in s)
            {
                if(item is '(' || item is ')')
                {
                    paranthesis.Add(item);
                }
            }
            int max = 0;
            int temp = 0;
            foreach (var item in paranthesis)
            {
                if(item is '(')
                {
                    temp++;
                }

                else
                {
                    if(temp>max)
                    {
                        max = temp;
                    }
                    temp--;
                   
                }
            }

            return max;
        }

        public static int CountAsterisks(string s)
        {
            var astheriks = s.Split("|*");
            Console.WriteLine(astheriks.Length);
            foreach (var item in astheriks)
            {
                Console.WriteLine(item);
            }
            int count = 0;

            for (int i = 2; i < astheriks.Length-2; i++)
            {
                foreach (var item in astheriks[i])
                {
                    if (item is '*')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int CountPoints(string rings)
        {

           Dictionary<string,string> dict = new Dictionary<string,string>();
            rings = string.Join("", rings.Reverse());
            for (int i = 0; i < rings.Length; i+=2)
            {
                if (!dict.ContainsKey(rings[i].ToString()))
                {
                    dict.Add(rings[i].ToString(), rings[i+1].ToString());


                }
                else
                {
                    dict[rings[i].ToString()] += rings[i + 1];

                }


            }

            foreach (var item in dict)
            {
                Console.WriteLine($"key: {item.Key}  value: {item.Value}");
            }
            int count = 0;
            foreach(var item in dict)
            {
                if(string.Join("",item.Value.Order().Distinct()).Contains("BGR"))
                {
                    count++;
                }
            }   
            return count;
        }

        public static string ReplaceDigits(string s)
        {
            List<char> alphabet = new List<char>();
            List<char> newString = new List<char>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet.Add(i);
            }
            for (int i = 1; i < s.Length; i+=2)
            {
                var temp = s[i - 1];
                newString.Add(temp);
                var index = alphabet.IndexOf(temp) + int.Parse(s[i].ToString());
                newString.Add(alphabet[index]);
            }
            if(s.Length%2!=0)
            {
                newString.Add(s[s.Length-1]);
            }
            return string.Join("",newString);
        }

        public static string MakeSmallestPalindrome(string s)
        {


            char leftPointer = '\0';
            char rightPointer = '\0';
            char[] newS = s.ToCharArray();

            for (int i = 0; i < s.Length / 2; i++)
            {
                leftPointer = s[i];
                rightPointer = s[s.Length - 1 - i];
                Console.WriteLine(leftPointer);
                Console.WriteLine(rightPointer);

                if (leftPointer == rightPointer)
                {
                    newS[i] = leftPointer;
                    newS[s.Length-1 - i] = rightPointer;
                }
                else if (leftPointer < rightPointer)
                {
                    newS[i] = leftPointer;
                    newS[s.Length - 1 - i] = leftPointer;


                }
                else
                {
                    newS[i] = rightPointer;
                    newS[s.Length - 1 - i] = rightPointer;
                }
            }
            return string.Join("",newS);
        }

        public static int MaximumNumberOfStringPairs(string[] words)
        {
            int count = 0;
            string temp = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                temp = string.Join("",words[i].Reverse());
                for (int j = i+1; j < words.Length; j++)
                {
                    if(temp == words[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int NumOfStrings(string[] patterns, string word)
        {
            int count = 0;
            foreach (var item in patterns)
            {
                if (word.Contains(item))
                {
                    count++;
                }
            }
            return count;

        }

        public string[] SortPeople(string[] names, int[] heights)
        {
            int temp = 0;
            int index = 0;
            List<string> sortedNamesByHeight = new List<string>();
            for (int i = 0; i < heights.Length; i++)
            {
                temp = heights.Take(i).Max();
                index = heights.ToList().IndexOf(temp);
                sortedNamesByHeight.Add(names[index]);

            }

            return sortedNamesByHeight.ToArray();
        }

        public static string ReversePrefix(string word, char ch)
        {
            var index = word.IndexOf(ch);

            if(index != -1)
            {
                return word.Substring(0, index).Reverse() + word.Substring(index);
            }
            return word;
        }

        public static string GetDuplicate(string word)
        {
            string duplicatedString = string.Empty;
            foreach (var item in word)
            {
                var duplicatedCountInItem = word.Count(x => x == item);

                if(duplicatedCountInItem >= 2)
                {
                    if(duplicatedString.IndexOf(item)  == -1)
                    {
                        duplicatedString += item;
                    }
                 
                }
            }
            return duplicatedString;
        }

        public static int  NFibNumber(int number)
        {
            int fib1 = 1;
            int fib2 = 1;
            int temp = 0;

            if(number == 1 || number == 2)
            {
                return 1;
            }

            for (int i = 0; i <= number - 3 ; i++)
            {
                temp = fib1 + fib2;
                Console.WriteLine(temp);
                fib1 = fib2;
                fib2 = temp;
                Console.WriteLine($"fib 1 = {fib1} --- fib2 = {fib2} ");

            }

            return temp;



        }


        public static int BigON(int number)
        {
            int sum = 0;
            for (int i = 0; i < number; i++)
            {
                sum += 1;
            }

            return sum;
        }

        public static int BigOLogN(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number; i*=2)
            {
                sum += 1;
            }

            return sum; 
         }



    }
    



   


}


  
