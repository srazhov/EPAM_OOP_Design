//-----------------------------------------------------------------------
// <copyright file="MatrixTests.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace OOPDesignPrinciples.Tests
{
    using NUnit.Framework;
    using System;

    /// <summary>
    /// Test class for <see cref="IMatrix{T}"/> interface
    /// </summary>
    [TestFixture]
    public class MatrixTests
    {
        private SquareMatrix<int> square;
        private SymmetricalMatrix<int> symmetric;

        private DiagonalMatrix<int> diagonal;
        private DiagonalMatrix<int> diagonalDiff;

        private SquareMatrix<string> squareString;
        private DiagonalMatrix<string> diagonalString;
        
        /// <summary>
        /// Setup method
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            int[,] arrayA =
            {
                { 4, 6, 3 },
                { 4, 6, 3 },
                { 4, 6, 3 }
            };

            int[,] arrayB =
            {
                { 5, 2, 7 },
                { 5, 2, 7 },
                { 5, 2, 7 }
            };

            string[,] arrayStr =
            {
                { "asd", "aqwe" },
                { "sakjd", "qwrb" }
            };

            // All of them have integer values
            this.square = new SquareMatrix<int>(arrayA);
            this.symmetric = new SymmetricalMatrix<int>(arrayB);

            this.squareString = new SquareMatrix<string>(arrayStr);
            this.diagonalString = new DiagonalMatrix<string>(2); // Full of nulls

            this.diagonal = new DiagonalMatrix<int>(arrayB); // Length is 3
            this.diagonalDiff = new DiagonalMatrix<int>(5);
        }

        /// <summary>
        /// Test method of additions of different matrixes 
        /// </summary>
        [Test]
        public void TestMatrix_INT_additions()
        {
            // Adding different types of matrix
            int[,] result = this.square + this.symmetric;

            int[,] expected = 
            {
                { 9, 8, 10 },
                { 6, 8, 10 },
                { 11, 13, 10 }
            };

            this.square.Show();
            this.symmetric.Show();

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Can normal values add default(null) values
        /// </summary>
        [Test]
        public void TestMatrix_DefaultPlusValue()
        {
            // squareString - is full of strings
            string[,] expected = this.squareString.To2DArray();

            // diagonalString - is null
            string[,] result = this.squareString + this.diagonalString;

            this.squareString.Show();
            this.diagonalString.Show();

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Should throw exception because Lengths of the objects cannot be different
        /// </summary>
        [Test]
        public void TestMatrix_CanMatrixesWithDiffLenghtsAdd()
        {
            int[,] result;

            // diagonal's length = 3
            // diagonalDiff's length = 5
            var ex = Assert.Throws<System.ArgumentException>(() => { result = this.diagonal + this.diagonalDiff; });
            Assert.AreEqual("Lengths of the objects cannot be different.", ex.Message);
        }

        /// <summary>
        /// Test of how symmetrical Matrix sort methods works
        /// </summary>
        [Test]
        public void SymmetricMatrixTest()
        {
            int[,] array =
            {
                { 4, 20, 69 },
                { 4, 20, 69 },
                { 4, 20, 69 }
            };

            SymmetricalMatrix<int> symmetrical = new SymmetricalMatrix<int>(array);

            int[,] expected =
            {
                { 4, 20, 69 },
                { 20, 20, 69 },
                { 69, 69, 69 }
            };

            int[,] actual = symmetrical.To2DArray();

            symmetrical.Show();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test of how actions work when element changed 
        /// </summary>
        [Test]
        public void TestOfActions()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(4);
            matrix.AddActionWhenElementChanged(3, 3, () => { Console.WriteLine("Test Works!!!"); matrix[2, 2] = 140; });

            matrix[3, 3] = 169;

            Assert.AreEqual(140, matrix[2, 2]);
        }

        /// <summary>
        /// Test of matrix' behavior on changing object outside the main diagonal
        /// </summary>
        [Test]
        public void Test_SettingObjectOutsideTheDiagonal()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(4);

            matrix[3, 1] = 169;

            Assert.AreEqual(0, matrix[3, 1]);

            SymmetricalMatrix<int> second = new SymmetricalMatrix<int>(10);

            second[1, 5] = 184;

            Assert.AreEqual(184, second[1, 5]);
            Assert.AreEqual(184, second[5, 1]);
        }
    }
}
