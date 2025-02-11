using System;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure.WinSystem.UI
{
  public class WinPresenter : MonoBehaviour, IDisposable
  {
    [SerializeField] private WinView _view;
    private IWinService _winService;

    [Inject]
    private void Construct(IWinService winService)
    {
      _winService = winService;
      _winService.OnWin += OnWin;
    }

    private void OnWin()
    {
      _view.Description.text = "You Win";
      _view.gameObject.SetActive(true);
    }

    public void Dispose() => 
      _winService.OnWin -= OnWin;
  }
}