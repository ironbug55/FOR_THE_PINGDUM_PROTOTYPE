using FTP.Infrastructre.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.PostProcessing
{
    public class BrightProcessor : PostProcessorBase, IBrightProcessor
    {
        public void SetBrightnessLevel(float brightnessLevel)
        {
            PostProcessingMaterial.SetFloat("_Brightness", brightnessLevel);
        }
    }
}
