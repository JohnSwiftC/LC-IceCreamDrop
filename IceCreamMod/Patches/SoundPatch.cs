using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using IceCreamDrop;

namespace IceCreamDrop.Patches
{
    [HarmonyPatch(typeof(ItemDropship))]
    internal class SoundPatch
    {


        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void thePatch(ItemDropship __instance)
        {
            AudioClip thSong = ICDModBase.theSong;
            AudioSource val = ((Component)__instance).transform.Find("Music").gameObject.GetComponent<AudioSource>();
            AudioSource val1 = ((Component)__instance).transform.Find("Music").transform.Find("Music (1)").gameObject.GetComponent<AudioSource>();
            val.clip = thSong;
            val1.clip = thSong;
        }
    }
}
