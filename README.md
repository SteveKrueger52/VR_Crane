
# Packet39 VR Crane Training Demo for XRTerra
**Experience Design Document**  
Version 1.0  
Team members: Steve Krueger, Amanda Vasconcelos, Xinyun (Shirene) Cao

___

### Overview
This VR App offers a unique Crane Operation training experience that saves on operations costs and has little to no safety risk involved.

### Unique Selling Points
1. Safe controlled environment removes risk of damaging expensive equipment or bodily harm
2. Leaves machinery in operation on site instead of removing it for training
3. Capture data on users time to complete the simulation.

### Sample Usage Loop
A new worker is being trained to operate a crane. Rather than going up into a crane immediately, they instead enter the office and enter a conference room where a trainer has a computer set up with the VR training app up and running. The worker puts on the headset and is placed inside a virtual crane control simulation. The instructor can follow along either on the connected computer or on a phone broadcasting the experience.

The worker then, for the first time, follows the motions of starting the crane engine, deploying the crane arm, lifting a highlighted object, and placing it on an elevated platform or truck.The entire process is timed step by step, and the instructor is armed with data on previous completion times to see where the new worker might struggle based on previous worker training.

Following a couple sessions, once the instructor is confident the new worker understands and has internalized all the steps, in-crane training can begin.

### Specifications

1. The app will be built for the Oculus Quest.
2. Experience is seated.
3. Users should be able to operate the crane by physically touching, holding or manipulating the controls, using the VR controllers.
   -  Haptic feedback optional as a stretch goal, not required for MVP
4. The crane should move and respond to users’ actions in a physically-correct way 
   -  The crane arm has 3 degrees of freedom

### Feature Breakdown
#### Crane Operation
The crane will mimic as closely as possible the control scheme and behavior in real life. Accurate movement is key.

#### Picking Up Objects
The actual pick up of objects will be simplified to a “touch-and-connect” mechanism, like a magnet.

#### Instructions
Step-by-step instructions will be presented within VR via pop-up windows next to the relevant buttons, dials, and levers displaying the next step. 

Optional Goal but not in MVP: If the pop up is not on the screen, an arrow pointing towards where the user should look will appear

#### (Optional) Audio
The engine sound and movement sounds will be realistic, in order to further immerse the player and prepare them for what they’ll be hearing during crane operation.

### Milestones
#### Controls that Mimic Crane Movement
All interactions such as pulling levers, pressing buttons, twisting dials, etc. accurately portray the movement of a crane in real life. Ability to grab objects via the magnet is also complete.

#### Step-By-Step Instructions
Implementation of the step by step instructions, with pop up windows and task completion checks.

#### Models imported
While potentially low poly and quite basic, there are models in the scene. The engine room looks realistic in layout and design.

### Timeline
#### Team Meetings
Sun, Jul 12: Team Meeting (12PM - 3PM EDT)
Sat, Jul 18: Team Meeting (3 hours, time TBH)

#### Deliverables
Thurs, Jul 9: Design Document Complete
Thurs, Jul 16th: Midpoint Presentation
Thurs, Jul 23rd: Final Presentation

### Other Links to Project Resources
[Google Drive](https://drive.google.com/drive/folders/1TPxlHvuyF-cO2q2wVJzWb1D2ZHIp-Bpq?usp=sharing)  
[Trello](https://trello.com/b/SF3rbZUw/packet39)
