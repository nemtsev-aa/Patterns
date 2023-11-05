using System.Collections.Generic;
using System.Linq;

namespace Question3 {
    public class SameColorSphereDestroyed : VictoryCondition {
        public SameColorSphereDestroyed(IEnumerable<Sphere> spheres, InputSystem inputSystem) : base(spheres, inputSystem) {
        }

        public int CountNumberSpheresByType() {
            return Spheres.Count(sphere => sphere.Color == Color);
        }

        protected override void CountNumberSpheres(Sphere sphere) {
            if (sphere.Color != Color)
                return;

            if (CountNumberSpheresByType() == 0)
                SetComplited();
        }
    }
}