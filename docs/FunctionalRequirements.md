# General Description

The objective of the project is to create a realistic simulation of the school life in B3, a building that is currently being built for AlgoSup. The project will need to be realized in VR (Virtual Reality). 
The project is given by Algosup and monitored by Sebastien Goisbeault, VR and XR consultant.

# Target audience
We target potential future students as well as their parents. 
This project could also be useful for current students and potential investors to help them visualize the future look of AlgoSup.
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
	- NPC limit (if multi-platform):
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
These characters must be able to have different interactions and must be able to access different parts of the building.

The user must be capable of choosing their preferred character at the reception.
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

# In-simulation
- Move around:
	The user must be capable of moving around
- Select / change personae:
	The users must be able to select the character they impersonate in-simulation
	This must be done at the reception desc
	The available scenarios must be changed depending on the personae
- Interact with doors and certain objects:
		Doors, keycards, and other interactive objects must be accessible for the user
		Objects that can be interacted with are highlighted
- Launch scenario
	The user must be able to launch their preferred scenario from their starting  points

	#  Personaes
- Users :
	- Student (Female/Male)
	- Investors
	- Franck
	- Parents

- Characters :
	- Student F/M
		- Move from class to class
		-	Is seated when in “Project time”, “Computer science class”
		- Move erratically in the room when in “Soft Skill” (may change layout of table)
		- Stand in group when in “Freetime”
		- Try to find a seat when in “Freetime”
		- Chance of exiting the building when “Lunch” otherwise go to cafeteria
		- Access women's toilets
		- Access men’s toilets
		- Rush for the exit when “end day”
		
- Teachers
	- Goes from project room to another project room during “Project time”
	- Coffee break
	- Lunch break
	- Courses on screen (remote work)
	- Stand/Sit at their desk during “Computer Science class” and “Soft skill”
	- Switch slides when in “Computer Science class” and “soft skill”
	- Chance of exiting the building when “Lunch” otherwise go to cafeteria
- Franck
	- Can move whenever and  wherever he wants
	- Can open all doors and lock them too
	- Key to open the building
	- Roam the building
	- Otherwise sit at his desk
	- Count people in “Fire Alarm” scenario
- Cleaning staff
	- Roaming the building, only access empty room
	- Exit when “lunch time”
	- Continue their action when “end day”
	- Regularly go to Cleaning Room
	- Mimic cleaning ground

 # Minimum Viable Product	
We should have a high quality 3D Visualization of the B3 with a playable character and non specific npcs roaming around. The user should be able to move and look around and open dors.


## Generic Use case



## Scenario specific use cases


# Footnotes

## Definitions

[^1]: Snap turn : camera rotation in step of 10°, controlled by a joystick
[^2]: Smooth turn : smooth camera rotation, controlled by a joystick
[^3]: No-mode : smooth camera rotation, controlled by the VR headset
[^4]: Teleportation : Move instantly to the point you are aiming at on the ground
[^5]: Locomotion : Move like a traditional 1st person game using the joystick
