using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ListBoxNew
{
    public partial class MainWindow : Window
    {

        List<Changing> productsName = new List<Changing>();
        List<Changing> values = new List<Changing>();
        List<Changing> editProd = new List<Changing>();
        List<Changing> deleteProd = new List<Changing>();
        List<Changing> valueshelp = new List<Changing>();
        int help;
        int i = 0;
        int currentPage = 0;
        string s;
        public MainWindow()
        {
            InitializeComponent();

        }
        public MainWindow(List<Changing> names, List<Changing> valuesTwo)
        {
            InitializeComponent();
            //animals.ItemsSource = productsName.ToList();
            if (valuesTwo != null)
            {
                foreach (Changing changing in valuesTwo)
                {
                    values.Add(changing);
                }
            }
            foreach (Changing changing in names)
            {
                productsName.Add(changing);
                
                //Source = new Bitmap(changing.ProductImage);
                              
            }
            UpdateList();
            //animals.ItemsSource = productsName.ToList();
        }
        public void SearchList(object? sender, KeyEventArgs e)
        {
            Sear();
        }
        public void UpdateList()
        {
            int startIndex = currentPage * 2;
            animals.ItemsSource = productsName.Skip(startIndex).Take(2).ToList();
        }
        public void Run(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int maxPage = (productsName.Count + 1) / 2 - 1;
            if(currentPage < maxPage)
            {
                currentPage++;
                UpdateList();
            }
        }

        public void Back(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(currentPage > 0)
            {
                currentPage--;
                UpdateList();
            }
        }
        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Add(productsName, values).Show();
            Close();
        }
        public void Button(object sender, RoutedEventArgs e)
        {
            bool error = false;
            if (animals.SelectedItems != null)
            {
                foreach (Changing strCol in animals.SelectedItems)
                {
                    valueshelp.Add(strCol);
                }
                if (values.Count > 0)
                {
                    foreach (Changing c in valueshelp)
                    {
                        foreach (Changing ch in values)
                        {
                            if (c.PriceV == ch.PriceV && c.NameV == ch.NameV)
                            {
                                error = true;   
                            }
                        }
                        if (error != true)
                        {
                            values.Add(c);
                        }
                        error = false;
                    }
                }
                else
                {
                    foreach (Changing strCol in animals.SelectedItems)
                    {
                        values.Add(strCol);
                    }
                }            
            }
            new Basket(values, productsName).Show();
            Close();
        }
        public void Edit(object? sender, RoutedEventArgs e)
        {
            int selectEdit = (int)(sender as Button).Tag;
            foreach(Changing c in productsName)
            {
                if(i ==  selectEdit)
                {
                    editProd.Add(c);
                    break;
                }
                i++;
            }
            i = 0;
            new Edit(editProd, productsName, values).Show();
            Close();
        }
        public void Del(object? sender, RoutedEventArgs e)
        {    
            int selectDel = (int)(sender as Button).Tag;
            foreach (Changing c in productsName)
            {            
                if (i == selectDel)
                {
                    deleteProd.Add(c);
                    break;
                }
                i++;
            }
            i = 0;
            productsName.RemoveAt(selectDel);
            if (values.Count > 0)
            {
                foreach(Changing chg in values)
                {
                    foreach(Changing c in deleteProd)
                    {
                        if (chg.NameV == c.NameV && chg.PriceV == c.PriceV)
                        {
                            values.Remove(chg);
                            help++;
                            break;
                        }
                    }
                    if (help > 0)
                    {
                        break;
                    }
                }
            }
            foreach (Changing chg in productsName)
            {
                if (chg.del > 0)
                {
                    chg.del = chg.del - 1;
                    chg.edit = chg.edit - 1;
                }
                
            }
            //animals.ItemsSource = productsName.ToList();
            UpdateList();
        }
        public void Sear()
        {

            s = sear.Text;
            foreach (Changing chg in productsName)
            {
                if (chg.NameV == s)
                {
                    i++;
                    animals.ItemsSource = productsName.Skip(productsName.IndexOf(chg)).Take(1).ToList();
                }
            }
            if (i == 0)
            {
                UpdateList();
            }
            i = 0;
        }
        public void SortPlus(object sender, RoutedEventArgs e)
        {
            productsName.Sort((x, y) => x.PriceV.CompareTo(y.PriceV));
            foreach (Changing chg in productsName)
            {
                chg.edit = productsName.IndexOf(chg);
                chg.del = productsName.IndexOf(chg);
            }
            UpdateList();
        }
        public void SortMinus(object sender, RoutedEventArgs e)
        {
            productsName.Sort((x, y) => y.PriceV.CompareTo(x.PriceV));
            foreach (Changing chg in productsName)
            {
                chg.edit = productsName.IndexOf(chg);
                chg.del = productsName.IndexOf(chg);
            }
            UpdateList();
        }
        public void SortAlf(object sender, RoutedEventArgs e)
        {
            productsName.Sort((x, y) => x.NameV.CompareTo(y.NameV));
            foreach (Changing chg in productsName)
            {
                chg.edit = productsName.IndexOf(chg);
                chg.del = productsName.IndexOf(chg);
            }
            UpdateList();
        }
    }
}