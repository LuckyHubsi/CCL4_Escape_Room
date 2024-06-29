
# Enchanted Escape
## Creative Code Lab 4 - Group 1

### Story
Lost in the depths of a dark, enchanted forest, you stumble upon an eerie, ancient hut. Rumors among villagers speak of a sinister witch who dwells here, weaving spells and concocting potions. Seeking refuge from the brewing storm, you enter the hut, but the door slams shut behind you, trapping you inside. The air is thick with magic, and you hear the witch's cackle echoing around you. Now, you must find a way to escape before the witch returns.

As you explore the witch's hut, you encounter a room filled with mysterious and magical items. Shelves are lined with old spell books, strange potions bubble on the tables, and peculiar artifacts are scattered throughout. The hut seems to be alive, with hidden mechanisms and enchanted locks guarding its secrets.
Your goal is to solve the various puzzles within the hut. Each puzzle you solve brings you closer to uncovering the secrets of the witch's magic and finding the key to escape. The atmosphere is tense, with the constant fear of the witch's imminent return urging you to hurry.

### Models
- Characters
    - Witch
    - Cat
    - Bird
- Props - Requirements
    - Cauldron ( & Stand )
    - Spellbook
    - Torch
- Props - Extra
    - Ingredient Glasses
    - Potions
    - Gravestones
    - Window
    - Door
    - Barriers
    - Glass Orb
    - Bird Cage
    - Mirror
- Props - Assets
    - Inside: Tables, Shelfs, Lectern, Key, Stove, Bed, Bucket, Broom
    - Outside: Trees, Mushrooms, Water Well, Wagon

### Animations
- Witch
    - Idle (looking around suspiciously)
    - Walk (stalking suspiciously)
    - Action (magicking potion into cauldron)
- Cat
    - Idle (rolling around while sleeping)
    - Bird (pecking the floor)

### Code Implementation

__Controls:__  
- WASD for Player Movement  
- Mouse for Camera Movement  
- CTRL to Crouch  
- E to Interact with Objects  
- Q to Drop Objects  

__GameObjects that are never destroyed:__  
- WwiseGlobal (important for the soundbank which holds all sounds)
- Managers (GameManager, ScenesManager, ProgressionManager, WitchManager)
- FirstPersonController (player + all deactivated items)
- UI (UI Timer, TimerText, SmokeOverlay, SusMeterOverlay, TooltipText, Crosshair)

__Interactable Objects:__  
- Torches
- Potions
- Ingredients
- Barriers
- Cauldron (& firepit below the cauldron)
- Key
- Door
- Runestones
- Gravestones
- Book
- Bucket

__Additional Features:__  
- Torch Colors saved in JSON file and will be loaded and randomised in real time
- Potion Colors saved in JSON file and will be loaded and randomised in real time
- Ingredients saved in JSON file and will be loaded and randomised in real time
- Timer (the Player has a total of 15 minutes to finish the game & only 3 minutes to solve the first puzzle)
- Tooltips (text at the bottom of the screen to show the name of interactable items as well as possible actions)
- SmokeOverlay (an overlay to show that the room is filled with smoke which gets darker as time goes on)
- SusMeterOverlay (an overlay to signalise the danger the player is in while the witch is looking at them which gets stronger the longer the player is looked at)
- RenderTexture (used to show the witch brewing something in a different room in real time)

### Game Audio

__NPC Sounds:__  
- Cat Purring
- Bird Chirping

__Ambient Sounds:__  
- Indoor (white noise, smoke)
- Outdoor (birds/crows chirping, owls hooting, nature sounds)

__Object Sounds:__  
- Cauldron (bubbling)
- Barriers (magic sounds)
- Firepit and Torches (fire crackling)

__Object Interactions:__  
- Book (turning pages)
- Torches (picking up, interacting with torches, dropping)
- Potions (picking up, putting into cauldron, dropping)
- Ingredients (picking up, putting into cauldron, dropping)
- Bucket (picking up, interacting with cauldron, interacting with barrier, dropping)
- Key (picking up, interacting with door, dropping)
- Runestones (picking up, interacting with gravestones, dropping)
- Barriers (notification if interacted with the correct item)
- Cauldron (different sounds based on interacted items and correct recipes)
- Door (different sounds based on interaction with or without key)

__Others:__  
- Menu Music
- Win Music
- Lose Music
- Ominous sound when witch sees player
- Coughing sound as long as the first puzzle is not solved

## Task Distribution

### Game Design Tasks
| **Type** | **Description** | **Status** | **Person** |
|--------------|--------------|--------------|--------------|
| Game Design  | Riddle 1 - Idea  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 1 - Specifics  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 2 - Idea  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 2 - Specifics  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 3 - Idea  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 3 - Specifics  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 4 - Idea  | `Done`  | 🔴 Leonard  |
| Game Design  | Riddle 4 - Specifics  | `Done`  | 🔴 Leonard  |
| Game Design  | Room Layout  | `Done`  | 🔴 Leonard  |
| Game Design  | Garden Layout  | `Done`  | 🔴 Leonard  |

### Art Tasks
| **Type** | **Description** | **Status** | **Person** |
|--------------|--------------|--------------|--------------|
| **Characters**  |   |   |   |
| Modelling  | Witch  | `Done`  | 🔵 Michaela  |
| Texturing  | Witch  | `Done`  | 🔵 Michaela  |
| Rigging  | Witch  | `Done`  | 🔵 Michaela  |
| Animation  | Witch - Idle  | `Done`  | 🔵 Michaela  |
| Animation  | Witch - Walk  | `Done`  | 🔵 Michaela  |
| Animation  | Witch - Action  | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| Modelling  | Cat  | `Done`  | 🟣 Noelle  |
| Texturing  | Cat  | `Done`  | 🟣 Noelle  |
| Rigging  | Cat  | `Done`  | 🟣 Noelle  |
| Animation  | Cat - Idle  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Bird  | `Done`  | 🟣 Noelle  |
| Texturing  | Bird  | `Done`  | 🟣 Noelle  |
| Rigging  | Bird  | `Done`  | 🟣 Noelle  |
| Animation  | Bird   Idle  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| **Props**  |   |   |   |
| Modelling  | Cauldron and Stand  | `Done`  | 🟣 Noelle  |
| Texturing  | Cauldron and Stand  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Spellbook  | `Done`  | 🔵 Michaela  |
| Texturing  | Spellbook  | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| Modelling  | Torch  | `Done`  | 🟣 Noelle  |
| Texturing  | Torch  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Ingredient Glasses  | `Done`  | 🟣 Noelle  |
| Texturing  | Ingredient Glasses  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Window & Door  | `Done`  | 🔵 Michaela, 🟣 Noelle  |
| Texturing  | Window & Door  | `Done`  | 🟣 Noelle  |
| Animation  | Window  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Gravestones  | `Done`  | 🟣 Noelle  |
| Texturing  | Gravestones  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Barriers & Glass Orb | `Done`  | 🟣 Noelle  |
| Texturing  | Barriers & Glass Orb  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Bird Cage | `Done`  | 🟣 Noelle  |
| Texturing  | Bird Cage  | `Done`  | 🟣 Noelle  |
|     |     |    |     |
| Modelling  | Potions  | `Done`  | 🔵 Michaela  |
| Texturing  | Potions  | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| Modelling  | Mirror  | `Done`  | 🔵 Michaela  |
| Texturing  | Mirror  | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| Assets  | from Unity Asset Store   | `Done`  | 🔴 Leonard, 🔵 Michaela  |
| Assets  | from Sketchfab.com  | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| Design  | Main Menu   | `Done`  | 🔵 Michaela  |
| Design  | Win Screen   | `Done`  | 🔵 Michaela  |
| Design  | Lose Screen   | `Done`  | 🔵 Michaela  |
|     |     |    |     |
| **Audio**  |   |   |   |
| Audio  | Footsteps  | `Done`  | 🔴 Leonard  |
| Audio  | Cauldron Bubbling  | `Done`  | 🔴 Leonard  |
| Audio  | Garden Ambience  | `Done`  | 🔴 Leonard  |
| Audio  | MAgic Effects  | `Done`  | 🔴 Leonard  |
| Audio  | Pick up   | `Done`  | 🔴 Leonard  |
| Audio  | Drop   | `Done`  | 🔴 Leonard  |
| Audio  | Creature noises  | `Done`  | 🔴 Leonard  |
| Audio  | Fire   | `Done`  | 🔴 Leonard  |
| Audio  | Alight torches   | `Done`  | 🔴 Leonard  |
| Audio  | Bucket/Water   | `Done`  | 🔴 Leonard  |
| Audio  | Turning book pages  | `Done`  | 🔴 Leonard  |
| Audio  | Menu  | `Done`  | 🔴 Leonard  |

### Dev Tasks
| **Type** | **Description** | **Status** | **Person** |
|--------------|--------------|--------------|--------------|
| **General**  |   |   |   |
| Dev  | Character Movement  | `Done`  | 🟢 Marco  |
| Dev  | Camera Panning  | `Done`  | 🟢 Marco  |
| Dev  | Camera Effects  | `Done`  | 🟢 Marco  |
| Asset  | Item Outlines  | `Done`  | 🟢 Marco  |
| Placement  | Room layout  | `Done`  | 🟢 Marco  |
| Placement  | Garden layout  | `Done`  | 🟢 Marco  |
| Dev  | Config Files  | `Done`  | 🟢 Marco  |
| Dev  | Interactions  | `Done`  | 🟢 Marco  |
| Dev  | Pick up/Drop/Use Mechanic  | `Done`  | 🟢 Marco  |
| Dev  | Timer  | `Done`  | 🟢 Marco  |
| Placement  | Mirror Room  | `Done`  | 🟢 Marco  |
| Dev  | Witch Animator  | `Done`  | 🟢 Marco  |
| Asset  | Importing Assets/Models  | `Done`  | 🟡 All  |
| Collaboration  | Creating Prefabs  | `Done`  | 🟢 Marco, 🔴 Leonard  |
| UI  | Main Menu  | `Done`  | 🟢 Marco  |
| UI  | Win Screen  | `Done`  | 🔴 Leonard  |
| UI  | Lose Screen  | `Done`  | 🔴 Leonard  |
|     |     |    |     |
| **Puzzle 1**  |   |   |   |
| Dev  | Smoke on Timer  | `Done`  | 🟢 Marco  |
| UI  | Smoke overlay  | `Done`  | 🟢 Marco  |
| Placement  | 3 colored/1 normal torch  | `Done`  | 🟢 Marco  |
| Dev  | Take normal torch  | `Done`  | 🟢 Marco  |
| Dev  | Color change torch  | `Done`  | 🟢 Marco  |
| Dev  | Color combination torch  | `Done`  | 🟢 Marco  |
| Dev  | Barrier Removal  | `Done`  | 🟢 Marco  |
|     |     |    |     |
| **Puzzle 2**  |   |   |   |
| Dev  | Window Animator  | `Done`  | 🟢 Marco  |
| Dev  | Throwing items into cauldron  | `Done`  | 🟢 Marco  |
| Dev  | Fire in fireplace  | `Done`  | 🟢 Marco  |
| Dev  | Bucket interaction  | `Done`  | 🟢 Marco  |
| Dev  | Get Key  | `Done`  | 🟢 Marco  |
|     |     |    |     |
| **Puzzle 3**  |   |   |   |
| Dev  | Mirror Activation  | `Done`  | 🟢 Marco  |
| Dev, Placement  | Witch Movement/Logic  | `Done`  | 🟢 Marco, 🔴 Leonard  |
| Dev  | 'SUS' Meter  | `Done`  | 🔴 Leonard  |
| Dev  | Potion interaction  | `Done`  | 🟢 Marco  |
| Dev  | Barrier Removal  | `Done`  | 🟢 Marco  |
|     |     |    |     |
| **Puzzle 4**  |   |   |   |
| Dev  | Scene Change  | `Done`  | 🟢 Marco  |
| Dev  | Stone Interaction  | `Done`  | 🟢 Marco  |
| Dev  | Place Stones  | `Done`  | 🔴 Leonard  |
| Dev  | Potion interaction  | `Done`  | 🟢 Marco  |
| Dev  | Win Condition  | `Done`  | 🟢 Marco  |





