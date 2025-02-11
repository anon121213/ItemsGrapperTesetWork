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
      Debug.Log("asd");
      _winService = winService;
      _winService.OnWin += OnWin;
    }

    private void OnWin()
    {
      Debug.Log("asd");
      _view.Description.text = "You Win";
      _view.gameObject.SetActive(true);
    }

    public void Dispose() => 
      _winService.OnWin -= OnWin;
  }
}