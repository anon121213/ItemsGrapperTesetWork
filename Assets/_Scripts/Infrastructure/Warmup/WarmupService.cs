using System.Collections.Generic;
using _Scripts.Gameplay.Items.Factory;
using _Scripts.Infrastructure.Factories.Cameras;
using _Scripts.Infrastructure.Factories.Player;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.Warmup
{
  public class WarmupService : IWarmupService
  {
    private readonly List<IWarmupable> _warmupables = new();

    public WarmupService(IItemsFactory itemsFactory,
      IPlayerFactory playerFactory,
      ICameraFactory cameraFactory)
    {
      _warmupables.Add(itemsFactory);
      _warmupables.Add(playerFactory);
      _warmupables.Add(cameraFactory);
    }

    public async UniTask Warmup()
    {
      foreach (var warmupable in _warmupables) 
        await warmupable.Warmup();
    }
  }

  public interface IWarmupable
  {
    UniTask Warmup();
  }
}