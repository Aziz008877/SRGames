using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PokeButton>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
