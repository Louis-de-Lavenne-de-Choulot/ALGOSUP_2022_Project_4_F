# Technical specification

BERNARD Max - DESVAUX Brendon - MOLNAR Ivan - DE LAVENNE Louis - CUAHONTE-CUEVAS David - CHAPUT Mathieu - PRIOL Eloi

## Glosary

## Objective
The objective of this project is to simulate the B3 in order to highlight possible problems that may arise within ALGOSUPs new shool building

The simulation must take place within the new school building, must contain characters (controlled by simple AI) to simulate students, speakers, teachers and administrative staff. It also needs to be able to launch various scenarios which could highlight the more foreseeable problems that may appear in the future.

The non-user characters must follow a pre-planned schedule ensuring the day-to-day functionality of the building. These schedules must be only interrupted when the user launches a scenario, in which case they should start to act according to it.

The project must be realized in Virtual Reality.

This project has been proposed by ALGOSUP's leadership.

## Solutions
### Current or Existing Solution
There is alredy a way to visit the building in VR. But there is no simulation of the scenario or NPC in the existing solution.

### Suggested or Proposed Solution
#### Unity
- We are familiar with C#
- We have a teacher for Unity
- VR integration is relatively easy
- Asset Store
- Animation
- Free

#### Photon Pun
- Multiplayer
- Relatively easy to setup
- Team alredy know the system
- Free

#### Reworking 3D Model
- Remove detail
- Remove almost everything but wall from the 2nd floor
- replace close together wall and windows by one single rectangle

#### NPC and Pathfinding
- use Unity NavMesh Adgent
- bake the NavMesh with Navigation Static
- use navMesh obstacle on doors

#### Door Access
- NPC should have a triger box colider at their feet
- when trigger it should check if layer corespond to door
- check tag and compare to what AI is allowed to do
- If player check if player scaned his phone first
