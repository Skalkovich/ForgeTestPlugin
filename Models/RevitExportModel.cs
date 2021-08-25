using System.Collections.Generic;
using Models.Aggregate;
using Models.Architecture;
using Models.Architecture.Common;

namespace Models.Externals.Revit {
	public class RevitExportModel {
		public List<Level> Levels { get; set; }
		public Grid Grid { get; set; }
		public List<ElementDefinition> Columns { get; set; }
		public List<ElementDefinition> Beams { get; set; }
		public List<ElementDefinition> Ramps { get; set; }
		public List<SlabDefinition> Slabs { get; set; }
		public List<WallDefinition> Walls { get; set; }
		public BuildingType BuildingType { get; set; }
	}

	public enum BuildingType {
		McCarthyParking = 0,
		ImtiResidential
	}

	public class Level {
		public int Id { get; set; }
		public string Identity { get; set; }
		public double Elevation { get; set; }
	}

	public class ElementDefinition {
		public int Id { get; set; }
		public DefinitionLocation Location { get; set; }
		public ElementGeometry Geometry { get; set; }
	}

	public class ElementGeometry {
		public Position StartPosition { get; set; }
		public Position EndPosition { get; set; }
		public Position YDirection { get; set; }
		public Section Section { get; set; }
		public Binding Binding { get; set; }
	}

	public enum Binding {
		Middle = 0,
		Top,
		Bottom
	}

	public class Section {
		public float Width { get; set; }
		public float Height { get; set; }
	}


	public class DefinitionLocation {
		public int Block { get; set; }
		public int Level { get; set; }
	}

	public partial class SlabDefinition {
		public int Id { get; set; }
		public DefinitionLocation Location { get; set; }
		public SlabGeometry Geometry { get; set; }
	}

	public class SlabGeometry {
		public ArchitectureAssembly Assembly { get; set; }
		public List<Position> Polygon { get; set; }
		public List<OpeningSlabDefinition> Openings { get; set; }
		public Binding Binding { get; set; }
	}

	public class OpeningSlabDefinition {
		public List<Position> Polygon { get; set; }
	}

	//Grid
	public class Grid {
		public List<Axis> VerticalAxes { get; set; }
		public List<Axis> HorizontalAxes { get; set; }
	}

	public class Axis {
		public string Id { get; set; }
		public AxisPosition Position { get; set; }
	}

	public class AxisPosition {
		public Point Origin { get; set; }
		public Point Direction { get; set; }
	}

	//Wall
	public class WallDefinition {
		public int Id { get; set; }
		public DefinitionLocation Location { get; set; }
		public WallGeometry Geometry { get; set; }
	}

	/// <summary>
	/// Path - OX axis for contour of the shape
	/// FaceVector - direction of assembly
	/// </summary>
	public class WallGeometry  {
		public Segment Path { get; set; }
		public double StartHeight { get; set; }
		public double EndHeight { get; set; }
		public Position FaceVector { get; set; }
		public ArchitectureAssembly Assembly { get; set; }
		public List<PolygonDefinition> Holes { get; set; }
		public List<OpeningDefinition> Openings { get; set; }
		public WallBinding Binding { get; set; }
	}

	public class OpeningDefinition  {
		public int Id { get; set; }
		public string Name { get; set; }
		public OpeningPosition Position { get; set; }
		public OpeningSize Size { get; set; }
		public OpeningType OpeningType { get; set; }
	}

	public class OpeningPosition {
		public double X { get; set; }
		public double Y { get; set; }
	}

	public class OpeningSize {
		public double Width { get; set; }
		public double Height { get; set; }
	}

	public enum OpeningType {
		Unknown = 0,
		Window = 1,
		Entry = 2,
		Door = 3,
		Opening = 4
	}

	public enum WallBinding {
		Middle = 0,
		Left,
		Right
	}
}
