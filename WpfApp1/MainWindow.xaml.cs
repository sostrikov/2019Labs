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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainViewModel();
		}

		/// <summary>
		/// Список слов
		/// </summary>
		List<string> list = new List<string>();

		private void Открыть_файл_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();

			fd.Filter = "текстовые файлы|*.txt";

			// Show open file dialog box
			Nullable<bool> result = fd.ShowDialog();

			if (result == true)
			{
				Stopwatch t = new Stopwatch();
				t.Start();

				//Чтение файла в виде строки
				string text = File.ReadAllText(fd.FileName);

				//Разделительные символы для чтения из файла
				char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

				string[] textArray = text.Split(separators);

				foreach (string strTemp in textArray)
				{
					//Удаление пробелов в начале и конце строки
					string str = strTemp.Trim();
					//Добавление строки в список, если строка не содержится в списке
					if (!list.Contains(str)) list.Add(str);
				}

				t.Stop();
				
				this.textBoxFileReadTime.Text = t.Elapsed.ToString();
				this.textBoxFileReadCount.Text = list.Count.ToString();
			}
			else
			{
				MessageBox.Show("Необходимо выбрать файл");
			}
		}

		private void Время_чтения_из_файла_TextChanged(object sender, TextChangedEventArgs e)
		{
			//
		}

		private void Количество_уникальных_слов_в_файле_TextChanged(object sender, TextChangedEventArgs e)
		{
			//-----
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			//Application.Exit();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//Слово для поиска
			string word = this.TextBoxFind.Text.Trim();

			//Если слово для поиска не пусто
			if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
			{
				//Слово для поиска в верхнем регистре
				string wordUpper = word.ToUpper();

				//Временные результаты поиска
				List<string> tempList = new List<string>();

				Stopwatch t = new Stopwatch();
				t.Start();

				foreach (string str in list)
				{
					if (str.ToUpper().Contains(wordUpper))
					{
						tempList.Add(str);
					}
				}

				t.Stop();
				this.textBoxExactTime.Text = t.Elapsed.ToString();

				//this.listBoxResult.B

				//Очистка списка
				this.listBoxResult.Items.Clear();

				//Вывод результатов поиска 
				foreach (string str in tempList)
				{
					this.listBoxResult.Items.Add(str);
				}
				//this.listBoxResult.EndUpdate();
			}
			else
			{
				MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
			}
		}

		
	}

		
}
