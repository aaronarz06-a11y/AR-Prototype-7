using UnityEngine;

public class Piano : MonoBehaviour
{
    public Transform player;
    public float interactDistance = 3f;
    public Transform pianoViewPoint;
    public Camera playerCamera;
    public Camera pianoCamera;
    public GameObject pianoInterface;
    public Movement playerMovement;
    public AudioManager songManager;
    private bool inPianoMode = false;

    void Start()
    {
        if (pianoCamera != null)
        pianoCamera.gameObject.SetActive(false);

        if (pianoInterface != null)
        pianoInterface.SetActive(false);
    }

    void Update()
    {
        if (player == null)
        return;

        if (!inPianoMode)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
            {
                EnterPianoMode();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPianoMode();
        }
    }

    void EnterPianoMode()
    {
        inPianoMode = true;

        if (playerMovement != null)
        playerMovement.enabled = false;

        if (playerCamera != null)
        playerCamera.gameObject.SetActive(false);

        if (pianoCamera != null)
        {
            if (pianoViewPoint != null)
            {
                pianoCamera.transform.position = pianoViewPoint.position;

                pianoCamera.transform.rotation = pianoViewPoint.rotation;
            }

            pianoCamera.gameObject.SetActive(true);
        }

        if (pianoInterface != null)
        pianoInterface.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (songManager != null)
        songManager.StartSong();
    }

    void ExitPianoMode()
    {
        inPianoMode = false;

        if (songManager != null)
        songManager.StopSong();

        if (pianoCamera != null)
        pianoCamera.gameObject.SetActive(false);

        if (playerCamera != null)
        playerCamera.gameObject.SetActive(true);

        if (pianoInterface != null)
        pianoInterface.SetActive(false);

        if (playerMovement != null)
        playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}