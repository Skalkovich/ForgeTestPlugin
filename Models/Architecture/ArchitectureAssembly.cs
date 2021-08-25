using System.Collections.Generic;
using System.Linq;

namespace Models.Architecture {
	public partial class ArchitectureAssembly : IDeepCopy<ArchitectureAssembly> {
		public string Identity { get; set; }
		public string DisplayName { get; set; }
		public List<AssemblyLayer> Layers { get; set; }
		public int BaseLayerIndex { get; set; }
		public Scenarios.ArchitecturalData.UnitsEnum Units { get; set; }

		public ArchitectureAssembly DeepCopy() {
			return new ArchitectureAssembly {
				Identity = Identity,
				DisplayName = DisplayName,
				Units = Units,
				Layers = Layers?.Select(o => o.DeepCopy()).ToList(),
				BaseLayerIndex = BaseLayerIndex
			};
		}
	}
}
