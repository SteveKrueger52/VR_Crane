
# Packet39 VR Crane Training Demo for XRTerra
**Experience Design Document**  
Version 2.0  
Team members: Steve Krueger, Amanda Vasconcelos, Xinyun (Shirene) Cao

___

### Overview
This VR App offers a unique Crane Operation training experience that saves on operations costs and has little to no safety risk involved.

Hypothetically, instead of spending time and resources training an employee using an actual crane - with the risks and 
safety concerns that entails - they could instead use our simulation to get a feel for how crane controls handle in general,
or a more tailored simulation that more closely emulates the crane they will be operating in particular.

### Installation

This application is not, and will not, be available on the Oculus store.

If you have [Unity version 2019.4.0f1](https://unity3d.com/unity/qa/lts-releases) , you can download this project and 
open it directly in unity, then simply build the main scene (Assets/_CraneGame/Scenes/Main Scene.unity) for the Android 
platform to acquire an .apk to sideload to your Oculus Quest device.

Alternatively, there is a pre-built .apk file (demo.apk) in the Builds folder for you to sideload directly onto your device.

In either case, once successfully installed the application should be available under  
`Library > Unknown Sources > VR Crane (com.DefaultCompany.VRCrane)`

## Feature Breakdown

- **Seated VR experience** - the user starts the app in the cockpit of the crane.
- **Power Button** - A button on the dashboard toggles the crane's engine on and off; The other crane controls will not 
function correctly while the crane is powered off.
- **4 Degrees of Freedom** - levers on the dashboard control (when the crane is powered on) the slew of the crane, the pitch
and extension of the telescoping boom, and the length of the chain.
- **Hook Magnet** - to simulate an on-site worker attaching a payload to your hook, a button on the dash can attach the highlighted
box to the magnet to be lifted by the crane. The same button can then disconnect the payload once it is in the proper position.
- **Timer and Reset** - a diegetic timer tracks how long the total simulation takes, from turning on the crane
to turning it off again after the payload has been moved to the goal platform. Additionally, this timer can be paused 
(locking the controls until unpaused) and reset (restarting the scene and simulation) without needing to exit and re-load 
the application itself.
- **Intuitive Interaction** - All interactibles are highlighted when they can be interacted with, and in all cases they
are activated by the use of either controller's trigger button.
- **Diagetic Audio** - Ambient BGM and SFX help to immerse the user in the scene, providing a more powerful sense of presence
and allowing for a more realistic simulation environment.
- **Haptic Feedback** - When the user interacts with an interactible object in the scene, the controllers will vibrate to
provide additional positive freedback.
- **Low Motion Sickness Risk** - The environment within the cockpit of the crane serves as an easy anchoring reference point
within the VR space, so even users prone to motion sickness will not be so easily affected by the experience. ***This 
has been tested empirically, albeit only on one person known to have fairly severe motion-sickness issues.***

## Next Steps
This demo is in its final state, however were we to take the project further here are a few potential avenues of improvement.

- More Realistic Physics
- Closer adherence to actual crane layouts and controls
  - Perhaps a choice of several actual crane models to operate
- Emulation of computerized crane operational tools
- Interactive instructions to guide new users through the proper actions and safety protocols
- More, and more realistic testing environments
- Optional operational hazards, such as inclement weather or strong winds
- More training options, such as removing highlighting or non-diegetic SFX, and the (visible) timer.
