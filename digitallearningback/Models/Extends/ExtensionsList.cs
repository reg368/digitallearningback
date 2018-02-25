using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitallearningback.Models
{
    /**
     * 集合擴充方法
     */
    public static class ExtensionsList
    {
        private static Random rng = new Random();

        /**
         *  打亂原集合內的順序 ICollection
         */
        public static void Shuffle<T>(this ICollection<T> list)
        {

            T[] tarray = new T[list.Count];
            list.CopyTo(tarray, 0);

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = tarray[k];
                tarray[k] = tarray[n];
                tarray[n] = value;
            }

            list.Clear();

            foreach(T t in tarray) {
                list.Add(t);
            }

        }

        /**
         *  打亂原集合內的順序 IList
         */
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /**
         * 類似 LinkedList 的 poll 
         * 回傳list內的第一個元素 並且從list內移除
         */
        public static T  PollFirst<T>(this IList<T> list)
        {
            if(list.Count > 0)
            {
                T obj = list[0];
                list.RemoveAt(0);
                return obj;
            }
            else
            {
                return default(T);
            }
        }

        /**
         * String 泛型集合 串接成一個字串回傳
         * dot 串接字元
         */
        public static String ContactString(this IEnumerable<String> strs, String dot)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Count(); i++)
            {
                if (i < (strs.Count() - 1))
                {
                    sb.Append(strs.ElementAt(i) + dot);
                }
                else
                {
                    sb.Append(strs.ElementAt(i));
                }
            }

            return sb.ToString();
        }
    }
}