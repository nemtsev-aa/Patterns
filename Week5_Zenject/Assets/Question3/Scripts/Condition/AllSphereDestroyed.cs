using System.Collections.Generic;
using System.Linq;

namespace Question3 {
    public class AllSphereDestroyed : VictoryCondition {
        public AllSphereDestroyed(IEnumerable<Sphere> spheres, InputSystem inputSystem) : base(spheres, inputSystem) {
        }

        protected override void CountNumberSpheres(Sphere sphere) {
            if (Spheres.Count() == 0)
                SetComplited();
        }
    }
}