using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Harmony;

namespace WeaponCrosshair
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }

    [HarmonyPatch(typeof(HUDManager), "UpdateCrosshair")]
    public class WeaponCrosshairUpdate
    {
        public static void Postfix(HUDManager __instance)
        {
            if (GameManager.GetPlayerManagerComponent().PlayerIsZooming())
            {
                GearItem itemInHands = GameManager.GetPlayerManagerComponent().m_ItemInHands;
                bool showForStoneItem = (Settings.options.stoneCrosshair && itemInHands.m_StoneItem);
                bool showForGunItem = (Settings.options.rifleCrosshair && itemInHands.m_GunItem);
                bool showForBowItem = (Settings.options.bowCrosshair && itemInHands.m_BowItem);
                if ( showForStoneItem || showForGunItem || showForBowItem )
                {
                    //MelonLoader.MelonLogger.Log("Attempting to show crosshair");
                    Utils.SetActive(InterfaceManager.m_Panel_HUD.m_Sprite_Crosshair.gameObject, true);
                    InterfaceManager.m_Panel_HUD.m_Sprite_Crosshair.alpha = 1f;
                }
            }
        }
    }
}
