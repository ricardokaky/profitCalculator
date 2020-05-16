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

namespace CalculadoraProfit
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)_radioManual.IsChecked)
            {
                _balanceEk.Text = string.Empty;
                _balanceEd.Text = string.Empty;
                _balanceRp.Text = string.Empty;
                _balanceMs.Text = string.Empty;
                _balance5.Text = string.Empty;

                _resultEk.Content = string.Empty;
                _resultEd.Content = string.Empty;
                _resultRp.Content = string.Empty;
                _resultMs.Content = string.Empty;
                _result5.Content = string.Empty;

                _profitPerPlayer.Content = string.Empty;
            }
            else
            {
                _clipboard.Text = string.Empty;
                _clipboardResult.Text = string.Empty;
                _clipboard.Visibility = Visibility.Visible;
                _scrollViewerClipboard.Visibility = Visibility.Hidden;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int balanceEk = 0;
            int balanceEd = 0;
            int balanceRp = 0;
            int balanceMs = 0;
            int balance5 = 0;
            int numPlayers = 0;
            double balancePerPlayer = 0;

            if ((bool)_radioManual.IsChecked)
            {
                if (_balanceEk.Text != string.Empty && _balanceEk.Text != null)
                {
                    if (!int.TryParse(_balanceEk.Text.Trim(), out balanceEk))
                    {
                        MessageBox.Show("The EK balance isn't in the right format. Correct examples: '250' or '-250'.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    numPlayers++;
                    balancePerPlayer += balanceEk;
                }
                else
                {
                    _resultEk.Content = string.Empty;
                }
                if (_balanceEd.Text != string.Empty && _balanceEd.Text != null)
                {
                    if (!int.TryParse(_balanceEd.Text.Trim(), out balanceEd))
                    {
                        MessageBox.Show("The ED balance isn't in the right format. Correct examples: '250' or '-250'.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    numPlayers++;
                    balancePerPlayer += balanceEd;
                }
                else
                {
                    _resultEd.Content = string.Empty;
                }
                if (_balanceRp.Text != string.Empty && _balanceRp.Text != null)
                {
                    if (!int.TryParse(_balanceRp.Text.Trim(), out balanceRp))
                    {
                        MessageBox.Show("The RP balance isn't in the right format. Correct examples: '250' or '-250'.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    numPlayers++;
                    balancePerPlayer += balanceRp;
                }
                else
                {
                    _resultRp.Content = string.Empty;
                }
                if (_balanceMs.Text != string.Empty && _balanceMs.Text != null)
                {
                    if (!int.TryParse(_balanceMs.Text.Trim(), out balanceMs))
                    {
                        MessageBox.Show("The MS balance isn't in the right format. Correct examples: '250' or '-250'.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    numPlayers++;
                    balancePerPlayer += balanceMs;
                }
                else
                {
                    _resultMs.Content = string.Empty;
                }
                if (_balance5.Text != string.Empty && _balance5.Text != null)
                {
                    if (!int.TryParse(_balance5.Text.Trim(), out balance5))
                    {
                        MessageBox.Show("The 5º player balance isn't in the right format. Correct examples: '250' or '-250'.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    numPlayers++;
                    balancePerPlayer += balance5;
                }
                else
                {
                    _result5.Content = string.Empty;
                }

                if (numPlayers < 2)
                {
                    return;
                }

                balancePerPlayer /= numPlayers;

                if (balancePerPlayer > 0)
                {
                    _profitPerPlayer.Foreground = Brushes.LimeGreen;
                }
                else if (balancePerPlayer < 0)
                {
                    _profitPerPlayer.Foreground = Brushes.Red;
                }
                _profitPerPlayer.Content = string.Format("{0:N0}", balancePerPlayer);

                if (_balanceEk.Text != string.Empty && _balanceEk.Text != null)
                {
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - balanceEk > 0)
                        {
                            _resultEk.Content = string.Format("+{0:N0}", balancePerPlayer - balanceEk);
                            _resultEk.Foreground = Brushes.LimeGreen;
                        }
                        else if (balancePerPlayer - balanceEk < 0)
                        {
                            _resultEk.Content = string.Format("{0:N0}", balancePerPlayer - balanceEk);
                            _resultEk.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        if (balanceEk < balancePerPlayer)
                        {
                            _resultEk.Content = string.Format("+{0:N0}", balancePerPlayer - balanceEk);
                            _resultEk.Foreground = Brushes.LimeGreen;
                        }
                        else if (balanceEk > balancePerPlayer)
                        {
                            _resultEk.Content = string.Format("{0:N0}", balancePerPlayer - balanceEk);
                            _resultEk.Foreground = Brushes.Red;
                        }
                    }
                }
                if (_balanceEd.Text != string.Empty && _balanceEd.Text != null)
                {
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - balanceEd > 0)
                        {
                            _resultEd.Content = String.Format("+{0:N0}", balancePerPlayer - balanceEd);
                            _resultEd.Foreground = Brushes.LimeGreen;
                        }
                        else if (balancePerPlayer - balanceEd < 0)
                        {
                            _resultEd.Content = String.Format("{0:N0}", balancePerPlayer - balanceEd);
                            _resultEd.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        if (balanceEd < balancePerPlayer)
                        {
                            _resultEd.Content = string.Format("+{0:N0}", balancePerPlayer - balanceEd);
                            _resultEd.Foreground = Brushes.LimeGreen;
                        }
                        else if (balanceEd > balancePerPlayer)
                        {
                            _resultEd.Content = string.Format("{0:N0}", balancePerPlayer - balanceEd);
                            _resultEd.Foreground = Brushes.Red;
                        }
                    }
                }
                if (_balanceRp.Text != string.Empty && _balanceRp.Text != null)
                {
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - balanceRp > 0)
                        {
                            _resultRp.Content = String.Format("+{0:N0}", balancePerPlayer - balanceRp);
                            _resultRp.Foreground = Brushes.LimeGreen;
                        }
                        else if (balancePerPlayer - balanceRp < 0)
                        {
                            _resultRp.Content = String.Format("{0:N0}", balancePerPlayer - balanceRp);
                            _resultRp.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        if (balanceRp < balancePerPlayer)
                        {
                            _resultRp.Content = string.Format("+{0:N0}", balancePerPlayer - balanceRp);
                            _resultRp.Foreground = Brushes.LimeGreen;
                        }
                        else if (balanceRp > balancePerPlayer)
                        {
                            _resultRp.Content = string.Format("{0:N0}", balancePerPlayer - balanceRp);
                            _resultRp.Foreground = Brushes.Red;
                        }
                    }
                }
                if (_balanceMs.Text != string.Empty && _balanceMs.Text != null)
                {
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - balanceMs > 0)
                        {
                            _resultMs.Content = String.Format("+{0:N0}", balancePerPlayer - balanceMs);
                            _resultMs.Foreground = Brushes.LimeGreen;
                        }
                        else if (balancePerPlayer - balanceMs < 0)
                        {
                            _resultMs.Content = String.Format("{0:N0}", balancePerPlayer - balanceMs);
                            _resultMs.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        if (balanceMs < balancePerPlayer)
                        {
                            _resultMs.Content = string.Format("+{0:N0}", balancePerPlayer - balanceMs);
                            _resultMs.Foreground = Brushes.LimeGreen;
                        }
                        else if (balanceMs > balancePerPlayer)
                        {
                            _resultMs.Content = string.Format("{0:N0}", balancePerPlayer - balanceMs);
                            _resultMs.Foreground = Brushes.Red;
                        }
                    }
                }
                if (_balance5.Text != string.Empty && _balance5.Text != null)
                {
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - balance5 > 0)
                        {
                            _result5.Content = string.Format("+{0:N0}", balancePerPlayer - balance5);
                            _result5.Foreground = Brushes.LimeGreen;
                        }
                        else if (balancePerPlayer - balance5 < 0)
                        {
                            _result5.Content = string.Format("{0:N0}", balancePerPlayer - balance5);
                            _result5.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        if (balance5 < balancePerPlayer)
                        {
                            _result5.Content = string.Format("+{0:N0}", balancePerPlayer - balance5);
                            _resultEk.Foreground = Brushes.LimeGreen;
                        }
                        else if (balance5 > balancePerPlayer)
                        {
                            _result5.Content = string.Format("{0:N0}", balancePerPlayer - balance5);
                            _result5.Foreground = Brushes.Red;
                        }
                    }
                }
            }
            else
            {
                string[] lines = _clipboard.Text.Split(new[] { "\n" }, StringSplitOptions.None);
                if (lines.Length < 18)
                {
                    MessageBox.Show("The clipboard isn't in the right format.", "Attention!", MessageBoxButton.OK);
                    return;
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Trim();
                }

                numPlayers = (lines.Length - 6) / 6;

                if (!int.TryParse(lines[5].Substring(lines[5].IndexOf(':') + 2).Replace(",", string.Empty), out int partyBalance))
                {
                    MessageBox.Show("The clipboard isn't in the right format.", "Attention!", MessageBoxButton.OK);
                    return;
                }
                partyBalance /= 1000;

                balancePerPlayer = partyBalance / numPlayers;

                List<string> playerNames = new List<string>();
                for (int i = 6; i < lines.Length; i += 6)
                {
                    playerNames.Add(lines[i]);
                }

                for (int i = 0; i < playerNames.Count; i++)
                {
                    playerNames[i] = playerNames[i].Replace("(Leader)", string.Empty).Trim();
                }

                List<int> playerBalances = new List<int>();
                for (int i = 9; i < lines.Length; i += 6)
                {
                    if (!int.TryParse(lines[i].Substring(lines[i].IndexOf(':') + 2).Replace(",", string.Empty), out int playerBalance))
                    {
                        MessageBox.Show("The clipboard isn't in the right format.", "Attention!", MessageBoxButton.OK);
                        return;
                    }
                    playerBalances.Add(playerBalance / 1000);
                }

                _clipboardResult.Inlines.Clear();

                for (int i = 0; i < numPlayers; i++)
                {
                    _clipboardResult.Inlines.Add(new Run(playerNames[i]) { FontWeight = FontWeights.Bold });
                    _clipboardResult.Inlines.Add(" -> ");
                    if (balancePerPlayer > 0)
                    {
                        if (balancePerPlayer - playerBalances[i] > 0)
                        {
                            _clipboardResult.Inlines.Add(new Run(string.Format("+{0:N0}\n", balancePerPlayer - playerBalances[i])) { Foreground = Brushes.LimeGreen, FontWeight = FontWeights.Bold });
                        }
                        else if (balancePerPlayer - playerBalances[i] < 0)
                        {
                            _clipboardResult.Inlines.Add(new Run(string.Format("{0:N0}\n", balancePerPlayer - playerBalances[i])) { Foreground = Brushes.Red, FontWeight = FontWeights.Bold });
                        }
                    }
                    else
                    {
                        if (playerBalances[i] < balancePerPlayer)
                        {
                            _clipboardResult.Inlines.Add(new Run(string.Format("+{0:N0}\n", balancePerPlayer - playerBalances[i])) { Foreground = Brushes.LimeGreen, FontWeight = FontWeights.Bold });
                        }
                        else if (playerBalances[i] > balancePerPlayer)
                        {
                            _clipboardResult.Inlines.Add(new Run(string.Format("{0:N0}\n", balancePerPlayer - playerBalances[i])) { Foreground = Brushes.Red, FontWeight = FontWeights.Bold });
                        }
                    }
                }

                if (balancePerPlayer > 0)
                {
                    _clipboardResult.Inlines.Add("\nProfit per Player: ");
                    _clipboardResult.Inlines.Add(new Run(string.Format("{0}", balancePerPlayer)) { Foreground = Brushes.LimeGreen, FontWeight = FontWeights.Bold });
                }
                else
                {
                    _clipboardResult.Inlines.Add("\nProfit per Player: ");
                    _clipboardResult.Inlines.Add(new Run(string.Format("{0}", balancePerPlayer)) { Foreground = Brushes.Red, FontWeight = FontWeights.Bold });
                }

                _clipboard.Visibility = Visibility.Hidden;
                _scrollViewerClipboard.Visibility = Visibility.Visible;
            }
        }

        private void RadioManual_Checked(object sender, RoutedEventArgs e)
        {
            if (!App.Current.MainWindow.IsLoaded)
            {
                return;
            }

            _falconShield.Visibility = Visibility.Visible;
            _falconRod.Visibility = Visibility.Visible;
            _falconBow.Visibility = Visibility.Visible;
            _falconWand.Visibility = Visibility.Visible;
            _player5.Visibility = Visibility.Visible;

            _balanceEk.Visibility = Visibility.Visible;
            _balanceEd.Visibility = Visibility.Visible;
            _balanceRp.Visibility = Visibility.Visible;
            _balanceMs.Visibility = Visibility.Visible;
            _balance5.Visibility = Visibility.Visible;

            _resultEk.Visibility = Visibility.Visible;
            _resultEd.Visibility = Visibility.Visible;
            _resultRp.Visibility = Visibility.Visible;
            _resultMs.Visibility = Visibility.Visible;
            _result5.Visibility = Visibility.Visible;

            _labelProfitPerPlayer.Visibility = Visibility.Visible;
            _profitPerPlayer.Visibility = Visibility.Visible;

            _clipboard.Visibility = Visibility.Hidden;
            _scrollViewerClipboard.Visibility = Visibility.Hidden;
        }

        private void RadioClipboard_Checked(object sender, RoutedEventArgs e)
        {
            _falconShield.Visibility = Visibility.Hidden;
            _falconRod.Visibility = Visibility.Hidden;
            _falconBow.Visibility = Visibility.Hidden;
            _falconWand.Visibility = Visibility.Hidden;
            _player5.Visibility = Visibility.Hidden;

            _balanceEk.Visibility = Visibility.Hidden;
            _balanceEd.Visibility = Visibility.Hidden;
            _balanceRp.Visibility = Visibility.Hidden;
            _balanceMs.Visibility = Visibility.Hidden;
            _balance5.Visibility = Visibility.Hidden;

            _resultEk.Visibility = Visibility.Hidden;
            _resultEd.Visibility = Visibility.Hidden;
            _resultRp.Visibility = Visibility.Hidden;
            _resultMs.Visibility = Visibility.Hidden;
            _result5.Visibility = Visibility.Hidden;

            _labelProfitPerPlayer.Visibility = Visibility.Hidden;
            _profitPerPlayer.Visibility = Visibility.Hidden;

            _clipboard.Visibility = Visibility.Visible;
        }
    }
}
