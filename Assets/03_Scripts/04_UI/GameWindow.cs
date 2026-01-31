using UnityEngine;

namespace UI
{
    public abstract class GameWindow : MonoBehaviour
    {
        public abstract void OpenWindow();
        public abstract void CloseWindow();
    }
}