using UnityEngine;

namespace MultiversalDungeons.Utilities
{
    public static class Utilities
    {

        public static Camera GameCamera;

        public static void Initialize()
        {
            SetGameCamera();
        }

        private static void SetGameCamera()
        {
            GameCamera = Camera.main;
        }
    }
}