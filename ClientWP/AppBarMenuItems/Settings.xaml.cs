using ClientWP.DataModel;
using ClientWP.Data;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ClientWP.AppBarMenuItems
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // not finalized what needs to be done.
        }

        private void areaSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			ComboBox areaSpecifier = new ComboBox();
			areaSpecifier.Name = "areaSpecifier";
			TextBlock newText = new TextBlock();
			newText.Text = "Hello!!!";
			homePanel.Children.Add(newText);
			areaSpecifier.Items.Add("one");
			areaSpecifier.Items.Add("two");
			areaSpecifier.Items.Add("three");
			areaSpecifier.Items.Add("four");
			areaSpecifier.Visibility = Visibility.Visible;
			homePanel.Children.Add(areaSpecifier);
            switch(areaSelector.SelectedIndex)
            {
                case 0:
                    {
                        break;
                    }

                case 1:
                    {
                        // TO-DO country selection
						fillComboBox(1);
						areaSpecifier.Visibility = Visibility.Visible;
                        break;
                    }

                case 2:
                    {
                        // TO-DO region selection
						fillComboBox(2);
						areaSpecifier.Visibility = Visibility.Visible;
						break;
                    }

                case 3:
                    {
                        // TO-DO city selection
						fillComboBox(3);
						areaSpecifier.Visibility = Visibility.Visible;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
			homePanel.UpdateLayout();
        }

		private async void fillComboBox(int ch)
		{
			switch(ch)
			{
				case 1:
					{
						JsonWebClient client = new JsonWebClient();
						var resp = await client.DoRequestAsync("http://169.254.80.80:88/api/countries");
						string result = resp.ReadToEnd();
						break;
					}

				case 2:
					{
						JsonWebClient client = new JsonWebClient();
						var resp = await client.DoRequestAsync("http://169.254.80.80:88/api/regions");
						string result = resp.ReadToEnd();
						break;
					}

				case 3:
					{
						JsonWebClient client = new JsonWebClient();
						var resp = await client.DoRequestAsync("http://169.254.80.80:88/api/cities");
						string result = resp.ReadToEnd();
						break;
					}
			}
		}
    }
}
