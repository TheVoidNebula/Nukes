# Nukes
Adds the Omega Warhead and a Auto Warhead!

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features
* Decide if you want to have a automatic Alpha Warhead
* Decide if you want to have a Omega Warhead
* Decide which doors should be closed and locked during a Alpha Warhead Detonation Progress
* Decide if you want a extra Broadcast when the Alpha Warhead Detonation Progress starts

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
`AutoWarheadAnnouncement` | String | '[Nukes] The Automatic Alpha Warhead has started!' | What should the Announcement be when the Alpha Warhead starts?
`AutoWarheadRoundBeginningAnnouncement` | String | '[Nukes] The Automatic Alpha Warhead starts in 25 Minutes!' | What should the Announcement be at the beginning of a round?
`EnableOmegaWarhead` | Boolean | true | Should the Omega Warhead be enabled?
`EnableOmegaWarheadLock` | Boolean | true | Should the Omega Warhead be locked so it cannot be disabled while it starts
`OmegaWarheadTime` | Int | 30 | The time in seconds in which the Omega Warhead starts
`OmegaWarheadAnnouncement` | String | '[Nukes] The Omega Alpha Warhead has started!\nWe are all doomed!' | What should the Announcement be when the Omega Warhead starts?
`OmegaWarheadRoundBeginningAnnouncement` | String | '[Nukes] The Omega Alpha Warhead starts in 30 Minutes!' | What should the Announcement be at the beginning of a round?
`OmegaWarheadDeathMessage` | String | '[Nukes] The Omega Warhead destroyed everybody and everything!' | What should the Announcement be when you die by the Omega Warhead?
`RoundEndWarheadTimer` | Int | 5 | How long after the round end should the warhead detonate?
`EnableCustomEndConditions` | Boolean | true | Should the Warhead which explodes after the round should only explode if a certain End Condition is meet?
`CustomEndConditions` | List | Anomalies | Which Team needs to win for the Warhead Explosion on the round end?
`EnableLockdownSystem` | Boolean | true | Should several doors be locked when the alpha warhead starts?
`Doors` | List | HCZ_049_Armory, HCZ_Armory,DoorType.LCZ_173_Armory, LCZ_Armory, Nuke_Armory | Which doors should be closed and locked during the alpha warhead procedure?

`EnableLockdownMessage` | Boolean | true | Should a Broadcast be shown when the Alpha Warhead starts?
`DoorLockdownMessage` | String | '[Nukes] Several Doors will be locked down during the Warhead Detonation...' | What should the Message be when the Alpha Warhead starts?

## Config.syml
```yml
[Nukes]
{
# Is this Plugin enabled?
isEnabled: true
# Should the automatic Alpha Warhead be enabled?
enableAutoWarhead: true
# Should the Warhead be locked so it cannot be disabled while it starts?
enableAutoWarheadLock: true
# The time in seconds in which the Warhead starts
autoWarheadTime: 1500
# What should the Announcement be when the Alpha Warhead starts?
autoWarheadAnnouncement: '::lcb::Nukes::rcb:: The Automatic Alpha Warhead has started!'
# What should the Announcement be at the beginning of a round?
autoWarheadRoundBeginningAnnouncement: '::lcb::Nukes::rcb:: The Automatic Alpha Warhead starts in 25 Minutes!'
# Should the Omega Warhead be enabled?
enableOmegaWarhead: true
# Should the Omega Warhead be locked so it cannot be disabled while it starts?
enableOmegaWarheadLock: true
# The time in seconds in which the Omega Warhead starts
omegaWarheadTime: 30
# What should the Announcement be when the Omega Warhead starts?
omegaWarheadAnnouncement: >-
  ::lcb::Nukes::rcb:: The Omega Alpha Warhead has started!

  We are all doomed!
# What should the Announcement be at the beginning of a round?
omegaWarheadRoundBeginningAnnouncement: '::lcb::Nukes::rcb:: The Omega Alpha Warhead starts in 30 Minutes!'
# What should the Announcement be when you die by the Omega Warhead?
omegaWarheadDeathMessage: '::lcb::Nukes::rcb:: The Omega Warhead destroyed everybody and everything!'
}
```
