# EA_Burning_Sky_Test
This is technical test by EA

Credits 
  - Art : Jeel Gajera(My Friend)

Approach to Development
  - Understand requirement
  - Break full game in modules
  - Separate data and functionalities
  - Create database for data required
  - Decide designs to implement modules
  - Implement (break module in smaller tasks for each module)

Designs Used for Modules
  - State pattern(Reusable) for GameState management
  - Object pooling(Reusable)
  - Observer pattern(Reusable) for Ui and gameplay communication
  - Strategy pattern where different algorithms required. Ex. Enemy movements, Power effects, State behaviours, Fleet Creation
  - Singleton pattern for global access of managers Ex. GameplayManager, UiManager(A generic singleton class - Reusable) 
  - Commands to remove dependency and make code modular(Commands implementation might be dependent)
  - Injecting Dependency classes from out side to make user class only dependent on interface Ex. Ui classes, Enemy Movement
  - Composition of interface to apply Damage and power. Ex. Abstraction using IDamagable, IPowerEffector and IComponentsGenerator and composition in other classes. So only specific function is composited not full class.
  - Tried to keep Single Responsibility to class



