using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class DefaultBehaviuor : MonoBehaviour
    {
        public GameObject Text;
        public GameObject Player;

        private float time;
        private bool isMenuVisible = false;
        private Vector3 lastAccelerationPosition;

        public GameObject Menu;

        public virtual void Start()
        {
            lastAccelerationPosition = Vector3.zero;
            time = Time.time;
        }

        protected void ShowText()
        {
            Vector3 playerPosition = this.Player.transform.position;
            Vector3 playerPositionZeroY = new Vector3(playerPosition.x, this.Text.transform.position.y, playerPosition.z);

            this.Text.transform.LookAt(playerPositionZeroY);
            this.Text.transform.Rotate(Vector3.up, 180.0f);

            this.Text.SetActive(true);
        }

        protected void HideText() { this.Text.SetActive(false); }

        protected void SetText(string newText) { this.Text.GetComponent<TextMesh>().text = newText; }

        protected void ShowMenu()
        {
            Vector3 playerPosition = this.Player.transform.position;
            Vector3 playerPositionZeroY = new Vector3(playerPosition.x, this.Menu.transform.position.y, playerPosition.z);

            this.Menu.transform.LookAt(playerPositionZeroY);
            this.Menu.transform.Rotate(Vector3.up, 180.0f);

            this.Menu.SetActive(true);
            isMenuVisible = true;
        }

        protected void HideMenu() { this.Menu.SetActive(false); isMenuVisible = false; }

        public virtual void Update()
        {
            if (this.Menu == null) return;

            Vector3 playerPosition = this.Player.transform.position;
            Vector3 playerPositionZeroY = new Vector3(playerPosition.x, this.Menu.transform.position.y, playerPosition.z);

            this.Menu.transform.LookAt(playerPositionZeroY);
            this.Menu.transform.Rotate(Vector3.up, 180.0f);

            if (isMenuVisible)
            {
                if (Time.time - time > 1.0f)
                {
                    if (Math.Abs(Vector3.Angle(Input.acceleration, lastAccelerationPosition) - 90) < 10)
                        this.HideMenu();

                    time = Time.time;
                    lastAccelerationPosition = Input.acceleration;
                }
            }
        }
    }
}
