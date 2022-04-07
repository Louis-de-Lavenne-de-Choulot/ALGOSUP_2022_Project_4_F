# Technical specification

BERNARD Max - DESVAUX Brendon - MOLNAR Ivan - DE LAVENNE Louis - CUAHONTE-CUEVAS David - CHAPUT Mathieu - PRIOL Eloi

## Glossary

## Objective 
The objective of this project is to simulate the B3 in order to highlight possible problems that may arise within ALGOSUPs new school building

The simulation must take place within the new school building and must contain characters (controlled by simple AI) to simulate students, speakers, teachers, and administrative staff. It also needs to be able to launch various scenarios which could highlight the more foreseeable problems that may appear in the future.

The non-user characters must follow a pre-planned schedule ensuring the day-to-day functionality of the building. These schedules must be only interrupted when the user launches a scenario, in which case they should start to act according to it.

The project must have a Virtual Reality environment.

This project has been proposed by ALGOSUP's leadership.

## Solutions
### Current or Existing Solution
There is already a way to visit the building in VR. But there is no simulation of the scenario or NPC in the existing solution.

### Suggested or Proposed Solution
#### Unity
- We are familiar with C#
- We have a teacher for Unity
- VR integration can be accomplished easily
- Asset Store
- Animations
- Free

#### Photon Pun
- Multiplayer
- Relatively easy to set up
- The Team already knows the system
- Free

#### Reworking 3D Model
- Remove details
- Remove almost everything but the wall from the 2nd floor
- replace walls that are close together and also the windows with one single rectangle

#### NPC and Pathfinding
- Use Unity NavMesh Agent
- Bake the NavMesh with Navigation Static
- Use navMesh obstacle on doors
- Have NPC aim at the transformation of their seat

#### Door Access
- NPC should have a trigger box collider at their feet
- When triggered it should check if the layer corresponds to the door
- Check the tag and compare it to the AI’s that are allowed to access 
- For the player check if the player scanned his phone first
- Phone is grabbable (using existing OVR Grabbable)

#### NPC interaction
- Create animation
- When the NPC is close to a target the animation will start.
- Transform the NPC so that it can have the best position for the animation
- If the NPC needs to interact with outside objects,  the NPC will carry the deactivated object

#### Sound
- Use the Audio Manager for the doors with the sound file
- Use a script to take random sound files and then play the theme for the NPC’s
- Take sound files from different folders depending on the gender and the specific situation

#### Scenario
- Scenarios will all inherit from a base class to allow for an easier schedule modification
- Each scenario should have a set of transforms and an order of priorities
- AI’s must aim for the highest priority transform that isn’t taken by another AI
- Scenario will switch based on a global clock
- If an AI is done with the task that has been placed on it,  before the end of the scenario, the AI will go back to the highest priority transform.

#### VR
- We will use XR plugin and also the OVR to make most of the VR functional
- It will only work with Oculus Quest 2 VR headset

### Costs
- The VR Headset is provided to us by the school.
- We don’t have to use any kind of paid asset.
- If the school wants to scale up the multi-user we would need some help 

### Test Plan
Our tests will consist of a combination of running the simulation to see if everything works well, along with smaller point-by-point tests on new features. Using different debug tools to catch the less visible bug.

### Monitoring
We use GitHub to observe and maintain the state of our project and to facilitate the work with other members of the team. 

## Further Consideration

### Third-party services and platforms considerations
We use Github for hosting and sharing the project. Our project is public and there are no privacy concerns. If our files are too big we may be at risk of getting removed from GitHub but if we rework well the B3’s 3D model it shouldn’t be an issue. <br>
Photon Pun has a limited number of connections per month and only up to 16 connections simultaneously. This should not be an issue under expected use (a few demonstrations).<br>
In the future this application could be worked on again in order to try different layouts or renovation of the building before really doing it.

### Accessibility consideration
The simulation is meant to run in VR and it should be able to only run with an Oculus Quest headset. Most people don’t have a VR headset but it should not be an issue in this expected use case. If the final product has too low FPS it could cause nausea.

### Risks
If the simulation accidentally overdoes an issue with the building or misses an actual danger it could lead to the wrong issue being solved in the final building.

## Success Evaluation
### Impact
The impact of the application should be on the decision making of ALGOSUP. Our application will be made to help them try scenarios and see some of the problems that they could have missed otherwise.
We will know if the project had an impact either by getting feedback by ALGOSUP or when we move into the new building.

### Metrics
- Any change done to the B3 plan
- Positive feedback at the end of the presentation

## Work
In order to have a timetable, know the time that each task takes and to know who works on each task , we will use trello.
To see our trello, here is the link: 
https://trello.com/b/6FXIYZsX/b3-vr-simulation
