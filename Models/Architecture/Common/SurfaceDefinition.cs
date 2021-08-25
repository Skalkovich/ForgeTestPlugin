using System.Collections.Generic;

namespace Models.Architecture.Common {
	public class SurfaceDefinition {
		public SurfaceDefinition() { }

		public SurfaceDefinition(int id, string material, PolygonDefinition contour, List<PolygonDefinition> openings) {
			Id = id;
			Material = material;
			Contour = contour;
			Openings = openings;
		}

		public int  Id { get; set; }
		public string Material { get; set; }
		public PolygonDefinition Contour { get; set; }
		public List<PolygonDefinition> Openings { get; set; }
	}
}
