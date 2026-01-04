# 🎵 Spoti2MP3

![Version](https://img.shields.io/badge/version-1.0-blue.svg)
![.NET](https://img.shields.io/badge/.NET-Framework-purple.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)

**Spoti2MP3** is a simple, efficient, and user-friendly **Windows desktop application** for downloading music from Spotify.  
Built with **C# and WinForms**, it offers a clean, native Windows interface for managing and downloading your favorite tracks with ease.

---

## ✨ Features

### 🎯 Core Functionality
- 🔗 **Easy Track Addition** – Paste Spotify track URLs and instantly add them to the queue  
- 📦 **Batch Downloads** – Download multiple tracks sequentially with one click  
- 📊 **Real-time Progress Tracking** – Visual progress bar showing overall status  
- 🎨 **Clean Output** – Files saved as `Artist - Title.mp3`

### 🛠️ Management Features
- 🗑️ **Delete Tracks** – Remove selected tracks using the `Delete` key  
- 🔄 **Reset Queue** – Clear completed or failed downloads instantly  
- 📂 **Custom Download Path** – Choose where your music is saved  
- 💾 **Export Track Lists** – Save track lists as `.txt` files

### 🎛️ User Interface
- 🖥️ **Native Windows Look** – Clean and professional WinForms UI  
- 📑 **Organized Layout** – Clearly separated input, queue, and controls  
- ℹ️ **Live Status Updates** – Always know what the app is doing  

---

## 📋 Requirements

- **OS:** Windows 7 or later  
- **Framework:** .NET Framework 4.7.2 or higher  
- **Dependencies:**
  - `Newtonsoft.Json` (JSON parsing)
  - Active internet connection

---

## 🚀 Installation

### Option 1: Download Release
1. Download the latest release from the **Releases** page  
2. Extract the ZIP anywhere you like  
3. Run `SpotifyDownloader.exe`

### Option 2: Build from Source

```bash
git clone https://github.com/yourusername/spotify-downloader.git
```

1. Open the solution in **Visual Studio 2019+**
2. Install dependency:
   ```powershell
   Install-Package Newtonsoft.Json
   ```
3. Build the solution (`Ctrl + Shift + B`)
4. Run from Visual Studio or `bin/Release`

---

## 📖 How to Use

### ➕ Adding Tracks
1. Copy a Spotify track URL  
   - Example:
     ```
     https://open.spotify.com/track/1Ba0n7Acuz2lOEw1XBdMZP
     ```
2. Paste it into the **Spotify Track URL** field  
3. Click **Add Track**
4. Repeat as needed

### 📂 Set Download Location
1. Click **Browse…**
2. Select your preferred folder
3. All tracks will be saved there

### ⬇️ Downloading
- Click **Download All**
- Tracks progress through:
  `Ready → Downloading → Completed / Failed`

### 🧹 Managing the Queue
- **Delete:** Select tracks + `Delete`
- **Reset:** Clears completed/failed entries
- **Export:** `File → Export List…`

---

## 📁 File Naming

All files follow:
```
Artist - Title.mp3
```

Invalid filename characters are automatically sanitized.

---

## 🔧 Technical Overview

- **Language:** C#
- **UI:** Windows Forms
- **Framework:** .NET Framework 4.7.2+
- **Networking:** `HttpClient`
- **JSON:** `Newtonsoft.Json`

### API
Uses **RapidAPI Spotify Downloader API**:
- Fetches metadata
- Converts tracks to MP3
- Handles downloads

---

## ⚠️ Important Notes

### ⚖️ Legal Disclaimer
- For **educational & personal use only**
- You must own or have rights to downloaded content
- Respect local copyright laws
- Support artists via official platforms

### 🌐 API Limitations
- Rate limits may apply
- Availability varies by region
- Speed depends on API & internet

### 🔐 Privacy
- No data collection
- All processing is local

---

## 🐛 Troubleshooting

**Track info not found**
- Check internet
- Verify Spotify URL
- Track must be public

**Very small MP3 file**
- API error response
- Retry after a moment

**App won’t start**
- Install .NET 4.7.2+
- Try running as admin

---

## ⌨️ Keyboard Shortcuts

| Key | Action |
|----|-------|
| Delete | Remove selected tracks |

---

## 🤝 Contributing

1. Fork the repo  
2. Create a feature branch  
3. Commit changes  
4. Open a Pull Request  

Follow C# conventions and update docs when needed.

---

## 📝 Changelog

### v1.0.0 – 2025-01-04
- 🎉 Initial release
- ✅ Batch downloads
- ✅ Queue management
- ✅ Export functionality
- ✅ Progress tracking

---

## 📄 License

MIT License © 2025 Spoti2MP3

See `LICENSE` for full text.

---

## 🙏 Acknowledgments
- RapidAPI
- Newtonsoft.Json
- Microsoft
- Open-source community

---

## ⭐ Support
If you like this project:
- ⭐ Star it
- 🐛 Report bugs
- 💡 Suggest features
- 🤝 Contribute

Made with ❤️ for music lovers  
**Always support artists.**
