# MetaHex


**Overview:**

Let’s try to cover the plane with hexagonal tiles, arranged in the pattern you expect, except that these tiles are not rigid: each side is capable of moving both into the tile or out of it. In each tile, what one side does will determine the motion of all the other sides, too. In particular, if one side reverses its motion then so do all the others. It turns out that the deformations of the sides can be correlated in eight distinct patterns:

![אני רעב קצת](https://github.com/user-attachments/assets/2a3ad6ca-95da-4cd7-bc6d-4f0659facc06)


We pick one of these eight `block types’ and place a copy of it in each cell of the honeycomb lattice, where they can also be arbitrarily rotated, independently of each other, and each block can deform in the way shown here or with flipping the direction of motion of all of its sides. The goal is to find arrangements in which a simultaneous motion of all sides of all tiles is possible. This app helps you with this task. 

**Instructions:**

Selection Screen:

●	Height and Width: You can set the height and width of the lattice, the bigger the lattice, the more time to auto-solve it.

●	Block Type: You can set which of the eight block types are enabled. If you later set a hexagon to a block type you didn't choose, it will write the block type and display a red x on it.

●	Hex Lattice / Square Lattice: In Hex mode it will create a giant hexagon made out of hexagonal blocks, there is no height, only length, which determines what will be the side length of the giant hexagon. In Square mode it will create a parallelogram and you can set its height and width.

●	Periodic: This will automatically link up the edges so the folded lattice created would be able to tile infinitely. So when you click one of the edges it will automatically set the compatible edge on the opposite side. In hex lattice mode this is disabled.

●	Auto: Tries to fill the hexagons with an equal amount of each chosen block type without any frustration. Will attempt all possible configurations with the given height and width, with the chosen block type and respecting if the periodic button is on or not. It stops when it finds a working solution (which it will show on the screen) or when there are no solutions (a big red x will show on the screen). Note: if the height or width is 1, then auto-solve will not work properly.

●	Variations: Only works when the auto-solve button is on. Finds all of the possible solutions to the selected settings, when it's done, it will show on the screen how many different solutions were found. 

●	Confirm: After setting everything up press it and you will go to the lattice screen.
Lattice Screen:

●	To decide where a beam will bend, click slightly toward where you want it to bend, if you want it to reset, press where it was originally. Once all 6 beams of a hexagon have been set it will show on the hex its block type and it will show a red x if this block type wasn't chosen at the start.

●	Reset: Resets the screen to what it was right after you pressed confirm.

●	Back: Goes back to the selection screen, it should remember and keep your settings

●	Auto: Will try to find a solution using all of the settings from the selection screen and without changing any beams you already set in the lattice.

**Additional features when downloaded:** 
    
  Selection Screen:

●	Photo Mode Button: Only works when the auto-solve button is on. When a solution is found automatically, it will save it as a picture to a folder named "autoSolves" which is in the folder named "MetaHex_Data". With buttons the variations and the more auto buttons, it will save all of the found solutions. Notes: doesn't work on the web version, if left to run on a big lattice for a long time it will fill up your PC. 

●	More Auto Button: Only works when the auto-solve button is on. Should only be used with photo mode on and if paired with variations, it will take a very long time. It runs over every combination of the amount of soft modes chosen and tries to find a solution to every one of them. Note: you should only choose the starting soft modes, so for example, if you want to go over all of the 3 soft modes combinations, you need to only choose soft mods 1, 2 and 3a.

  **Lattice Screen:**

●	Variations: Will try to find all of the variations that are using the settings from the selection screen and are using your current changed beams.






[here are all of the files](https://mega.nz/file/sDFxBBJC#dhCrq0IqhnLGDqhXj_oTH5hxv-mr_xKHUwicla5TWi4)
