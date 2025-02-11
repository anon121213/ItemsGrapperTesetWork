using System;
using _Scripts.Gameplay.Items.Container;

namespace _Scripts.Infrastructure.WinSystem
{
  public class WinService : IWinService
  {
    private readonly IItemsContainer _itemsContainer;
    public event Action OnWin;

    public WinService(IItemsContainer itemsContainer) =>
      _itemsContainer = itemsContainer;

    public void Initialize() =>
      _itemsContainer.AllItemsDelivered += Win;

    private void Win() => 
      OnWin?.Invoke();
  }

  public interface IWinService
  {
    event Action OnWin;
    void Initialize();
  }
}