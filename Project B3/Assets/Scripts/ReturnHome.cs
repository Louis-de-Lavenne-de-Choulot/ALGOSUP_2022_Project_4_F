using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : ScenarioBase
{
    public Transform End;

    public override void StartScenario()
    {
        targets = new List<string>() { "Male 1(Clone)", "Male 2(Clone)", "Male 3(Clone)", "Male 4(Clone)", "Female 1(Clone)", "Female 2(Clone)", "Female 3(Clone)", "Female 4(Clone)" };
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
        npc.ChangeGoal(End);
        yield break;
    }
}
