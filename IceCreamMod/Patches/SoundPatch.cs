using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace IceCreamDrop.Patches
{
    [HarmonyPatch(typeof(ItemDropship))]
    internal class SoundPatch
    {
        public static AudioClip theSong;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void thePatch(ItemDropship __instance)
        {
            AssetBundle songAssetBundle = AssetBundle.LoadFromMemory(IceCreamDrop.Properties.Resources.icecreamtruck);
            theSong = songAssetBundle.LoadAsset<AudioClip>("Assets/icesong.mp3");

            AudioSource val = ((Component)__instance).transform.Find("Music").gameObject.GetComponent<AudioSource>();
            val.clip = theSong;
        }
    }
}
