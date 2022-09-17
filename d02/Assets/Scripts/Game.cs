using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private List<Unit> units = new List<Unit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            OnLeftMouseDown();
        if (Input.GetMouseButtonDown(1))
            units.Clear();
    }

    private void OnLeftMouseDown()
    {

        Vector3 mousePoint = 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
        if (hit.collider)
        {
            var unit = hit.collider.gameObject.GetComponent<Unit>();
            if (unit)
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                    units.Clear();
                units.Add(unit);
            }
            else
            {
                moveUnits();
            }
        }
    }

    private void moveUnits()
    {
        foreach (var unit in units)
        {
            unit.SetTargetPosition();
        }
    }
}
