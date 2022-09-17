using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerShopItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject towerObject;
    public Image[] beatFly;
    public Image image;
    public TMP_Text damage;
    public bool isBeatFly;
    public TMP_Text energy;
    public TMP_Text range;
    public TMP_Text fireRate;
    public gameManager resources;

    private bool _canBuy = false;

    private towerScript _towerScript;
    private bool _isDragging = false;
    private Vector2 startPosition;
        
    // Start is called before the first frame update
    void Start()
    {
        towerObject.TryGetComponent(out _towerScript);
        
        damage.text = _towerScript.damage.ToString();
        energy.text = _towerScript.energy.ToString();
        range.text = _towerScript.range.ToString(CultureInfo.InvariantCulture);
        fireRate.text = _towerScript.fireRate.ToString(CultureInfo.InvariantCulture);

        Destroy(beatFly[isBeatFly ? 0: 1]);
        startPosition = image.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _canBuy = resources.playerEnergy >= _towerScript.energy;
        if (_isDragging)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - image.transform.position;
            image.transform.Translate(targetPosition);
        }

        image.color = _canBuy ? Color.white : Color.red;
    }

    private GameObject BuyTower()
    {
        resources.playerEnergy -= _towerScript.energy;
        return Instantiate(towerObject);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragging) return;
        _isDragging = false;

        var globalPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        var hit = Physics2D.Raycast(globalPosition, Vector2.zero );

        if (hit.collider)
        {
            var targetObject = hit.collider.gameObject;
            var isEmpty = targetObject.tag.Equals("empty");
            if (isEmpty)
            {
                var newTower = BuyTower();
                newTower.transform.position = targetObject.transform.position;
            }
        }
       
        image.transform.position = startPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_canBuy) return;
        _isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new NotImplementedException();
    }
}
