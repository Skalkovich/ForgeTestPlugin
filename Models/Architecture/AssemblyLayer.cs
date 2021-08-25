namespace Models.Architecture {
	public partial class ArchitectureAssembly {
		public class AssemblyLayer : IDeepCopy<AssemblyLayer> {
			public string MaterialIdentity { get; set; }
			public string DisplayName { get; set; }
			public float Thickness { get; set; }
			public LayerFunction Function { get; set; }

			public AssemblyLayer DeepCopy() { 
				return new AssemblyLayer {MaterialIdentity = MaterialIdentity, Thickness = Thickness, Function = Function};
			}
		}
	}
}
