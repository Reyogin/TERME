using UnityEngine;
using System.Collections.Generic;

public class MazeRoom : ScriptableObject
{

    public int settingsIndex;


    [SerializeField]
    public MazeRoomSettings settings;

    private List<MazeCell> cells = new List<MazeCell>();

    public void Add(MazeCell cell)
    {
        cell.room = this;
        cells.Add(cell);
    }

    //only show the room that the player is currently inside of.
    public void Hide()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Hide();
        }
    }

    public void Show()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Show();
        }
    }
}




