using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string UI; // Name of the overlay scene

    private void Start()
    {
        
     // Load and add the overlay scene additively
     SceneManager.LoadScene(UI, LoadSceneMode.Additive);
        
    }
}
