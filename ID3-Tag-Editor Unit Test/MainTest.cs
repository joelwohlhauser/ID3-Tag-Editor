using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ID3_Tag_Editor_Unit_Test
{
    [TestClass]
    public class MainTest
    {
        private ID3_Tag_Editor.ViewModels.Main_ViewModel testViewModel = new ID3_Tag_Editor.ViewModels.Main_ViewModel(true);


        [TestMethod]
        public void Test_Basis()
        {
            Assert.IsTrue(testViewModel.NumberOfFiles == 0);
            Assert.IsNull(testViewModel.SelectedFile);

            testViewModel.InfoCommand.CanExecute(null);
        }


        [TestMethod]
        public void Test_Tags()
        {
            testViewModel.AddFileCommand.Execute(null);

            Assert.IsTrue(testViewModel.NumberOfFiles == 1);
            Assert.IsNotNull(testViewModel.MusicFileTags[0]);
            Assert.IsNotNull(testViewModel.MusicFileTags[0].FilePath);
            Assert.IsNotNull(testViewModel.MusicFileTags[0].FileName);


            // Enable V1 and V2
            testViewModel.MusicFileTags[0].EnabledV1 = false;
            testViewModel.MusicFileTags[0].EnabledV1 = true;
            testViewModel.MusicFileTags[0].EnabledV2 = false;
            testViewModel.MusicFileTags[0].EnabledV2 = true;
            testViewModel.MusicFileTags[0].VersionV2 = "3";
            testViewModel.MusicFileTags[0].VersionV2 = "4";



            // Test V1
            if (testViewModel.MusicFileTags[0].EnabledV1)
            {
                testViewModel.MusicFileTags[0].TrackV1 = "2";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].TrackV1);

                testViewModel.MusicFileTags[0].TitleV1 = "Test Title";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].TitleV1);

                testViewModel.MusicFileTags[0].ArtistV1 = "Test Artist";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].ArtistV1);

                testViewModel.MusicFileTags[0].AlbumV1 = "Test Album";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].AlbumV1);

                testViewModel.MusicFileTags[0].GenreV1 = ID3_Tag_Editor.Models.ComboboxCollections.AllGenres[2].ToString();
                Assert.IsNotNull(testViewModel.MusicFileTags[0].GenreV1);

                testViewModel.MusicFileTags[0].YearV1 = "2020";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].YearV1);

                testViewModel.MusicFileTags[0].CommentV1 = "Test Comment";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].CommentV1);
            }


            // Test V2
            if (testViewModel.MusicFileTags[0].EnabledV2)
            {
                testViewModel.MusicFileTags[0].TitleV2 = "Test Title";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].TitleV2);

                testViewModel.MusicFileTags[0].SubtitleV2 = "Test SubTitle";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].SubtitleV2);

                testViewModel.MusicFileTags[0].AlbumV2 = "Test Album";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].AlbumV2);

                testViewModel.MusicFileTags[0].InterpretedV2 = "Test Interpreted";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].InterpretedV2);

                testViewModel.MusicFileTags[0].LanguageV2 = ID3_Tag_Editor.Models.ComboboxCollections.AllLanguages[10];
                Assert.IsNotNull(testViewModel.MusicFileTags[0].LanguageV2);

                testViewModel.MusicFileTags[0].ArtistV2 = "Test Artist";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].ArtistV2);

                testViewModel.MusicFileTags[0].GenreV2 = ID3_Tag_Editor.Models.ComboboxCollections.AllGenres[6];
                Assert.IsNotNull(testViewModel.MusicFileTags[0].GenreV2);

                testViewModel.MusicFileTags[0].ContentDescriptionV2 = "Test Content Descrip.";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].ContentDescriptionV2);

                testViewModel.MusicFileTags[0].KeyV2 = ID3_Tag_Editor.Models.ComboboxCollections.AllKeys[30];
                Assert.IsNotNull(testViewModel.MusicFileTags[0].KeyV2);

                testViewModel.MusicFileTags[0].TrackNumberV2 = "6";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].TrackNumberV2);

                testViewModel.MusicFileTags[0].PlayListDelayV2 = "Test PlayListDelay";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].PlayListDelayV2);

                testViewModel.MusicFileTags[0].PartOfSetV2 = "1";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].PartOfSetV2);

                testViewModel.MusicFileTags[0].BPMV2 = "Test BPM";
                Assert.IsNotNull(testViewModel.MusicFileTags[0].BPMV2);

                if (testViewModel.MusicFileTags[0].IsVersion4EnabledV2)
                {
                    testViewModel.MusicFileTags[0].TitleSortV2 = "Test TitleSort";
                    Assert.IsNotNull(testViewModel.MusicFileTags[0].TitleSortV2);

                    testViewModel.MusicFileTags[0].AlbumSortV2 = "Test AlbumSort";
                    Assert.IsNotNull(testViewModel.MusicFileTags[0].AlbumSortV2);

                    testViewModel.MusicFileTags[0].MoodV2 = ID3_Tag_Editor.Models.ComboboxCollections.AllMoods[2];
                    Assert.IsNotNull(testViewModel.MusicFileTags[0].MoodV2);

                    testViewModel.MusicFileTags[0].SetSubtitleV2 = "Test SetSubtitle";
                    Assert.IsNotNull(testViewModel.MusicFileTags[0].SetSubtitleV2);
                }
            }

            // Test Copy From
            testViewModel.CopyfromV1Command.Execute(null);
            testViewModel.CopyfromV2Command.Execute(null);

            // Save and remove
            testViewModel.SaveAllFilesCommand.Execute(null);
            testViewModel.RemoveFileCommand.Execute(null);
        }


        [TestMethod]
        public void Test_Playlists()
        {
            testViewModel.CreatePlaylistCommand.Execute(null);
            testViewModel.LoadPlaylistCommand.Execute(null);
        }


        [TestMethod]
        public void Test_ComboboxContent()
        {
            Assert.IsNotNull(testViewModel.AllGenres);
            Assert.IsNotNull(testViewModel.AllLanguages);
            Assert.IsNotNull(testViewModel.AllMoods);
            Assert.IsNotNull(testViewModel.AllVersions);
            Assert.IsNotNull(testViewModel.AllKeys);
        }
    }
}
