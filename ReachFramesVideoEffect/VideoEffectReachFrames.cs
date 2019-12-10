using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Media.Effects;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;

namespace ReachFramesVideoEffect
{
    public sealed class VideoEffectReachFrames: IBasicVideoEffect
    {
        public VideoEffectReachFrames()
        {

        }


        public void ProcessFrame(ProcessVideoFrameContext context)
        {
            //Getingt pixel data

            var inputFrameBitmap = context.InputFrame.SoftwareBitmap;
            var frameSize = inputFrameBitmap.PixelWidth * inputFrameBitmap.PixelHeight * 4;

            var frameBuffer = new Buffer((uint)frameSize);
            context.InputFrame.SoftwareBitmap.CopyToBuffer(frameBuffer);
            var framePixels = frameBuffer.ToArray();

            Debug.WriteLine($"Touching 25th red pixel {framePixels[100]}");
        }
        public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
        {
        }

        public void Close(MediaEffectClosedReason reason)
        {

        }

        public void DiscardQueuedFrames()
        {
        }

        public bool IsReadOnly { get; }
        public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties { get; } = new List<VideoEncodingProperties>();
        public MediaMemoryTypes SupportedMemoryTypes { get; } = MediaMemoryTypes.Cpu;// MediaMemoryTypes.GpuAndCpu
        public bool TimeIndependent { get; } = true;

        public void SetProperties(IPropertySet configuration)
        {
        }
    }
}
