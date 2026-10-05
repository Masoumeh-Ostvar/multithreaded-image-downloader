# Multi-Threaded Image Downloader

A C# Windows Forms application for downloading multiple images concurrently using `BackgroundWorker` and a thread-safe `ConcurrentQueue`.

The application allows the user to select the number of background workers and measures how the execution time changes as the level of concurrency increases.

## Overview

The application reads image URLs from an `images.txt` file and places them into a shared `ConcurrentQueue`.

A configurable number of `BackgroundWorker` instances then process the queue concurrently. Each worker retrieves an image URL from the queue and downloads the corresponding image into the `SavedImages` directory.

The application also provides a progress bar and measures the total execution time after all workers have completed.

## Key Features

- Concurrent image downloading using multiple `BackgroundWorker` instances
- Thread-safe task distribution using `ConcurrentQueue`
- User-configurable number of workers
- Progress reporting through a Windows Forms UI
- Execution time measurement using `Stopwatch`
- Synchronization of worker completion using `lock`
- Automatic creation of the output directory
- Performance benchmarking with different numbers of workers
- Downloads images from URLs provided in a text file

## Architecture

The basic workflow of the application is:

```text
images.txt
    │
    ▼
ConcurrentQueue<string>
    │
    ├──────────────┬──────────────┬──────────────┐
    ▼              ▼              ▼              ▼
Worker 1       Worker 2       Worker 3       Worker N
    │              │              │              │
    ▼              ▼              ▼              ▼
WebClient       WebClient       WebClient       WebClient
    │              │              │              │
    └──────────────┴──────────────┴──────────────┘
                           │
                           ▼
                     SavedImages/
```

Each worker independently retrieves URLs from the shared queue using `TryDequeue()`. Since `ConcurrentQueue` is designed for concurrent access, multiple workers can safely consume tasks from the same queue.

## Concurrency

The number of workers is selected by the user through the application interface.

For example, if the user selects 8 workers, the application creates 8 `BackgroundWorker` instances and starts them concurrently.

Each worker executes the same download routine:

1. Retrieve an image URL from the shared queue.
2. Download the image using `WebClient`.
3. Save the image to the `SavedImages` directory.
4. Report progress to the UI.
5. Continue until the queue has been processed.

A `lock` is also used when updating the shared counter that tracks completed workers.

## Performance Benchmark

The project was tested with 117 image URLs using different numbers of workers.

| Number of Workers | Execution Time (seconds) |
| ----------------: | -----------------------: |
| 1 | 12.56 |
| 2 | 9.04 |
| 3 | 7.358 |
| 4 | 5.88 |
| 5 | 4.60 |
| 6 | 4.40 |
| 7 | 3.22 |
| 8 | 2.68 |
| 9 | 2.93 |
| 10 | 3.215 |
| 20 | 2.06 |
| 30 | 2.031 |
| 40 | 2.42 |
| 50 | 1.80 |

The results show that increasing the number of workers can significantly reduce execution time compared with a single worker. However, the improvement is not strictly linear. For example, the measured execution time increased when moving from 30 to 40 workers.

This demonstrates that increasing concurrency does not necessarily produce proportional performance improvements, as the overall performance can also be affected by network conditions, system resources, and concurrency overhead.

### Benchmark Result

The lowest measured execution time in this experiment was **1.80 seconds with 50 workers**.

All **117 images** in the test dataset were successfully downloaded.

## Technologies

- **C#**
- **.NET / Windows Forms**
- `BackgroundWorker`
- `ConcurrentQueue`
- `WebClient`
- `Stopwatch`
- Thread synchronization with `lock`

## Project Structure

```text
multi-threaded-image-downloader/
│
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
├── images.txt
├── SavedImages/
└── README.md
```

## Main Files

### `Form1.cs`

Contains the main application logic, including:

- Creating and managing background workers
- Managing the shared `ConcurrentQueue`
- Downloading images
- Reporting progress
- Measuring execution time
- Synchronizing worker completion

### `Form1.Designer.cs`

Contains the Windows Forms UI components and layout.

### `Program.cs`

Contains the application entry point and initializes the Windows Forms application.

### `images.txt`

Contains the image URLs used as input for the downloader.

### `SavedImages/`

The directory where downloaded images are stored.

## How It Works

1. The user specifies the number of workers.
2. The application reads URLs from `images.txt`.
3. URLs are inserted into a `ConcurrentQueue`.
4. The selected number of `BackgroundWorker` instances are created.
5. All workers start processing the shared queue.
6. Each worker downloads images using `WebClient`.
7. Progress is reported through the Windows Forms interface.
8. The application waits until all workers have completed.
9. The total execution time is displayed.

## Example

For 8 workers:

```text
User selects: 8 workers
        │
        ▼
Read image URLs
        │
        ▼
ConcurrentQueue
        │
        ├── Worker 1
        ├── Worker 2
        ├── Worker 3
        ├── Worker 4
        ├── Worker 5
        ├── Worker 6
        ├── Worker 7
        └── Worker 8
        │
        ▼
Download images
        │
        ▼
SavedImages/
```

## Limitations and Possible Improvements

The project was developed as a university assignment focused on multithreaded programming and concurrent task processing.

Possible improvements include:

- Replacing `WebClient` with the modern `HttpClient` API
- Adding explicit error logging for failed downloads
- Tracking successful and failed downloads separately
- Improving input validation for the number of workers
- Preventing multiple simultaneous runs from the UI
- Improving cancellation support
- Separating downloading, synchronization, and UI logic into dedicated classes
- Running repeated benchmark trials and reporting average execution times

## Learning Objectives

This project provided practical experience with:

- Multithreaded programming in C#
- Background workers
- Thread-safe data structures
- Concurrent task distribution
- Synchronization using `lock`
- UI updates from background operations
- Network-based file downloading
- Performance measurement and benchmarking
