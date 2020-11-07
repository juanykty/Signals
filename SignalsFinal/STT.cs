using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.CognitiveServices.Speech;

namespace SignalsFinal
{

    public class STT : Window
    {
        static readonly string SPEECH_SERVICE_KEY = Environment.GetEnvironmentVariable(nameof(SPEECH_SERVICE_KEY));
        static readonly string SPEECH_SERVICE_REGION = Environment.GetEnvironmentVariable(nameof(SPEECH_SERVICE_REGION));
        public async Task Main()
        {
            await RecognizeSpeechAsync();
        }
        static async Task RecognizeSpeechAsync()
        {
//            MainWindow mw = new MainWindow();
//            mw.Signal.Source = new BitmapImage(new Uri(@"Images/Image1.jpg", UriKind.Relative));

            var config = SpeechConfig.FromSubscription("asd", "asd");
            using var recognizer = new SpeechRecognizer(config);
            MessageBox.Show("El programa comenzara a escuchar tu equipo");
            var result = await recognizer.RecognizeOnceAsync();
            var reason = GetRecognitionResultReason(result);
            //           MessageBox.Show(reason);
            //pending to fix
            MainWindow mw = new MainWindow();
            mw.Signal.Source = new BitmapImage(new Uri(@"/Images/Image1.jpg", UriKind.Relative));
        }
        static string GetRecognitionResultReason(SpeechRecognitionResult result) =>
            result.Reason switch
            {
                ResultReason.RecognizedSpeech => $"Recorgnized:\"{result.Text}\"",
                ResultReason.NoMatch => "NOMATCH",
                ResultReason.Canceled => GetCancellationResult(result),
                _ => $"Unhandled {result.Reason}"
            };
        static string GetCancellationResult(SpeechRecognitionResult result)
        {
            var cancellation = CancellationDetails.FromResult(result);
            var reason = $"Canceled {cancellation.Reason}";
            if (cancellation.Reason == CancellationReason.Error)
            {
                reason += $"Canceled{cancellation.ErrorCode} Details {cancellation.ErrorDetails}";
            }
            MessageBox.Show(reason);
            return reason;
        }
    }
}
