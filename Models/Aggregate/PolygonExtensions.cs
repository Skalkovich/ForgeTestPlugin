using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Aggregate {
	public static class PolygonExtensions {
		public static double Area(this Polygon polygon) {
			if (polygon is null) {
				throw new ArgumentNullException(nameof(polygon));
			}
			if (polygon.Nodes is null) {
				throw new ArgumentNullException(nameof(polygon.Nodes));
			}

			List<Point> points = new List<Point>(polygon.Nodes) {polygon.Nodes[0]};
			double area = Math.Abs(points.Take(points.Count - 1)
			.Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
			.Sum() / 2);
			return area;
		}

		public static SpatialUtils.Contour ToContour(this Polygon polygon) {
			if (polygon is null) {
				throw new ArgumentNullException(nameof(polygon));
			}
			if (polygon.Nodes is null) {
				throw new ArgumentNullException(nameof(polygon.Nodes));
			}
			var points = polygon.Nodes.Select(p=>p.ToPoints2D()).ToList();
			return new SpatialUtils.Contour(points);
		}

		public static SpatialUtils.Contour ToContour(this Polygon polygon, int nums, double eps) {
			if (polygon is null) {
				throw new ArgumentNullException(nameof(polygon));
			}
			if (polygon.Nodes is null) {
				throw new ArgumentNullException(nameof(polygon.Nodes));
			}

			List<MathNet.Spatial.Euclidean.Point2D> roundedPoints = polygon.Nodes.Select(p => p.ToPoints2D(nums)).ToList();
			List<MathNet.Spatial.Euclidean.Point2D> cleanedPoints = new List<MathNet.Spatial.Euclidean.Point2D> { roundedPoints[0]};
			for (int i = 1; i < roundedPoints.Count; i++) {
				if (roundedPoints[i].DistanceTo(cleanedPoints.Last()) > eps) {
					cleanedPoints.Add(roundedPoints[i]);
				}
			}
			return new SpatialUtils.Contour(cleanedPoints);
		}

		public static Polygon ToAggregatePolygon(this SpatialUtils.Contour contour) {
			if (contour is null) {
				throw new ArgumentNullException(nameof(contour));
			}
			if (contour.Points?.Count == 0) {
				throw new ArgumentNullException(nameof(contour.Points));
			}
			var points = contour.Points.Select(p => new Point(p)).ToList();
			return new Polygon(points);
		}
	}
}
