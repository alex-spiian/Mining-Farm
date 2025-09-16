# 🪙 Mining Farm - Modular Idle Clicker Prototype

This project is a **Unity-based prototype** of an incremental/idle game where the player builds a mining farm and earns currency through mining machines.  
The main purpose of the project is to demonstrate **scalable modular architecture**, integration of modern Unity tools, and clean code practices.

---

##  How to Run
- Open the project in Unity 6000.0.53f1.
- Set the Login scene as the first scene.
- Run the game from the Login scene.

---

## ✨ Features

- **Login & Player Data**
  - Player profile is created on first launch or loaded from local storage (`PlayerPrefs`).
  - Data persistence via custom save/load services.

- **Wallet System**
  - Tracks player’s currency balance.
  - Integrated with mining machines to add rewards automatically.

- **Mining Machines**
  - Default machines are spawned on the game field at the start.
  - Machines generate currency automatically over time.
  - Each machine displays:
    - Name
    - Income per cycle
    - Progress bar

- **Game Field**
  - Contains slots for mining machines.
  - Default: 2 machines + 2 empty slots (expandable).
  - Empty slots are interactable (shop will be connected here later).

- **Modular Architecture**
  - Zenject is used for dependency injection and module management.
  - Each system is separated into **Logic**, **Bridge**, and **UI** layers.

- **Asynchronous Workflow**
  - UniTask is used for async operations (loading, initialization, etc.).

- **Custom Logger**
  - Centralized logging for debugging and development.

---

## 🛠️ Tech Stack

- **Engine**: Unity 6000.0.53f1
- **Language**: C#
- **Frameworks**: 
  - [Zenject] (Dependency Injection)
  - [UniTask] (Async/await in Unity)
- **Data Storage**: PlayerPrefs (local persistence)

---

## 🎮 Current State

- ✅ Login flow (create/load player data)  
- ✅ Game scene with wallet display  
- ✅ Mining machines spawn with income & progress visualization  
- ✅ Game field with default and empty slots  
- ✅ Modular, extendable architecture in place  

**Next Steps (Planned):**
- Shop system for purchasing new mining machines  
- Upgrade mechanics for machines  
- Integration of remote config, analytics, ads, and IAP  
- More locations & progression system  

---

## 🚀 Purpose

This project is not a finished game, but rather a **technical demo** built within a short timeframe.  
The main goals:  
- Showcase **architecture design skills** in Unity.  
- Provide a solid foundation for scaling features (shop, IAP, analytics, etc.).  
- Demonstrate **clean, testable, and maintainable code** with modern Unity practices.
