//-----------------------------------------------------------------------
// <copyright file="DiagonalMatrix.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace OOPDesignPrinciples
{
    /// <summary>
    /// Class for Diagonal Matrix. Inherited from the <see cref="SquareMatrix{T}"/> class.
    /// <para>A diagonal matrix is a matrix in which the entries outside the main diagonal are all zero</para>
    /// </summary>
    /// <typeparam name="T">Any type to store in matrix</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>, IMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class
        /// <para>Matrix in which the entries outside the main diagonal are all default</para>
        /// <para>Values outside the main diagonal become default value</para>
        /// </summary>
        /// <param name="array">Array must be square (X = Y)</param>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            this.SortingMethod();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// <para>Matrix is empty with the given size</para>
        /// </summary>
        /// <param name="size">Size of the 2D array</param>
        public DiagonalMatrix(int size) : base(size)
        {
            this.SortingMethod();
        }

        /// <summary>
        /// Sorting method of matrix
        /// </summary>
        protected virtual void SortingMethod()
        {
            T[,] temp = new T[LayersCount, LayersCount];
            for (int i = 0; i < this.LayersCount; i++)
            {
                temp[i, i] = this._matrix[i, i];
            }

            this._matrix = temp;
        }
    }
}
