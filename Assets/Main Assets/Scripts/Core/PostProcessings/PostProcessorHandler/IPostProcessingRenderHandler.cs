using FTP.Infrastructre.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.PostProcessing.Handler
{
    public interface IPostProcessingRenderHandler
    {
        public void InitalizePostProcessors(List<IPostProcessor> postProcessorBases);
    }
}
