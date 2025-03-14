using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeckProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // قراءة n و q
            string[] input = Console.ReadLine()!.Split();
            int n = int.Parse(input[0]); // عدد البطاقات
            int q = int.Parse(input[1]); // عدد الاستعلامات

            // قراءة ألوان البطاقات
            string[] numsInput = Console.ReadLine()!.Split();
            List<int> nums = numsInput.Select(int.Parse).ToList(); // تحويل الألوان لـ List<int>

            // قراءة الاستعلامات
            string[] queryInput = Console.ReadLine()!.Split();
            List<int> queries = queryInput.Select(int.Parse).ToList(); // تحويل الاستعلامات لـ List<int>

            // Dictionary لتخزين مواضع البطاقات لكل لون
            Dictionary<int, List<int>> colorToIndices = new Dictionary<int, List<int>>();

            // ملء الـ Dictionary بمواضع البطاقات لكل لون
            for (int i = 0; i < n; i++)
            {
                int color = nums[i];
                if (!colorToIndices.ContainsKey(color))
                {
                    colorToIndices[color] = new List<int>();
                }
                colorToIndices[color].Add(i + 1); // نضيف 1 لأن المؤشرات تبدأ من 1
            }

            // List لتخزين ترتيب البطاقات
            List<int> deck = Enumerable.Range(1, n).ToList(); // ترتيب البطاقات من 1 إلى n

            // List لتخزين النتائج
            List<int> result = new List<int>();

            // معالجة الاستعلامات
            foreach (int query in queries)
            {
                // البحث عن البطاقة الأعلى (ذات المؤشر الأدنى) للون المطلوب
                int minIndex = colorToIndices[query].Min();

                // إضافة موضع البطاقة للنتيجة
                result.Add(minIndex);

                // نقل البطاقة لأعلى الـ List
                deck.Remove(minIndex); // نزيل البطاقة من مكانها الحالي
                deck.Insert(0, minIndex); // نضيفها لأعلى الـ List

                // تحديث مواضع البطاقات في الـ Dictionary
                foreach (var color in colorToIndices.Keys)
                {
                    for (int i = 0; i < colorToIndices[color].Count; i++)
                    {
                        if (colorToIndices[color][i] < minIndex)
                        {
                            colorToIndices[color][i]++;
                        }
                    }
                }

                // تحديث موضع البطاقة المنقولة في الـ Dictionary
                colorToIndices[query].Remove(minIndex);
                colorToIndices[query].Insert(0, 1); // البطاقة المنقولة بتكون في الموضع 1
            }

            // طباعة النتائج
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}