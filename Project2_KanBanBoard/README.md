
---

## 📋 Features

- Full-screen Kanban Board interface in the Console.
- Three columns: **To Do**, **In Progress**, **Done**.
- Each column can hold a maximum of **10 tasks**.
- Tasks consist of:
  - **Task ID** (short description)
  - **Task Description** (detailed info)
- Control via **Function Keys**:
  - `F1` ➔ Add a Task to **To Do**
  - `F5` ➔ Move a Task from **To Do** to **In Progress**
  - `F6` ➔ Move a Task from **In Progress** to **Done**
  - `F7` ➔ Save the board to a JSON file and Exit
- Supports:
  - Creating a **new Kanban Board**.
  - Loading an **existing Kanban Board** from a JSON file.
  - Saving tasks to a file when exiting.

---

## 🛠 Requirements

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) (for JSON serialization)

  Install with:
  ```bash
  dotnet add package Newtonsoft.Json
