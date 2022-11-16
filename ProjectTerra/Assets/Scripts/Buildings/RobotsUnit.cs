using UnityEngine;

public class RobotsUnit : Building
{
    private float metalResourceRate = 5;
    private float mineralResourceRate = 3;
    private bool m_miningMinerals;
    private bool m_miningMetals;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 25  && 
            GameManager.Instance.m_minerals >= 70)
        {
            bool hasRobotLab = false;
            foreach (Building building in GameManager.Instance.buildings)
            {
                if (building is RoboticsLab)
                {
                    hasRobotLab = true;
                }
            }

            if (!hasRobotLab)
            {
                Debug.LogWarning("This unit requires a Robot Lab");
                return false;
            }
            
            GameManager.Instance.m_metals -= 25;
            GameManager.Instance.m_minerals -= 70;
            
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void ResourceTick()
    {
        MineMinerals();
        MineMetals();
    }

    private void MineMinerals()
    {
        GameManager.Instance.m_minerals += mineralResourceRate;
    }

    private void MineMetals()
    {
        GameManager.Instance.m_metals += metalResourceRate;

    }
}
