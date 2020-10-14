//-----------------------------------------------------------------------
// <copyright file="IMatrix.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace OOPDesignPrinciples
{
    public interface IMatrix<T>
    {
        T this[int x, int y] { get; set; }
        T[,] To2DArray();
    }
}
