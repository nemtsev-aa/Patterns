using System;
using System.Collections.Generic;
using System.Linq;

namespace Question3 {
    public class VictoryConditionFactory {
        private readonly InputSystem _inputSystem;
        private IEnumerable<Sphere> _spheres;

        public IEnumerable<Sphere> Spheres {
            get { return _spheres; }
            set {
                if (value.Count() == 0) {
                    throw new ArgumentException($"Empty SphereList");
                }

                _spheres = value;
            }
        }

        public VictoryConditionFactory(InputSystem inputSystem) {
            _inputSystem = inputSystem;
        }

        public VictoryCondition GetVictoryCondition(VictoryConditionTypes conditionType) {
            switch (conditionType) {
                case VictoryConditionTypes.SameColor:
                    return new SameColorSphereDestroyed(_spheres, _inputSystem);

                case VictoryConditionTypes.AllColor:
                    return new AllSphereDestroyed(_spheres, _inputSystem);

                default:
                    throw new ArgumentException(nameof(conditionType));
            }
        }
    }
}