# General Description

The objective of the project is to create a realistic simulation of the school life in B3, a building that is currently being built for AlgoSup. The project will need to be realised in VR (Virtual Reality). 
The project is given by Algosup and monitored by Sebastien Goisbeault, VR and XR consultant.

# Target audience
We target potential future students as well as their parents. 
This project could also be useful for current students and potential investors to help them visualise the future look of AlgoSup.
Finally, the school Staff could use the simulation to see if they like the way the B3 is arranged and predict possible complications in advance.


# In-simulation mechanics

## Menus
<sup>* Menus must be interactive <sup>
<!-- Came back here to specify how menus are accesed, how it should look etc.. -->

- Main menu:
	- Start button
	- Settings button
	- Quit button


- Settings menu:
	- Height controls:
		- Set user height
	- Movement controls:
		- Snap turn[^1] / Smooth turn[^2] / No-mode[^3]
		- Teleportation[^4] / locomotion[^5]
	- Sound controls:
		- Slider
	- NPC limit (if multiplatform):
		- The ability to set a npc limit for weaker computers
	- Respawn access:
		- A security respawn button
    - Stop scenario:
        - A button that stops the current scenario (must be inactive if user is not mid-scenario)
	- Back to main menu button:
		- A link back to the main menu


- Map:
	- The user must be able to access the map at all times.
	- The user must be able to see their position on the map.
	- There must be a list of available scenarios and other similar points of interest (ex: character selection).
	- There must be a legend detailing the significations of the pins on the map.

## Playable characters

The user must be able to play the simulation out from the perspective of different characters.
These characters must be able to have different interractions and must be able to access different parts of the building.

The user must be capable of choosing their prefeered character at the reception.
The reception must have a clear and highly visible indicator that marks it as the place to change character at.
The map must have a pin that clearly indicates the location of the reception.
The user must not be able to change his character mid-scenario.

### Planned characters:

- Male / Female student:
  - Young looking characters, preferably with a similar nut distinguishable model to that of the other student npc's
  - The student characters must have access to the following rooms:
    - Common rooms (ex: the relaxation room(s))
    - The classrooms
    - Their and only their project room
    - Their respective toilettes

- Orator ("intervenant" in french):
  - A bit older looking character
  - The orator can access to the following rooms:
    - Common rooms (ex: the relaxation room(s))
    - The classrooms
    - Any project room
    - Their respective toilettes
    - Teacher specific rooms (ex: Reunion rooms)
  
- Franck:
  - A very Franck looking character
  - Has access to every part of the school

## Predefined scenarios

The simulation must contain a list of predefined scenarios.
These scenarios must stay fairly simplistic.

<!-- WIP -->

# Use cases

## Generic Use case

## Scenario specific use cases

### As Student

- Lunch rush :
  - most Student and Orator NPCs immediately go to the cafeteria
  - remaining Student and Orator NPCs exit the building
  - Once in the cafeteria NPCs get lunch from fridge
  - NPCs go microwave, if no microwave available NPCs go sit
  - NPC eat
  - Outside NPC get back inside
  - NPCs exit cafeteria and go in "free time" mode

- Toilet rush :
  - many student leave class to go to the nearest toilets
  - NPCs wait in line for the toilet to be free
  - When they exit NPC resume previews activity

- Computer Science class :
  - Student and a Teacher NPCs move toward the amphitheater
  - Teacher stand behind his desk
  - Student sits at random desk
  - Teacher switch slides a few time
  - Student all try to leave at once
  - Student go in "free time" mode

- Project time :
  - student NPCs go in project room in groups of 8
  - use card to open room
  - student NPCs lock the room by scanning card
  - student NPCs sit behind computer
  - Slide change on the room's TV
  - Teacher NPC can enter the room at some point with card
  - as student player can't enter the room if card was not scanned before dor was locked

- Soft Skill :
  - students NPC go to soft skills room
  - teacher NPC Stand in the middle of the room
  - some student move erratically around the room
  - remaining student stand in circle
  - Student all try to leave at once
  - Student go in "free time" mode

- Drone :
  - One of the NPC group in "project time" mode leave their room
  - students go to teacher
  - teacher and student go to teacher computer
  - student give teacher access card
  - teacher manipulate card (supposed to represent allowing access to storage)
  - teacher give back card to student NPC
  - teacher resume previews activity
  - student go to secured storage room
  - scan card on drone shelf (confirm that student is allowed to take drone)
  - take drone
  - exit room and close dor
  - go to drone testing area, lay drone on the ground and sit on bench
  - NPC in "free time" mode near the drone testing may sit on bench or look at the cage
  - Drone fly around the cage in pattern 
  - after some time drone lands, "free time" NPC resume normal activity
  - Group student pickup the drone and put it back in storage room
  - Student group go back to project room

# Footnotes

## Definitions

[^1]: Snap turn : camera rotation in step of 10°, controlled by a joystick
[^2]: Smooth turn : smooth camera rotation, controlled by a joystick
[^3]: No-mode : smooth camera rotation, controlled by the VR headset
[^4]: Teleportation : Move instantly to the point you are aiming at on the ground
[^5]: Locomotion : Move like a traditional 1st person game using the joystick
