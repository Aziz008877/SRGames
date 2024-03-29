using System.Collections.Generic;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PokeButton>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<QuestionContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<List<AnswerOption>>().FromComponentInHierarchy().AsSingle();
    }
}
