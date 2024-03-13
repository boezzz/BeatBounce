using System;
using System.Collections;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RecordingScript : MonoBehaviour
{
    public AudioClip[] backgroundClips;

    // For recording
    public TextMeshProUGUI RecordButtonText;
    private bool isRecording = false;
    internal string FILENAME;
    private int outputRate;
    private int headerSize = 44; // default for uncompressed wav
    private String fileName;
    private FileStream fileStream;
    float[] tempDataSource;

    // For playback
    public AudioSource audioSource;
    public TextMeshProUGUI PlaybackButtonText;
    private AudioClip recordedClip;
    private bool isPlayingBack = false;

    void Awake()
    {
        outputRate = AudioSettings.outputSampleRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRecording = false;
        isPlayingBack = false;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlaybackButtonText.text = "Playback";
        }
    }

    // Play back the audio that was just recorded
    public void PlayAudio()
    {
        isPlayingBack = !isPlayingBack;

        if (isPlayingBack)
        {
            PlaybackButtonText.text = "Stop";

            if (recordedClip != null)
            {
                audioSource.clip = recordedClip;
                audioSource.Play();
            }
            else
            {
                // Load and play the recorded audio clip
                string filePath = fileName;
                recordedClip = LoadAudioClip(filePath);
                if (recordedClip != null)
                {
                    audioSource.clip = recordedClip;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogError("Failed to load recorded audio clip.");
                }
            }
        }
        else
        {
            PlaybackButtonText.text = "Playback";
            audioSource.Stop();
        }
    }

    // Load the audio clip from file
    private AudioClip LoadAudioClip(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Read all bytes from the file
            byte[] fileData = File.ReadAllBytes(filePath);
            float[] floatData = new float[fileData.Length / 2];
            for (int i = 0; i < floatData.Length; i++)
            {
                floatData[i] = BitConverter.ToInt16(fileData, i * 2) / 32768f; // Convert to range -1 to 1
            }

            // Create a new AudioClip
            AudioClip audioClip = AudioClip.Create("RecordedClip", floatData.Length / 2, 2, outputRate, false);

            // Set the audio clip data
            audioClip.SetData(floatData, 0);

            return audioClip;
        }
        else
        {
            Debug.LogError("File does not exist: " + filePath);
            return null;
        }
    }

    // Button click function
    public void OnRecord()
    {
        isRecording = !isRecording;

        if (isRecording)
        {
            audioSource.Stop();
            playRandomBackgroundClip();
            RecordButtonText.text = "Stop";
            record();
        }
        else
        {
            audioSource.Stop();
            Debug.Log("Recording stopped");
            RecordButtonText.text = "Record";
            saveRecording();
        }
    }

    private void playRandomBackgroundClip()
    {
        System.Random random = new System.Random();
        int randIndex = random.Next(0, backgroundClips.Length);
        audioSource.PlayOneShot(backgroundClips[randIndex]);
    }

    // Record in-game audio
    void record()
    {
        Debug.Log("Start recording");
        fileName = Path.Combine(Application.persistentDataPath, "recordedAudio.mp3");
        fileStream = new FileStream(fileName, FileMode.Create);

        var emptyByte = new byte();
        for (int i = 0; i < headerSize; i++) // Preparing the header
        {
            fileStream.WriteByte(emptyByte);
        }
    }

    // Save the recording
    void saveRecording()
    {
        WriteHeader();
    }

    // Override default Unity function for reading audio
    private void OnAudioFilterRead(float[] data, int channels)
    {
        if (isRecording)
        {
            ConvertAndWrite(data);
        }
    }

    // Generate initial bytes for .mp3 file
    private void ConvertAndWrite(float[] dataSource)
    {
        var intData = new Int16[dataSource.Length];
        // Converting in 2 steps : float[] to Int16[], then Int16[] to Byte[]
        var bytesData = new Byte[dataSource.Length * 2];
        // bytesData array is twice the size of
        // dataSource array because a float converted in Int16 is 2 bytes

        var rescaleFactor = 32767; // to convert float to Int16
        for (var i = 0; i < dataSource.Length; i++)
        {
            intData[i] = (Int16)(dataSource[i] * rescaleFactor);
            var byteArr = new Byte[2];
            byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }
        fileStream.Write(bytesData, 0, bytesData.Length);
        tempDataSource = new float[dataSource.Length];
        tempDataSource = dataSource;
    }

    // Convert bytes into different format for .mp3 file
    private void WriteHeader()
    {
        fileStream.Seek(0, SeekOrigin.Begin);
        var riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);

        var chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);

        var wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);

        var fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);

        var subChunk1 = BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);

        UInt16 two = 2;
        UInt16 one = 1;
        var audioFormat = BitConverter.GetBytes(one);
        fileStream.Write(audioFormat, 0, 2);

        var numChannels = BitConverter.GetBytes(two);
        fileStream.Write(numChannels, 0, 2);

        var sampleRate = BitConverter.GetBytes(outputRate);
        fileStream.Write(sampleRate, 0, 4);

        var byteRate = BitConverter.GetBytes(outputRate * 4);
        fileStream.Write(byteRate, 0, 4);

        UInt16 four = 4;
        var blockAlign = BitConverter.GetBytes(four);
        fileStream.Write(blockAlign, 0, 2);

        UInt16 sixteen = 16;
        var bitsPerSample = BitConverter.GetBytes(sixteen);
        fileStream.Write(bitsPerSample, 0, 2);

        var dataString = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(dataString, 0, 4);

        var subChunk2 = BitConverter.GetBytes(fileStream.Length - headerSize);
        fileStream.Write(subChunk2, 0, 4);

        fileStream.Close();
    }
}
