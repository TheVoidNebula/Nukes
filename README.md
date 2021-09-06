# Nukes
Adds a lot of options related to our Warhead

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

![preview](https://user-images.githubusercontent.com/75329526/127044047-79b99e5c-0b95-465b-9b11-ca44ea4b8ed1.gif)

![NukeLights](https://user-images.githubusercontent.com/75329526/131705767-b53211fa-d58a-4eed-9b04-9a5f2e436ea5.png)

## Features
* Automatic Alpha Warhead
* Omega Warhead
* Decide which doors should be closed and locked during a Alpha Warhead Detonation Progress
* Decide if you want a extra Broadcast when the Alpha Warhead Detonation Progress starts
* Should Players get damage after the Warhead detonation on the surface?

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the Nukes.dll file that you can download [here](https://github.com/TheVoidNebula/Nukes/releases) in your plugin directory
3. Restart/Start your server.

## All Doors
* LCZ_012
* LCZ_012_Bottom
* LCZ_012_Locker
* HCZ_049_Armory
* HCZ_049_Gate
* HCZ_079_First
* HCZ_079_Second
* HCZ_096
* HCZ_106_Bottom
* HCZ_106_Primary
* HCZ_106_Secondary
* LCZ_173_Armory
* LCZ_173_Connector
* LCZ_173_Gate
* LCZ_173_Bottom
* LCZ_914
* Checkpoint_EZ_HCZ
* Checkpoint_LCZ_A
* Checkpoint_LCZ_B
* Escape_Primary
* Escape_Secondary
* Gate_A
* Gate_B
* GR18
* HCZ_Armory
* HID
* HID_Left
* HID_Right
* Intercom
* LCZ_Armory
* LCZ_Cafe
* LCZ_Wc
* Nuke_Armory
* Servers_Bottom
* Surface_Gate
* Surface_Nuke
* LCZ_Door
* HCZ_Door
* EZ_Door
* PrisonDoor
* Airlock
* Other


## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`EnableAutoWarhead` | Boolean | true | Should the automatic Alpha Warhead be enabled?
`EnableAutoWarheadLock` | Boolean | true | Should the Warhead be locked so it cannot be disabled while it starts?
`AutoWarheadTime` | Int | true | The time in seconds in which the Warhead starts
`EnableOmegaWarhead` | Boolean | true | Should the Omega Warhead be enabled?
`EnableOmegaWarheadLock` | Boolean | true | Should the Omega Warhead be locked so it cannot be disabled while it starts
`OmegaWarheadTime` | Int | 30 | The time in seconds in which the Omega Warhead starts
`RoundEndWarheadTimer` | Int | 5 | How long after the round end should the warhead detonate?
`EnableCustomEndConditions` | Boolean | true | Should the Warhead which explodes after the round should only explode if a certain End Condition is meet?
`CustomEndConditions` | List | Anomalies | Which Team needs to win for the Warhead Explosion on the round end?
`EnableLockdownSystem` | Boolean | true | Should several doors be locked when the alpha warhead starts?
`Doors` | List | HCZ_049_Armory, HCZ_Armory,DoorType.LCZ_173_Armory, LCZ_Armory, Nuke_Armory | Which doors should be closed and locked during the alpha warhead procedure?
`EnableLockdownMessage` | Boolean | true | Should a Broadcast be shown when the Alpha Warhead starts?
`EnableSurfaceTension` | Boolean | true | Should players receive damage on the surface after the detonation of the Alpha Warhead?"
`EnableSurfaceTensionMessage` | Boolean | true | Should there be a broadcast when the players start getting damaged by the surface tension?
`SurfaceTensionMessage` | String | '[Nukes] <color=red>The radiation from the Detonation is starting to damage you...</color>' | What should the Message be when the Alpha Warhead starts?
`SurfaceTensionDamage` | Int | 1 | The damage players get in the Surface Tension per Intervall?
`SurfaceTensionIntervall` | Int | 1f | The intervall (in seconds) in which players get damage over time?
`EnableSurfaceTensionDelay` | Boolean | true | Should there be a delay before players get damaged?
`SurfaceTensionDelay` | Float | 30f | Time (in seconds) to wait after the nuke is detonated before damaging players
`EnableNukeLightsCustomColor` | Boolean | true | Should the Nuke Lights have a custom color?
`NukeLightColor` | NukeLightColor | Red = 93, Green = 4,Blue = 176 | The RGB colorcode for the Nuke Lights?
`EnableNukeLightsCustomColorAfterDetonation` | Boolean | true | Should the Nuke Lights have a custom color after the Detonation?
`NukeLightDetonationColor` | NukeLightColor | Red = 255, Green = 0,Blue = 0 | The RGB colorcode for the Nuke Lights after the Detonation?
`EnableNoLightsAfterDetonation` | Boolean | false |Should the Lights be disabled after the Detonation?
`NoLightsAfterDetonationDuration` | Float | 60f | Should the Lights be disabled after the Detonation?

## Config.syml
```yml
[Nukes]
{
# The RGB colorcode for the Nuke Lights?
nukeLightColor:
  red: 255
  green: 165
  blue: 0
# The RGB colorcode for the Nuke Lights after the Detonation?
nukeLightDetonationColor:
  red: 255
  green: 165
  blue: 0
# Is this Plugin enabled?
isEnabled: true
# Should the automatic Alpha Warhead be enabled?
enableAutoWarhead: true
# Should the Warhead be locked so it cannot be disabled while it starts?
enableAutoWarheadLock: true
# The time in seconds in which the Warhead starts
autoWarheadTime: 1500
# Should the Omega Warhead be enabled?
enableOmegaWarhead: true
# Should the Omega Warhead be locked so it cannot be disabled while it starts?
enableOmegaWarheadLock: true
# The time in seconds in which the Omega Warhead starts
omegaWarheadTime: 1800
# What should the Announcement be when the Omega Warhead starts?
omegaWarheadAnnouncement: >-
  ::lcb::Nukes::rcb:: The Omega Alpha Warhead has started!

  We are all doomed!
# Should the Warhead explode after the round has ended?
enableRoundEndWarhead: true
# How long after the round end should the warhead detonate?
roundEndWarheadTimer: 5
# Should the Warhead which explodes after the round should only explode if a certain End Condition is meet?
enableCustomEndConditions: true
# Which Team needs to win for the Warhead Explosion on the round end?
customEndConditions:
- Anomalies
# Should several doors be locked when the alpha warhead starts?
enableLockdownSystem: true
# Which doors should be closed and locked during the alpha warhead procedure?
doors:
- HCZ_049_Armory
- HCZ_Armory
- LCZ_173_Armory
- LCZ_Armory
- Nuke_Armory
# Should a Broadcast be shown when the Alpha Warhead starts?
enableLockdownMessage: true
# Should players receive damage on the surface after the detonation of the Alpha Warhead?
enableSurfaceTension: true
# Should there be a broadcast when the players start getting damaged by the surface tension?
enableSurfaceTensionMessage: true
# The damage players get in the Surface Tension per Intervall?
surfaceTensionDamage: 1
# The intervall (in seconds) in which players get damage over time?
surfaceTensionIntervall: 1
# Should there be a delay before players get damaged?
enableSurfaceTensionDelay: true
# Time (in seconds) to wait after the nuke is detonated before damaging players
surfaceTensionDelay: 30
# Should the Nuke Lights have a custom color?
enableNukeLightsCustomColor: true
# Should the Nuke Lights have a custom color after the Detonation?
enableNukeLightsCustomColorAfterDetonation: true
# Should the Lights be disabled after the Detonation?
enableNoLightsAfterDetonation: false
# Should the Lights be disabled after the Detonation?
noLightsAfterDetonationDuration: 60
}
```
