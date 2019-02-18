using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class TeleportationBehaviour : DefaultBehaviuor
    {
        public GameObject GVRPointer;
        private float yCurrentValue;
        private float yPreviousValue;

        public override void Start()
        {
            base.Start();

            this.SetText("Move [E]");

            yCurrentValue = 0.0f;
            yPreviousValue = 0.0f;
        }

        public void OnTriggerEnter() { this.ShowText(); }
        public void OnTriggerExit() { this.HideText(); }

        public void OnTriggerClick()
        {
            Vector3 translation = this.transform.position - this.Player.transform.position;
            translation.y = 0.0f;

            this.Player.transform.Translate(translation);
        }
    }
}
