using Cysharp.Threading.Tasks;

namespace FTP.Infrastructre.Screens
{
    public interface IScreen
    {
        public UniTask Initialize();
        public UniTask OnShow();
        public UniTask OnHide();
    }
}
