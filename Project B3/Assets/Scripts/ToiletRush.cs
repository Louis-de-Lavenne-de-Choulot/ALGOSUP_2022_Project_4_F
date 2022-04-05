using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToiletRush : ScenarioBase
{
    private List<Transform> MToilets;
    private List<bool> MToiletUsed;
    private List<Transform> MToiletsWait;
    private List<bool> MToiletWaitUsed;
    private List<Transform> FToilets;
    private List<bool> FToiletUsed;
    private List<Transform> FToiletsWait;
    private List<bool> FToiletWaitUsed;
    public override void StartScenario()
    {
        active = true;
        targets = new List<string>() { "Male 1(Clone)", "Male 2(Clone)", "Male 3(Clone)", "Male 4(Clone)", "Female 1(Clone)", "Female 2(Clone)", "Female 3(Clone)", "Female 4(Clone)", };
        MToilets = spots.Where(spot => spot.name == "MToilets").ToList();
        MToiletsWait = spots.Where(spot => spot.name == "MToiletsWait").ToList();
        FToilets = spots.Where(spot => spot.name == "FToilets").ToList();
        FToiletsWait = spots.Where(spot => spot.name == "FToiletsWait").ToList();
        MToiletUsed = Enumerable.Repeat(false, MToilets.Count).ToList();
        MToiletWaitUsed = Enumerable.Repeat(false, MToiletsWait.Count).ToList();
        FToiletUsed = Enumerable.Repeat(false, FToilets.Count).ToList();
        FToiletWaitUsed = Enumerable.Repeat(false, FToiletsWait.Count).ToList();
        npcs = GetNPCs();
        npcs.Sort((npc1,npc2) => Vector2.Distance(npc1.transform.position, MToilets[0].position).CompareTo(Vector2.Distance(npc2.transform.position, MToilets[0].position)));
        Debug.Log($"NPC count : {npcs.Count}");
        foreach (NPC npc in npcs)
        {
            npc.inScenario = true;
            StartCoroutine(GetNextGoal(npc));
        }
    }

    public override void EndScenario()
    {
        StopAllCoroutines();
        active = false;
        foreach (var npc in npcs)
        {
            npc.inScenario = false;
            npc.ChangeGoal();
        }
    }

    public override IEnumerator GetNextGoal(NPC npc)
    {
        while (true)
        {
            Debug.Log(npc.goal);
            Debug.Log(npc.name);

            switch (npc.name)
            {
                case "Male 1(Clone)":
                case "Male 2(Clone)":
                case "Male 3(Clone)":
                case "Male 4(Clone)":
                    for (int i = 0; i < MToilets.Count; i++)
                    {
                        if (!MToiletUsed[i])
                        {
                            npc.ChangeGoal(MToilets[i]);
                            MToiletUsed[i] = true;
                            yield return new WaitUntil(() => Vector3.Distance(npc.transform.position, npc.goal.position) < 5f);
                            yield return new WaitForSeconds(5);
                            MToiletUsed[i] = false;
                            npc.inScenario = false;
                            npc.ChangeGoal();
                            npcs.Remove(npc);
                            yield break;
                        }
                    }
                    for (int i = 0; i < MToiletsWait.Count; i++)
                    {
                        if (!MToiletWaitUsed[i])
                        {
                            npc.ChangeGoal(MToiletsWait[i]);
                            MToiletWaitUsed[i] = true;
                            yield return new WaitUntil(() => Vector3.Distance(npc.transform.position, npc.goal.position) < 5f);
                            yield return new WaitForSeconds(Random.Range(1, 5));
                            MToiletWaitUsed[i] = false;
                            break;
                        }
                    }
                    break;
                case "Female 1(Clone)":
                case "Female 2(Clone)":
                case "Female 3(Clone)":
                case "Female 4(Clone)":
                    for (int i = 0; i < FToilets.Count; i++)
                    {
                        if (!FToiletUsed[i])
                        {
                            npc.ChangeGoal(FToilets[i]);
                            FToiletUsed[i] = true;
                            yield return new WaitUntil(() => Vector3.Distance(npc.transform.position, npc.goal.position) < 5f);
                            yield return new WaitForSeconds(5);
                            FToiletUsed[i] = false;
                            break;
                        }
                    }
                    for (int i = 0; i < FToiletsWait.Count; i++)
                    {
                        if (!FToiletWaitUsed[i])
                        {
                            npc.ChangeGoal(FToiletsWait[i]);
                            FToiletWaitUsed[i] = true;
                            yield return new WaitUntil(() => Vector3.Distance(npc.transform.position, npc.goal.position) < 5f);
                            yield return new WaitForSeconds(Random.Range(1, 5));
                            FToiletWaitUsed[i] = false;
                            npc.inScenario = false;
                            npc.ChangeGoal();
                            npcs.Remove(npc);
                            yield break;
                        }
                    }
                    break;
            }
        }
    }

}
