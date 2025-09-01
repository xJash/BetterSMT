## 3.0.0
- Removed rerolls config due to implementation into the base game through perk
- Merged a PR from Damntry fixing some Custom Products fuckery
- Fixed a ton of issues I accidentally implementied with building structures
- Changed checks for hotkeys to be much more harsh, less likely for them to activate in non-intended ways
- Fixed auto-paying invoices
- Touched up some replace comma with period functions since it is a nightmare, should be fully functional again
- Fixed some issues with selling structures during the day while customers are in-store
- Removed the save button & autosaving due to the implementation of it into the base game has finally been done correctly (and technically stolen idea from my mod, like how many other features, like seriously does this game dev just watch my pr? watch the mod on nexus? what you doin c276, give some credit sheeesh, like you even took my fix for autosaves and published it like you figured out what was wrong and all when I did lmao)
- Redid the entirety of the base games employe data generation since it was actually terrible
- Added a new feature to have a text notification appear on-screen when a thief walks through anti-theft alarms
- Added some further checks preventing modification to abse game without configs being fully enabled for future-proofing
- Added new feature to adjust how fast order packaging orders come
- Added new feature to adjust max amount of orders received through order packaging per day

## 2.5.0
- Added new products to existing dicts
- Fixed "free placement"
- Added a "more cheaty" version of Free Placement called Cheat Placement (place anything anywhere)
- Fixed esc menu placement of save button
- Added new feature to get 100% refund on selling placed structures
- Remove highlighting and added notification to get it from SuperQoLity
- Centralized product dict for (hopefully) smoother notifications

## 2.4.1
- Fixed one click checkmarks on customers through the security terminal
- Removed skip tutorial feature since it has been taken into the base game
- Added visual que feature for when thieves walk through the anti-theft door
- Fixed cost reduction on sledgehammer demolishables
- Added new products to notifications
- Added some future proofing into product lists to track future products and crashes
- Reimplemented a secondary free-placement option to truly place whatever structure wherever (even floating in the air)

## 2.4.0
- Added option to allow all products to be stock-able on all shelves
- Added option to allow all normal products to be stocked on pallets (removing the size check)
- Added option to modifiy pillar removal price
- Added option to stop rubble from spawning 
- Added option to disable self checkout breaking
- Added option to disable cardboard baler breaking
- Added option to move the location of boxes spawning from manager blackboard to be closer to the storage area
- Fixed an issue with employe level generation from 7/2/2025 game update

## v2.3.0
- Fixed an issue where the Ordering Device would add the same product twice
- Added a setting to allow more employee rerolls
- Removed outdated options (e.g., modifying end-of-day rent, lighting, and employee fees)
- Added a hotkey to cancel active sales during the day
- You can now pay off loans early using a button on the loan screen
- Reworked the in-game Vehicle system:
  - Automatically picks up boxes within a configurable range while driving
  - Added a hotkey to auto-drop boxes while driving
  - Configurable pickup limit (up to 6 boxes)
- Cleaned and reorganized the config file for better readability
  - ⚠️ Recommended: delete your current config and let it regenerate
- Added a config option to disable the save game button (enabled by default)
- Fixed additional logic issues related to commas being replaced improperly
- Added an option to make all NPCs at the surveillance desk interactable with one click
- Improved how the mod interacts with the in-game clock:
  - Now requires the relevant perk to function
  - Cannot be activated while the store is open
  - Requires at least one active employee job to use
  - Can be toggled to activate in the morning, but auto-disables once the store opens
- Ordering Device now correctly subtracts existing inventory when generating orders
- Ordering Device screen now displays what's being added to the shopping list
- Adjusted default keybinds for various hotkeys
- Further refined the config file layout
- Updated cardboard bale value to match changes in the base game
- Major code optimizations for improved performance and lower resource usage

## v2.2.0
- Option to disable tutorials on fresh saves
- Added config and option to change amount of cardboard required to get a bale, aswell as adjusting the value of the bale accordingly
- Added options to enable the use of normal number's instead of just numpad
- Cleaned Builder_Main patch
- Added a feature to make most products in the game stack two high (but only where it doesn't clip into other shelves)
- Added removing collision with structures
- Fixed some config mishaps
- Added stocking an entire box in one click
- Added a feature to pickup the tablet and automatically have everything you need to fill the store be added to shopping order
- Further fixed some issues with comma's being replaced with periods

## v2.1.0
- Added option to change comma's into period's
- Added option to replace default currency symbol $ with anything
- Made drastic code improvements
- Drastically reorganized and revamped the configuration file

## v2.0.1
- Updated internal localization
- Added new products to too expensive/missing product notifications
- Added option to unlock Pallet Displays without the perk
- Added option to turn nearest Trash Bin into a Recycler without the perk 

## v2.0.0
- Reworked too expensive and missing product notifications
- Added auto-saving
- Added options to change customer cart size, and customer spawn amounts
- Fixed box size multiplier applying repeatedly between save loads
- Adjusted how box size multiplier works to future-proof it for new products (aswell as custom products added vid other mods)
- Fixed highlighting not disabling when disabled
- Added option to change the limit of how many sales you can run per perk unlocked
- Added option to automatically have invoices paid for
- Adding hotkey's to spawn a Sledgehammer, Os Mart 2.0 Tablet, Tray, and Sales Tablet into your hands

## 1.9.9

- Fixed a bug within deletion of structures
- Re-aded auto-2x price
- Added hotkey for clock activation
- Clock is now throughout the full day

## v1.9.8
- Removed remove pillar feature due to it being added to base game
- Removed auto-2x price everything due to it being added to base game
- Removed some config option's removed in previous versions I overlooked
- Fixed building/deleting bug

## v1.9.7
- Removed mod to delete shelves containing product due to it being added in base game
- Fixed a bugged cuased by new update with deleting decorations

## v1.9.6
- Added Third Person hotkey being disabled while typing
- Revamped the entire highlighting system
- - Now includes labeled storage shelves
- - Should be much quicker to both highlight and de-highlight
- - Could potentially be buggy in multiplayer, please report any instances of bugs
- Fixed some issues with vehicles and decorations not being able to be deleted
- Fixed some general typos within existing notifications aswell as changelog and readmes
- Updated custom box sizes to include most recent products

## v1.9.5
- Added deleting the last checkout
- Fixed a small money duplication error pointed out by Ika
- Fixed box collision
- Fixed random cashier no worky error (Thanks to TheGoatler for testing)

## v1.9.4
- Fixed 2 errors in previous update that I am dumb for making

## v1.9.3
- Added ability to adjust amount of products in a box, also adjusts price accordingly to purchase
- - WARNING THIS IS EXTREMELY BUGGY IN MULTIPLAYER.
- Added ability to disable box collision so they can stack inside of eachother
- Added ability to make purchases boxes spawn extremely quickly

## v1.9.2
- Removed ordering from price gun due to it being added in base game
- Removed comma to period replacement due to partial and eventual full implementation into base game
- Removed highlighting on top right corner due to being added into base game
- Modified how Self Checkout Limit works

## v1.9.1
- Added option to disable/enable shelf highlighting
- Added option to enter and leave third/first person view. Third person is currently semi-buggy. Some of these happen intermintently, to fix them enter first person and re-enter third person.
- - Cant pickup broom, dlc tablet, pricing gun
- - Cant price things
- - Cant interact with register
- - Cant place down most structures
- - Cant hit employee, robber, or customer with broom
- - Cant emote
- - Managers board distance is weird
- - DLC distance is weird
- - Browser isnt working
- Added option for missing products and too expensive products to be entered into chat.

## v1.9.0
- Removed employee radius patch due to implementation into base game
- Removed options for raising max amount of materials in a box
- Removed box collision
- Fixed max amount of employees
- Added feature to adjust level of employee's that spawn aswell as their stats
- Due to new employee update, raising employee cap is no longer required and I have removed raising Max Employee options.
- Fixed Save Game option
- Fixed Double Price Module option
- Fixed automatic double pricing daily option
- Fixed highlighting in top right corner
- Fixed deleting pillars
- Fixed deleting structures while the store is open

## v1.8.5
- Fixed pricing gun not ordering when pressing E

## v1.8.4
- Fixed the loading issues when removing pillars

## v1.8.3
- Added ability to remove most of the pillar's within the store
- Added functionality of spawning pricing gun/borom/dlc tablet while typing
- Changed default keybinding on Pricing Gun to Y, Broom to U, and DLC Tablet to I.
- Added ability to enable/disable ordering from price gun, aswell as changing the hotkey for it
- Additional fuck-coding and memory usage cleanup

## v1.8.2
- Added option to automatically double the price of every product at the start of the day (Credit to Trevor)
- Added current fix for "ant circle of death" only enabled with max employee's is higher then 10
- Removed employee collision (is apart of the above)
- Added config options to be able to spawn Pricing Gun, Broom, and the DLC tablet into your hand, aswell as a hotkey to despawn them.
- [Highly suggest removing old config file and re-generating]
- TODO: Disable spawning of pricing gun, broom, and DLC tablet while typing
- Large amount of general code cleanup

## v1.8.1
- Added the option to delete buildings while the store is open
- Added the option to delete buildings while their is customers in the store
- Added the option to delete buildings that currently have product on them 

## v1.8.0
- Added ability to manually adjust the cost of lights, employee's, and rent.
- Added config for enabling and disabling trash
- Added option to disable spawning of thieves
- Added option to turn every customer into a thief
- Added config to increase amount of customer's spawned through in-game perk
- Reorganized configuration file
- Fixed a minor issue with highlighting of some boxes
- [Highly suggest removing old config file and re-generating]

## v1.7.1
- Fixed an error caused with commas being replaced by periods introduced with custom currency functions

## v1.7.0
- Added double pricing module (Credit to Moudiz)
- Created basis for custom currencies
- Further fixed highlighting
- Fixed issues with thieve's dropped loot not always being picked up
- Added option to increase or lower income from employee perk on checkout
- Streamlined some older code and removed unused code
- Corrected some misc spelling errors

## v1.6.3
- Fixed some issues with highlighting (Credit to Damntry)

## v1.6.2
- Fixed some issues with one hit thiefs

## v1.6.1
- Removed always open doors (Is now part of the main game)

## v1.6.0
- Storage shelves now highlight aswell when holding a box with that product

## v1.5.1
- Fixed some issues with Save button

## v1.5.0
- Split employees checkout config into 3 separate ones
- Can now add products to shopping list when you press E while holding the Scanner
- Added Save Game button to the pause menu

### v1.4.0
- Added config to show fps counter (off by default)
- Added config to show ping (off by default)
- Re enabled One hit thiefs config

### v1.3.1
- Removed testing code

### v1.3.0
- Fixed scanner showing wrong product
- Updated to support the latest version
- Disabled One hit thiefs (until i can find a better solution)
- Added config for employees restock time per perk (lower = slower)
- Added config for employees checkout time per perk (lower = slower)
- Added config for customers gained per perk
- Extra employee & Employee speed config applies to newly added perks

### v1.2.0
- Added Faster Checkout to config. When enabled customers will place all items down on the checkout at once

### v1.1.3
- Fixed errors when looking at trash bins
- Right click to clear now works again (thanks Ika)

### v1.1.2
- Updated to August 19th patch
- Added ability to see product info when hovering boxes

### v1.1.1
- Added One hit thief config
- Better patching methods

### v1.1.0
- Added config for employees gained per perk & speed per perk

### v1.0.1
- Fixed doors closing

### v1.0.0
- Release