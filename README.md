# AutoMouseClickActivator
Activator program for the AutoMouseClick tool by Murgee

This is not a fancy tool. I threw it together somewhat quickly early in the morning...

This project has been on my mind for a little while. I don't know if it has been done before but I did it anyway \
I spent a number of hours reverse engineering the AutoMouseClick tool, digging through its code and understanding how it handles registration.\
In the end, I found 2 methods to activate the software manually. The method in this tool was the more interesting of the two.

I have tested this only on the latest AutoMouseClick version, 99.2 \
I have tested this on two devices of mine, and it worked but there may be issues I have not come across on other devices.

# What this tool does
This tool uses the needed hardware parameters to generate the hardware/registration code. \
This gets written to the registry for AMC to read and activate the software, removing trial limitations.

Note: Registry writes are limited to the application's registration-related values. Writing to the registry is optional and requires user confirmation.

# How to use
Simply download and run the latest release executable. \
Or download the source code and compile it yourself.\
Let the app run and then prompt yes or no to write to the registry.

# Requirements
Windows \
.NET Framework 4.8 (should be installed on most systems by default)