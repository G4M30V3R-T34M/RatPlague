using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class BuildingsManager : Singleton<BuildingsManager>
{
    protected List<BaseBuilding> currentBuildings;

    [SerializeField] ObjectPool housePool, warehousePool, barraksPool;

    [SerializeField] BuildingSpawnScriptable _settings;

    void Start() {
        currentBuildings = new List<BaseBuilding>();
    }

    public void CreateBuilding() {
        // Decide what type of building
        // Call method of given type

    }

    public void CreateHouse(bool notifyCrier = true) {
        PoolableBuilding houseContainer = (PoolableBuilding)housePool.GetNext();
        House house = houseContainer.GetComponentInChildren<House>();
        PlaceBuilding(houseContainer.gameObject);
        houseContainer.gameObject.SetActive(true);
        if (notifyCrier) {
            CrierManager.Instance.newBuildings[Buildings.House]++;
        }
        currentBuildings.Add(house);
    }

    public void CreateWareHouse(bool notifyCrier = true) {
        PoolableBuilding houseContainer = (PoolableBuilding)warehousePool.GetNext();
        House warehouse = houseContainer.GetComponentInChildren<House>();
        PlaceBuilding(houseContainer.gameObject);
        houseContainer.gameObject.SetActive(true);
        if (notifyCrier) {
            CrierManager.Instance.newBuildings[Buildings.Warehouse]++;
        }
        currentBuildings.Add(warehouse);
    }

    public void CreateBarrak (bool notifyCrier = true) {
        PoolableBuilding houseContainer = (PoolableBuilding)barraksPool.GetNext();
        MilitaryBuilding barrak = houseContainer.GetComponentInChildren<MilitaryBuilding>();
        PlaceBuilding(houseContainer.gameObject);
        houseContainer.gameObject.SetActive(true);
        if (notifyCrier) {
            CrierManager.Instance.newBuildings[Buildings.Military]++;
        }
        currentBuildings.Add(barrak);
    }

    protected void PlaceBuilding(GameObject building) {
        bool validPosition = false;
        int failsafe = 0;

        float xPos = 0;
        float yPos = 0;

        while (!validPosition && failsafe++ < 10) {
            xPos = Random.Range(_settings.minX, _settings.maxX);
            yPos = Random.Range(_settings.minY, _settings.maxY);

            validPosition = true;
            for (int i = 0; i < currentBuildings.Count; i++) {
                Vector2 buildingPos = currentBuildings[i].transform.parent.position;
                if (
                    Mathf.Abs(xPos - buildingPos.x) < _settings.xDist && 
                    Mathf.Abs(yPos - buildingPos.y) < _settings.yDist
                ) {
                    validPosition = false;
                    break;
                }
            }
        }

        building.transform.position = new Vector2(xPos, yPos);
    }

    public void DestroyBuilding(BaseBuilding building, BaseBuildingScriptable settings) {
        CrierManager.Instance.destroyedBuildings[settings.buildingName]++;
        currentBuildings.Remove(building);
        building.transform.parent.gameObject.SetActive(false);
    }
}
