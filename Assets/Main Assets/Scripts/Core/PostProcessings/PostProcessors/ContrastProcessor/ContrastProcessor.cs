using FTP.Infrastructre.PostProcessing;
using UnityEngine;

namespace FTP.Core.PostProcessing
{
    public class ContrastProcessor : PostProcessorBase, IContrastProcessor
    {
        public void SetContrastLevel(float contrastLevel)
        {
            PostProcessingMaterial.SetFloat("_Contrast", contrastLevel);
        }
    }
}
