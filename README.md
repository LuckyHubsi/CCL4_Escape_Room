
# Enchanted Escape
## Creative Code Lab 4 - Group 1

### Story
Lost in the depths of a dark, enchanted forest, you stumble upon an eerie, ancient hut. Rumors among villagers speak of a sinister witch who dwells here, weaving spells and concocting potions. Seeking refuge from the brewing storm, you enter the hut, but the door slams shut behind you, trapping you inside. The air is thick with magic, and you hear the witch's cackle echoing around you. Now, you must find a way to escape before the witch returns.

As you explore the witch's hut, you encounter a room filled with mysterious and magical items. Shelves are lined with old spell books, strange potions bubble on the tables, and peculiar artifacts are scattered throughout. The hut seems to be alive, with hidden mechanisms and enchanted locks guarding its secrets.
Your goal is to solve the various puzzles within the hut. Each puzzle you solve brings you closer to uncovering the secrets of the witch's magic and finding the key to escape. The atmosphere is tense, with the constant fear of the witch's imminent return urging you to hurry.

[click me](#animations)

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
<table>
  <thead>
    <tr>
      <th>Type</th>
      <th>Description</th>
      <th>Status</th>
      <th>Person</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Game Design</td>
      <td>Riddle 1 - Idea</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 1 - Specifics</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 2 - Idea</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 2 - Specifics</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 3 - Idea</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 3 - Specifics</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 4 - Idea</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Riddle 4 - Specifics</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Room Layout</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Game Design</td>
      <td>Garden Layout</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
  </tbody>
</table>

### Art Tasks

<table>
  <thead>
    <tr>
      <th>Type</th>
      <th>Description</th>
      <th>Status</th>
      <th>Person</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th colspan="4">Characters</th>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Witch</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Witch</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Rigging</td>
      <td>Witch</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Witch - Idle</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Witch - Walk</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Witch - Action</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Cat</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Cat</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Rigging</td>
      <td>Cat</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Cat - Idle</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Bird</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Bird</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Rigging</td>
      <td>Bird</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Bird Idle</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Props</th>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Cauldron and Stand</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Cauldron and Stand</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Spellbook</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Spellbook</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Torch</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Torch</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Ingredient Glasses</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Ingredient Glasses</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Window & Door</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela, 🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Window & Door</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Animation</td>
      <td>Window</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Gravestones</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Gravestones</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Barriers & Glass Orb</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Barriers & Glass Orb</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Bird Cage</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Bird Cage</td>
      <td><code>Done</code></td>
      <td>🟣 Noelle</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Potions</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Potions</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Modelling</td>
      <td>Mirror</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Texturing</td>
      <td>Mirror</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Assets</td>
      <td>from Unity Asset Store</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard, 🔵 Michaela</td>
    </tr>
    <tr>
      <td>Assets</td>
      <td>from Sketchfab.com</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <td>Design</td>
      <td>Main Menu</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Design</td>
      <td>Win Screen</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td>Design</td>
      <td>Lose Screen</td>
      <td><code>Done</code></td>
      <td>🔵 Michaela</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Audio</th>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Footsteps</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Cauldron Bubbling</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Garden Ambience</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Magic Effects</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Pick up</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Drop</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Creature noises</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Fire</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Alight torches</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Bucket/Water</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Turning book pages</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Audio</td>
      <td>Menu</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
  </tbody>
</table>

### Dev Tasks

<table>
  <thead>
    <tr>
      <th>Type</th>
      <th>Description</th>
      <th>Status</th>
      <th>Person</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th colspan="4">General</th>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Character Movement</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Camera Panning</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Camera Effects</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Asset</td>
      <td>Item Outlines</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Placement</td>
      <td>Room layout</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Placement</td>
      <td>Garden layout</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Config Files</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Interactions</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Pick up/Drop/Use Mechanic</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Timer</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Placement</td>
      <td>Mirror Room</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Witch Animator</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Asset</td>
      <td>Importing Assets/Models</td>
      <td><code>Done</code></td>
      <td>🟡 All</td>
    </tr>
    <tr>
      <td>Collaboration</td>
      <td>Creating Prefabs</td>
      <td><code>Done</code></td>
      <td>🟢 Marco, 🔴 Leonard</td>
    </tr>
    <tr>
      <td>UI</td>
      <td>Main Menu</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>UI</td>
      <td>Win Screen</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>UI</td>
      <td>Lose Screen</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Puzzle 1</th>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Smoke on Timer</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>UI</td>
      <td>Smoke overlay</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Placement</td>
      <td>3 colored/1 normal torch</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Take normal torch</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Color change torch</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Color combination torch</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Barrier Removal</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Puzzle 2</th>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Window Animator</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Throwing items into cauldron</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Fire in fireplace</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Bucket interaction</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Get Key</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Puzzle 3</th>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Mirror Activation</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev, Placement</td>
      <td>Witch Movement/Logic</td>
      <td><code>Done</code></td>
      <td>🟢 Marco, 🔴 Leonard</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>'SUS' Meter</td>
      <td><code>Done</code></td>
      <td>🔴 Leonard</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Potion interaction</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Barrier Removal</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td colspan="4"></td>
    </tr>
    <tr>
      <th colspan="4">Puzzle 4</th>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Scene Change</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Stone Interaction</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Place Stones</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Potion interaction</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
    <tr>
      <td>Dev</td>
      <td>Win Condition</td>
      <td><code>Done</code></td>
      <td>🟢 Marco</td>
    </tr>
  </tbody>
</table>





