﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GuitarLA
{
    class FFT
    {
        static public Complex[] Fft(short[] arr)
        {
            Complex[] X;
            int N = arr.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = arr[0] + arr[1];
                X[1] = arr[0] - arr[1];
            }
            else
            {
                short[] x_even = new short[N / 2];
                short[] x_odd = new short[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = arr[2 * i];
                    x_odd[i] = arr[2 * i + 1];
                }
                Complex[] X_even = Fft(x_even);
                Complex[] X_odd = Fft(x_odd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    double arg = -2 * Math.PI * i / N;
                    X[i] = X_even[i] + (new Complex(Math.Cos(arg), Math.Sin(arg))) * X_odd[i];
                    X[i + N / 2] = X_even[i] - (new Complex(Math.Cos(arg), Math.Sin(arg))) * X_odd[i];
                }
            }
            return X;
        }
        static public double[] ToArray(Complex[] X)
        {
            double[] array = new double[X.Length / 2];
            for (int i = 0; i < X.Length / 2; i++)
                array[i] = X[i].Magnitude;
            return array;
        }
    }
}
