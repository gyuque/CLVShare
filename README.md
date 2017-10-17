# CLVShare

![screenshot](https://github.com/gyuque/CLVShare/blob/master/screenshot.png)

CLVShare takes screenshot of SNES classic / Mini Super Famicom via USB and upload to your twitter account. HDMI capture devices are not needed.

CLVShare is inspired by PS4Share and CLV is Nintendo's internal name of NES/SNES classic.

## Prerequisites

You have to replace kernel of your console using hakchi2(https://github.com/ClusterM/hakchi2)

**Using hakchi2 may brick your console!** I've already bricked my console twice :-) Calm down, probably bricked console can be restored with a backup file. But don't try with your father/child/friend's console if you want not to lose your special person.

This application doesn't implement complete OAuth flow. You have to get tokens on Twitter developer web.

## Setup

Before launching, visit Twitter developer web and create new application. Application name must be unique across all users therefore I recommend you to use your name as prefix e.g. 'JohnsCLVShare'
Then generate consumer key/secret and access token/secret.

At first launch, CLVShare generates a file named **accounts.yaml** in the same folder as exe. Replace 'xxxxxx' with your own consumer key/secret and access token/secret. Restarting the app, twitter account will be enabled.

## How to use

Just click 'Take screenshot' button.

Check followings if failed.
- Have you installed driver included in hakchi2?
- Change USB cable.
- Change USB port.
