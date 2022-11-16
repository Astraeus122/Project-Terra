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

    public void BuildRecreationCenterButton()
    {
        GameManager.Instance.Build(new RecreationCenter());
    }

    public void BuildSolarHarvesterButton()
    {
        if (GameManager.Instance.Build(new SolarHarvester()))
        {
            for (int i = 0; i <= GetSolarHarvesterNum(); i++)
            {
                if (m_solarHarvesters.transform.GetChild(i) != null)
                {
                    m_solarHarvesters.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    private int GetSolarHarvesterNum()
    {
        int count = 0;
        foreach (Building b in GameManager.Instance.buildings)
        {
            if (b is SolarHarvester)
            {
                count++;
            }
        }

        return count;
    }
    
    public void BuildRoboticsLabButton()
    {
        GameManager.Instance.Build(new RoboticsLab());
    }
    
    public void BuildDirectAirCaptureButton()
    {
        GameManager.Instance.Build(new DirectAirCapture());
    }
    
    public void BuildMacroBiomeButton()
    {
        GameManager.Instance.Build(new MacroBiome());
    }

    public void BuildRobotsUnitButton()
    {
        GameManager.Instance.Build(new RobotsUnit());
    }

    public void BuildGasPoweredGenerator()
    {
        if (GameManager.Instance.Build(new GasPoweredGenerator()))
        {
            for (int i = 0; i <= GetGasGeneratorNum(); i++)
            {
                if (m_gasGenerators .transform.GetChild(i) != null)
                {
                    m_gasGenerators.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
    
    private int GetGasGeneratorNum()
    {
        int count = 0;
        foreach (Building b in GameManager.Instance.buildings)
        {
            if (b is GasPoweredGenerator)
            {
                count++;
            }
        }

        return count;
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
