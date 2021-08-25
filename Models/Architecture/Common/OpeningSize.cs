namespace Models.Architecture.Common {
	public class OpeningSize: IDeepCopy<OpeningSize>{
		public float Width { get; set; }
		public float Height { get; set; }
		public OpeningSize DeepCopy() {
			return new OpeningSize{
				Width = Width,
				Height = Height
			};
		}
	}
}
