
namespace Question3 {
    public class VictoryConditionSwitcher {
        private LevelLoadingData _levelLoadingData;
        private VictoryConditionFactory _conditionFactory;
        private SpheresSpawner _spheresSpawner;

        public VictoryConditionSwitcher(LevelLoadingData levelLoadingData, VictoryConditionFactory conditionFactory, SpheresSpawner spheresSpawner) {
            _levelLoadingData = levelLoadingData;
            _conditionFactory = conditionFactory;
            _spheresSpawner = spheresSpawner;
        }

        public VictoryCondition GetVictoryCondition() {
            _conditionFactory.Spheres = _spheresSpawner.Spheres;
            VictoryCondition condition = _conditionFactory.GetVictoryCondition(_levelLoadingData.ConditionType);
            condition.SetColorDestroyedSpheres(_levelLoadingData.SphereColor);
            
            return condition;
        }
    }
}