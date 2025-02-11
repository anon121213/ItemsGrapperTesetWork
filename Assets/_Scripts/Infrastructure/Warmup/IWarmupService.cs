using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.Warmup
{
  public interface IWarmupService
  {
    UniTask Warmup();
  }
}