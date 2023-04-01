﻿# GrapeFruit OS - Powered by Cosmos
## Changelog

### 2023-04-01
- Reorganised `help` command
- Introduced `nano`
    - It has some issues, but it works to a certain degree
    - Known bug: sometimes it crashes with an index issue
- Introduced `rm`
    - Currently only deletes files

### 2023-03-31
- Introduced changelog
- Commands that require at least one parameter will now warn the user if insufficient parameters are supplied
- Since it resembles the other one more, `man` command was changed to `whatis`
- Reorganised `help`
- User can now decide if they want to initialise the Virtual File System and any network device
    - To prevent crashes, if the VFS or NIC isn't initialised, related commands will not execute
- Currently working on implementing a hungarian keyboard layout

- Implemented `cd`, probably everything works