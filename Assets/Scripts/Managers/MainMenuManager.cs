using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /*
        // World 1 level names
        [Header("=====World1=====")]
        [SerializeField] string _world1_level1;
        [SerializeField] string _world1_level2;
        [SerializeField] string _world1_level3;
        [Header("=====World2=====")]
        // World 2 level names
        [SerializeField] string _world2_level1;
        [SerializeField] string _world2_level2;
        [SerializeField] string _world2_level3;
    */

    public void LoadLevel(string _levelName)
    {
        SceneManager.LoadScene(_levelName);
    }
}
