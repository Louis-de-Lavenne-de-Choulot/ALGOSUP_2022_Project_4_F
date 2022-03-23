using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personae
{
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

    public char _lunch { get; }
    public char _morning1 { get; }
    public char _afternoon1 { get; }
    public char _morning2 { get; }
    public char _afternoon2 { get; }
    public char _morning3 { get; }
    public char _afternoon3 { get; }
    public char _morning4 { get; }
    public char _afternoon4 { get; }
    public char _morning5 { get; }
    public char _afternoon5 { get; }

    public char[] all() { 
        return new char[]{_lunch, _morning1, _afternoon1, _morning2, _afternoon2, _morning3, _afternoon3, _morning4, _afternoon4, _morning5, _afternoon5};
    }
}
