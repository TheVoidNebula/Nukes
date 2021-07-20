# Nukes
Adds the Omega Warhead and a Auto Warhead!

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features
* Decide if you want to have a automatic Alpha Warhead
* Decide if you want to have a Omega Warhead

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the Nukes.dll file that you can download [here](https://github.com/TheVoidNebula/Nukes/releases) in your plugin directory
3. Restart/Start your server.


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
