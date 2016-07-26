using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private MazeCell currentCell;

    private MazeDirection currentDirection;
    private float rot;

    public void SetLocation(MazeCell cell)
    {
        if (currentCell != null)
        {
            currentCell.OnPlayerExited();
        }
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
        currentCell.OnPlayerEntered();
    }


    public void MoveLocation(MazeCell cell)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + (cell.transform.localPosition - transform.localPosition).normalized, Time.deltaTime); ;
        if (Vector3.Distance(transform.localPosition, cell.transform.localPosition) < 0.5f)
        {
            if (currentCell != null)
            {
                currentCell.OnPlayerExited();
                currentCell = cell;
                currentCell.OnPlayerEntered();
            }
        }
    }
    private void Move(MazeDirection direction)
    {
        MazeCellEdge edge = currentCell.GetEdge(direction);
        if (edge is MazePassage)
            MoveLocation(edge.otherCell);
        else
        {//recentre si pas de passage
            Vector3 newpos = Vector3.Lerp(transform.localPosition, transform.localPosition + (currentCell.transform.localPosition - transform.localPosition).normalized, Time.deltaTime);
            if (Vector3.Distance(newpos, currentCell.transform.localPosition) < Vector3.Distance(transform.localPosition, currentCell.transform.localPosition))
                transform.localPosition = newpos;
        }
    }

    private void Start()
    {
        this.rot = 0;
        transform.rotation = Quaternion.Euler(0, this.rot, 0);
    }

    private void Update()
    {
        //orientation camera
        this.rot = (this.rot + Input.GetAxis("Mouse X") * 2 +  360) % 360;

        transform.rotation = Quaternion.Euler(0, this.rot, 0);

        if (this.rot < 45 || this.rot > 315)
            this.currentDirection = MazeDirection.North;
        if (this.rot < 135 && this.rot > 45)
            this.currentDirection = MazeDirection.East;
        else if (this.rot < 225  && this.rot > 135)
            this.currentDirection = MazeDirection.South;
        else if (this.rot < 315 && this.rot > 225)
            this.currentDirection = MazeDirection.West;

        //deplacement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move(MazeDirection.North);
            Move(currentDirection);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Move(MazeDirection.East);
            Move(currentDirection.GetNextClockwise());
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move(MazeDirection.South);
            Move(currentDirection.GetOpposite());
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move(MazeDirection.West);
            Move(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(currentDirection.GetNextClockwise());
        }

        Camera.main.transform.position = gameObject.transform.position + Vector3.up * 10 - gameObject.transform.forward * 5;
        Camera.main.transform.LookAt(gameObject.transform);
    }

    private void Rotate(MazeDirection direction)
    {
        transform.localRotation = direction.ToRotation();
        currentDirection = direction;
    }
}


