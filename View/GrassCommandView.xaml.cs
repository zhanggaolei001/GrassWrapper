using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using GrassWrapper.Parameter;

namespace GrassWrapper.View
{
    /// <summary>
    /// GrassCommandView.xaml 的交互逻辑
    /// </summary>
    public partial class GrassCommandView : Window
    {

        public GrassCommandView(GrassCommand command)
        {
            InitializeComponent();
            this.DataContext = new GrassCommandViewModel(command);
        }
    }

    public class GrassCommandViewModel : INotifyPropertyChanged
    {
        public GrassCommandViewModel()
        {
            GrassCommand = new GrassCommand();

            CommonParameters =
                new ObservableCollection<IParameter>(
                    GrassCommand.Parameters.Where(p => !p.IsAdvancedParameter).ToList());
            AdvancedParameters =
                new ObservableCollection<IParameter>(GrassCommand.Parameters.Where(p => p.IsAdvancedParameter)
                    .ToList());
            ;

        }

        public GrassCommandViewModel(GrassCommand cmd)
        {
            GrassCommand = cmd;
            CommonParameters =
                new ObservableCollection<IParameter>(cmd.Parameters.Where(p => !p.IsAdvancedParameter).ToList());
            AdvancedParameters =
                new ObservableCollection<IParameter>(cmd.Parameters.Where(p => p.IsAdvancedParameter).ToList());
            ;
        }

        public GrassCommand GrassCommand { get; set; }
        public ObservableCollection<IParameter> CommonParameters { get; set; }
        public ObservableCollection<IParameter> AdvancedParameters { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ParameterDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is IParameter)
            {
                var taskitem = item as IParameter;
                return element.FindResource(taskitem.TypeString) as DataTemplate;
            }
            return null;
        }
    }
    public class ParameterEnumDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is IParameter)
            {
                var p = (item as QgsProcessingParameterEnum);
                if (p.AllowMultiple)
                { 
                    return element.FindResource("QgsProcessingParameterEnumCheckBoxList") as DataTemplate;
                }
                else
                {
                    return element.FindResource("QgsProcessingParameterEnumRadioButtonList") as DataTemplate;

                }

            }
            return null;
        }
    }
}
