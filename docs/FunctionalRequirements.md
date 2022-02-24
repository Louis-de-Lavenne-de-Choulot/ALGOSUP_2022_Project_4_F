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

- Student (m/f):
  - Young looking characters, preferably with a similar nut distinguishable model to that of the other student npc's
  - The student characters must have access to the following rooms:
    - Common rooms (ex: the relaxation room(s))
    - The classrooms
    - Their and only their project room
    - Their respective toilettes

- Handicapped:
  - Has a wheelchaire
  - Can not use the staircases but has access to the lift
  - Moves a bit slower
  - They are a normal student otherwise

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

## Time

The simulation must follow a sequence of timed events during which the user could roam the school building (only the parts available for the character in question).

During each event the non-playable characters must live out a generic schoolday.
The non-playable characters timetable is as follows:

<!-- TODO -->

## Predefined scenarios

The simulation must contain a list of predefined scenarios.
These scenarios must stay fairly simplistic.

The objective of these scenarios is to simulate specific events from the peerspective of different characters.

### Planned scenarios:

#### **Lunchtime**

Simulates lunchtime. Most students tries to access the food facilitest (Microwaves, refrigerators, etc) at the same time.

<br>
<img src="img/PNGS FUNCTIONAL/LunchRush_PL.drawio.png">

<details>
<summary>Scenario settings</summary>

- Number of students
- Number of staff members
- Ratio of students that decides to eat outside of schoolgrounds
- Amount of time microwaves take for each npc
- Amount of time charcters need to eat
- Number of microwaves

</details>

<details>
<summary>Characters this scenario is available for</summary>

- Student (needs to eat with students)
- Handicapped (needs to eat with students)
- Orator (needs to eat with staff)
- Franck (Roams free and observes)

</details>

<u>scenario script</u>
<!-- TODO -->

#### **Computer science class**

In this scenario the user can experience a normal computer science class.

<br>

<details>
<summary>Scenario settings</summary>

</details>
None
<details>
<summary>Characters this scenario is available for</summary>

- Student (Takes class)
- Handicapped (Takes class)
- Orator (Gives class)
- Franck (Roams free and observes)

</details>

<u>scenario script</u>
<img src="img/PNGS FUNCTIONAL/Computer science class_PL.drawio.png">

#### **Softskills class**

In this scenario the user can experience a normal softskills class.

<br>

<details>
<summary>Scenario settings</summary>

</details>
None
<details>
<summary>Characters this scenario is available for</summary>

- Student (Takes class)
- Handicapped (Takes class)
- Orator (Gives class)
- Franck (Roams free and observes)

</details>

<u>scenario script</u>
<img src="img/PNGS FUNCTIONAL/Soft skills_PL.drawio.png">

#### **Project time**

The user goes trought a simple exercise to simulate project work.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<details>
<summary>Characters this scenario is available for</summary>

- Student (Works on a project)
- Handicapped (Works on a project)
- Franck (Roams free and observes)

</details>

<u>scenario script</u>
<img src="img/PNGS FUNCTIONAL/Project time_PL.png">


#### **The drone**

The user gets an opportunity to try out the drone in its intended area.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<details>
<summary>Characters this scenario is available for</summary>

- Student (Drives drone)
- Handicapped (Drives drone)

</details>

<u>scenario script</u>
<img src="img/PNGS FUNCTIONAL/Drone_PL.png">


#### **Emergency**

The user experiences a fire emergency and needs to go trought the emergency motions.

<br>

<details>
<summary>Scenario settings</summary>

- Number of students
- Organisation level (some student might waste time on gathering their holdings, going in the wrong direction, etc..)
</details>

<details>
<summary>Characters this scenario is available for</summary>

- Student (user needs to exit the building then gets the amunt of time they took)
- Handycapped (user needs to exit the building then gets the amunt of time they took)
- Franck (user needs can observe as everyone exits and gets the total amount of time it took)

</details>

<u>scenario script</u>
<!-- TODO -->


#### **Toilet rush**

A particularly high number of students needs to use the toilets at the same time.

<br>

<details>
<summary>Scenario settings</summary>

- Number of students
- The amount of time each student takes
</details>

<details>
<summary>Characters this scenario is available for</summary>

- Student (Has to use the bathroom)
- Handycapped (Has to use the bathroom)
- Franck (Roams free and observes)
</details>

<u>scenario script</u>
<img src="img/PNGS FUNCTIONAL/ToiletRush_PL.drawio.png">


## Non-playable characters

Non playable characters must be able to pathfind and perform prescripted actions such as sit down, stand up, grabbing objects, etc.
They must also be able to pathfind without bumping into each other.

### Planned non player characters:

- Students (m/f):
  - They make up the bulk of the available non-playable characters.
  - Characters enter the school building in the morning and leaves at night.
  - They roam the school during breaks, pretend to socialize and visit the bathroom from time to time.
  - They got to classrooms / projectrooms (in teams of 4-8) during work hours.

- Hapndycapped students:
  - A rare, wheelchaired version of students
  - Can not use the staircases but has access to the lift
  - Moves a bit slower

- Orators ("intervenants" in french):
  - There should be 1 orator for each class given to students that are not on projet-time.
  - They should roam the scool freely during breaktimes but should mainly be in the staff-specific relaxation areas.
  - They should give lectures during workhours.

- Cleaning / Maintenance staff:
  - They should came in specific hours.
  - They should "do work".

- Administration staff:
  - Specific characters that follow strick scripts instead of automatically generated-agendas.

# Use cases

<!-- Revisit this -->

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
	- Student
	- Investors
	- Franck
	- Parents

- Characters :
	- Student F/M
		- Move from class to class
		- Is seated when in “Project time”, “Computer science class”
		- Move erratically in the room when in “Soft Skill” (may change layout of table)
		- Stand in group when in “Freetime”
		- Try to find a seat when in “Freetime”
		- Chance of exiting the building when “Lunch” otherwise go to cafeteria
		- Access women's toilets
		- Access men's toilets
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

The criterias for the minimal viable product are:
* The entire B3 modelled with basic materials.
* Functionnal doors.
* A single (articulated) playable character that can roam the schoolbuilding.
* VR compatibility.


<!-- ------------------------------------------------------------------ -->
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
  - as student player can not enter the room if card was not scanned before dor was locked
  - student NPCs sit behind computer
  - Slide change on the room's TV
  - Teacher NPC can enter the room at some point with card
  - after sometime students leave room and go in "free time" mode

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

- Free time : 
  - some student will roam the school in groups
  - some NPC will go on the terrasse and stand in group, sit and/or smoke
  - some NPC will go sit in rec room and look at their phone
  - some NPC will go sit in the cafeteria and drink
  - some NPC will sit on bench in the corridors and look at their phone
  - after some times NPC will go in "class" or "project time" mode if rooms are available


# Footnotes

## Definitions

[^1]: Snap turn : camera rotation in step of 10°, controlled by a joystick
[^2]: Smooth turn : smooth camera rotation, controlled by a joystick
[^3]: No-mode : smooth camera rotation, controlled by the VR headset
[^4]: Teleportation : Move instantly to the point you are aiming at on the ground
[^5]: Locomotion : Move like a traditional 1st person game using the joystick
