using UnityEngine;

namespace Unfair
{
    public static class Loader
    {
        private static GameObject _gameObject;
        private static Main _main;

        public static void Load()
        {
            _gameObject = new GameObject();
            _main = _gameObject.AddComponent<Main>();
            Object.DontDestroyOnLoad(_gameObject);
            
            /*// initialize harmony and patch
            _main.Harmony = new HarmonyLib.Harmony("unfair");
            _main.Harmony.PatchAll();*/
        }

        public static void Unload()
        {
	        // unpatch
	        //_main.Harmony.UnpatchAll();
	        
            Object.Destroy(_gameObject);
        }
    }
}