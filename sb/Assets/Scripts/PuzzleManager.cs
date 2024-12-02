using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int totalPuzzles;
    public int puzzlesSolved = 0;
    [SerializeField] private GameObject orb;

    void Start()
    {
        // Make sure the orb is inactive at the start
        // if (orb != null)
        // {
        //     orb.SetActive(false);
        // }
    }

    public void PuzzleSolved()
    {
        puzzlesSolved++;
        Debug.Log("Puzzle solved! Total solved: " + puzzlesSolved);

        if (AllPuzzlesComplete())
        {
            ActivateOrb();
        }
    }

    private void ActivateOrb()
    {
        if (orb != null)
        {
            orb.SetActive(true);
            Debug.Log("All puzzles solved! Orb activated.");
        }
    }

    public bool AllPuzzlesComplete()
    {
        return puzzlesSolved >= totalPuzzles;
    }
}
