using UnityEngine;

namespace FTP.Infrastructre.Utils
{
    public class Helper
    {
        /// <summary>
        /// To remove (Clone) name on editor.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void RemoveCloneNameOnGameobject(GameObject gameObject)
        {
            var cloneStartIndex = gameObject.name.IndexOf("(Clone)");
            gameObject.name = gameObject.name.Remove(cloneStartIndex);
        }
    }
}
