using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    void Start() {
    }

    void Update() {
    }

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }

}
