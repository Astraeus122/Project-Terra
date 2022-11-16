using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] private TMP_Text metalsText;
    [SerializeField] private TMP_Text mineralsText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text habitabilityText;
    [SerializeField] private TMP_Text habitabilityProgressText;
    [SerializeField] private TMP_Text DACProgressText;

    [SerializeField] private GameObject m_solarHarvesters;
    [SerializeField] private GameObject m_gasGenerators;
    [SerializeField] private GameObject m_macroBiome;
    [SerializeField] private GameObject m_recreationCenters;
    [SerializeField] private GameObject m_roboticsLab;
    [SerializeField] private GameObject m_directAirCaptureFacilities;
    [SerializeField] private GameObject m_robots;

    public void BuildRecreationCenterButton()
    {
        if (GameManager.Instance.Build(new RecreationCenter()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is RecreationCenter).Count; i++)
            {
                if (m_recreationCenters.transform.GetChild(i) != null)
                {
                    m_recreationCenters.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void BuildSolarHarvesterButton()
    {
        if (GameManager.Instance.Build(new SolarHarvester()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is SolarHarvester).Count; i++)
            {
                if (m_solarHarvesters.transform.GetChild(i) != null)
                {
                    m_solarHarvesters.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void BuildRoboticsLabButton()
    {
        if (GameManager.Instance.Build(new RoboticsLab()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is RoboticsLab).Count; i++)
            {
                if (m_roboticsLab.transform.GetChild(i) != null)
                {
                    m_roboticsLab.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
    
    public void BuildDirectAirCaptureButton()
    {
        if (GameManager.Instance.Build(new DirectAirCapture()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is DirectAirCapture).Count; i++)
            {
                if (m_directAirCaptureFacilities.transform.GetChild(i) != null)
                {
                    m_directAirCaptureFacilities.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
    
    public void BuildMacroBiomeButton()
    {
        if (GameManager.Instance.Build(new MacroBiome()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is MacroBiome).Count; i++)
            {
                if (m_macroBiome.transform.GetChild(i) != null)
                {
                    m_macroBiome.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void BuildRobotsUnitButton()
    {
        if (GameManager.Instance.Build(new RobotsUnit()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is RobotsUnit).Count; i++)
            {
                if (m_robots.transform.GetChild(i) != null)
                {
                    m_robots.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void BuildGasPoweredGenerator()
    {
        if (GameManager.Instance.Build(new GasPoweredGenerator()))
        {
            for (int i = 0; i <= GameManager.Instance.buildings.FindAll(b => b is GasPoweredGenerator).Count; i++)
            {
                if (m_gasGenerators .transform.GetChild(i) != null)
                {
                    m_gasGenerators.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
    
    
    public void UpdateResourceInterface()
    {
        metalsText.text = "Metals: <br>" + GameManager.Instance.m_metals;
        mineralsText.text = "Minerals: <br>" + GameManager.Instance.m_minerals;
        energyText.text = "Energy Avail: <br>" + GameManager.Instance.m_energy + " / " + GameManager.Instance.m_energyCapacity;
        habitabilityText.text = "Habitability: <br>" + GameManager.Instance.m_habitability;

        habitabilityProgressText.text = "Habitability: <br>" + GameManager.Instance.m_habitability + "/3000";
        DACProgressText.text = "DAC Facilities: <br>" + GameManager.Instance.buildings.FindAll(b => b is DirectAirCapture).Count + " /5";
    }
}
