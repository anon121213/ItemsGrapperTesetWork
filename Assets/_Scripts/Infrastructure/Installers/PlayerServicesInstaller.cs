using _Scripts.Gameplay.Items.Container;
using _Scripts.Gameplay.Player.Mover;
using _Scripts.Gameplay.Player.Services;
using _Scripts.Gameplay.Player.Services.Services.Base;
using _Scripts.Gameplay.Player.Services.Services.Camera;
using _Scripts.Gameplay.Player.Services.Services.Grapper;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class PlayerServicesInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<IItemsContainer, ItemsContainer>(Lifetime.Singleton);
      builder.Register<IPlayerServices, PlayerServices>(Lifetime.Singleton);
      builder.Register<IGrapper, Grapper>(Lifetime.Singleton).As<IUpdatable>();
      builder.Register<ICameraRotator, CameraRotator>(Lifetime.Singleton).As<IUpdatable>();
      builder.Register<IPlayerMover, PlayerMover>(Lifetime.Singleton).As<IFixedUpdatable>();
    }
  }
}