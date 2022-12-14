using UnityEngine;

public class MacroBiome : Building
{
    private float m_habitabilityGenerationRate = 10f;
    private float m_mineralGenerationRate = 5f;
    private int energyCost = 3;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 150)
        {
            Debug.Log("Building Macro Biome failed. Not enough metal.");
        }
        else if (GameManager.Instance.m_minerals < 100)
        {
            Debug.Log("Building Macro Biome failed. Not enough minerals.");
        }
        else if (GameManager.Instance.m_energy + energyCost > GameManager.Instance.m_energyCapacity)
        {
            Debug.Log("Building Macro Biome failed. Not enough energy capacity.");
        }
        else
        {
            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 100;

            GameManager.Instance.m_energy += energyCost;
            return true;
        }

        return false;
    }
    public override void ResourceTick()
    {
        GameManager.Instance.m_habitability += m_habitabilityGenerationRate;
        GameManager.Instance.m_minerals += m_mineralGenerationRate;
    }
}
