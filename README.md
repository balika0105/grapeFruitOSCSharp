# grapeFruitOSCSharp
A version of grapeFruitOS written in C#, made bootable with [Cosmos](https://github.com/CosmosOS/Cosmos)

### WARNING!

Some features are currently in an experimental phase. Use with caution!

It is highly recommended to use this *operating system* in a Virtual Machine, instead of running it on real hardware.

***We are not responsible for any type of data loss!***

### Additional information
The project has been "rebuilt" due to the changes in the Cosmos Framework.
You can find the older code in the `old` directory.

Please note that after porting over older functionality, this folder will be removed.

Please also note that due to unknown reasons, the OS might hang when performing operations on the filesystem.

### Known bugs
- When saving a file in `nano` without an extension, the system will report a critical failure, then create a file with the extension of the last 2 characters of the given filename (possible FAT32 limitation)
- The `la` command can crash the system if the `ls` command hasn't been used beforehand (cause unknown)