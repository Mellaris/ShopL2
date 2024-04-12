using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Linq;
using System.Xml.Linq;
using Tmds.DBus.Protocol;

namespace ListBoxNew;

public partial class Basket : Window
{
    public float sum = 0;
    List<Changing> namesTwo = new List<Changing>();
    List<Changing> valuesTwo = new List<Changing>();
    List<Changing> kolT = new List<Changing>();
    
    public int kol = 1;
    public int help;
    public string Bask { get; set; }
    public string KolTwo { get; set; }
    int i = 0;
    

    public Basket()
    {
        InitializeComponent();
    }
    public Basket(List<Changing> values, List<Changing> names)
    {
        InitializeComponent();

        foreach (Changing c in values)
        {
            kolT.Add(
                new Changing()
                {
                    NameV = c.NameV,
                    PriceV = c.PriceV,
                    fileName = c.fileName,
                    DobProd = new TextBox(),
                    Sum = c.Sum,
                    id = kolT.Count,
                    idKol = kolT.Count,
                });
        }

        product.ItemsSource = kolT.ToList();
        foreach (Changing c in values)
        {
            valuesTwo.Add(c);
        }

        foreach (Changing strCol in names)
        {
            namesTwo.Add(strCol);
        }
        ClickHandler();

    }
    public void ClickHandler()
    {
        foreach (Changing chg in kolT)
        {
            sum = sum + Convert.ToInt32(chg.Sum) * Convert.ToInt32(chg.PriceV);
        }
        SumF.Text = Convert.ToString(sum);
        sum = 0;
        valuesTwo.Clear();
        foreach (Changing strCol in kolT)
        {
            valuesTwo.Add(
                new Changing()
                {
                    NameV = strCol.NameV,
                    PriceV = strCol.PriceV,
                    Sum = strCol.Sum,
                    fileName = strCol.fileName,
                });
        }
        }
    public void Back(object sender, RoutedEventArgs e)
    {
        ClickHandler();
        new MainWindow(namesTwo, valuesTwo).Show();
        Close();
    }
    public void Delete(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;

        kolT.RemoveAt(selectId);
        valuesTwo.Clear();
        foreach (Changing c in kolT)
        {
            valuesTwo.Add(
                new Changing()
                {
                    NameV = c.NameV,
                    PriceV = c.PriceV,
                    Sum = c.Sum,
                    fileName = c.fileName,
                }
                );
        }
        foreach (Changing chg in kolT)
        {
            if (chg.id > 0)
            {
                chg.id = chg.id - 1;
            }          
        }
        product.ItemsSource = kolT.ToList();
        ClickHandler();
    }
    public void Kol(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;
        foreach (Changing chg in kolT)
        {
            if (selectId == i)
            {
                chg.Sum++;
                break;
            }
            i++;
        }
        i = 0;
        product.ItemsSource = kolT.ToList();
        ClickHandler();
    }
    public void KolM(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;
        foreach (Changing chg in kolT)
        {
            if (selectId == i)
            {
                if (sum > 1)
                {
                    chg.Sum--;
                    break;
                }    
            }
            i++;
        }
        i = 0;
        product.ItemsSource = kolT.ToList();
        ClickHandler();
    }
}