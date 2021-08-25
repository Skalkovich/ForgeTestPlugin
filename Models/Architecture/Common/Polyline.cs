using System.Collections.Generic;
using System.Linq;
using SpatialUtils;

namespace Models.Architecture.Common {
	public class Polyline : List<Segment>, IDeepCopy<Polyline> {
		public Polyline() { }

		public Polyline(List<Segment> segments):base(segments) { }
		public Polyline(Segment segment) : base(new List<Segment> { segment }) { }

		public Polyline DeepCopy() {
			return new Polyline(this?.Select(o=> o?.DeepCopy()).ToList());
		}

		public float Length() {
			return this.Select(s => s.Length()).Sum();
		}

		public SegmentNorms[] GetNorms() {
			List<float> lenSegments = this
				.Select(s => s.Length())
				.ToList();
			List<float> segmentLengthOffsets = lenSegments.CumulativeSum().ToList();
			float wallLen = segmentLengthOffsets.Last();
			return lenSegments
				.Zip(
					segmentLengthOffsets, (segLen, segOffsets) =>
					new SegmentNorms {
						MaxNorm = segOffsets / wallLen,
						SegLen = segLen,
						BasisNorm = (segOffsets - segLen) / wallLen,
						SegStart = segOffsets,
						PolyLength = wallLen
					})
				.ToArray();
		}
	}
}
