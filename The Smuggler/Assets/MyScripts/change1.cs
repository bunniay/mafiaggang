using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lowend : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;
    // public int sceneBuildIndex;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("schange"))
        {
            Debug.Log("colllider is read");

            _sceneController.LoadScene("Underground");
            // SceneManager.LoadScene("PracticeRoom");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
