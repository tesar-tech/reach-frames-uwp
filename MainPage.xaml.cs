using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Editing;
using Windows.Media.Effects;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReachFramesVideoEffect;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReachFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void LoadedAsync(object sender, RoutedEventArgs e)
        {
            //set file to process
            StorageFile videoFile = await Package.Current.InstalledLocation.GetFileAsync("big_buck_bunny.mp4");

            MediaClip clip = await MediaClip.CreateFromFileAsync(videoFile);

            //applay "effect" on clip
            var vefdef = new VideoEffectDefinition(typeof(VideoEffectReachFrames).FullName);
            clip.VideoEffectDefinitions.Add(vefdef);

            compositor = new MediaComposition();
            compositor.Clips.Add(clip);
        }


        MediaComposition compositor;

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var tempFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("tempFile.mp4", CreationCollisionOption.ReplaceExisting);
            //create temp file 

            await compositor.RenderToFileAsync(tempFile);//render to file to envoke VideoEffect..
        }
    }
}
