using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SpotifyDownloader
{
    public partial class Form1 : Form
    {
        private const string API_KEY = "b91efa9e98msh0740daeb9ec4c30p1d892ejsn03745f6b17e0";
        private const string API_HOST = "spotify-downloader12.p.rapidapi.com";
        private readonly HttpClient client;
        private readonly List<TrackItem> tracks;
        private bool isBulkDownloading = false;
        private string downloadPath;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            tracks = new List<TrackItem>();

            // Set default download path to Downloads folder
            downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            txtDownloadPath.Text = downloadPath;
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            string url = txtSpotifyUrl.Text.Trim();

            if (string.IsNullOrEmpty(url) || !url.Contains("open.spotify.com"))
            {
                MessageBox.Show("Please enter a valid Spotify URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnCheck.Enabled = false;
            btnCheck.Text = "Adding...";
            lblOverallStatus.Text = "Fetching track information...";

            try
            {
                var trackInfo = await GetTrackInfo(url);

                if (trackInfo != null)
                {
                    // Check if track already exists
                    if (tracks.Any(t => t.SpotifyUrl == url))
                    {
                        MessageBox.Show("This track is already in the list.", "Duplicate Track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        AddTrackToList(trackInfo);
                        lblOverallStatus.Text = $"Track added: {trackInfo.TrackName}";
                        txtSpotifyUrl.Clear();

                        if (tracks.Count > 0)
                        {
                            btnDownloadAll.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Could not retrieve track information. Please check the URL and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblOverallStatus.Text = "Failed to fetch track information.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblOverallStatus.Text = "Error occurred.";
            }
            finally
            {
                btnCheck.Enabled = true;
                btnCheck.Text = "Add Track";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select download folder";
                folderDialog.SelectedPath = downloadPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    downloadPath = folderDialog.SelectedPath;
                    txtDownloadPath.Text = downloadPath;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear completed or failed tracks
            var toRemove = tracks.Where(t => t.Status == "Completed" || t.Status == "Failed").ToList();

            foreach (var track in toRemove)
            {
                tracks.Remove(track);
                var item = listViewTracks.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag == track);
                if (item != null)
                {
                    listViewTracks.Items.Remove(item);
                }
            }

            // Reset progress bar and status
            progressBarOverall.Value = 0;
            lblOverallStatus.Text = "Ready";

            // Update Download All button state
            btnDownloadAll.Enabled = tracks.Any(t => t.Status == "Ready");
        }

        private void listViewTracks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewTracks.SelectedItems.Count > 0)
            {
                if (isBulkDownloading)
                {
                    MessageBox.Show("Cannot remove tracks while downloading.", "Operation in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedItems = listViewTracks.SelectedItems.Cast<ListViewItem>().ToList();

                foreach (var item in selectedItems)
                {
                    var track = item.Tag as TrackItem;
                    if (track != null)
                    {
                        tracks.Remove(track);
                    }
                    listViewTracks.Items.Remove(item);
                }

                lblOverallStatus.Text = $"Removed {selectedItems.Count} track(s)";
                btnDownloadAll.Enabled = tracks.Any(t => t.Status == "Ready");
            }
        }

        private void exportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tracks.Count == 0)
            {
                MessageBox.Show("No tracks to export.", "Export List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = "spotify_tracks.txt";
                saveDialog.Title = "Export Track List";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("Spotify Track List");
                        sb.AppendLine("==================");
                        sb.AppendLine();

                        foreach (var track in tracks)
                        {
                            sb.AppendLine($"Artist: {track.Artist}");
                            sb.AppendLine($"Title: {track.TrackName}");
                            sb.AppendLine($"URL: {track.SpotifyUrl}");
                            sb.AppendLine($"Status: {track.Status}");
                            sb.AppendLine();
                        }

                        File.WriteAllText(saveDialog.FileName, sb.ToString());
                        MessageBox.Show($"Track list exported successfully to:\n{saveDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to export track list:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBulkDownloading)
            {
                var result = MessageBox.Show("Downloads are in progress. Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutMessage = "Spoti2MP3 v1.0\n\n" +
                                "A simple and efficient tool for downloading music from Spotify.\n\n" +
                                "Features:\n" +
                                "• Add multiple tracks to download queue\n" +
                                "• Batch download\n" +
                                "• Export track lists\n" +
                                "• Simple and intuitive interface\n\n" +
                                "Files are saved in 'Artist - Title.mp3'\n\n" +
                                "© 2025 Spoti2MP3";

            MessageBox.Show(aboutMessage, "About Spotify Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<TrackInfo> GetTrackInfo(string spotifyUrl)
        {
            try
            {
                var encodedUrl = Uri.EscapeDataString(spotifyUrl);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://{API_HOST}/Gettrack?spotify_url={encodedUrl}"),
                    Headers =
                    {
                        { "x-rapidapi-key", API_KEY },
                        { "x-rapidapi-host", API_HOST },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    var json = JObject.Parse(body);

                    // Parse the response based on API structure
                    string trackName = json["title"]?.ToString() ?? json["name"]?.ToString() ?? "Unknown Track";
                    string artist = json["artist"]?.ToString() ?? json["artists"]?[0]?["name"]?.ToString() ?? "Unknown Artist";

                    return new TrackInfo
                    {
                        TrackName = trackName,
                        Artist = artist,
                        SpotifyUrl = spotifyUrl
                    };
                }
            }
            catch
            {
                return null;
            }
        }

        private void AddTrackToList(TrackInfo info)
        {
            var trackItem = new TrackItem
            {
                TrackName = info.TrackName,
                Artist = info.Artist,
                SpotifyUrl = info.SpotifyUrl,
                Status = "Ready"
            };

            tracks.Add(trackItem);

            var item = new ListViewItem(trackItem.TrackName);
            item.SubItems.Add(trackItem.Artist);
            item.SubItems.Add("Ready");
            item.Tag = trackItem;

            listViewTracks.Items.Add(item);
        }

        private async void btnDownloadAll_Click(object sender, EventArgs e)
        {
            if (tracks.Count == 0 || isBulkDownloading) return;

            var readyTracks = tracks.Where(t => t.Status == "Ready").ToList();
            if (readyTracks.Count == 0)
            {
                MessageBox.Show("No tracks ready to download.", "Nothing to Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isBulkDownloading = true;
            btnDownloadAll.Enabled = false;
            btnCheck.Enabled = false;
            progressBarOverall.Value = 0;
            progressBarOverall.Maximum = readyTracks.Count;
            lblOverallStatus.Text = $"Starting download of {readyTracks.Count} track(s)...";

            int completed = 0;
            foreach (var track in readyTracks)
            {
                await DownloadTrack(track);
                completed++;
                progressBarOverall.Value = completed;
                lblOverallStatus.Text = $"Downloaded {completed} of {readyTracks.Count} track(s)";
                await Task.Delay(500); // Small delay between downloads
            }

            isBulkDownloading = false;
            btnCheck.Enabled = true;
            btnDownloadAll.Enabled = tracks.Any(t => t.Status == "Ready");
            lblOverallStatus.Text = $"All downloads completed! ({completed} track(s))";
        }

        private async Task DownloadTrack(TrackItem track)
        {
            var item = listViewTracks.Items.Cast<ListViewItem>()
                .FirstOrDefault(i => i.Tag == track);

            if (item == null) return;

            track.Status = "Downloading";
            UpdateUI(() =>
            {
                if (item.Index >= 0 && item.Index < listViewTracks.Items.Count)
                {
                    item.SubItems[2].Text = "Downloading...";
                }
            });

            try
            {
                var encodedUrl = Uri.EscapeDataString(track.SpotifyUrl);

                // First, call the convert API to initiate the conversion
                var convertRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"https://{API_HOST}/convert?urls={encodedUrl}"),
                    Headers =
                    {
                        { "x-rapidapi-key", API_KEY },
                        { "x-rapidapi-host", API_HOST },
                    },
                    Content = new StringContent("{}")
                    {
                        Headers =
                        {
                            ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                        }
                    }
                };

                string downloadUrl = null;

                using (var convertResponse = await client.SendAsync(convertRequest))
                {
                    convertResponse.EnsureSuccessStatusCode();
                    var convertBody = await convertResponse.Content.ReadAsStringAsync();

                    // Parse the response to get the download URL
                    var json = JObject.Parse(convertBody);

                    // Try different possible JSON structures
                    downloadUrl = json["download_url"]?.ToString()
                               ?? json["downloadUrl"]?.ToString()
                               ?? json["url"]?.ToString()
                               ?? json["data"]?["download_url"]?.ToString()
                               ?? json["data"]?["url"]?.ToString()
                               ?? json["result"]?["download_url"]?.ToString();

                    if (string.IsNullOrEmpty(downloadUrl))
                    {
                        // If no direct download URL, check if the response itself is a download link
                        if (convertBody.StartsWith("http"))
                        {
                            downloadUrl = convertBody.Trim();
                        }
                        else
                        {
                            throw new Exception("Download URL not found in response. Response: " + convertBody);
                        }
                    }
                }

                // Now download the actual file from the URL
                using (var downloadRequest = new HttpRequestMessage(HttpMethod.Get, downloadUrl))
                using (var downloadResponse = await client.SendAsync(downloadRequest, HttpCompletionOption.ResponseHeadersRead))
                {
                    downloadResponse.EnsureSuccessStatusCode();

                    var buffer = new byte[8192];
                    var totalBytesRead = 0L;

                    // Clean filename - use Artist - Title.mp3 format
                    string fileName = $"{track.Artist} - {track.TrackName}.mp3"
                        .Replace("\"", "")
                        .Replace("/", "-")
                        .Replace("\\", "-")
                        .Replace(":", "-")
                        .Replace("*", "")
                        .Replace("?", "")
                        .Replace("<", "")
                        .Replace(">", "")
                        .Replace("|", "");

                    string filePath = Path.Combine(downloadPath, fileName);

                    using (var contentStream = await downloadResponse.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        int bytesRead;
                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;
                        }
                    }

                    // Verify file size
                    var fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length < 10000) // Less than 10KB is suspicious
                    {
                        throw new Exception($"Downloaded file is too small ({fileInfo.Length} bytes). This might not be the actual audio file.");
                    }

                    // Remove all metadata from MP3 file
                    RemoveAllMP3Metadata(filePath);

                    track.Status = "Completed";
                    UpdateUI(() =>
                    {
                        if (item.Index >= 0 && item.Index < listViewTracks.Items.Count)
                        {
                            item.SubItems[2].Text = "Completed";
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                track.Status = "Failed";
                UpdateUI(() =>
                {
                    if (item.Index >= 0 && item.Index < listViewTracks.Items.Count)
                    {
                        item.SubItems[2].Text = "Failed";
                    }
                });
                MessageBox.Show($"Download failed for {track.TrackName}:\n\n{ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveAllMP3Metadata(string filePath)
        {
            try
            {
                // Read the entire file
                byte[] fileBytes = File.ReadAllBytes(filePath);
                int startOfAudio = 0;
                int endOfAudio = fileBytes.Length;

                // Remove ID3v2 tag from the beginning (if present)
                if (fileBytes.Length > 10 && fileBytes[0] == 0x49 && fileBytes[1] == 0x44 && fileBytes[2] == 0x33) // "ID3"
                {
                    // ID3v2 header is 10 bytes
                    // Size is stored in bytes 6-9 as a synchsafe integer (7 bits per byte)
                    int tagSize = ((fileBytes[6] & 0x7F) << 21) |
                                  ((fileBytes[7] & 0x7F) << 14) |
                                  ((fileBytes[8] & 0x7F) << 7) |
                                  (fileBytes[9] & 0x7F);

                    // Add 10 bytes for the header itself
                    tagSize += 10;

                    // Check for footer (ID3v2.4)
                    if (fileBytes.Length > tagSize && (fileBytes[5] & 0x10) != 0)
                    {
                        tagSize += 10; // Footer is also 10 bytes
                    }

                    startOfAudio = tagSize;
                }

                // Remove ID3v1 tag from the end (if present)
                if (fileBytes.Length > 128)
                {
                    int id3v1Pos = fileBytes.Length - 128;
                    if (fileBytes[id3v1Pos] == 0x54 && fileBytes[id3v1Pos + 1] == 0x41 && fileBytes[id3v1Pos + 2] == 0x47) // "TAG"
                    {
                        endOfAudio = id3v1Pos;
                    }
                }

                // Remove APEv2 tag from the end (if present, often contains album art)
                if (endOfAudio > 32)
                {
                    int apePos = endOfAudio - 32;
                    if (fileBytes[apePos] == 0x41 && fileBytes[apePos + 1] == 0x50 &&
                        fileBytes[apePos + 2] == 0x45 && fileBytes[apePos + 3] == 0x54 &&
                        fileBytes[apePos + 4] == 0x41 && fileBytes[apePos + 5] == 0x47 &&
                        fileBytes[apePos + 6] == 0x45 && fileBytes[apePos + 7] == 0x58) // "APETAGEX"
                    {
                        // APE tag size is in bytes 12-15 (little-endian)
                        int apeSize = BitConverter.ToInt32(fileBytes, apePos + 12);
                        endOfAudio = apePos - apeSize + 32;
                    }
                }

                // Check for Lyrics3v2 tag (another metadata format)
                if (endOfAudio > 15)
                {
                    int lyrics3Pos = endOfAudio - 15;
                    if (fileBytes[lyrics3Pos] == 0x4C && fileBytes[lyrics3Pos + 1] == 0x59 &&
                        fileBytes[lyrics3Pos + 2] == 0x52 && fileBytes[lyrics3Pos + 3] == 0x49 &&
                        fileBytes[lyrics3Pos + 4] == 0x43 && fileBytes[lyrics3Pos + 5] == 0x53 &&
                        fileBytes[lyrics3Pos + 6] == 0x32 && fileBytes[lyrics3Pos + 7] == 0x30 &&
                        fileBytes[lyrics3Pos + 8] == 0x30) // "LYRICS200"
                    {
                        // Size is stored 6 bytes before "LYRICS200"
                        string sizeStr = System.Text.Encoding.ASCII.GetString(fileBytes, lyrics3Pos - 6, 6);
                        if (int.TryParse(sizeStr, out int lyrics3Size))
                        {
                            endOfAudio = lyrics3Pos - 6 - lyrics3Size;
                        }
                    }
                }

                // Extract only the audio data (between start and end markers)
                int audioLength = endOfAudio - startOfAudio;
                if (audioLength > 0 && audioLength < fileBytes.Length)
                {
                    byte[] cleanedBytes = new byte[audioLength];
                    Array.Copy(fileBytes, startOfAudio, cleanedBytes, 0, audioLength);

                    // Write the cleaned file back
                    File.WriteAllBytes(filePath, cleanedBytes);
                }
            }
            catch (Exception ex)
            {
                // If metadata removal fails, log it but don't fail the whole download
                Console.WriteLine($"Failed to remove metadata: {ex.Message}");
            }
        }

        private void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            client?.Dispose();
            base.OnFormClosing(e);
        }
    }

    public class TrackInfo
    {
        public string TrackName { get; set; }
        public string Artist { get; set; }
        public string SpotifyUrl { get; set; }
    }

    public class TrackItem
    {
        public string TrackName { get; set; }
        public string Artist { get; set; }
        public string SpotifyUrl { get; set; }
        public string Status { get; set; } // Ready, Downloading, Completed, Failed
    }
}