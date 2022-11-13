using FTP.Infrastructre.PostProcessing;

namespace FTP.Core.PostProcessing
{
    public interface IContrastProcessor : IPostProcessor
    {
        public void SetContrastLevel(float contrastLevel);
    }
}
