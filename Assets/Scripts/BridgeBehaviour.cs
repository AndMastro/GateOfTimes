using UnityEngine;

namespace Assets.Scripts
{
    public class BridgeBehaviour : DefaultBehaviuor, ITimedEventHandler
    {
        private float Alpha { get; set; }
        
        public ColorPicker colourPicker;
        
        private bool isMenuActive = false;
        public override void Start()
        {
            this.Alpha = 0.0f; this.SetText("Rotate [E]");
        }

        public override void Update() { base.Update(); this.transform.Rotate(Vector3.up, this.Alpha);
            if (isMenuActive && Vector3.Distance(Player.transform.position, Menu.transform.position) >= 90f)
            {
                this.HideMenu();
                isMenuActive = !isMenuActive;
            }
        }

        public void OnTriggerClick() { }
        public void OnTriggerEnter() { }
        public void OnTriggerExit() { }

        public void HandleTimedInput()
        {
            if (!isMenuActive)
                this.ShowMenu();
            else this.HideMenu();

            isMenuActive = !isMenuActive;
        }
    }
}
