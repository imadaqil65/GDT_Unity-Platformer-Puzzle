using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipePuzzleManager : MonoBehaviour
{
    [SerializeField] private puzzleInteractable puzzleInteractable;
    [SerializeField] private GameObject pipesParent; // Parent GameObject containing all the pipes
    private List<Pipe> pipes = new List<Pipe>(); // List of pipes in the puzzle
    private int pipesPerRow; // Number of pipes per row (calculated based on total pipes)
    private int selectedPipeIndex = 0;

    void Start()
    {
        InitializePipes();
        HighlightSelectedPipe();
    }

    void Update()
    {
        HandleKeyboardInput();
    }

    private void InitializePipes()
    {
        // Get all Pipe components from the children of pipesParent
        pipes.AddRange(pipesParent.GetComponentsInChildren<Pipe>());

        // Calculate pipesPerRow based on the number of pipes
        int totalPipes = pipes.Count;
        pipesPerRow = Mathf.RoundToInt(Mathf.Sqrt(totalPipes));

        if (pipesPerRow * pipesPerRow != totalPipes)
        {
            Debug.LogWarning("The number of pipes does not form a perfect square grid. Adjust the number of pipes for best results.");
        }
    }

    private void HandleKeyboardInput()
    {
        // Navigate between pipes using Horizontal and Vertical inputs
        if (Input.GetButtonDown("Horizontal"))
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput > 0) ChangeSelection(1); // Right
            else if (horizontalInput < 0) ChangeSelection(-1); // Left
        }

        if (Input.GetButtonDown("Vertical"))
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            if (verticalInput > 0) ChangeSelection(-pipesPerRow); // Up
            else if (verticalInput < 0) ChangeSelection(pipesPerRow); // Down
        }

        // Rotate the selected pipe
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space))
        {
            pipes[selectedPipeIndex].RotatePipe();
            CheckIfPuzzleSolved();
        }
    }

    private void ChangeSelection(int direction)
    {
        // Update selected pipe index within bounds
        selectedPipeIndex = (selectedPipeIndex + direction + pipes.Count) % pipes.Count;
        HighlightSelectedPipe();
    }

    private void HighlightSelectedPipe()
    {
        // Visual feedback for selected pipe
        foreach (var pipe in pipes)
            pipe.GetComponent<Image>().color = Color.white; // Reset all pipes to white

        pipes[selectedPipeIndex].GetComponent<Image>().color = Color.yellow; // Highlight selected pipe
    }

    private void CheckIfPuzzleSolved()
    {
        foreach (var pipe in pipes)
        {
            if (!pipe.IsCorrectlyAligned())
                return;
        }
        
        Debug.Log("Puzzle Solved!");
        puzzleInteractable.ClosePuzzle(); // Close the Puzzle
    }
}
