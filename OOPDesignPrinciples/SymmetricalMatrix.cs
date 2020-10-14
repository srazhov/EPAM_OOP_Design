//-----------------------------------------------------------------------
// <copyright file="SymmetricalMatrix.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------


namespace OOPDesignPrinciples
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Class for Symmetrical Matrix. Inherited from the <see cref="SquareMatrix{T}"/> class.
    /// <para>A symmetric matrix is a square matrix that is equal to its transpose</para>
    /// </summary>
    /// <typeparam name="T">Any type to store in matrix</typeparam>
    public class SymmetricalMatrix<T> : DiagonalMatrix<T>, IMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class
        /// <para>The entries of a symmetric matrix are symmetric with respect to the main diagonal.</para>
        /// </summary>
        /// <param name="array">Array must be square (X = Y)</param>
        public SymmetricalMatrix(T[,] array) : base(array)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class
        /// <para>Matrix is empty with the given size</para>
        /// </summary>
        /// <param name="size">Size of the 2D array</param>
        public SymmetricalMatrix(int size) : base(size)
        {

        }

        /// <summary>
        /// Sorting method of matrix
        /// </summary>
        protected override void SortingMethod()
        {
            T[,] temp = new T[LayersCount, LayersCount];
            for (int i = 0; i < LayersCount; i++)
            {
                for (int k = 0; k < LayersCount; k++)
                {
                    if (i <= k) {
                        temp[i, k] = _matrix[i, k];
                        temp[k, i] = _matrix[i, k];
                    }
                }
            }
            _matrix = temp;
        }
    }
}
