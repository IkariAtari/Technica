using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateTerrains;

namespace Technica.World
{
    public class WorldManager : MonoBehaviour
    {
        private UltimateTerrain Terrain;
        private bool TimeHasStarted = false;
        public int TimeScale;
        private int Timer = 0;

        [SerializeField]
        private GameObject Sun;

        private void Start()
        {
            Terrain = GameObject.Find("uTerrain").GetComponent<UltimateTerrain>() as UltimateTerrain;
            TimeHasStarted = Time.TimeInit();
            Time.TimeScale = TimeScale;
        }

        private void Update()
        {
            if(Timer < TimeScale)
            {
                Timer++;
            }
            else
            {
                TickSun();
                Timer = 0;
            }

            if (Terrain.IsLoaded == true && TimeHasStarted == true)
            {                        
                Time.Timer();
            }          
        }

        private void TickSun()
        {
            Sun.transform.rotation *= Quaternion.Euler(Vector3.right * 0.0020833f);
        }
    }
}

