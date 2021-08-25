using System.Collections.Generic;

namespace Models.Architecture.Common {
	public class PolygonDefinition {
		public PolygonDefinition() {
				
		}
		public PolygonDefinition(List<Segment> segments) {
			Segments = segments;
		}
		public List<Segment> Segments { get; set; }
	}
}
