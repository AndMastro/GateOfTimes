using UnityEngine;

namespace Assets.Scripts
{
    public class RedCubeBehaviour : DefaultBehaviuor
    {
        private float Alpha { get; set; }
        public ColorPicker colourPicker;

        public override void Start()
        {
            this.Alpha = 0.0f;

            colourPicker.onValueChanged.AddListener(newColour => this.ChangeColour(newColour));
        }

        public override void Update() { base.Update(); this.transform.Rotate(Vector3.up, this.Alpha); }

        public void OnTriggerClick()
        {
            this.ShowMenu();
        }

        public void OnTriggerEnter() { }
        public void OnTriggerExit() { }

        private void ChangeColour(Color newColour)
        {
            GetComponent<Renderer>().material.color = newColour;
        }
    }
}
