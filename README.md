# Crowdrun

### Description

Clone of the [Count Masters](https://play.google.com/store/apps/details?id=freeplay.crowdrun.com&hl=ru&gl=US).

### Implemented features:
- Running crowd (root-motion).
- Crowd control with input (in editor and on device).
- Gates power-ups.
- Special effects (particles and sounds).
- Finish level animation (differs from reference).
- Crowd counter.
- Coins counter.
- Finish screen.
- Save progress and coins between sessions.
- 3 different levels.
- Adaptive UI.

### Missing features:
- No obstacles.
- No enemy crowds.
- No haptics (vibration).
- No boss at the end of the level.
- No multiplier animation at the end of the level (multiplication stairs).
- No reward at the end of the level (chest).
- No object pooling (performance).

### Known bugs:
- Increasing the crowd at the edge of the platform causes some characters to go outside the platform, and then at the first next input, the entire crowd is instantly teleported to the platform. Easy fix.
- Very large crowd causes bugs with input and does not fit in the platform. Easy fix.

### Possible improvements:
- Implement missing features. Most important are obstacles and enemy crowds.
- Add noise in the animation of characters (fix the fact that they run all with the same animation and on the same trajectory).
- Make saving progress between sessions a little bit earlier to prevent possible loss of progress data. Saving only takes place after the end of the coin accrual animation, but this data can be saved a little earlier. Not critical
- Use DI to improve maintainability.
- Add pooling of different objects (characters, special effects, etc) to improve performance.