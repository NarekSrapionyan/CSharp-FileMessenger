# CSharp File Messenger 💬🔄

A C# console application demonstrating real-time communication between two independent console applications using a shared text file.

The solution consists of two applications:

* **WriterApp** – writes text to a shared file.
* **ReaderApp** – continuously reads newly written text from the same file.

---

## Features

### WriterApp

* Auto Flush mode
* Manual Flush mode
* Buffered writing using `StringBuilder`
* `/flush` command (Manual mode only)
* `/exit` command

### ReaderApp

* Continuously monitors the shared file
* Reads newly written text
* Displays new messages in real time

---

## Project Structure

```text
CSharp-FileMessenger/
│
├── CSharp-FileMessenger.sln
│
├── WriterApp/
│   ├── Program.cs
│   └── WriterApp.csproj
│
├── ReaderApp/
│   ├── Program.cs
│   └── ReaderApp.csproj
│
├── README.md
└── .gitignore
```

---

## Technologies

* C#
* .NET
* Console Applications
* File I/O
* FileStream
* StreamWriter
* StreamReader
* StringBuilder

---

## Writer Modes

### Auto Flush

Each entered line is immediately written to the shared file.

Example:

```text
Enter text: Hello
Text written to file.

Enter text: How are you?
Text written to file.
```

### Manual Flush

Entered text is stored in memory until the user executes the `/flush` command.

Example:

```text
Enter text: Hello
Text added to buffer.

Enter text: How are you?
Text added to buffer.

Enter text: /flush
Buffer written to file.
```

---

## Commands

| Command  | Description                                         |
| -------- | --------------------------------------------------- |
| `/flush` | Writes buffered text to the file (Manual mode only) |
| `/exit`  | Stops the application                               |

---

## Getting Started

Clone the repository:

```bash
git clone https://github.com/NarekSrapionyan/CSharp-FileMessenger.git
```

Open the solution:

```text
CSharp-FileMessenger.sln
```

Run **WriterApp** and **ReaderApp** in separate console windows.

The Writer application writes messages to the shared file, while the Reader application continuously reads and displays newly written messages.

---

## Example

**WriterApp**

```text
Please select mode:
1 - Auto Flush
2 - Manual Flush

Enter text: Hello
Text written to file.
```

**ReaderApp**

```text
Hello
```


