using UnityEngine;

namespace Technica.Items.Tools
{
    public class Tool : Item
    {
        [SerializeField]
        protected int Uses;

        protected virtual void Use()
        {
            Uses -= 1;
        }
    }
}
