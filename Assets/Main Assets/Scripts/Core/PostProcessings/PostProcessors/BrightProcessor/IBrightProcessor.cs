using FTP.Infrastructre.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.PostProcessing
{
    interface IBrightProcessor : IPostProcessor
    {
        public void SetBrightnessLevel(float brightnessLevel);
    }
}
