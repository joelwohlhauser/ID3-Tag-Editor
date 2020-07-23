using ID3_Tag_Editor.Models;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using TagLib;
using File = TagLib.File;

namespace ID3_Tag_Editor.Logic
{
    public class TaggingLogic
    {
        public static MusicFileTag AddFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                var tagInfo = File.Create(path);

                TagLib.Id3v1.Tag id3v1Tag = tagInfo.GetTag(TagTypes.Id3v1) as TagLib.Id3v1.Tag;
                TagLib.Id3v2.Tag id3v2Tag = tagInfo.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;

                return MusicFileTag.ConvertTagToMusicFileTag(id3v1Tag, id3v2Tag, path);
            }
            else
            {
                MessageBox.Show("Couldn't find:\n" + path);
                return null;
            }
        }


        public static string GetTagContent(TagLib.Id3v2.Tag tag, string ID3v2Frame)
        {
            string tagContent = "";
            var frames = tag.GetFrames<TagLib.Id3v2.TextInformationFrame>(ID3v2Frame);

            foreach (TagLib.Id3v2.TextInformationFrame frame in frames)
            {
                foreach (string text in frame.Text)
                {
                    if (text.Length > tagContent.Length)
                    {
                        tagContent = text;
                    }
                }
            }

            return tagContent;
        }


        public void SaveTagToFile(MusicFileTag tag)
        {
            if (String.IsNullOrEmpty(tag.FilePath))
            {
                return;
            }

            File tagInfo = MusicFileTag.ConvertMusicFileTagToTag(tag);
            tagInfo.Save();
        }



        public void CreatePlaylist(ObservableCollection<MusicFileTag> musicFileTags, string filePath)
        {
            foreach (var tag in musicFileTags)
            {
                SaveTagToFile(tag);
            }

            M3uPlaylist playlist = new M3uPlaylist
            {
                IsExtended = true
            };

            foreach (var tag in musicFileTags)
            {
                playlist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {
                    Path = tag.FilePath,
                });
            }

            // save playlist
            M3uContent content = new M3uContent();
            StreamWriter SW = new StreamWriter(filePath);
            SW.WriteLine(content.ToText(playlist));
            SW.Close();
        }


        public ObservableCollection<MusicFileTag> LoadPlaylist(string filePath)
        {
            ObservableCollection<MusicFileTag> NewMusicFileTags = new ObservableCollection<MusicFileTag>();

            Stream fileContentStream = new FileStream(filePath, FileMode.Open);

            M3uContent content = new M3uContent();
            M3uPlaylist playlist = content.GetFromStream(fileContentStream);

            List<string> paths = playlist.GetTracksPaths();

            foreach (var file in paths)
            {
                MusicFileTag newMusicFile = AddFile(file);
                if (newMusicFile != null)
                {
                    NewMusicFileTags.Add(newMusicFile);
                }
            }

            return NewMusicFileTags;
        }


    }
}
