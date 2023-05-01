using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour {
    public AudioClip earthquakeSound;
    public float shakeDuration = 5f;
    public float shakeMagnitude = 0.1f;
    public GameObject preTilemap;
    public GameObject postTilemap;
    public string nextSceneName;

    private AudioSource audioSource;
    private Vector3 originalCameraPosition;
    private Camera mainCamera;

    private void Start(){
        mainCamera = Camera.main;
        originalCameraPosition = mainCamera.transform.position;
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(CutsceneSequence());
    }

    private IEnumerator CutsceneSequence(){
        audioSource.PlayOneShot(earthquakeSound, 1f);
        yield return new WaitForSeconds(2);

        StartCoroutine(CameraShake());
        yield return new WaitForSeconds(2); 
        preTilemap.SetActive(false);
        postTilemap.SetActive(true);
        yield return new WaitForSeconds(shakeDuration - 2); 

        yield return new WaitForSeconds(2);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator CameraShake(){
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration) {
            float x = Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = Random.Range(-shakeMagnitude, shakeMagnitude);
            mainCamera.transform.position = new Vector3(originalCameraPosition.x + x, originalCameraPosition.y + y, originalCameraPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = originalCameraPosition;
    }
}
