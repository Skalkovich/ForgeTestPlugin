using System.Collections.Generic;
using System.Linq;

namespace Models.Aggregate {
	public class Polygon: IDeepCopy<Polygon> {
		public List<Point> Nodes { get; set; }

		public Polygon(IEnumerable<Point> nodes) {
			Nodes = nodes.ToList();
		}

		public Polygon() { }

		public Polygon DeepCopy() {
			Polygon res = default(Polygon);
			if (Nodes != null) res = new Polygon(Nodes.Select(o => o.DeepCopy()).ToList());
			return res;
		}

		public static Polygon GetShiftedRectanglePolygon(double Length, double Width, double shiftX, double shiftY) {
			Point p1 = new Point { X = shiftX, Y = shiftY };
			Point p2 = new Point { X = shiftX + Length, Y = shiftY };
			Point p3 = new Point { X = shiftX + Length, Y = shiftY + Width };
			Point p4 = new Point { X = shiftX, Y = shiftY + Width };
			Polygon pol = new Polygon {
				Nodes = new List<Point> { p1, p2, p3, p4 }
			};
			return pol;
		}
		public static Polygon GetShiftedRectanglePolygonWithoutCorners(double Length, double Width, double shiftX, double shiftY, double dx,double dy) {
			Point p1 = new Point { X = shiftX + dx, Y = shiftY};
			Point p2 = new Point { X = shiftX + Length - dx, Y = shiftY };
			Point p3 = new Point { X = shiftX + Length - dx, Y = shiftY + dy};
			Point p4 = new Point { X = shiftX + Length, Y = shiftY + dy };
			Point p5 = new Point { X = shiftX + Length, Y = shiftY + Width - dy};
			Point p6 = new Point { X = shiftX + Length - dx, Y = shiftY + Width - dy };
			Point p7 = new Point { X = shiftX + Length - dx, Y = shiftY + Width };
			Point p8 = new Point { X = shiftX + dx, Y = shiftY + Width };
			Point p9 = new Point { X = shiftX + dx, Y = shiftY + Width - dy};
			Point p10 = new Point { X = shiftX , Y = shiftY + Width - dy };
			Point p11 = new Point { X = shiftX, Y = shiftY + dy };
			Point p12 = new Point { X = shiftX + dx, Y = shiftY + dy };
			Polygon pol = new Polygon {
				Nodes = new List<Point> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12}
			};
			return pol;
		}
	}
}
