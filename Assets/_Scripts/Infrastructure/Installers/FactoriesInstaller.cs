using _Scripts.Gameplay.Items.Factory;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Infrastructure.Factories.Cameras;
using _Scripts.Infrastructure.Factories.Player;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class FactoriesInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
      builder.Register<ICameraFactory, CameraFactory>(Lifetime.Singleton);
      builder.Register<IItemsFactory, ItemsFactory>(Lifetime.Singleton);
      builder.Register<IItemsSpawner, ItemsSpawner>(Lifetime.Singleton);
    }
  }
}