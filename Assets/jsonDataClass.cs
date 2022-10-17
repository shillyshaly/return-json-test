using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonDataClass
{
    public string city { get; set; }
    public string region_code { get; set; }
    public Tags tags { get; set; }
}

public class Tags
{
    public string ip { get; set; }
}
