using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Break : ScenarioBase
{
    List<Transform> SmokingSpots;
    List<bool> SmokingSpotsOccupied;
    List<Transform> BreakSpots;
    List<bool> BreakSpotsOccupied;

    public override void StartScenario()
    {
        targets = new List<string>() { "Male 1(Clone)", "Male 2(Clone)", "Male 3(Clone)", "Male 4(Clone)", "Female 1(Clone)", "Female 2(Clone)", "Female 3(Clone)", "Female 4(Clone)" };
        SmokingSpotsOccupied = Enumerable.Repeat(false, SmokingSpots.Count).ToList();
        BreakSpotsOccupied = Enumerable.Repeat(false, BreakSpots.Count).ToList();
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
        for (int i = 0; i < 3; i++)
        {
            if (npc.name == "Female 1(clone)" && Random.Range(0, 3) == 0)
            {
                while (true)
                {
                    int spot = Random.Range(0, SmokingSpots.Count);
                    if (!SmokingSpotsOccupied[spot])
                    {
                        SmokingSpotsOccupied[spot] = true;
                        npc.ChangeGoal(SmokingSpots[spot]);
                        yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, npc.goal.position) < 5f);
                        yield return new WaitForSeconds(Random.Range(1, 3));
                        break;
                    }
                    if(SmokingSpotsOccupied.All(x => !x))
                    {
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    int spot = Random.Range(0, BreakSpots.Count);
                    if (!BreakSpotsOccupied[spot])
                    {
                        BreakSpotsOccupied[spot] = true;
                        npc.ChangeGoal(BreakSpots[spot]);
                        yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, npc.goal.position) < 5f);
                        yield return new WaitForSeconds(Random.Range(1, 3));
                        break;
                    }
                    if(BreakSpotsOccupied.All(x => !x))
                    {
                        break;
                    }
                }
            }
        }
        npc.ChangeGoal();
        npc.inScenario = false;
        yield break;
    }
}
