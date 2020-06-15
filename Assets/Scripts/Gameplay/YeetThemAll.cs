using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class YeetThemAll : MonoBehaviour
    {
        public Text winText;
        // Start is called before the first frame update
        void Start()
        {
            winText.text = "";
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                winText.text = "You Win!";
                Debug.Log("You Win!");
            }
        }
    }
}
