using UnityEngine;

public class RobotsUnit : Building
{
    private float metalResourceRate = 5;
    private float mineralResourceRate = 3;
    private bool m_miningMinerals;
    private bool m_miningMetals;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 25)
        {
            Debug.Log("Building robot unit failed. Not enough metal.");
        }
        
        if (GameManager.Instance.m_minerals < 70)
        {
            Debug.Log("Building robot unit failed. Not enough minerals.");
        }
        else
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
                Debug.Log("This unit requires a Robot Lab");
                return false;
            }
            
            GameManager.Instance.m_metals -= 25;
            GameManager.Instance.m_minerals -= 70;
            
            return true;
        }

        return false;
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
