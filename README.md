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


Special thanks to https://github.com/MattTW/BlinkMonitorProtocol for providing an API
