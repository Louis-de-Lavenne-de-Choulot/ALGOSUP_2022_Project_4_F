# General description

The objective of the simulation is to highlight possible problems that may arise within ALGOSUPs new shool building, the B3[^4].

The simulation must take place within the new school building, must contain characters (controlled by simple AI) to simulate students, speakers, teachers and administrative staff.
It also needs to be able to launch various scenarios which could highlight the more foreseeable problems that may appear in the future.

The non-user characters[^2] must follow a pre-planned schedule ensuring the day-to-day functionality of the building. These schedules must be only interrupted when the user launches a scenario, in which case they should start to act according to it.

The project must be realized in Virtual Reality[^1].

If successful, this project should be able to ensure the school building is built without any obvious faults.

This project has been proposed by ALGOSUP's[^3] leadership.

# Target audience
Our main target is  potential future students as well as their parents. However, this project could also be useful for current students and potential investors to help them visualise the future look of ALGOSUP[^3]. It could also be used to highlight the problems that we could encounter in the daily life in the building. Finally, the school Staff could use the simulation to see if they like the way the B3[^4] is arranged and predict possible complications in advance.

# The school building
While the 3D model of the building is provided at the start of the project, it needs to be seriously reworked before it could be considered usable for the simulation.

Most of the building is currently unoptimized for virtual reality[^1] and the inner textures of the building are purposefully missing.

The building also needs to be decorated.

The building must be fitted with signs and a map somewhere that is easy to spot.

The top floor of the building is not part of the school and therefore it can be ignored, however the elevator must still be made functional.

## The map

This is the map of the starting points for the different scenarios.
This map currently only exist for development purposes.
A simplified version of this map must be added to the school building somewhere easy to spot.

<img src="img/PNGS FUNCTIONAL/map_with.pins.png">

Legend:

1. Building entrance
2. [Elevator](#the-school-building)
3. [Scenario lunchtime](#lunchtime)
4. [Scenario computer science class](#computer-science-class)
5. [Scenario soft-skills class](#softskills-class)
6. [Scenario project time](#project-time)
7. [Scenario the drone](#the-drone)
8. [Scenario toilet rush](#toilet-rush)

# Menus
<sup>* Menus must be interactive <sup>
<!-- Came back here to specify how menus are accessed, how it should look etc.. -->

## Main menu:
- Start button
- Settings button
- Quit button


## Settings menu:
- Height controls:
  - Set user height
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


# Non-Player characters

<sup>* Non-Player characters</sup> [^2]


## Students NPC
| Name - Gender   | Age | Locomotion                    | Lunch                             | Morning   | Afternoon | Likes                         | Dislikes                          | Details                               |
|:---------------:|:---:|:-----------------------------:|:---------------------------------:|:---------:|:---------:|:-----------------------------:|:---------------------------------:|:-------------------------------------:|
| Johnny - M      | 19  | Walks                         | Orders food                       | EN        | PR        | Rabbits, to play with drones  | Smoking people, loud noise        | Easily distracted                     |
| Steph - F       | 21  | Drives, co-driving with Nick  | Eats in school                    | CS        | CS        | Boys Band, mushrooms          | Heated food                       | Has a small bladder, smokes           |
| Janka - F       | 24  | Bus                           | Fast food restaurant              | SS        | SS        | Paralympics, Neon wheelchairs | Staircases,insects                | Wheelchair, ventolin                  |
| Alexandre - M   | 18  | Bicycle                       | Eats outside                      | PR        | PR        | Italian food                  | Famous clothe brands, Crayfishes  | Always late                           |
| Nick - M        | 27  | Is co-driven by Steph         | Bring his own meal                | PR        | PR        | Old tech, steam engines       | Smartphones, social medias        | Has a really old phone, wants to work in green energy, Eats a lot and very slowly |
| Lindzy - F      | 17  | Bus                           | Eats outside                      | CS        | EN        | Music and arts                | Sports and small places           | Always wears headphone and is late    |
| Denis - M       | 20  | Drives                        | Eats in school                    | EN        | CS        | Video games and anime         | Hard work and amateurs               | Speaks way too much                   |
| Lana - F        | 22  | Drives                        | Goes out to buy than comes back   | EN        | SS        | Nature, tofu                  | Meat, fast food                   | Vegan, ric                            |
| Sam - M         | 25  | Comes in a motorbike       | Uses kitchen and eats in school   | CS        | PR        | POH-TAH-TOES, unique jewelry  | Being hungry, bad hygiene         | Loves to eat, he is very short, likes to adventure    |
| Gen-Eric - N/A  | 18  | Walks                         | Eats in school                    | PR        | CS        | Normal things                 | Strange things                    | Gen-Erics are normal students. Not aliens. Don't ask  |

## CNAM NPC
|**Name** |**Age**  |**Locomotion** |**Eat**    |**Like**           |**Dislike**                  |**Details**                                      |
|---      |---      |---            |---        |---                |---                          |---                                              |
|Robert   |31y/o    |Drive          |Eat inside |football,beer      |books, the color red         |Forget his pass often, ask students to let him in|
|Sarah    |38 y/o   |Walk           |Eat outside|fancy cars and dogs|tractors and all noisy things|Confident, arrives before everyone

## Speakers NPC

|**Name** |**Age**  |**Locomotion** |**Eat**    |**Like**|**Dislike**   |**Details**  |**Job**|
|---      |---      |---            |---        |---     |---           |---          |---    |
|Kenny    |34y/o    |Carpooling     |Eat outside|Disney princesses|animals,Russia|Is a bit hard to understand, needs a screen to display courses|Importance of life
|Theresa  |48y/o    |Driving        |Eat in, orders food|Food and soccer|Cheating and git copilot|  Is overweight|C#/github
|Chad     |30y/o    |Bicycle        |Eat healthy at “Au healthy”|beautiful things| Bells and ukrainian|Self overconfidence, chad behavior|Self Confidence
|Branden  |25y/o    |Copilot       |eat on site|Nobody and monster drinks|Everyone, spiders|Long hair, big black coat, glasses|GO
|Louisa   |29y/o    |Driving        |Eat outside |wine, competition|people that are lacking skills|Crazy hair, checked shirt and always broken glasses|Problem solving


# Scenarios

## **Lunchtime**

Simulates lunchtime. Most students tries to access the food facilities (Microwaves, refrigerators, etc) at the same time.

<br>

<details>
<summary>Scenario settings</summary>

- Number of students
- Number of staff members
- Ratio of students that decides to eat outside of school grounds
- Amount of time microwaves take for each npc
- Amount of time characters need to eat
- Number of microwaves

</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/LunchRush_PL.drawio.png">

## **Computer science class**

In this scenario the user can experience a normal computer science class.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/Computer science class_PL.png">

## **Soft skills class**

In this scenario the user can experience a normal soft skills class.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>


<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/Soft skills_PL.png">

#### **Project time**

The user goes through a simple exercise to simulate project work.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/Project time_PL.png">

## **Project time**

The user goes through a simple exercise to simulate project work.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/Project time_PL.png">


#### **The drone**

The user gets an opportunity to try out the drone in its intended area.

<br>

<details>
<summary>Scenario settings</summary>
None
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/Drone_PL.png">

#### **Toilet rush**

A particularly high number of students needs to use the toilets at the same time.

<br>

<details>
<summary>Scenario settings</summary>

- Number of students
- The amount of time each student takes
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/ToiletRush_PL.png">


#### **Toilet rush**

A particularly high number of students needs to use the toilets at the same time.

<br>

<details>
<summary>Scenario settings</summary>

- Number of students
- The amount of time each student takes
</details>

<u>scenario script</u><br>
<img src="img/PNGS FUNCTIONAL/ToiletRush_PL.png">


# Minimum Viable Product	

The criteria for the minimal viable product are:
* The entire B3[^4] modelled with basic materials.
* Functional doors.
* A single (articulated) playable character that can roam the school building.
* VR compatibility.


# Footnotes

## Definitions

[^1]: VR: Virtual reality (VR) is a simulated experience that can be similar to or completely different from the real world.
[^2]: NPC(Non player character): A non-player character (NPC) is any character in a game or simulation that is not controlled by a player/user.
[^3]: ALGOSUP: Computer science school from France (The B3 will be the main building of the school)
[^4]: B3 : The school building the simulation must take place in. A 3D model of the building is provided at the start of the projectA.






