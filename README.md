# Production Test Task

## Overview
This project is a small production simulation where buildings convert resources through a fixed crafting chain.  
The player transports resources between buildings using a character with a limited backpack.

The task demonstrates:
- Production logic
- Resource flow
- Player interaction
- Clear visual feedback for production states

---

## Project Entry Point

### BootstrapScene
The game is started from **`BootstrapScene`**.

This scene is responsible for:
- Initializing core services
- Creating and wiring game systems
- Loading the main gameplay scene

> Please make sure to run the project from `BootstrapScene`.

---

## Core Systems

### Producers
- Each producer works using a **Recipe** (inputs → output + craft time)
- Production stops when:
  - Required input resources are missing
  - Output storage is full
- Stop reasons are displayed **in-world** via UI messages

---

### Warehouses
- Each warehouse stores **one resource type**
- Storage capacity is limited
- Used both for producer input/output and player interaction

---

### Resource Transfer
- All resource movement is **visualized**
- Resources are transferred using linear interpolation:
  - Producer → Warehouse
  - Warehouse → Player backpack
  - Player backpack → Warehouse
- Resource count increases **only after the transfer animation completes**

---

### Player & Backpack
- Player movement is controlled via a virtual joystick
- Backpack features:
  - Limited capacity
  - Can store only one resource type at a time
  - Resource type resets when backpack becomes empty

---

### UI
- Production stop messages are displayed on a shared Canvas
- UI elements track markers' world positions

---

## Architecture Notes
- Core gameplay logic is implemented in **plain C# model classes**
- MonoBehaviours are used for:
  - Initialization and wiring
  - Input handling
  - Animations
  - Visual representation
- Folder structure is **generalized** for easy navigation within the scope of the test task

---

## Assumptions
- Production schemes are predefined and validated at initialization
- The player cannot break production logic
- One resource type per warehouse and backpack

---

## How to Run
1. Open the project in Unity
2. Open **`BootstrapScene`**
3. Press **Play**
4. Move the player and transport resources between buildings

---

## Notes
This project prioritizes **clarity, correctness, and visual feedback** over extensibility beyond the test task requirements.
