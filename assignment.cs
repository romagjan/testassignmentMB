using System;
using System.Collections.Generic;

namespace FigureLibrary
{
    public interface IFigure
    {
        double CalculateArea();
    }

    public class Rectangle : IFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : IFigure
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
		public bool IsRectangular()
		{
			List <double> sides = new List<double>();
			sides.Add(Side1);
			sides.Add(Side2);
			sides.Add(Side3);
			sides.Sort();
			return  (sides[0]*sides[0]+sides[1]*sides[1]==sides[2]*sides[2]);
		}
        public double CalculateArea()
        {
            double p = (Side1+Side2+Side3) / 2.0;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
    }

    public class Circle : IFigure
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class AreaCalculator
    {
        public static double CalculateArea(IFigure figure)
        {
            return figure.CalculateArea();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureLibrary.Tests
{
    [TestClass]
    public class AreaCalculatorTests
    {
        [TestMethod]
        public void TestRectangleArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 4;
            rectangle.Height = 5;

            // Act
            double area = AreaCalculator.CalculateArea(rectangle);

            // Assert
            Assert.AreEqual(20, area);
        }

        [TestMethod]
        public void TestTriangleArea()
        {
            // Arrange
            Triangle triangle = new Triangle();
            triangle.Base = 4;
            triangle.Height = 5;

            // Act
            double area = AreaCalculator.CalculateArea(triangle);

            // Assert
            Assert.AreEqual(10, area);
        }

        [TestMethod]
        public void TestCircleArea()
        {
            // Arrange
            Circle circle = new Circle();
            circle.Radius = 5;

            // Act
            double area = AreaCalculator.CalculateArea(circle);

            // Assert
            Assert.AreEqual(78.53981633974483, area);
        }
    }
}
