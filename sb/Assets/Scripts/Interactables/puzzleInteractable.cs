using UnityEngine;

public class puzzleInteractable : MonoBehaviour
{
    [SerializeField] private GameObject puzzleCanvas;
    [SerializeField] private PuzzleManager puzzleManager;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject player;
    private Movement playerMovement;
    private bool isPlayerNearby = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<Movement>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetButtonDown("Submit"))
        {
            OpenPuzzle();
        }
    }

    private void OpenPuzzle()
    {
        Debug.Log("Puzzle starts");
        puzzleCanvas.SetActive(true);
        playerMovement.enabled = false;
        
    }

    public void ClosePuzzle()
    {
        Debug.Log("Puzzle ends");
        puzzleCanvas.SetActive(false);
        playerMovement.enabled = true;

        puzzleManager.PuzzleSolved();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactButton.SetActive(true);
            Debug.Log("Puzzle detected");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            isPlayerNearby = false;
        }
    }
}
