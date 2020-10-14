//-----------------------------------------------------------------------
// <copyright file="SquareMatrix.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace OOPDesignPrinciples
{
    using System;

    /// <summary>
    /// Class for Square Matrix.
    /// Square matrix' dimensions have to be equal X=Y
    /// </summary>
    /// <typeparam name="T">Any type to store in matrix</typeparam>
    public class SquareMatrix<T> : IMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class
        /// </summary>
        /// <exception cref="ArgumentException">Array's dimensions must me equal</exception>
        /// <param name="array">Array must be square (X = Y)</param>
        public SquareMatrix(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Array's dimensions must me equal");
            }

            this._matrix = array;
            this.LayersCount = array.GetLength(0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class
        /// </summary>
        /// <param name="size">Size of square matrix</param>
        public SquareMatrix(int size)
        {
            this.LayersCount = size;
            this._matrix = new T[size, size];
            for (int i = 0; i < this.LayersCount; i++)
            {
                for (int k = 0; k < this.LayersCount; k++)
                {
                    this._matrix[i, k] = default;
                }
            }
        }
        
        /// <summary>
        /// Gets size of both dimensions of matrix
        /// </summary>
        public int LayersCount { get; protected set; }
        
        /// <summary>
        /// Gets matrix array
        /// </summary>
        protected T[,] _matrix { get; set; }

        /// <summary>
        /// Gets an object stored in specific position
        /// </summary>
        /// <exception cref="ArgumentException">X and Y must be more than 0 and less than length</exception>
        /// <param name="x">First dimension</param>
        /// <param name="y">Second dimension</param>
        /// <returns>Generic type</returns>
        public virtual T this[int x, int y]
        {
            get
            {
                if (this.LayersCount < x || this.LayersCount < y || x < 0 || y < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this._matrix[x, y];
            }

            set
            {
                if (this.LayersCount < x || this.LayersCount < y || x < 0 || y < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this._matrix[x, y] = value;
            }
        }

        /// <summary>
        /// Adding two objects of <see cref="SquareMatrix{T}"/> class
        /// </summary>
        /// <exception cref="ArgumentException">Lengths of the objects cannot be different.</exception>
        /// <param name="left">Left object</param>
        /// <param name="right">Right object</param>
        /// <returns>United 2D array of two <see cref="SquareMatrix{T}"/>' object</returns>
        public static T[,] operator +(SquareMatrix<T> left, SquareMatrix<T> right)
        {
            if (left.LayersCount != right.LayersCount)
            {
                throw new ArgumentException("Lengths of the objects cannot be different.");
            }

            T[,] result = new T[left.LayersCount, left.LayersCount];

            try
            {
                for (int x = 0; x < left.LayersCount; x++)
                {
                    for (int y = 0; y < left.LayersCount; y++)
                    {
                        dynamic leftDynamic = left[x, y];
                        dynamic rightDynamic = right[x, y];

                        result[x, y] = leftDynamic + rightDynamic;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Converts this object to 2D array of given type
        /// </summary>
        /// <returns>2D array</returns>
        public T[,] To2DArray() 
        {
            T[,] outPut = new T[this.LayersCount, this.LayersCount];
            for (int i = 0; i < this.LayersCount; i++)
            {
                for (int k = 0; k < this.LayersCount; k++)
                {
                    outPut[i, k] = this._matrix[i, k];
                }
            }

            return outPut;
        }

        /// <summary>
        /// Prints in Console all the values of Matrix
        /// </summary>
        public void Show()
        {
            Console.WriteLine();

            int length = this._matrix.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (this._matrix[x, y] != null)
                    {
                        Console.Write(this._matrix[x, y].ToString() + " | ");
                    }
                    else
                    {
                        Console.Write("Null | ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
