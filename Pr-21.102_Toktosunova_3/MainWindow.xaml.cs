using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Pr_21._102_Toktosunova_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtN.Text, out int arraySize) &&
                    int.TryParse(txtMin.Text, out int minRange) &&
                    int.TryParse(txtMax.Text, out int maxRange))
                {
                    if (arraySize <= 0)
                    {
                        MessageBox.Show("Размер массива должен быть положительным числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (minRange >= maxRange)
                    {
                        MessageBox.Show("Некорректный диапазон. Максимальное значение должно быть больше минимального.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    int[] generatedArray = GenerateRandomArray(arraySize, minRange, maxRange);
                    int[] sortedArray = SortArray(generatedArray);

                    generatedArrayListBox.ItemsSource = generatedArray; // Отображаем сгенерированный массив в первом ListBox.
                    sortedArrayListBox.ItemsSource = sortedArray; // Отображаем отсортированный массив во втором ListBox.
                }
                else
                {
                    MessageBox.Show("Некорректные значения в полях ввода.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int[] SortArray(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Создаем копию массива.
            Array.Sort(sortedArray, (a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                    return -1; // a (четное) идет перед b (нечетное).
                else if (a % 2 != 0 && b % 2 == 0)
                    return 1; // b (нечетное) идет перед a (четное).
                else
                    return a.CompareTo(b); // Если a и b оба четные или оба нечетные, то сортируем по возрастанию.
            });

            return sortedArray;
        }

        private int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }

            return array;
        }

    }
}
