using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using GrassWrapper.Parameter;

namespace GrassWrapper.Convert
{
    public class Options2ControlConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool allowMulti = (bool)values[0];
                List<Option> options = values[1] as List<Option>;
                StackPanel panel = new StackPanel();
                if (allowMulti)
                {
                    foreach (var option in options)
                    {
                        var cb = new CheckBox();
                        cb.DataContext = option;
                        Binding b = new Binding("IsSelected");
                        Binding b2 = new Binding("Name");
                        cb.SetBinding(CheckBox.IsCheckedProperty, b);
                        cb.SetBinding(CheckBox.ContentProperty, b2);
                        panel.Children.Add(cb);
                    }
                    return panel;
                }
                else
                {
                    var cbox = new ComboBox();
                    cbox.ItemsSource = options;
                    cbox.SelectionChanged += (o, e) =>
                    { 
                        foreach (var item in e.AddedItems)
                        {
                            (item as Option).IsSelected = true;
                        }

                        foreach (var item in e.RemovedItems)
                        {
                            (item as Option).IsSelected = false;
                        }
                    };
                    return cbox; 
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
