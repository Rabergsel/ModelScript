using FFMpegCore;
using FFMpegCore.Pipes;
using SkiaSharp;

namespace ModelScript.Simulation
{
    public class VideoStacker
    {
        internal class SKBitmapFrame : IVideoFrame, IDisposable
        {
            public int Width => Source.Width;
            public int Height => Source.Height;
            public string Format => "bgra";

            private readonly SKBitmap Source;

            public SKBitmapFrame(SKBitmap bmp)
            {
                if (bmp.ColorType != SKColorType.Bgra8888)
                    throw new NotImplementedException("only 'bgra' color type is supported");
                Source = bmp;
            }

            public void Dispose() =>
                Source.Dispose();

            public void Serialize(Stream pipe) =>
                pipe.Write(Source.Bytes, 0, Source.Bytes.Length);

            public Task SerializeAsync(Stream pipe, CancellationToken token) =>
                pipe.WriteAsync(Source.Bytes, 0, Source.Bytes.Length, token);

        }
        static IEnumerable<IVideoFrame> CreateFrames(List<SKImage> images)
        {
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"\rRendering frame {i + 1} of {images.Count}");
                using SKBitmap bmp = SKBitmap.FromImage(images[i]);
                using SKBitmapFrame frame = new(bmp);
                yield return frame;
            }
        }

        public static void makeVideo(List<SKImage> images, int framerate = 30, string outputpath = "output.webm")
        {
            var frames = CreateFrames(images);
            RawVideoPipeSource videoFramesSource = new(frames) { FrameRate = framerate };
            bool success = FFMpegArguments
                .FromPipeInput(videoFramesSource)
                .OutputToFile(outputpath, overwrite: true, options => options.WithVideoCodec("libvpx-vp9"))
                .ProcessSynchronously();
        }



    }
}
