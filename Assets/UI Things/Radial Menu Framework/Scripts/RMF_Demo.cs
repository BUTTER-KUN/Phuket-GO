using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RMF_Demo : MonoBehaviour {

    public ParticleSystem ps;
    public RMF_RadialMenu rm;

    void Update() {
        if (Input.GetKeyDown(KeyCode.S) && rm.useLazySelection) {
            rm.useSelectionFollower = !rm.useSelectionFollower;
            rm.selectionFollowerContainer.gameObject.SetActive(rm.useSelectionFollower);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SceneManager.LoadScene(1);
        }
    }

    public void emitButton(int count) {
        ps.Emit(count);
    }
}
