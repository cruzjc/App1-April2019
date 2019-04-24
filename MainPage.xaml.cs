using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1_April2019
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        String introText = "Text preview area. Displays text copied onto clip board";
        List<string> searchText;
        List<string> replaceText;

        public MainPage()
        {
            this.InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            MainInputTextBox.PlaceholderText = "Preview Text";
            MainInputTextBox.Text = introText;
            MainInputTextBox.TextWrapping = TextWrapping.Wrap;
            searchText = new List<string>();
            replaceText = new List<string>();
        }


        private void SearchReplaceTextInit()
        {
            foreach (TextBox textBox in SearchTextBoxes.Children)
            {
                if (textBox.Text != "")
                {
                    searchText.Add(textBox.Text);
                }
            }

            foreach (TextBox textBox in ReplacetextBoxes.Children)
            {
                if (textBox.Text != "")
                {
                    replaceText.Add(textBox.Text);
                }
            }
        }

        private void PastFormatCopy(object sender, RoutedEventArgs e)
        {
            ResetMainTextbox();
            MainInputTextBox.PasteFromClipboard();

            string inputText= MainInputTextBox.Text;
            string stringToSearchFor = "";
            string stringToReplaceWith = "";


            SearchReplaceTextInit();
            for(int i = 0; i < searchText.Count; i++)
            {
                stringToSearchFor = searchText[i];
                stringToReplaceWith = replaceText[i];

                if (stringToSearchFor.Length > 0)
                {
                    inputText = MainInputTextBox.Text;
                    inputText = inputText.Replace(stringToSearchFor, stringToReplaceWith);
                    MainInputTextBox.Text = inputText;
                }
            }

            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(inputText);
            Clipboard.SetContent(dataPackage);

        }

        private void ResetMainTextbox()
        {
            MainInputTextBox.Text = "";
        }

    }
}
