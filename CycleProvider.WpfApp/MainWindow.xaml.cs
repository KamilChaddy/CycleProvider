using CycleProvider.Library;
using System.Windows;
using sp = System.Windows.Shapes;

namespace CycleProvider.WpfApp
{

    public partial class MainWindow : Window
    {
        private CycleProvider<Point> _provider = new CycleProvider<Point>();

        public MainWindow()
        {
            InitializeComponent();
            var sp1 = new sp.Rectangle(); //używanie aliasów

            
            _provider.Add(new Point { X = 1, Y = 1 });
            _provider.Add(new Point { X = 0, Y = 1 });
            _provider.Add(new Point { X = 0, Y = 0 });
            _provider.Add(new Point { X = 1, Y = 0 });
            _provider.Next();

            ElpFloat.DataContext = _provider;
            ElpFloat.MouseEnter += (s, a) => { _provider.Next(); Title = _provider.CurrentItem.ToString(); };
        }
        private struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public override string ToString()
            {
                return $"{X} x {Y}";
            }
        }
    }
}
