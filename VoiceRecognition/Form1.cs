using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VoiceRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            Grammar grammer = new DictationGrammar();
            recognizer.LoadGrammar(grammer);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }
        private void recognizer_SpeechRecognized(Object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text += e.Result.Text + "\r\n";
        }
    }
}
