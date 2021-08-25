using Models.Architecture.Abstractions;

namespace Models.Architecture.Common {
	public class OpeningDefinition: IDeepCopy<OpeningDefinition>, IOpeningDefinition {
		public int OpeningId { get; set; }
		public string OpeningIdentity { get; set; }
		public RelativePosition Position { get; set; }
		public OpeningSize Size { get; set; }
		public OpeningType Type { get; set; }

		public OpeningDefinition DeepCopy() {
			return new OpeningDefinition {
				OpeningId = OpeningId,
				OpeningIdentity = OpeningIdentity,
				Position = Position?.DeepCopy(),
				Size = Size?.DeepCopy(),
				Type = Type
			};
		}
	}

	public enum OpeningType {
		Unknown = 0,
		Window = 1,
		Door = 3,
		LiftDoor = 4,
		Entry = 2,
		Opening = 5
	}
}
