using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader) {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void Load(LevelLoadingData levelLoadingData) {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(levelLoadingData).WhenInjectedInto<GameplaySceneInstaller>();
        }, (int)SceneID.GameplayLevel);
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayLevel)
            throw new ArgumentException($"{SceneID.GameplayLevel} cannot be strated withot configuration, use ILevelLoader");

        _zenjectSceneLoader.Load(null, (int)sceneID);
    }
}
