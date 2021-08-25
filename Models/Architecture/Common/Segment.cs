using System;

namespace Models.Architecture.Common {
	public class Segment : IDeepCopy<Segment> {
		public Position Start { get; set; }
		public Position End { get; set; }

		public Segment DeepCopy() {
			return new Segment {
				Start = Start?.DeepCopy(),
				End = End?.DeepCopy()
			};
		}

		public float Length() {
			return (float) Math.Sqrt(Math.Pow(Start.X - End.X, 2) + Math.Pow(Start.Y - End.Y, 2) +
			                         Math.Pow(Start.Z - End.Z, 2));
		}
	}
}
