using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BepInEx.Configuration;
using GameNetcodeStuff;
using IceCreamDrop.Patches;
using UnityEngine;

namespace IceCreamDrop
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ICDModBase : BaseUnityPlugin
    {
        const string modGUID = "Aries.IceCreamTruck";
        const string modName = "Ice Cream Dropship";
        const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ICDModBase Instance;

        internal ManualLogSource val;

        public static AudioClip theSong;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            val = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            AssetBundle songAssetBundle = AssetBundle.LoadFromMemory(IceCreamDrop.Properties.Resources.icecreamtruck);
            theSong = songAssetBundle.LoadAsset<AudioClip>("Assets/icesong.mp3");

            val.LogWarning("ICD is online!");

            harmony.PatchAll(typeof(ICDModBase));
            harmony.PatchAll(typeof(SoundPatch));

        }


    }

}