using UnityEngine;
using UnityEngine.UI;

namespace Technica.UI
{
    public class UImanager : MonoBehaviour
    {
        public Text DebugText1;
        public Text Debugtext2;
        public Text TimeDisplay;
        public Text TimeDisplayAbsolute;
        public Text PlayerPosition;
        private GameObject Player;

        private void Start()
        {
            Player = GameObject.Find("Player");
        }

        private void Update()
        {
            TimeDisplay.text = "Second: " + World.Time.Second + "\n"
                              + "Minute: " + World.Time.Minute + "\n"
                              + "Hour: " + World.Time.Hour + "\n"
                              + "Day: " + World.Time.Day + "\n"
                              + "Week: " + World.Time.Week + "\n"
                              + "Month: " + World.Time.Month + "\n"
                              + "Year: " + World.Time.Year + "\n"
                              + "Ticks: " + World.Time.TotalTicks;
            TimeDisplayAbsolute.text = "Time: " + (World.Time.Hour + 5) + ":" + World.Time.Minute + ":" + World.Time.Second;
            PlayerPosition.text = "X: " + Mathf.Floor(Player.transform.position.x) + " Z: " + Mathf.Floor(Player.transform.position.z) + " Y :" + Mathf.Floor(Player.transform.position.y);
        }
    }
}
