namespace Models.Architecture.Common {
	public class Position : IDeepCopy<Position> {
		public Position() {}
		public Position(float x, float y, float z) {
			X = x;
			Y = y;
			Z = z;
		}

		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }

		public Position DeepCopy() {
			return new Position {
				X = X,
				Y = Y,
				Z = Z
			};
		}
	}
}
