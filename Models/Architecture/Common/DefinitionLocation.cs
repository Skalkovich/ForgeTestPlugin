namespace Models.Architecture.Common {
	public class DefinitionLocation: IDeepCopy<DefinitionLocation> {
		public int Section { get; set; }
		public int Level { get; set; }
		public DefinitionLocation DeepCopy() {
			return new DefinitionLocation {
				Section = Section,
				Level = Level
			};
		}
	}
}
