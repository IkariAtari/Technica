using UnityEngine;
using UnityEngine.UI;

namespace Technica.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        protected ushort MaxStack;
        public string Name;
        public int ID;
        public Image ItemImage;
        
        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }
    }
}
