﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static string username;
    public static string choosen;
    public static int id;

    public static bool LoggedIn{
        get {
            return username != null;
        }
    }

    public static void LogOut(){
        username = null;
    }
}
