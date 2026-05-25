using System;
using NAudio.Wave;

namespace StredoEvropskaFilmovaDatabaze.Services;

public class Audio
{
    public static Audio Instance = new Audio();
    
    private IWavePlayer? _waveOut;
    private AudioFileReader? _audioFile;
    
    public void Play(string cesta)
    {
        Stop();
        
        _audioFile = new AudioFileReader(cesta);

        _waveOut = new WaveOutEvent();
        
        _waveOut.Init(_audioFile);
        
        NastavHlasitost();
        
        _waveOut.Play();
    }

    public void Pause()
    {
        _waveOut?.Pause();
    }

    public void Resume()
    {
        _waveOut?.Play();
    }

    public void Stop()
    {
        _waveOut?.Stop();
        _waveOut?.Dispose();
        _audioFile?.Dispose();
    }
    
    public void NastavHlasitost()
    {
        if (_audioFile != null)
        {
            float hlasitost = Settings.Instance.Hlasitost / 100f;
            _audioFile.Volume = hlasitost;
        }
            
    }
}