using _Scripts.Infrastructure.WinSystem.UI;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class UIInstaller : MonoInstaller
  {
    [SerializeField] private WinPresenter _winPresenter;
    
    public override void Register(IContainerBuilder builder)
    {
      builder.RegisterInstance(_winPresenter);
    }
  }
}