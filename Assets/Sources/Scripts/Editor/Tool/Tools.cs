using Sources.Scripts.Domain.Models.Data.Ids;
using UnityEditor;
using UnityEngine;

namespace Sources.Scripts.Editor.Tool
{
    public class Tools
    {
        [MenuItem("Tools/Clear prefs")]
        public static void ClearPrefs()
        {
            foreach (string id in ModelId.ModelsIds)
            {
                Debug.Log($"Deleted {id}");
                PlayerPrefs.DeleteKey(id);
            }

            PlayerPrefs.Save();
        }
    }
}