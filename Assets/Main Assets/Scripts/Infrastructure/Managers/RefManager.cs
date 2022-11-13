using FTP.Core.Managers;
using FTP.Infrastructre.Bootstraps;

namespace FTP.Infrastructre.Managers
{
    public abstract class RefManager
    {
        protected static Bootstrap _bootstrap;

        public static void SetBootstrap(Bootstrap instance)
        {
            _bootstrap = instance;
        }
    }

    public class RefManager<T> : RefManager where T : IManager
    {
        private T _manager;

        public T GetManager
        {
            get
            {
                if(_manager == null)
                {
                    _manager = _bootstrap.GetManager<T>();
                }

                return _manager;
            }
        }
    }
}
