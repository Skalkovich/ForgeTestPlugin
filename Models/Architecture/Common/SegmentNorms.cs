using System;

namespace Models.Architecture.Common {
	public struct SegmentNorms : IEquatable<SegmentNorms> {
		public float MaxNorm { get; set; }
		public float SegLen { get; set; }
		public float BasisNorm { get; set; }
		public float SegStart { get; set; }
		public float PolyLength { get; set; }

		public bool Equals(SegmentNorms other) {
			double tolerance = 1e-5;
			return Math.Abs(MaxNorm - other.MaxNorm) < tolerance &&
				  Math.Abs(SegLen - other.SegLen) < tolerance &&
				  Math.Abs(BasisNorm - other.BasisNorm) < tolerance &&
				  Math.Abs(SegStart - other.SegStart) < tolerance;
		}
	}
}
