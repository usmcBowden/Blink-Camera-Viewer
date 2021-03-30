# Blink-Camera-Viewer

Blink Camera Viewer is an object oriented windows based application currently under development.

Current working feautures:
- Arm/Disarm Camera
- Update Thumbnails
- Generates List of motion event clips
- Login/Logout
- Pin verification
- Battery level is shown
- View all downloaded clips

Known bugs
- Viewing motion event clips sometimes results in the clips being corrupt. 
- Some motion event clip thumbnails corrupt on download
- Repatedly logging in and out may cause the system to reject your pin for around an hour
- The thumbnail updates, but sometimes the screen refreshes before it the camera has time to capture a picture. To see the change arm or disarm the camera till it updates

Unimplemented Features
- Notifications
- Live view
- Arm/disarm entire system

Feel Free to clone and edit the code or use parts of it for your own applications. 
Please report bugs found.


Usage instructions.

Download the zip file to install.
After installation you will be able to enter your username and password if 2FA is enabled you will recieve a pin via text or email to verify your account. The homescreen will show each of your cameras. You can right click each one to view actions associated with the respective camera. You can view a list of motion event clips under the clips tab. Clicking the clip will download it to a file in your documents folder while also opening it in a separate window to view it. It may download as corrupt and not play.


I've noticed after leaving the program running for an extended period that clips do not download corrupt.


Special thanks to https://github.com/MattTW/BlinkMonitorProtocol for providing an API
