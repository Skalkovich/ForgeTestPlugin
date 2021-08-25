namespace Models.Architecture.Common {
	public class RelativePosition : IDeepCopy<RelativePosition> {
		// TODO: perform [0..1] check
		public float X { get; set; }
		public float Y { get; set; }

		public RelativePosition DeepCopy() {
			return new RelativePosition {
				X = X,
				Y = Y
			};
		}
	}
}
