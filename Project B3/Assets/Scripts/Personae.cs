using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personae
{
    public Personae(char lunch, char morning0, char afternoon0, char morning1, char afternoon1, char morning2, char afternoon2, char morning3, char afternoon3, char morning4, char afternoon4){
        _lunch = lunch;
        _morning0 = morning0;
        _afternoon0 = afternoon0;
        _morning1 = morning1;
        _afternoon1 = afternoon1;
        _morning2 = morning2;
        _afternoon2 = afternoon2;
        _morning3 = morning3;
        _afternoon3 = afternoon3;
        _morning4 = morning4;
        _afternoon4 = afternoon4;
    }

    public char _lunch { get; }
    public char _morning0 { get; }
    public char _afternoon0 { get; }
    public char _morning1 { get; }
    public char _afternoon1 { get; }
    public char _morning2 { get; }
    public char _afternoon2 { get; }
    public char _morning3 { get; }
    public char _afternoon3 { get; }
    public char _morning4 { get; }
    public char _afternoon4 { get; }
}
