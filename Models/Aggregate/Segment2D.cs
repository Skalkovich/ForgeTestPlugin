using MathNet.Spatial.Euclidean;

namespace Models.Aggregate {
	public class Segment2D : IDeepCopy<Segment2D> {
		public Segment2D() { }

		public Segment2D(Point start, Point end) {
			Start = start;
			End = end;
		}

		public Segment2D(Line2D line) {
			Start = new Point(line.StartPoint);
			End = new Point(line.EndPoint);
		}
			
		public Point Start { get; set; }
		public Point End { get; set; }

		public Segment2D DeepCopy() {
			return new Segment2D {
				Start = Start.DeepCopy(),
				End = End.DeepCopy()
			};
		}
	}
}
