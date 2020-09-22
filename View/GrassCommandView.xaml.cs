using System;
using System.Collections.Generic;
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
        public GrassCommand GrassCommand { get; set; }
        public GrassCommandView(GrassCommand command)
        {
            InitializeComponent();
            GrassCommand = command;
            this.DataContext = command; 
        }
    }
    public class GrassCommandViewModel:INotifyPropertyChanged
    {
        public GrassCommandViewModel()
        {
            GrassCommand=new GrassCommand();
         
            CommonParameters = GrassCommand.Parameters.Where(p => !p.IsAdvancedParameter).ToList();
            AdvancedParameters = GrassCommand.Parameters.Where(p => p.IsAdvancedParameter).ToList();
        }
        public GrassCommandViewModel(GrassCommand cmd)
        {
            GrassCommand = cmd;
            CommonParameters = cmd.Parameters.Where(p => !p.IsAdvancedParameter).ToList();
            AdvancedParameters = cmd.Parameters.Where(p => p.IsAdvancedParameter).ToList();
        }
        public GrassCommand GrassCommand { get; set; }
        public List<IParameter> CommonParameters { get; set; }
        public List<IParameter> AdvancedParameters { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
