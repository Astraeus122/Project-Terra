using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Logic

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gm = new GameObject("Game Manager");
                gm.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    private void Awake() => instance = this;

    #endregion

    [HideInInspector] public float m_metals;
    [HideInInspector] public float m_minerals;
    [HideInInspector] public float m_energy;
    [HideInInspector] public float m_energyCapacity;
    [HideInInspector] public float m_habitability;

    [SerializeField] private float resourceTickRate;
    private float resourceTickTime;

    public List<Building> buildings = new List<Building>();

    private void Start()
    {
        m_metals = 500;
        m_minerals = 500;
        m_energy = 3;
        m_energyCapacity = 5;
        
        Build(new CommandHub());
        FindObjectOfType<Interface>().UpdateResourceInterface();
    }

    private void Update()
    {
        if (Time.time > resourceTickTime + resourceTickRate)
        {
            resourceTickTime = Time.time;

            foreach (Building building in buildings)
            {
                building.ResourceTick();
                CheckGameWin();
            }
            
            FindObjectOfType<Interface>().UpdateResourceInterface();
        }
    }
    
    public bool Build(Building _building)
    {
        if (_building.CanBuild())
        {
            FindObjectOfType<Interface>().UpdateResourceInterface();
            buildings.Add(_building);
            return true;
        }

        return false;
    }

    private void CheckGameWin()
    {
        int DACnum = 0;
        foreach (Building building in buildings)
        {
            if (building is DirectAirCapture)
            {
                DACnum++;
            }
        }
        
        if (DACnum >= 5 && m_habitability >= 2000)
        {
            print("Won the game!");
        }
    }
}
