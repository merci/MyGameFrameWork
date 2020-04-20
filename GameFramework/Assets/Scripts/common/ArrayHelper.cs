using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    //C#的扩展方法： 在不修改代码的情况下，为其增加新的功能，就好像调用自身方法一样
    //扩展方法所在的类必须是静态类
    //在第一个参数上，使用this关键字修饰被扩展的类型
    //在另一个命名空间下


    /// <summary>
    /// 数组助手类，主要就是对数组的一些改造和操作；
    /// 提供一些数组常用的功能
    /// </summary>
    public  static class ArrayHelper 
    {

        //7个方法 查找 查找所有满足条件的所有对象
        //排序【升序，降序】最大值 最小值 筛选

        /// <summary>
        /// 查找所有满足条件的单个元素
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">查找条件</param>
        /// <returns></returns>
        public static T Find<T>(this T[] array,Func<T,bool> handler)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(handler(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        /// <summary>
        /// 查找所有满足条件的所有对象
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">查找条件</param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] array, Func<T, bool> handler)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (handler(array[i]))
                {
                    list.Add(array[i]);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <typeparam name="Q">返回指类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托类型</param>
        /// <returns></returns>
        public static T GetMax<T,Q>(this T[] array,Func<T,Q> handler)where Q : IComparable
        {
            T max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (handler(max).CompareTo(array[i])< 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        /// <summary>
        /// 最小值
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <typeparam name="Q">返回指类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托类型</param>
        /// <returns></returns>
        public static T GetMin<T, Q>(this T[] array, Func<T, Q> handler) where Q : IComparable
        {
            T min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (handler(min).CompareTo(array[i]) > 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// 升序
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <typeparam name="Q">返回指类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托类型</param>
        public static T[] OrderBy<T,Q>(this T[] array, Func<T,Q> handler) where Q : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length-1 -i; j++)
                {
                    if (handler(array[j]).CompareTo(array[j+1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j+1];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// 降序
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <typeparam name="Q">返回指类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托类型</param>
        public static T[] OrderDescding<T, Q>(this T[] array, Func<T, Q> handler) where Q : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (handler(array[j]).CompareTo(array[j + 1]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// 筛选
        /// 例如： GameObject[] ----> Transform[]
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <typeparam name="Q">返回指类型</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托类型</param>
        /// <returns></returns>
        public static Q[] Select<T,Q>(this T[] array,Func<T,Q> handler)
        {
            Q[] result = new Q[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = handler(array[i]);
            }
            return result;
        }
    }


}


