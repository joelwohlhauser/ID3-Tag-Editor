using DevExpress.Mvvm;
using System;
using System.IO;
using TagLib;

namespace ID3_Tag_Editor.Models
{
    public class MusicFileTag : BindableBase
    {
        #region Properties

        // File Details
        private string _filePath;
        private string _fileName;
        private string _fileSize;

        // V1
        private bool _enabledV1;
        private string _artistV1;
        private string _albumV1;
        private string _genreV1;
        private string _yearV1;
        private string _titleV1;
        private string _commentV1;
        private string _trackV1;

        // V2
        private bool _enabledV2;
        private bool _isVersion4EnabledV2;
        private string _versionV2;
        private string _titleV2;
        private string _albumV2;
        private string _genreV2;
        private string _artistV2;
        private string _languageV2;
        private string _playListDelayV2;
        private string _trackNumberV2;
        private string _albumSortV2;
        private string _interpretedV2;
        private string _moodV2;
        private string _partOfSetV2;
        private string _contentDescriptionV2;
        private string _setSubtitleV2;
        private string _keyV2;
        private string _bPMV2;
        private string _titleSortV2;
        private string _subtitleV2;

        #endregion


        #region File Details Getter and Setter

        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value, () => FilePath); }
        }

        public string FileName
        {
            get { return _fileName; }
            set { SetProperty(ref _fileName, value, () => FileName); }
        }

        public string FileSize
        {
            get { return _fileSize; }
            set { SetProperty(ref _fileSize, value, () => FileSize); }
        }

        #endregion

        #region V1 Getter and Setter 

        public bool EnabledV1
        {
            get { return _enabledV1; }
            set { SetProperty(ref _enabledV1, value, () => EnabledV1); }
        }

        public string TrackV1
        {
            get { return _trackV1; }
            set { SetProperty(ref _trackV1, value, () => TrackV1); }
        }

        public string ArtistV1
        {
            get { return _artistV1; }
            set { SetProperty(ref _artistV1, value, () => ArtistV1); }
        }

        public string TitleV1
        {
            get { return _titleV1; }
            set { SetProperty(ref _titleV1, value, () => TitleV1); }
        }

        public string AlbumV1
        {
            get { return _albumV1; }
            set { SetProperty(ref _albumV1, value, () => AlbumV1); }
        }

        public string GenreV1
        {
            get { return _genreV1; }
            set { SetProperty(ref _genreV1, value, () => GenreV1); }
        }

        public string YearV1
        {
            get { return _yearV1; }
            set { SetProperty(ref _yearV1, value, () => YearV1); }
        }

        public string CommentV1
        {
            get { return _commentV1; }
            set { SetProperty(ref _commentV1, value, () => CommentV1); }
        }

        #endregion

        #region V2 Getter and Setter 

        public bool EnabledV2
        {
            get { return _enabledV2; }
            set { SetProperty(ref _enabledV2, value, () => EnabledV2); }
        }

        public bool IsVersion4EnabledV2
        {
            get { return _isVersion4EnabledV2; }
            set { SetProperty(ref _isVersion4EnabledV2, value, () => IsVersion4EnabledV2); }
        }

        public string VersionV2
        {
            get { return _versionV2; }
            set { SetProperty(ref _versionV2, value, () => VersionV2);
                if (_versionV2 == "4")
                {
                    IsVersion4EnabledV2 = true;
                }
                else
                {
                    IsVersion4EnabledV2 = false;
                }
            }
        }

        public string PlayListDelayV2
        {
            get { return _playListDelayV2; }
            set { SetProperty(ref _playListDelayV2, value, () => PlayListDelayV2); }
        }

        public string TrackNumberV2
        {
            get { return _trackNumberV2; }
            set { SetProperty(ref _trackNumberV2, value, () => TrackNumberV2); }
        }

        public string PartOfSetV2
        {
            get { return _partOfSetV2; }
            set { SetProperty(ref _partOfSetV2, value, () => PartOfSetV2); }
        }

        public string BPMV2
        {
            get { return _bPMV2; }
            set { SetProperty(ref _bPMV2, value, () => BPMV2); }
        }

        public string ArtistV2
        {
            get { return _artistV2; }
            set { SetProperty(ref _artistV2, value, () => ArtistV2); }
        }

        public string GenreV2
        {
            get { return _genreV2; }
            set { SetProperty(ref _genreV2, value, () => GenreV2); }
        }

        public string LanguageV2
        {
            get { return _languageV2; }
            set { SetProperty(ref _languageV2, value, () => LanguageV2); }
        }

        public string KeyV2
        {
            get { return _keyV2; }
            set { SetProperty(ref _keyV2, value, () => KeyV2); }
        }

        public string SetSubtitleV2
        {
            get { return _setSubtitleV2; }
            set { SetProperty(ref _setSubtitleV2, value, () => SetSubtitleV2); }
        }

        public string ContentDescriptionV2
        {
            get { return _contentDescriptionV2; }
            set { SetProperty(ref _contentDescriptionV2, value, () => ContentDescriptionV2); }
        }

        public string MoodV2
        {
            get { return _moodV2; }
            set { SetProperty(ref _moodV2, value, () => MoodV2); }
        }

        public string InterpretedV2
        {
            get { return _interpretedV2; }
            set { SetProperty(ref _interpretedV2, value, () => InterpretedV2); }
        }

        public string AlbumSortV2
        {
            get { return _albumSortV2; }
            set { SetProperty(ref _albumSortV2, value, () => AlbumSortV2); }
        }

        public string AlbumV2
        {
            get { return _albumV2; }
            set { SetProperty(ref _albumV2, value, () => AlbumV2); }
        }

        public string SubtitleV2
        {
            get { return _subtitleV2; }
            set { SetProperty(ref _subtitleV2, value, () => SubtitleV2); }
        }

        public string TitleSortV2
        {
            get { return _titleSortV2; }
            set { SetProperty(ref _titleSortV2, value, () => TitleSortV2); }
        }

        public string TitleV2
        {
            get { return _titleV2; }
            set { SetProperty(ref _titleV2, value, () => TitleV2); }
        }

        #endregion



        public static MusicFileTag ConvertTagToMusicFileTag(TagLib.Id3v1.Tag tagV1, TagLib.Id3v2.Tag tagV2, string filePath)
        {
            var tmp = new MusicFileTag
            {
                // File Details
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                FileSize = Logic.BasicFunctions.FormatFileSize(new FileInfo(filePath).Length),
            };

            // TagTypes
            TagTypes myTagTypes = TagLib.File.Create(filePath).TagTypesOnDisk;
            tmp.EnabledV1 = myTagTypes.ToString().ToLower().Contains("id3v1") ? true : false;
            tmp.EnabledV2 = myTagTypes.ToString().ToLower().Contains("id3v2") ? true : false;

            // V1
            if (tmp.EnabledV1)
            {
                tmp.ArtistV1 = tagV1.FirstPerformer == null ? "" : tagV1.FirstPerformer.Replace("�", string.Empty);
                tmp.AlbumV1 = tagV1.Album == null ? "" : tagV1.Album.Replace("�", string.Empty);
                tmp.GenreV1 = tagV1.FirstGenre == null ? "" : tagV1.FirstGenre.Replace("�", string.Empty);
                tmp.YearV1 = tagV1.Year.ToString() == null ? "" : tagV1.Year.ToString().Replace("�", string.Empty);
                tmp.TitleV1 = tagV1.Title == null ? "" : tagV1.Title.Replace("�", string.Empty);
                tmp.CommentV1 = tagV1.Comment == null ? "" : tagV1.Comment.Replace("�", string.Empty);
                tmp.TrackV1 = tagV1.Track.ToString() == null ? "" : tagV1.Track.ToString().Replace("�", string.Empty);
            }

            // V2
            if (tmp.EnabledV2)
            {
                tmp.VersionV2 = tagV2.Version.ToString();

                // Version 3
                tmp.PlayListDelayV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TDLY").Replace("�", string.Empty);
                tmp.TrackNumberV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TRCK").Replace("�", string.Empty);
                tmp.PartOfSetV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TPOS").Replace("�", string.Empty);
                tmp.BPMV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TBPM").Replace("�", string.Empty);
                tmp.ArtistV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TPE1").Replace("�", string.Empty);
                tmp.GenreV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TCON").Replace("�", string.Empty);
                tmp.LanguageV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TLAN").Replace("�", string.Empty);
                tmp.KeyV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TKEY").Replace("�", string.Empty);
                tmp.SetSubtitleV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TSST").Replace("�", string.Empty);
                tmp.ContentDescriptionV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TIT1").Replace("�", string.Empty);
                tmp.InterpretedV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TPE4").Replace("�", string.Empty);
                tmp.AlbumV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TALB").Replace("�", string.Empty);
                tmp.TitleV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TIT2").Replace("�", string.Empty);

                /// Frames from
                /// http://id3.org/id3v2.3.0#Declared_ID3v2_frames

                // + Version 4
                if (tagV2.Version == 4)
                {
                    tmp.TitleSortV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TSOT").Replace("�", string.Empty);
                    tmp.AlbumSortV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TSOA").Replace("�", string.Empty);
                    tmp.MoodV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TMOO").Replace("�", string.Empty);
                    tmp.SubtitleV2 = Logic.TaggingLogic.GetTagContent(tagV2, "TIT3").Replace("�", string.Empty);
                }
            }
            else
            {
                tmp.VersionV2 = "4";
            }

            return tmp;
        }


        public static TagLib.File ConvertMusicFileTagToTag(MusicFileTag musicTag)
        {
            TagLib.File tagInfo = TagLib.File.Create(musicTag.FilePath);

            // V1
            if (!musicTag.EnabledV1)
            {
                tagInfo.RemoveTags(TagTypes.Id3v1);
            }
            else
            {
                tagInfo.GetTag(TagTypes.Id3v1).Performers = new string[] { musicTag.ArtistV1 ?? "" };
                tagInfo.GetTag(TagTypes.Id3v1).Genres = new string[] { musicTag.GenreV1 ?? "" };
                tagInfo.GetTag(TagTypes.Id3v1).Album = musicTag.AlbumV1 ?? "";
                tagInfo.GetTag(TagTypes.Id3v1).Title = musicTag.TitleV1 ?? "";
                tagInfo.GetTag(TagTypes.Id3v1).Comment = musicTag.CommentV1 ?? "";
                int.TryParse(musicTag.YearV1, out int tmpYearV1);
                if (tmpYearV1 > 0)
                {
                    tagInfo.GetTag(TagTypes.Id3v1).Year = (uint)tmpYearV1;
                }

                int.TryParse(musicTag.TrackV1, out int tmpTrackV1);
                if (tmpTrackV1 > 0)
                {
                    tagInfo.GetTag(TagTypes.Id3v1).Track = (uint)tmpTrackV1;
                }
            }

            // V2
            if (!musicTag.EnabledV2)
            {
                tagInfo.RemoveTags(TagTypes.Id3v2);
            }
            else
            {
                TagLib.Id3v2.Tag id3v2Tag = tagInfo.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;

                id3v2Tag.Version = Convert.ToByte(musicTag.VersionV2);

                id3v2Tag.SetTextFrame("TDLY", musicTag.PlayListDelayV2);
                id3v2Tag.SetTextFrame("TRCK", musicTag.TrackNumberV2);
                id3v2Tag.SetTextFrame("TPOS", musicTag.PartOfSetV2);
                id3v2Tag.SetTextFrame("TBPM", musicTag.BPMV2);
                id3v2Tag.SetTextFrame("TPE1", musicTag.ArtistV2);
                id3v2Tag.SetTextFrame("TCON", musicTag.GenreV2);
                id3v2Tag.SetTextFrame("TLAN", musicTag.LanguageV2);
                id3v2Tag.SetTextFrame("TKEY", musicTag.KeyV2);
                id3v2Tag.SetTextFrame("TSST", musicTag.SetSubtitleV2);
                id3v2Tag.SetTextFrame("TIT1", musicTag.ContentDescriptionV2);
                id3v2Tag.SetTextFrame("TMOO", musicTag.MoodV2);
                id3v2Tag.SetTextFrame("TPE4", musicTag.InterpretedV2);
                id3v2Tag.SetTextFrame("TSOA", musicTag.AlbumSortV2);
                id3v2Tag.SetTextFrame("TALB", musicTag.AlbumV2);
                id3v2Tag.SetTextFrame("TIT3", musicTag.SubtitleV2);
                id3v2Tag.SetTextFrame("TSOT", musicTag.TitleSortV2);
                id3v2Tag.SetTextFrame("TIT2", musicTag.TitleV2);

                /// Frames from
                /// http://id3.org/id3v2.3.0#Declared_ID3v2_frames
            }

            return tagInfo;
        }
    }
}
