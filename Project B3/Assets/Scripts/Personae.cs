using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personae : MonoBehaviour
{
    char _lunch;
    char _morning1;
    char _afternoon1;
    char _morning2;
    char _afternoon2;
    char _morning3;
    char _afternoon3;
    char _morning4;
    char _afternoon4;
    char _morning5;
    char _afternoon5;

    public Personae(char lunch, char morning, char afternoon, char morning2, char afternoon2, char morning3, char afternoon3, char morning4, char afternoon4, char morning5, char afternoon5){
        _lunch = lunch;
        _morning1 = morning;
        _afternoon1 = afternoon;
        _morning2 = morning2;
        _afternoon2 = afternoon2;
        _morning3 = morning3;
        _afternoon3 = afternoon3;
        _morning4 = morning4;
        _afternoon4 = afternoon4;
        _morning5 = morning5;
        _afternoon5 = afternoon5;
    }

    // G = get/order food, O = outside, I = inside, B = bring his meal
    public Personae johnny = new Personae('G', 'E', 'P', 'S', 'S', 'P', 'P', 'C', 'C', 'P', 'P');

    public Personae steph = new Personae('I', 'C', 'C', 'E', 'P', 'S', 'S', 'P', 'P', 'P', 'P');

    public Personae alexandre = new Personae('O', 'P', 'P', 'P', 'E', 'P', 'P', 'S', 'S', 'C', 'C');

    public Personae janka = new Personae('O', 'S', 'S', 'C', 'C', 'P', 'E', 'P', 'P', 'P', 'P');

    public Personae nick = new Personae('B', 'P', 'P', 'P', 'P', 'C', 'C', 'P', 'E', 'S', 'S');

    public Personae lindzy = new Personae('G', 'P', 'E', 'C', 'C', 'S', 'S', 'P', 'P', 'P', 'P');

    public Personae lana = new Personae('O', 'S', 'S', 'P', 'P', 'C', 'C', 'E', 'P', 'P', 'P');

    public Personae denis = new Personae('I', 'C', 'C', 'S', 'S', 'E', 'P', 'P', 'P', 'P', 'E');

    public Personae sam = new Personae('I', 'P', 'P', 'P', 'P', 'S', 'S', 'C', 'C', 'P', 'E');

}
