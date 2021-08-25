using System;
using MathNet.Spatial.Euclidean;
using SpatialUtils.MathNet.Spatial.Euclidean;

namespace Models.Aggregate {
	public class Point : IEquatable<Point>, IDeepCopy<Point> {
		private double _x;
		private double _y;
		public double X {
			get { return Math.Round(_x, _rounding);}
			set { _x = value; }
		}
		public double Y {
			get { return Math.Round(_y, _rounding);}
			set { _y = value; }
		}
		private readonly double _tolerance = 1e-5;
		private readonly int _rounding = 6; 

		public Point() { }

		public Point(double x, double y) {
			X = x;
			Y = y;
		}

		public Point(Point point) {
			X = point.X;
			Y = point.Y;
		}

		public Point(Point2D point) {
			X = point.X;
			Y = point.Y;
		}

		public Point(Vector2D vector) {
			X = vector.X;
			Y = vector.Y;
		}

		public bool Equals(object other, double tolerance) {
			var point = other as Point;
			if (point == null) {
				return false;
			}
			return Math.Abs(X - point.X) < tolerance && Math.Abs(Y - point.Y) < tolerance;
		}

		public bool Equals(Point point) {
			return point != null && (Math.Abs(X - point.X) < _tolerance && Math.Abs(Y - point.Y) < _tolerance);
		}

		public override bool Equals(object other) {
			var point = other as Point;
			if (point == null) {
				return false;
			}

			return Math.Abs(X - point.X) < _tolerance && Math.Abs(Y - point.Y) < _tolerance;
		}
		public override int GetHashCode() {
			return (int) (X * X * Y * Y);
		}

		public static Point operator -(Point first, Point second) {
			return new Point {
				X = first.X - second.X,
				Y = first.Y - second.Y
			};
		}

		public static Point operator +(Point first, Point second) {
			return new Point {
				X = first.X + second.X,
				Y = first.Y + second.Y
			};
		}

		public static Point operator *(double value, Point second) {
			return new Point {
				X = value * second.X,
				Y = value * second.Y
			};
		}

		public Point2D ToPoints2D() {
			return new Point2D(X, Y);
		}

		public Point2D ToPoints2D(int nums) {
			return new Point2D(Math.Round(_x, nums), Math.Round(_y, nums));
		}

		public Vector2D ToVector2D() {
			return new Vector2D(X, Y);
		}

		public Vector3D ToVector3D() {
			return new Vector3D(X, Y, 0);
		}

		public bool CompareTo(Point2D point) {
			var tolerance = 1e-5;
			return Math.Abs(X - point.X) < tolerance && Math.Abs(Y - point.Y) < tolerance;
		}

		public Point DeepCopy() {
			return new Point {
				X = this.X,
				Y = this.Y
			};
		}
	}
}
