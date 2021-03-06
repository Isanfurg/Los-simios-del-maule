using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.GameBoard
{
    //using UnityEngine;
    //using UnityEngine;
    //code from
    //https://answers.unity.com/questions/1515750/list-sorting-but-random-order.html
    public static class FisherShuffle
    {
        private static readonly Random rng = new Random();

        //Fisher - Yates shuffle
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
    }
}