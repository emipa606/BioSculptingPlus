# GitHub Copilot Instructions for BioSculptingPlus Mod

## Mod Overview and Purpose
The **BioSculptingPlus** mod is a C# mod for the game RimWorld, designed to enhance the functionality and versatility of the Biosculpter Pods introduced in the game. It offers players the ability to customize and optimize their gameplay experience by adjusting various pod cycles for their colonists.

## Key Features and Systems
- **Custom Biosculpting Cycles**: The mod introduces various new cycles for the Biosculpter Pod, each with unique properties.
  - **Age Increase Cycle**: Adjusts the age of the colonist.
  - **Beauty Cycle**: Enhances the beauty of the colonist.
  - **Immunity Cycle**: Boosts the colonist's immunity.
  - **Tough Cycle**: Increases the toughness of the colonist.
  - **Voice Cycle**: Modifies the colonist's voice attributes.
- **Cycle Settings Customization**: Allows players to tweak settings such as potency, duration, and enable/disable cycle options.
- **Settings Management**: The mod provides a user-friendly settings interface to apply and save settings within the game.

## Coding Patterns and Conventions
- **Class Structure**: Each cycle and corresponding properties are defined in separate classes inheriting from base classes to maintain a clean project structure.
- **Mod-Typed Classes**: Classes like `BioSculptingPlusMod` and `BioSculptingPlusSettings` use the RimWorld's `Mod` and `ModSettings` as base classes, leveraging inheritance to integrate easily.
  
## XML Integration
While the project summary does not specify explicit XML files, XML can be used in RimWorld mods primarily for defining game assets such as items, recipes, and patches. You might want to use XML to define additional game data or update game files accordingly.

## Harmony Patching
The mod likely uses Harmony for runtime patching to modify or enhance existing game mechanics:
- **PatchOperationCheckSettings**: A class designed for checking settings dynamically, indicating possible areas where Harmony patches could be implemented to alter game behaviors based on configuration.

## Suggestions for Copilot
- Ensure correct inheritance and object-oriented practices while suggesting new methods or classes.
- Offer XML snippet suggestions for asset definitions or for additional patch operations.
- Use consistent naming conventions that align with existing class names and methods.
- Suggest how Harmony patches can be set up for dynamically changing game logic.
- Prioritize methods that allow user interaction and provide concise documentation comments to guide users on the purpose of the methods.

### Additional Suggestions
- Code readability is crucial for mod maintainability; Copilot could help in ensuring understandable and clear code styles.
- Consider security when suggesting any network or file operations; avoid exposing sensitive data inadvertently.
- Always suggest testing new features in a controlled environment before release to avoid game-breaking issues. 

By adhering to these guidelines, you can effectively leverage GitHub Copilot for developing and maintaining the BioSculptingPlus mod, enhancing RimWorld's gameplay experience.
