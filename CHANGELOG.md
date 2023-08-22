# GrapeFruit OS - Powered by Cosmos
## Changelog

### 2023-08-22
- Introduced usage of the Prism API from [PrismOS](https://github.com/Project-Prism/Prism-OS)
    - To fulfill the license terms of using the Prism API (as a part of PrismOS)
      GrapeFruit OS is now available under the GPL 2.0 License
- Started working on a GUI
- Started working on an improved file system handling

### 2023-08-21
- Updated to latest build of Cosmos
- Created new project file to accomodate changes
- Minor changes to `nano`
    - New header and footer
    - Overhauled input logic

### 2023-04-02
- Fixed an issue where if you used `touch` to create a file, then opened it with `nano`,
  `nano` would crash because the file was literally 0 in length.
  `touch` now adds a zero character (`\0`) to every file created, so `nano` won't crash

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