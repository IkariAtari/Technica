using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technica.Player
{
    public class Player : MonoBehaviour, Generic.IDamageable<int>
    {
        public int Health;
        public int MaxHealth;

        public Inventory.Inventory PlayerInventory;

        private void Start()
        {
            PlayerInventory = new Inventory.Inventory();
            PlayerInventory.InventorySize = 50;
            PlayerInventory.MaxStackSize = 20;

            if(PlayerInventory.Setup() == true)
            {
                Debug.Log("Player inventory has been setup");
            }
            else
            {
                Debug.LogError("Could not setup player inventory");
            }
        }

        public void Damage(int Damage)
        {
            Health -= Damage;
        }    
    }
}
