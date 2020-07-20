using DevExpress.Mvvm;
using ID3_Tag_Editor.Logic;
using ID3_Tag_Editor.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace ID3_Tag_Editor.ViewModels
{
    public class Main_ViewModel : ViewModelBase
    {
        /// For Unit Testing:
        /// If this is activated, the files for unit testing will
        /// automatically be selected
        public static bool testMode = false;


        #region Properties

        public TaggingLogic Logic { get; }
        private ObservableCollection<MusicFileTag> _musicFileTags;
        private MusicFileTag _selectedFile;
        private int _numberOfFiles = 0;
        public ObservableCollection<string> AllGenres { get; }
        public ObservableCollection<string> AllLanguages { get; }
        public ObservableCollection<string> AllMoods { get; }
        public ObservableCollection<string> AllVersions { get; }
        public ObservableCollection<string> AllKeys { get; }
        public ICommand AddFileCommand { get; }
        public ICommand RemoveFileCommand { get; }
        public ICommand SaveFileTagsCommand { get; }
        public ICommand SaveAllFilesCommand { get; }
        public ICommand CopyfromV1Command { get; }
        public ICommand CopyfromV2Command { get; }
        public ICommand CreatePlaylistCommand { get; }
        public ICommand LoadPlaylistCommand { get; }
        public ICommand InfoCommand { get; }

        #endregion


        #region Getter and Setter

        public MusicFileTag SelectedFile
        {
            get { return _selectedFile; }
            set { SetProperty(ref _selectedFile, value, () => SelectedFile); }
        }
        public ObservableCollection<MusicFileTag> MusicFileTags
        {
            get { return _musicFileTags; }
            set { SetProperty(ref _musicFileTags, value, () => MusicFileTags); }
        }

        public int NumberOfFiles
        {
            get { return MusicFileTags.Count; }
            set { SetProperty(ref _numberOfFiles, value, () => NumberOfFiles); }
        }

        #endregion



        public Main_ViewModel(bool _testMode = false)
        {
            testMode = _testMode;

            MusicFileTags = new ObservableCollection<MusicFileTag>();
            Logic = new TaggingLogic();
            AllGenres = new ObservableCollection<string>(ComboboxCollections.AllGenres);
            AllLanguages = new ObservableCollection<string>(ComboboxCollections.AllLanguages);
            AllMoods = new ObservableCollection<string>(ComboboxCollections.AllMoods);
            AllVersions = new ObservableCollection<string>(ComboboxCollections.AllVersions);
            AllKeys = new ObservableCollection<string>(ComboboxCollections.AllKeys);

            // Commands
            AddFileCommand = new DelegateCommand(AddFile);
            SaveFileTagsCommand = new DelegateCommand(SaveFileTags);
            SaveAllFilesCommand = new DelegateCommand(SaveAllFiles);
            RemoveFileCommand = new DelegateCommand(RemoveFile);
            CopyfromV1Command = new DelegateCommand(CopyfromV1);
            CopyfromV2Command = new DelegateCommand(CopyfromV2);
            CreatePlaylistCommand = new DelegateCommand(CreatePlaylist);
            LoadPlaylistCommand = new DelegateCommand(LoadPlaylist);
            InfoCommand = new DelegateCommand(OpenGitHubWebsite);
        }




        #region Add and Remove File

        private void AddFile()
        {
            string filePath = testMode ?
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../File Examples/file_example_1.mp3")) :
                GetFilePath_OpenDialog("mp3");
            if (filePath != null && File.Exists(filePath) && !BasicFunctions.FileInUse(filePath))
            {
                // check if File is already in list
                bool FileIsInList = false;
                foreach (MusicFileTag FileInList in MusicFileTags)
                {
                    if (FileInList.FilePath == filePath)
                    {
                        FileIsInList = true;
                        MessageBox.Show("This file is already in the list");
                    }
                }
                if (!FileIsInList)
                {
                    MusicFileTag newFile = TaggingLogic.AddFile(filePath);
                    MusicFileTags.Add(newFile);
                    NumberOfFiles++;
                }
            }
        }

        private void RemoveFile()
        {
            MusicFileTags.Remove(SelectedFile);
            NumberOfFiles--;
        }

        #endregion


        #region Copy From

        private void CopyfromV1()
        {
            if (SelectedFile != null)
            {
                SelectedFile.TrackV1 = SelectedFile.TrackNumberV2;
                SelectedFile.TitleV1 = SelectedFile.TitleV2;
                SelectedFile.ArtistV1 = SelectedFile.ArtistV2;
                SelectedFile.AlbumV1 = SelectedFile.AlbumV2;
                SelectedFile.GenreV1 = SelectedFile.GenreV2;
            }
        }

        private void CopyfromV2()
        {
            if (SelectedFile != null)
            {
                SelectedFile.TrackNumberV2 = SelectedFile.TrackV1;
                SelectedFile.TitleV2 = SelectedFile.TitleV1;
                SelectedFile.ArtistV2 = SelectedFile.ArtistV1;
                SelectedFile.AlbumV2 = SelectedFile.AlbumV1;
                SelectedFile.GenreV2 = SelectedFile.GenreV1;
            }
        }

        #endregion


        #region Saving (Tags and Files)

        private void SaveFileTags()
        {
            Logic.SaveTagToFile(SelectedFile);
        }

        private void SaveAllFiles()
        {
            foreach (var MusicFile in MusicFileTags)
            {
                Logic.SaveTagToFile(MusicFile);
            }
        }

        #endregion


        #region Playlist

        private void CreatePlaylist()
        {
            string playlistPath = testMode ? @"../../../File Examples/My Playlist.m3u" : GetFilePath_SaveDialog("My Playlist", "m3u");

            if (playlistPath != null)
            {
                Logic.CreatePlaylist(MusicFileTags, playlistPath);
            }
        }

        private void LoadPlaylist()
        {
            string playlistPath = testMode ? @"../../../File Examples/My Playlist.m3u" : GetFilePath_OpenDialog("m3u");

            if (playlistPath != null && !BasicFunctions.FileInUse(playlistPath))
            {
                MusicFileTags = Logic.LoadPlaylist(playlistPath);
            }

            NumberOfFiles = MusicFileTags.Count;
        }

        #endregion


        #region Dialogues

        public static string GetFilePath_SaveDialog(string FileNameSuggestion, string fileExtension)
        {
            SaveFileDialog savefile = new SaveFileDialog();

            switch (fileExtension.ToLower())
            {
                case "m3u":
                    savefile.FileName = FileNameSuggestion + ".m3u";
                    savefile.Filter = "M3U file (*.m3u)|*.m3u";
                    break;
                default:
                    return null;
            }

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                Path.GetFullPath(savefile.FileName);
            }

            try
            {
                return Path.GetFullPath(savefile.FileName);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }


        public static string GetFilePath_OpenDialog(string fileExtension)
        {
            OpenFileDialog savefile = new OpenFileDialog();

            switch (fileExtension.ToLower())
            {
                case "mp3":
                    savefile.DefaultExt = "mp3";
                    savefile.Filter = "MP3 files (*.mp3)|*.mp3";
                    break;
                case "m3u":
                    savefile.DefaultExt = ".m3u";
                    savefile.Filter = "M3U file (*.m3u)|*.m3u";
                    break;
                case "all":
                    savefile.Filter = "All files (*.*)|*.*";
                    break;
                default:
                    return null;
            }

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                Path.GetFullPath(savefile.FileName);
            }

            try
            {
                return Path.GetFullPath(savefile.FileName);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        #endregion



        private void OpenGitHubWebsite() => System.Diagnostics.Process.Start("https://github.com/jwohlhauser/ID3-Tag-Editor");
    }
}
