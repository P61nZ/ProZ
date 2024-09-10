using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Garfield_Collect_Move_List : MonoBehaviour
{
    public GarfieldCollectMove Data_Garfield_Move;
    private List<char> moveHistory = new List<char>();
    private const int MaxHistorySize = 20;
    Animator anim;

    // Dictionary to store move sequences and their corresponding animation triggers
    private readonly Dictionary<string, char[]> sequences = new Dictionary<string, char[]>()
    {
        { "attack1", new[] { 'U', 'L', 'D', 'R', 'R' } },
        { "attack2", new[] { 'U', 'L', 'D', 'R', 'L' } },
        { "attack3", new[] { 'U', 'L', 'D', 'R', 'D' } },
        { "attack4", new[] { 'U', 'L', 'D', 'L', 'L' } },
        { "attack5", new[] { 'U', 'L', 'D', 'R', 'L' } },
        { "attack6", new[] { 'U', 'L', 'L', 'R', 'L' } },
        { "attack7", new[] { 'R', 'L', 'R', 'R', 'L' } },
        { "attack8", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack9", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack10", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack11", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack12", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack13", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack14", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack15", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack16", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack17", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack18", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack19", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack20", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack21", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack22", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack23", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack24", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack25", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack26", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack27", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack28", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack29", new[] { 'L', 'L', 'D', 'R', 'L' } },
        { "attack30", new[] { 'L', 'L', 'D', 'R', 'L' } },
    };

    void Start()
    {
        anim = GetComponent<Animator>();
        Data_Garfield_Move = GetComponent<GarfieldCollectMove>();
        if (Data_Garfield_Move != null)
        {
            Debug.Log("ได้ Component GarfieldCollectMove มาเรียบร้อยแล้ว");
        }
        else
        {
            Debug.LogError("ไม่มี Component GarfieldCollectMove ใน GameObject นี้");
        }
    }

    void Update()
    {
        // Track movement inputs
        if (Input.GetKeyDown(KeyCode.W) && Data_Garfield_Move.GarfieldMoveUp == 'U')
        {
            AddMoveToHistory(Data_Garfield_Move.GarfieldMoveUp);
        }
        if (Input.GetKeyDown(KeyCode.S) && Data_Garfield_Move.GarfieldMoveDown == 'D')
        {
            AddMoveToHistory(Data_Garfield_Move.GarfieldMoveDown);
        }
        if (Input.GetKeyDown(KeyCode.A) && Data_Garfield_Move.GarfieldMoveLeft == 'L')
        {
            AddMoveToHistory(Data_Garfield_Move.GarfieldMoveLeft);
        }
        if (Input.GetKeyDown(KeyCode.D) && Data_Garfield_Move.GarfieldMoveRight == 'R')
        {
            AddMoveToHistory(Data_Garfield_Move.GarfieldMoveRight);
        }
        if (Input.GetMouseButtonDown(0))
        {
            CheckMoveSequence();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("ประวัติการเคลื่อนไหว: " + string.Join(", ", moveHistory));
        }
    }

    private void AddMoveToHistory(char move)
    {
        if (moveHistory.Count >= MaxHistorySize)
        {
            moveHistory.RemoveAt(0);
        }
        moveHistory.Add(move);
    }

    private void CheckMoveSequence()
    {
        if (moveHistory.Count < sequences.Values.Max(seq => seq.Length))
        {
            moveHistory.Clear();
            return;
        }

        foreach (var kvp in sequences)
        {
            string triggerName = kvp.Key;
            char[] sequence = kvp.Value;

            if (IsSequenceMatch(sequence))
            {
                Debug.Log($"ลำดับตรง: {string.Join(", ", sequence)}");
                HandleSequenceMatch(triggerName);
                moveHistory.Clear();
                return;
            }
        }

        // Handle the last move if no sequence matched
        if (moveHistory.Count > 0)
        {
            char lastMove = moveHistory[moveHistory.Count - 1];
            Debug.Log($"Last move: {lastMove}");
            HandleLastMove(lastMove);
        }
    }

    private bool IsSequenceMatch(char[] sequence)
    {
        List<char> lastMoves = moveHistory.GetRange(moveHistory.Count - sequence.Length, sequence.Length);

        for (int i = 0; i < sequence.Length; i++)
        {
            if (lastMoves[i] != sequence[i])
            {
                return false;
            }
        }
        return true;
    }

    private void HandleSequenceMatch(string triggerName)
    {
        Debug.Log("จัดการลำดับที่ตรง...");
        anim.SetTrigger(triggerName);
    }

    private void HandleLastMove(char move)
    {
        Debug.Log($"Handling last move: {move}");

        switch (move)
        {
            case 'U':
                Debug.Log("Special handling for move 'U'.");
                anim.SetTrigger("attackU");
                moveHistory.Clear();
                break;
            case 'L':
                Debug.Log("Special handling for move 'L'.");
                anim.SetTrigger("attackL");
                moveHistory.Clear();
                break;
            case 'D':
                Debug.Log("Special handling for move 'D'.");
                anim.SetTrigger("attackD");
                moveHistory.Clear();
                break;
            case 'R':
                Debug.Log("Special handling for move 'R'.");
                anim.SetTrigger("attackR");
                moveHistory.Clear();
                break;
            default:
                Debug.Log("Last move is not U, L, D, or R.");
                moveHistory.Clear();
                break;
        }
    }
}
